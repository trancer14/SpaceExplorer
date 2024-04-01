using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorer.Models
{
    public class Space
    {
        public Space(int x,int y)
        {
            this.BoundryX = x;
            this.BoundryY = y;
        }
        public int BoundryX { get; set; }
        public int BoundryY { get; set; }
    }
}
