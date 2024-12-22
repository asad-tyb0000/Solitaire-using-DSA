using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
using classLibrary.BL;

namespace classLibrary.UI
{
    public class main
    {
        List<string> ranks = new List<string> {"Two", "Three", "Four", "Five", "Six", "Seven","Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace"};
        List<string> suits = new List<string> {"Hearts", "Diamonds", "Clubs", "Spades"};
        List<Cards> fullDeck = new List<Cards>();
        List<Stacks> tableaus = new List<Stacks>();
        Queue StockPileHide = new Queue();
        Queue StockPileShow = new Queue();
        Stacks SpadeFoundation = new Stacks("Spades");
        Stacks ClubFoundation = new Stacks("Clubs");
        Stacks HeartFoundation = new Stacks("Hearts");
        Stacks DiamondFoundation = new Stacks("Diamonds");
        public main()
        {
            makeTableau();
            makeStockPile();
        }

        public void makeDeck()
        {
            foreach(var rank in ranks)
            {
                foreach (var suit in suits)
                {
                    Cards card = new Cards(rank, suit);
                    fullDeck.Add(card);
                }
            }
        }

        public void shuffleDeck()
        {
            Random rand = new Random();
            fullDeck = fullDeck.OrderBy(x => rand.Next()).ToList();
        }

        private void makeTableau()
        {
            makeDeck();        
            shuffleDeck();
            tableaus.Clear();  
            for (int i = 0; i < 7; i++)
            {
                Stacks tableau = new Stacks();
                for (int j = 0; j < i+1; j++)
                {
                    if (fullDeck.Count > 0)
                    {
                        tableau.push(fullDeck[0]);
                        fullDeck.RemoveAt(0);
                    }
                }
                tableaus.Add(tableau);
            }
        }

        

        public List<Stacks> getTableau()
        {
            return tableaus;
        }


        private void makeStockPile()
        {
            for (int i = 0; i < fullDeck.Count; i++)
            {
                StockPileHide.enqueue(fullDeck[i]);
            }
        }
        public Queue GetStockPileHide()
        {
            return StockPileHide;
        }


        public Queue GetStockPileShow()
        {
            return StockPileShow;
        }


        public Stacks getSpadeFoundation()
        {
            return SpadeFoundation;
        }


        public Stacks getClubFoundation()
        {
            return ClubFoundation;
        }

       

        public Stacks getHeartFoundation()
        {
            return HeartFoundation;
        }
        public Stacks getDiamondFoundation()
        {
            return DiamondFoundation;
        }

        


        public string giveReloadImage()
        {
            return "E:/semester 3/DSA lab/projects/Solitaire project/Images/reload.png";
        }

        public string giveSpadeFoundation()
        {
            return "E:/semester 3/DSA lab/projects/Solitaire project/Images/spades_slot.png";
        }

        public string giveClubFoundation()
        {
            return "E:/semester 3/DSA lab/projects/Solitaire project/Images/clubs_slot.png";
        }
        public string giveHeartFoundation()
        {
            return "E:/semester 3/DSA lab/projects/Solitaire project/Images/hearts_slot.png";
        }

        public string giveDiamondFoundation()
        {
            return "E:/semester 3/DSA lab/projects/Solitaire project/Images/diamonds_slot.png";
        }

    }
}
