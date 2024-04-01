using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorer.Models
{
    public class Explorer
    {
        public Explorer(int x,int y,string direction)
        {
            LocationX = x;
            LocationY = y;
            Direction = direction;
        }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public string Direction { get; set; }

    }
}
