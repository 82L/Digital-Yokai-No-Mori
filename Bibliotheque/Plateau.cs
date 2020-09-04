using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque
{
    public class Plateau
    {
        public yokai[,] plateaudejeu = new yokai[4,3];
       
        private joueur _joueur1 =null;
        private joueur _joueur2=null;
        private bool alleretour = false;
        public int tour;

        public Plateau(string j1, string j2)
        {
            this._joueur1 = new joueur(j1, 1);// initialisation du jeu
            this._joueur2 = new joueur(j2, 2);
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 3; j++)
                    plateaudejeu[i, j] = null;
            Random rd = new Random();//tirage de celui qui commencera en premier
            tour = rd.Next(1, 3);
            plateaudejeu[0, 1] = this._joueur2.Deck[0];//koropokkuru haut
            plateaudejeu[1, 1] = this._joueur2.Deck[1];//kodama haut
            plateaudejeu[0, 2] = this._joueur2.Deck[2];//kitsune haut
            plateaudejeu[0, 0] = this._joueur2.Deck[3];//tanuki haut
            plateaudejeu[3, 1] = this._joueur1.Deck[0];//koropokkuru bas
            plateaudejeu[2, 1] = this._joueur1.Deck[1];//kodama bas
            plateaudejeu[3, 0] = this._joueur1.Deck[2];//kitsune bas
            plateaudejeu[3, 2] = this._joueur1.Deck[3];//tanuki bas
        }

        public int validdeplace(int x, int y, int fx, int fy)//x, y coord actuelle, fx, fy futur coord, gère les déplacements
        {//Nous avons assumez que le koropokkuru aurait les même contraintes qu'un roi aux échecs!
            yokai initial = plateaudejeu[x, y];
            yokai futur = plateaudejeu[fx, fy];
            yokai garde =null;
            int solution = 0;
            if (plateaudejeu[x, y] != null)//si notre choix n'est pas null
            {
                if ((plateaudejeu[x, y].deplacement(x, y, fx, fy) == true) && (plateaudejeu[x, y].Surplateau == true) && (koropokkurutest(new Coord(x, y), new Coord(fx, fy)) == true) && initial.Sens == tour)//Gère si la pièce sélectionné suit le déplacement prévu en fonction de sa classe, gère les collisions, si le koropokkuru n'est pas en danger par ce mouvement
                {
                    Coord koro;
                    if (tour == 1)//en fonction du joueur
                        koro = this._joueur1.Deck[0].tabtest[1];
                    else
                        koro = this._joueur2.Deck[0].tabtest[1];
                    if (plateaudejeu[x, y] is koropokkuru)//si c'est le koro qu'on déplace
                        koro = new Coord(fx, fy);
                    if (seul() == true && ((koropokkurudanger(_joueur2.Deck[0].tabtest[1]) == false) || (koropokkurudanger(this._joueur1.Deck[0].tabtest[1]) == false))) //test si on peut encore faire un mouvement sur l'échiquier
                        return 3;//trois pour égalité
                    if (futur == null)//si la case dans laquelle on veut placer la pièce est vide
                    {
                        changeplace(x, y, fx, fy);
                        solution = 1;//quel cas est arrivé

                    }
                    else if ((futur.Sens != initial.Sens))//si elle est pleine, avec une pièce de l'adversaire
                    {
                        plateaudejeu[fx, fy].Guerrier = false;//changement des valeurs de la pièce supprimé
                        plateaudejeu[fx, fy].Surplateau = false;
                        if (plateaudejeu[x, y].Sens == 1)//en fonction de chaque joueur, instructions différentes
                        {
                            plateaudejeu[fx, fy].Sens = 1;
                            this._joueur1.Deck.Add(plateaudejeu[fx, fy]);//ajout dans deck joueur, suppression dans deck joueur opposé
                            _joueur1.banqueadd(plateaudejeu[fx, fy]);
                            this._joueur2.Deck.Remove(plateaudejeu[fx, fy]);
                        }
                        else
                        {
                            plateaudejeu[fx, fy].Sens = 2;
                            this._joueur2.Deck.Add(plateaudejeu[fx, fy]);
                            _joueur2.banqueadd(plateaudejeu[fx, fy]);
                            this._joueur1.Deck.Remove(plateaudejeu[fx, fy]);
                        }
                        solution = 2;//quel cas est arrivé
                        garde = plateaudejeu[fx, fy];//garde de la valeur au cas où
                        changeplace(x, y, fx, fy);

                    }
                    else
                    {
                        return 0;//si on ne peut pas
                    }
                    if (initial.Sens == 1 && koropokkurutest(koro) == false)//si notre mouvement laisse le koro en danger, en fonction de chaque joueur
                    {
                        changeplace(fx, fy, x, y);//on revient à la situation initiale
                        this._joueur1.Deck.Remove(plateaudejeu[x, y]);
                        if (solution == 1)//on efface puis remet la pièce qu'on a bougé car si c'est un kodama, sa vertu peut avoir changer. 
                            this._joueur1.Deck.Add(initial);
                        else if (solution == 2)
                        {
                            joueur1.banquesuppr(garde);//on supprime ce qu'on a mis dans la banque
                            this._joueur1.Deck.Remove(garde);//on enlève le yokai mis dans la banque du deck
                            this._joueur1.Deck.Add(initial);//on remet le yokai initial dans le deck
                            this._joueur2.Deck.Add(futur);//on remet l'ancien yokai à sa place

                            plateaudejeu[fx, fy] = this._joueur2.Deck[this._joueur2.Deck.IndexOf(futur)];
                        }
                        plateaudejeu[x, y] = this._joueur1.Deck[this._joueur1.Deck.IndexOf(initial)];
                        return 0;// au final erreur
                    }
                    else if (initial.Sens == 2 && koropokkurutest(koro) == false)//idem que pour joueur1
                    {
                        changeplace(fx, fy, x, y);
                        this._joueur2.Deck.Remove(plateaudejeu[x, y]);
                        if (solution == 1)
                            this._joueur2.Deck.Add(initial);
                        else if (solution == 2)
                        {
                            joueur2.banquesuppr(garde);
                            this._joueur2.Deck.Remove(garde);
                            this._joueur2.Deck.Add(initial);
                            this._joueur1.Deck.Add(futur);

                            plateaudejeu[fx, fy] = this._joueur1.Deck[this._joueur1.Deck.IndexOf(futur)];
                        }
                        plateaudejeu[x, y] = this._joueur2.Deck[this._joueur2.Deck.IndexOf(initial)];
                        return 0;
                    }
                    alleretour = plateaudejeu[fx, fy].testcoord(fx, fy);//si on est parvenu jusqu'ici, mise à jour des coordonnées de la pièce bougé, et teste si on a pas fait trois aller retour
                    if (tour == 1)//tour mis à jour
                        tour = 2;
                    else if (tour == 2)
                        tour = 1;
                    if (alleretour == true)//si trois aller retour
                        return 3;//3 pour égalité

                    else if (finzone(fx, fy) == true)
                        return 2;//si on a mis le koropokkuru dans la zonne adverse (2 pour victoire)
                    else if (( tour==2 && (koropokkurudanger(_joueur2.Deck[0].tabtest[1]) == false) && koropokkurutest(_joueur2.Deck[0].tabtest[1])==false) ||((tour == 1 &&(koropokkurudanger(this._joueur1.Deck[0].tabtest[1]) == false) && koropokkurutest(_joueur1.Deck[0].tabtest[1]) == false))) //Test si le Koropokkuru adverse est en échec et mat
                    {
                        return 2;
                    }
                    else//si aucune condition de victoire
                    {

                        return 1;//1 pour normal
                    }

                }
                else
                {
                    return 0;//erreur
                }
            }
            else
            {
                return 0;//erreur
            }
        }
        public int parachutage(int i, int x, int y )//fonction de parachutage, plus simple que celle de changement de place, car pas de gestion de suppression de pièce
        {
            yokai envoi= null;
            Coord koro;
            if (tour == 1)//koro afin d'avoir coordonnées du koropokkuru à tester, envoi, informations du yokai à parachuter, pour chaque joueur
            {
                envoi = joueur1.banque[i];
                koro = this._joueur1.Deck[0].tabtest[1];
            }
            else
            {
                envoi = joueur2.banque[i];
                koro = this._joueur2.Deck[0].tabtest[1];
            }
               
            if ((envoi.Surplateau == false) && (plateaudejeu[x, y] == null) && koropokkurutest(koro)==true)//test si le parachutage est possible si le koro n'est pas en danger, et que la case est vide
            {
                plateaudejeu[x, y] = envoi;//on donne au plateau la valeur
                envoi.Surplateau = true;//on change les données d'envoi
                envoi.renittabtest(x, y);//réinitt du tabtest au coord actuelles
                if (tour==1)//en fonction du joueur, on met à jour la banque
                {
                    joueur1.banquesuppr(i);
                }
                else if (tour==2)
                {
                    joueur2.banquesuppr(i);
                }
                if (tour == 1)//maj tour
                    tour = 2;
                else if (tour == 2)
                    tour = 1;
                
                if ((( (koropokkurudanger(this._joueur2.Deck[0].tabtest[1]) == false)) && koropokkurutest(_joueur2.Deck[0].tabtest[1]) == false )|| ((koropokkurudanger(this._joueur1.Deck[0].tabtest[1]) == false) && koropokkurutest(_joueur1.Deck[0].tabtest[1]) == false )) //Test si le Koropokkuru adverse est en échec et mat
                {
                    
                    return 2;//fin du jeu
                }
                else//si le jeu continu
                {
                    return 1;
                }
            }
            else
                return 0;
        }
        private void changeplace(int x, int y, int fx, int fy)//fonction d'échange de place sur le plateau, si une pièce sur la position future, disparition de cette dernière du plateau
        {
            plateaudejeu[fx, fy] = plateaudejeu[x, y];
            plateaudejeu[x, y] = null;
        }
       private bool koropokkurutest(Coord a, Coord b)//test si la pièce que l'on déplace est le koro, sera t'elle en danger
        {
            if (plateaudejeu[a.X, a.Y] is koropokkuru)
            {
                for (int i = b.X - 1; i < b.X + 2; i++)
                    for (int j = b.Y - 1; j < b.Y + 2; j++)
                    {
                        if (i < 4 && i > -1 && j > -1 && j < 3 && (i!=b.X || j!=b.Y) && (i!=a.X || j!=a.Y) && (plateaudejeu[i, j] != null))//boucle faisant le tour du koro, si dans le plateau; et contient une pièce
                            if ((plateaudejeu[i, j].deplacement(i, j, b.X, b.Y) == true) && (plateaudejeu[i, j].Sens != plateaudejeu[a.X, a.Y].Sens))
                            {
                                return false;
                            }
                    }
                return true;
            }
            else
                return true;
        }
        private bool koropokkurutest(Coord a)
        {//test si notre koro n'est pas en danger
       
               
                for (int i = a.X - 1; i < a.X + 2; i++)
                    for (int j = a.Y - 1; j < a.Y + 2; j++)
                    {
                        if (i < 4 && i > -1 && j > -1 && j < 3 && (i != a.X || j != a.Y) && plateaudejeu[i,j]!=null)//idem que pour le premier korotest
                            if ((plateaudejeu[i, j].deplacement(i, j, a.X, a.Y) == true) && (plateaudejeu[i, j].Sens != plateaudejeu[a.X, a.Y].Sens)) 
                            {
                                return false;
                            }
                    }
            
                return true;
        }
        private bool koropokkurudanger(Coord a) //test si le koro peut se déplacer 
        {
            for (int k = a.X - 1; k < a.X + 2; k++)
                for (int l = a.Y - 1; l < a.Y + 2; l++)//boucle regardant autour du koropokkuru 
                {
                    if (k < 4 && k > -1 && l > -1 && l < 3 && (new Coord(k, l) != a))//Si on est bien sur le plateau et pas sur les coordonnées du koroppokuru
                    {
                        if (plateaudejeu[k, l] == null) //si la case k, l est nulle
                        {
                            int testnull = 0;//Réinitialisation des variables de tests
                            for (int m = k - 1; m < k + 2; m++)
                            {
                                for (int n = l - 1; n < l + 2; n++)//on tourne autour de la case k,l
                                {
                                    if (m < 4 && m > -1 && n > -1 && n < 3 && (new Coord(m,n) != a) && plateaudejeu[m, n] != null) //Si on est bien sur le plateau et pas sur les cases du koroppokuru ni de celle autour de laquelle on tourne
                                    {
                                        if ((plateaudejeu[m, n].deplacement(m, n, k, l) == true) && (plateaudejeu[m, n].Sens != plateaudejeu[a.X, a.Y].Sens))//si la case k,l est menacé par un pion adverse
                                        {
                                            testnull++; //change la valeur de test si la case est nulle
                                        }
                                    }
                                }
                            }
                            if (testnull == 0)// si à la fin d'une boucle les deux sont égal à 0, alors, le koro peut s'enfuir
                                return true;
                        }
                        else if ((plateaudejeu[k, l].Sens != plateaudejeu[a.X, a.Y].Sens) && (plateaudejeu[k, l].deplacement(k, l, a.X, a.Y) == true)) //Si la case k,l est un ennemi du koro
                        {
                            int testpiece = 0;//réinit variables de test
                            bool contre = false;
                            for (int m = k - 1; m < k + 2; m++)
                                for (int n = l - 1; n < l + 2; n++)//on tourne autour de la case k,l
                                {
                                    if (m < 4 && m > -1 && n > -1 && n < 3 && (m != a.X || n != a.Y) && (m != k || n != l) && plateaudejeu[m, n] != null) //Si on est bien sur le plateau autour du koro et pas sur les cases du koroppokuru ni de celle autour de laquelle on tourne
                                    {
                                        if ((plateaudejeu[m, n].deplacement(m, n, k, l) == true) && (plateaudejeu[m, n].Sens == plateaudejeu[k, l].Sens))//Si k,l est protégé par un pion allié
                                        {
                                            testpiece++;//on augmente degré de menace de la case
                                        }
                                        if ((plateaudejeu[m, n].Sens != plateaudejeu[k, l].Sens) && (plateaudejeu[m, n].deplacement(m, n, k, l) == true))//si k,l est à la merci d'un pion allié au koro
                                        {
                                            contre = true;//Contre devient vrai
                                        }
                                    }
                                }
                            if (testpiece == 0 || contre==true && testpiece!=0)// si à la fin d'une boucle les deux sont égal à 0, alors, le koro peut s'enfuir
                                return true;
                        }
                    }
                }
            return false;//Si il n'y a pas eu de cas ou le koro peut s'enfuir, il est alors condamné
            //PS: il ne peut y avoir de cas ou deux pièces menace le koroppokuru, car les pièces ne peuvent se déplacer que d'une case
        }
        private bool finzone(int fx, int fy)//test si le koroppokuru est bien dans la zone adverse
        {
            yokai atester = plateaudejeu[fx, fy];
            if ((atester is koropokkuru) && ((atester.Sens == 1 && fx == 0) || (atester.Sens == 2 && fx == 3)))
                return true;
            else
                return false;
        }

        private bool seul()//test si on n'a plus que le koro comme pièce (immangeable, donc dernière pièce présente
        {
            if (tour == 1)
            {
                if (joueur1.Deck.Count == 1)
                    return true;
                else
                    return false;
            }
            else if (tour==2)
            {
                if (joueur2.Deck.Count == 1)
                    return true;
                else
                    return false;
            }
            return false;
        }
        public joueur joueur1
        {
            get { return this._joueur1; }
            set { this._joueur1 = value; }
        }

        public joueur joueur2
        {
            get { return this._joueur2; }
            set { this._joueur2 = value; }
        }
    }
}
