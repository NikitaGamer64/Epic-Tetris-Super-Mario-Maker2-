using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;

using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace Epic_Tetris_Super_Mario_Maker_2
{
    public class MovBTex
    {
        public int TexID { get; set; }
        public MovBTex(int texID)
        {
            TexID = texID;
        }

        public void BlockTexture(Block block)
        {
            TexID = block.TileID;
        }
    }
}
