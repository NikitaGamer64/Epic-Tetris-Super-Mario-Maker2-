﻿using System;
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
        protected override Position StartOffset => new Position(0, 3);
        protected override Position[][] Tiles => tiles;
    }
}
