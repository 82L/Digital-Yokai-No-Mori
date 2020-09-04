using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque
{
   public class kodama : yokai
    {
        protected new bool  _guerrier;

        public kodama(int sens, Coord a) :base( sens, a)
        {
            Guerrier = false;
            numb = 2;
        }
        public override bool Guerrier
        {
            get
            {
                return _guerrier;
            }
            set
            {
                _guerrier = value;
            }
        }
        public override bool deplacement(int x, int y, int px, int py)//x, y = positon de base px,py =future position
        {//si déplacement possible

            if (((px == x - 1) && (py == y)) && (Sens == 1) && (Surplateau == true))//sens montant guerrier et non
            {
                if (px == 0)//si on arrive dans zone joueur adverse
                    Guerrier = true;
                return true;
            }
            else if (((px == x + 1) && (py == y)) && (Sens == 2) && (Surplateau == true))//sens descendant guerrier et non
            {
                if (px == 3)//si on arrive dans zone joueur adverse
                    Guerrier = true;
                return true;
            }
            else if (((((py == y + 1) || (py == y - 1)) && (px == x - 1)) || ((py == y) && (px == x + 1)) || ((px == x) && ((py == y + 1) || (py == y - 1)))) && (Sens == 1) && (Surplateau == true) && (Guerrier == true))//sens montant guerrier reste
            {

                return true;
            }
            else if (((((py == y + 1) || (py == y - 1)) && (px == x + 1)) || ((py == y) && (px == x - 1)) || ((px == x) && ((py == y + 1) || (py == y - 1)))) && (Sens == 2) && (Surplateau == true) && (Guerrier == true))
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
