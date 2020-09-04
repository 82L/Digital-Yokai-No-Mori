using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque
{
   public class kitsune: yokai
    {
        public kitsune(int sens,Coord a) : base( sens, a)
        {
            numb = 3;
        }
            public override bool deplacement(int x, int y, int px, int py)//x, y = positon de base px,py =future position
        {//si déplacement possible
            if ((((px == x + 1) || (px == x - 1)) && ((py == y + 1) || (py == y - 1))) && (Surplateau == true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
