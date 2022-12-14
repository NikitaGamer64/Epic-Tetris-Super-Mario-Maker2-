using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epic_Tetris_Super_Mario_Maker_2
{
    public class OBlock : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] {new Position(0,0),new Position(0,1),new Position(1,0),new Position(1,1)}
        };
        public override int Id => 4;
        private readonly MovBTex[][] tileTex = new MovBTex[][]
        {
            new MovBTex[] {new MovBTex(56),new MovBTex(63),new MovBTex(7),new MovBTex(13)}
        };
        protected override Position StartOffset => new Position(0, 4);
        protected override Position[][] Tiles => tiles;
        protected override MovBTex[][] TileTex => tileTex;
        public override int TileID => throw new NotImplementedException();
    }
}
