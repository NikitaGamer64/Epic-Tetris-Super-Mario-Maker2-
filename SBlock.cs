namespace Epic_Tetris__Super_Mario_Maker_2_
{
    public class SBlock : Block
    {
        private readonly Position[][] tiles =
        [
            [new (0,1), new (0,2), new (1,0), new (1,1)],
            [new (0,1), new (1,1), new (1,2), new (2,2)],
            [new (1,1), new (1,2), new (2,0), new (2,1)],
            [new (0,0), new (1,0), new (1,1), new (2,1)]
        ];

        public override int Id => 5;
        protected override Position StartOffSet => new(0, 3);
        protected override Position[][] Tiles => tiles;
    }
}
