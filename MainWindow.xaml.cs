using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Epic_Tetris_Super_Mario_Maker2_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ImageSource[] tileImages = new ImageSource[256];

        private void LoadTileAtlas()
        {
            const int tileSize = 32;
            const int totalTiles = 256;

            var atlasUri = new Uri("Assets/TileAtlas.png", UriKind.Relative);
            BitmapImage atlas = new(atlasUri);

            if ((atlas.PixelWidth % tileSize != 0) || (atlas.PixelHeight % tileSize != 0))
                throw new Exception($"Размер атласа не кратен {tileSize}px");

            int tilesX = atlas.PixelWidth / tileSize;
            int tilesY = atlas.PixelHeight / tileSize;

            if (tilesX * tilesY != totalTiles)
                throw new Exception($"Атлас содержит {tilesX * tilesY} тайлов, а нужно {totalTiles}.");

            for (int i = 0; i < totalTiles; i++)
            {
                int x = (i % tilesX) * tileSize;
                int y = (i / tilesX) * tileSize;

                tileImages[i] = new CroppedBitmap(
                    source: atlas,
                    sourceRect: new Int32Rect(x, y, tileSize, tileSize));

            }
        }

        private readonly ImageSource[] blockImages =
        //7.2. Массив, содержащий изображения блоков (в порядке, определённом ID блока)
        [
            new BitmapImage(new Uri("Assets/Block-Empty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-I.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-J.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-L.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-O.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-S.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-T.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-Z.png", UriKind.Relative)),
        ];

        private readonly Image[,] imageControls; //Устанавливает связь между ID ячейки и изображением
        private readonly int maxDelay = 1000;
        private readonly int minDelay = 75;
        private readonly int delayDecrease = 25;

        private GameState gameState = new();

        private int CalculateTileMask(GameGrid grid, int row, int column)
        {
            int mask = 0;

            if (grid.IsInside(row - 1, column) && grid[row - 1, column] != 0) mask |= 1;
            if (grid.IsInside(row, column + 1) && grid[row, column + 1] != 0) mask |= 2;
            if (grid.IsInside(row + 1, column) && grid[row + 1, column] != 0) mask |= 4;
            if (grid.IsInside(row, column - 1) && grid[row, column - 1] != 0) mask |= 8;

            if (grid.IsInside(row - 1, column - 1) && grid[row - 1, column - 1] != 0) mask |= 16;
            if (grid.IsInside(row - 1, column + 1) && grid[row - 1, column + 1] != 0) mask |= 32;
            if (grid.IsInside(row + 1, column + 1) && grid[row + 1, column + 1] != 0) mask |= 64;
            if (grid.IsInside(row + 1, column - 1) && grid[row + 1, column - 1] != 0) mask |= 128;

            return mask;
        }

        private Image[,] SetupGameCanvas(GameGrid grid)
        //7.3. Метод, возвращающий параметры imageControls
        {
            Image[,] imageControls = new Image[grid.Rows, grid.Columns];
            int cellSize = 25;

            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    Image imageControl = new()
                    {
                        Width = cellSize,
                        Height = cellSize
                    };

                    Canvas.SetTop(imageControl, (r - 2) * cellSize + 10);
                    Canvas.SetLeft(imageControl, c * cellSize);
                    GameCanvas.Children.Add(imageControl);
                    imageControls[r, c] = imageControl;
                }
            }

            return imageControls;
        }
        public MainWindow()
        {
            InitializeComponent();
            LoadTileAtlas();
            imageControls = SetupGameCanvas(gameState.GameGrid);
        }

        private void DrawGrid(GameGrid grid)
        {
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    int id = grid[r, c];
                    Image image = imageControls[r, c];

                    if (id == 0)
                    {
                        image.Source = tileImages[0];
                    }
                    else
                    {
                        int mask = CalculateTileMask(grid, r, c);
                        image.Source = tileImages[mask];
                    }

                    image.Opacity = 1;
                }
            }
        }

        private void DrawBlock(Block block)
        {
            foreach (Position p in block.TilePositions())
            {
                imageControls[p.Row, p.Column].Opacity = 1;
                imageControls[p.Row, p.Column].Source = tileImages[block.Id];
            }
        }

        private void DrawNextBlock(BlockQueue blockQueue)
        {
            Block next = blockQueue.NextBlock;
            NextImage.Source = blockImages[next.Id];
        }

        private void DrawHeldBlock(Block heldBlock)
        {
            if (heldBlock == null)
            {
                HoldImage.Source = blockImages[0];
            }
            else
            {
                HoldImage.Source = blockImages[heldBlock.Id];
            }
        }

        private void DrawGhostBlock(Block block)
        {
            int dropDistance = gameState.BlockDropDistance();

            foreach (Position p in block.TilePositions())
            {
                int targetRow = p.Row + dropDistance;

                if (targetRow >= gameState.GameGrid.Rows) continue;

                int mask = CalculateTileMask(gameState.GameGrid, targetRow, p.Column);

                imageControls[p.Row + dropDistance, p.Column].Opacity = 0.25;
                imageControls[p.Row + dropDistance, p.Column].Source = tileImages[mask];
            }
        }

        private void Draw(GameState gameState)
        {
            DrawGrid(gameState.GameGrid);
            DrawGhostBlock(gameState.CurrentBlock);
            DrawBlock(gameState.CurrentBlock);
            DrawNextBlock(gameState.BlockQueue);
            DrawHeldBlock(gameState.HeldBlock);
            ScoreText.Text = $"Score: {gameState.Score}";
        }

        private async Task GameLoop()
        {
            Draw(gameState);

            while (!gameState.GameOver)
            {
                int delay = Math.Max(minDelay, maxDelay - (gameState.Score * delayDecrease));
                await Task.Delay(delay);
                gameState.MoveBlockDown();
                Draw(gameState);
            }

            GameOverMenu.Visibility = Visibility.Visible;
            FinalScoreText.Text = $"Score: {gameState.Score}";
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameState.GameOver)
            {
                return;
            }

            switch (e.Key)
            {
                case Key.Left:
                    gameState.MoveBlockLeft();
                    break;
                case Key.Right:
                    gameState.MoveBlockRight();
                    break;
                case Key.Down:
                    gameState.MoveBlockDown();
                    break;
                case Key.Up:
                    gameState.RotateBlockCW();
                    break;
                case Key.X:
                    gameState.RotateBlockCW();
                    break;
                case Key.Z:
                    gameState.RotateBlockCCW();
                    break;
                case Key.C:
                    gameState.HoldBlock();
                    break;
                case Key.Space:
                    gameState.DropBlock();
                    break;
                default:
                    return;
            }

            Draw(gameState);
        }

        private async void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            await GameLoop();
        }

        private async void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            gameState = new GameState();
            GameOverMenu.Visibility = Visibility.Hidden;
            await GameLoop();
        }
    }
}