using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque
{
    public class Coord
    {
        private int _x;
        private int _y;
        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }


       
    

}
   
}
