using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque
{
    public class joueur
    {
        private string _nomjoueur;
        private int _position;
        private List<yokai> _deck;
        public yokai[] banque = new yokai[6];
        public joueur(string nomjoueur, int position)//ajout des pièces dans le deck du joueu, en fonction de sa position sur le plateau
        {
            Deck=new List<yokai>() ;
            Nomjoueur = nomjoueur;
            Position = position;
            if (position == 1)
            {
                Deck.Add(new koropokkuru(Position, new Coord(3,1)));//sens, puis, premières coordonnées de la pièce
                Deck.Add(new kodama(Position, new Coord(2, 1)));
                Deck.Add(new kitsune(Position, new Coord(3, 0)));
                Deck.Add(new tanuki(Position, new Coord(3, 2)));
            }
            else if (position ==2)
            {
                Deck.Add(new koropokkuru(Position, new Coord(0, 1)));//sens, puis, premières coordonnées de la pièce
                Deck.Add(new kodama(Position, new Coord(1, 1)));
                Deck.Add(new kitsune(Position, new Coord(0, 2)));
                Deck.Add(new tanuki(Position, new Coord(0, 0)));
            }
    
        }
        public List<yokai> Deck
        {
            get { return _deck; }
            set { _deck = value; }
        }

        public string Nomjoueur
        {
            get
            {  return this._nomjoueur;  }
            set
            {   this._nomjoueur = value;  }
        }
        private int Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public void banqueadd(yokai envoi)//ajout dans la banque d'un yokai
        {
            int i = 0;
            while (banque[i] != null && i<6)
                i++;
            if (i < 6)
                banque[i] = envoi;
        }
        public void banquesuppr(int i)//supression d'un yokai en fonction de sa position dans la banque
        {
            if (i < 6)
                banque[i] = null;
        }
        public void banquesuppr(yokai envoi)//suppression d'un yokai dans la banque en fonction de lui dans la banque 
        {
            int i = 0;
            while (envoi != banque[i] && i<6)
                i++;
            if (i < 6)
                banque[i] = null;
        }
    }
}
