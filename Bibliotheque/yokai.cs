using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque
{
     public class yokai
    {//dedans se trouve le profil de chaque yokai
        protected bool _surplateau ;//s'il est présent sur le plateau
        protected bool _guerrier;//si il est en guerrier, s'applique que pour le kodama
        protected int _sens;//sens du yokai
        protected int nb = 1;//nombre pour l'aller retour
        public int  numb;//numéro de yokai
        public Coord[] tabtest = new Coord[3]; 
        public yokai( int sens,Coord a)//création yokai
        {
            for(int i =0; i<3; i++)
                tabtest[i] =new Coord( 0, 0);
            Surplateau = true;
            Sens = sens;
            tabtest[1].X = a.X;
            tabtest[1].Y = a.Y;
            Guerrier = false;
        }

        public int Sens
        {
            get
            {
                return _sens;
            }
            set
            {
                _sens = value;
            }
        }

        public bool Surplateau
        {
            get
            {
                return _surplateau;
            }
            set
            {
                _surplateau = value;
            }
        }
        public virtual bool deplacement(int x, int y,int px, int py)//x, y = positon de base px,py =future position
        {
            return false;
        }
        public virtual bool Guerrier
        {
            get { return _guerrier; }
            set { _guerrier = value; }

                
        }
        public void renittabtest(int x, int y)
        {//reéinit tabtest si sort d'un parachutage
            for (int i = 0; i < 3; i++)
            {
                tabtest[i].X = 0;
                tabtest[i].Y = 0;
            }
            tabtest[1].X = x;
            tabtest[1].Y = y;
        }
        public bool testcoord(int x, int y)//test si le yokai a fait trois aller retour
        {
            tabtest[2].X = x;
            tabtest[2].Y = y;
            if (tabtest[2].X == tabtest[0].X && tabtest[2].Y==tabtest[0].Y)
                nb++;
            else
                nb = 1;

            tabtest[0].X = tabtest[1].X;
            tabtest[0].Y = tabtest[1].Y;
            tabtest[1].X = tabtest[2].X;
            tabtest[1].Y = tabtest[2].Y;
            if (nb == 6)//3 aller +3 retours =6
                return true;
            else
                return false;
        }


 
    }   

    
}
