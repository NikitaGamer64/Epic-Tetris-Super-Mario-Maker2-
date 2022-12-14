using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epic_Tetris_Super_Mario_Maker_2
{
    public class TBlock : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] {new Position(0,1),new Position(1,0),new Position(1,1),new Position(1,2)},
            new Position[] {new Position(0,1),new Position(1,1),new Position(1,2),new Position(2,1)},
            new Position[] {new Position(1,0),new Position(1,1),new Position(1,2),new Position(2,1)},
            new Position[] {new Position(0,1),new Position(1,0),new Position(1,1),new Position(2,1)}
        };
        public override int Id => 6;
        private readonly MovBTex[][] tileTex = new MovBTex[][]
        {
            new MovBTex[] {new MovBTex(71),new MovBTex(22),new MovBTex(41),new MovBTex(27)},
            new MovBTex[] {new MovBTex(71),new MovBTex(39),new MovBTex(27),new MovBTex(69)},
            new MovBTex[] {new MovBTex(22),new MovBTex(36),new MovBTex(27),new MovBTex(69)},
            new MovBTex[] {new MovBTex(71),new MovBTex(22),new MovBTex(38),new MovBTex(69)}
        };
        protected override Position StartOffset => new Position(0, 3);
        protected override Position[][] Tiles => tiles;
        protected override MovBTex[][] TileTex => tileTex;
        public override int TileID => throw new NotImplementedException();
    }
}
