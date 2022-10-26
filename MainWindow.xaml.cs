using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Epic_Tetris_Super_Mario_Maker_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ImageSource[] tileImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/TileEmpty.png", UriKind.Relative)), //0
            new BitmapImage(new Uri("Assets/SMB3/Ground/Bottom_3.png", UriKind.Relative)), //1
            new BitmapImage(new Uri("Assets/SMB3/Ground/Bottom_PipeDown.png", UriKind.Relative)), //2
            new BitmapImage(new Uri("Assets/SMB3/Ground/Bottom1.png", UriKind.Relative)), //3
            new BitmapImage(new Uri("Assets/SMB3/Ground/Bottom2.png", UriKind.Relative)), //4
            new BitmapImage(new Uri("Assets/SMB3/Ground/Bottom3.png", UriKind.Relative)), //5
            new BitmapImage(new Uri("Assets/SMB3/Ground/BottomLeft.png", UriKind.Relative)), //6
            new BitmapImage(new Uri("Assets/SMB3/Ground/BottomLeft_2.png", UriKind.Relative)), //7
            new BitmapImage(new Uri("Assets/SMB3/Ground/BottomLeft_PipeDown.png", UriKind.Relative)), //8
            new BitmapImage(new Uri("Assets/SMB3/Ground/BottomLeft_PipeDownLeft.png", UriKind.Relative)), //9
            new BitmapImage(new Uri("Assets/SMB3/Ground/BottomLeft_PipeLeft.png", UriKind.Relative)), //10
            new BitmapImage(new Uri("Assets/SMB3/Ground/BottomLeftExt.png", UriKind.Relative)), //11
            new BitmapImage(new Uri("Assets/SMB3/Ground/BottomRight.png", UriKind.Relative)), //12
            new BitmapImage(new Uri("Assets/SMB3/Ground/BottomRight_2.png", UriKind.Relative)), //13
            new BitmapImage(new Uri("Assets/SMB3/Ground/BottomRight_PipeDown.png", UriKind.Relative)), //14
            new BitmapImage(new Uri("Assets/SMB3/Ground/BottomRight_PipeDownRight.png", UriKind.Relative)), //15
            new BitmapImage(new Uri("Assets/SMB3/Ground/BottomRight_PipeRight.png", UriKind.Relative)), //16
            new BitmapImage(new Uri("Assets/SMB3/Ground/BottomRightExt.png", UriKind.Relative)), //17
            new BitmapImage(new Uri("Assets/SMB3/Ground/Full_3.png", UriKind.Relative)), //18
            new BitmapImage(new Uri("Assets/SMB3/Ground/Full1.png", UriKind.Relative)), //19
            new BitmapImage(new Uri("Assets/SMB3/Ground/Full2.png", UriKind.Relative)), //20
            new BitmapImage(new Uri("Assets/SMB3/Ground/Full3.png", UriKind.Relative)), //21
            new BitmapImage(new Uri("Assets/SMB3/Ground/HorPipeLeft.png", UriKind.Relative)), //22
            new BitmapImage(new Uri("Assets/SMB3/Ground/HorPipeMid_3.png", UriKind.Relative)), //23
            new BitmapImage(new Uri("Assets/SMB3/Ground/HorPipeMid1.png", UriKind.Relative)), //24
            new BitmapImage(new Uri("Assets/SMB3/Ground/HorPipeMid2.png", UriKind.Relative)), //25
            new BitmapImage(new Uri("Assets/SMB3/Ground/HorPipeMid3.png", UriKind.Relative)), //26
            new BitmapImage(new Uri("Assets/SMB3/Ground/HorPipeRight.png", UriKind.Relative)), //27
            new BitmapImage(new Uri("Assets/SMB3/Ground/Left_2.png", UriKind.Relative)), //28
            new BitmapImage(new Uri("Assets/SMB3/Ground/Left_3.png", UriKind.Relative)), //29
            new BitmapImage(new Uri("Assets/SMB3/Ground/Left_PipeLeft.png", UriKind.Relative)), //30
            new BitmapImage(new Uri("Assets/SMB3/Ground/Left1.png", UriKind.Relative)), //31
            new BitmapImage(new Uri("Assets/SMB3/Ground/Left2.png", UriKind.Relative)), //32
            new BitmapImage(new Uri("Assets/SMB3/Ground/Left3.png", UriKind.Relative)), //33
            new BitmapImage(new Uri("Assets/SMB3/Ground/Pipe4Way.png", UriKind.Relative)), //34
            new BitmapImage(new Uri("Assets/SMB3/Ground/PipeDownLeft.png", UriKind.Relative)), //35
            new BitmapImage(new Uri("Assets/SMB3/Ground/PipeDownLeftRight.png", UriKind.Relative)), //36
            new BitmapImage(new Uri("Assets/SMB3/Ground/PipeDownRight.png", UriKind.Relative)), //37
            new BitmapImage(new Uri("Assets/SMB3/Ground/PipeUpDownLeft.png", UriKind.Relative)), //38
            new BitmapImage(new Uri("Assets/SMB3/Ground/PipeUpDownRight.png", UriKind.Relative)), //39
            new BitmapImage(new Uri("Assets/SMB3/Ground/PipeUpLeft.png", UriKind.Relative)), //40
            new BitmapImage(new Uri("Assets/SMB3/Ground/PipeUpLeftRight.png", UriKind.Relative)), //41
            new BitmapImage(new Uri("Assets/SMB3/Ground/PipeUpRight.png", UriKind.Relative)), //42
            new BitmapImage(new Uri("Assets/SMB3/Ground/Right_2.png", UriKind.Relative)), //43
            new BitmapImage(new Uri("Assets/SMB3/Ground/Right_3.png", UriKind.Relative)), //44
            new BitmapImage(new Uri("Assets/SMB3/Ground/Right_PipeRight.png", UriKind.Relative)), //45
            new BitmapImage(new Uri("Assets/SMB3/Ground/Right1.png", UriKind.Relative)), //46
            new BitmapImage(new Uri("Assets/SMB3/Ground/Right2.png", UriKind.Relative)), //47
            new BitmapImage(new Uri("Assets/SMB3/Ground/Right3.png", UriKind.Relative)), //48
            new BitmapImage(new Uri("Assets/SMB3/Ground/Single.png", UriKind.Relative)), //49
            new BitmapImage(new Uri("Assets/SMB3/Ground/Top_3.png", UriKind.Relative)), //50
            new BitmapImage(new Uri("Assets/SMB3/Ground/Top_PipeUp.png", UriKind.Relative)), //51
            new BitmapImage(new Uri("Assets/SMB3/Ground/Top1.png", UriKind.Relative)), //52
            new BitmapImage(new Uri("Assets/SMB3/Ground/Top2.png", UriKind.Relative)), //53
            new BitmapImage(new Uri("Assets/SMB3/Ground/Top3.png", UriKind.Relative)), //54
            new BitmapImage(new Uri("Assets/SMB3/Ground/TopLeft.png", UriKind.Relative)), //55
            new BitmapImage(new Uri("Assets/SMB3/Ground/TopLeft_2.png", UriKind.Relative)), //56
            new BitmapImage(new Uri("Assets/SMB3/Ground/TopLeft_BottomRight.png", UriKind.Relative)), //57
            new BitmapImage(new Uri("Assets/SMB3/Ground/TopLeft_PipeLeft.png", UriKind.Relative)), //58
            new BitmapImage(new Uri("Assets/SMB3/Ground/TopLeft_PipeUp.png", UriKind.Relative)), //59
            new BitmapImage(new Uri("Assets/SMB3/Ground/TopLeft_PipeUpLeft.png", UriKind.Relative)), //60
            new BitmapImage(new Uri("Assets/SMB3/Ground/TopLeftExt.png", UriKind.Relative)), //61
            new BitmapImage(new Uri("Assets/SMB3/Ground/TopRight.png", UriKind.Relative)), //62
            new BitmapImage(new Uri("Assets/SMB3/Ground/TopRight_2.png", UriKind.Relative)), //63
            new BitmapImage(new Uri("Assets/SMB3/Ground/TopRight_BottomLeft.png", UriKind.Relative)), //64
            new BitmapImage(new Uri("Assets/SMB3/Ground/TopRight_PipeRight.png", UriKind.Relative)), //65
            new BitmapImage(new Uri("Assets/SMB3/Ground/TopRight_PipeUp.png", UriKind.Relative)), //66
            new BitmapImage(new Uri("Assets/SMB3/Ground/TopRight_PipeUpRight.png", UriKind.Relative)), //67
            new BitmapImage(new Uri("Assets/SMB3/Ground/TopRightExt.png", UriKind.Relative)), //68
            new BitmapImage(new Uri("Assets/SMB3/Ground/VerPipeBottom.png", UriKind.Relative)), //69
            new BitmapImage(new Uri("Assets/SMB3/Ground/VerPipeMid.png", UriKind.Relative)), //70
            new BitmapImage(new Uri("Assets/SMB3/Ground/VerPipeUp.png", UriKind.Relative)) //71
        };
        private readonly ImageSource[] blockImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/Block-Empty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/SMB3/Ground/Block-I.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/SMB3/Ground/Block-J.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/SMB3/Ground/Block-L.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/SMB3/Ground/Block-O.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/SMB3/Ground/Block-S.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/SMB3/Ground/Block-T.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/SMB3/Ground/Block-Z.png", UriKind.Relative)),
            //This is a future set of blocks which will appear in Hold and Next.
        };

        private readonly Image[,] imageControls;

        private GameState gameState = new GameState();
        public MainWindow()
        {
            InitializeComponent();
            imageControls = SetupGameCanvas(gameState.GameGrid);
        }
        private Image[,] SetupGameCanvas(GameGrid grid)
        {
            Image[,] imageControls = new Image[grid.Rows, grid.Columns];
            int cellSize = 25;

            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    Image imageControl = new Image
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
        private void DrawGrid(GameGrid grid)
        {
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    int id = grid[r, c];
                    imageControls[r, c].Opacity = 1;
                    imageControls[r, c].Source = tileImages[id];
                }
            }
        }
        private void DrawBlock(Block block)
        {
            foreach (Position p in block.TilePositions())
            {
                imageControls[p.Row, p.Column].Opacity = 1;
                imageControls[p.Row, p.Column].Source = tileImages[block.Id];
                //Is this supposed to be changed?
            }
        }
        private void DrawNextBlock(BlockQueue blockQueue)
        {
            Block next = blockQueue.NextBlock;
            NextImage.Source = blockImages[next.Id];
        }
        private void DrawGhostBlock(Block block)
        {
            int dropDistance = gameState.BlockDropDistance();
            foreach (Position p in block.TilePositions())
            {
                imageControls[p.Row + dropDistance, p.Column].Opacity = 0.25;
                imageControls[p.Row + dropDistance, p.Column].Source = tileImages[block.Id];
            }
        }
        private void Draw(GameState gameState)
        {
            DrawGrid(gameState.GameGrid);
            DrawGhostBlock(gameState.CurrentBlock);
            DrawBlock(gameState.CurrentBlock);
            DrawNextBlock(gameState.BlockQueue);
            ScoreText.Text = $"Score: {gameState.Score}";
        }
        private async Task GameLoop()
        {
            Draw(gameState);
            while (!gameState.GameOver)
            {
                await Task.Delay(500);
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
        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
