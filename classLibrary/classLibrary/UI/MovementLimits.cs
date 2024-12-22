using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classLibrary.BL;
using classLibrary.DL;
using classLibrary.UI;
using System.IO;


namespace classLibrary.UI
{
    public class MovementLimits
    {
        main Main = new main();
        List<string> ranks = new List<string> { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
        List<string> rankstab = new List<string> {"King", "Queen", "Jack", "Ten", "Nine", "Eight", "Seven", "Six", "Five", "Four", "Three", "Two" };

        List<int> tabnum = new List<int> { 0,1,2,3,4,5,6};
        
        public bool cardTofoundation(Cards card, Stacks foundation)
        {
            string nextExpectedRank = getNextRankInFoundation(foundation);

            if (card.getRank() == nextExpectedRank && card.getSuite() == foundation.getName())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string getNextRankInFoundation(Stacks foundation)
        {
            if (foundation == null || foundation.isEmpty() || foundation.getLength() == 0)
            {
                return ranks[0];
            }
            if (foundation != null)
            {
                Cards topCard = foundation.peek();
                if (topCard == null)
                {
                    return ranks[0];
                }
                string currentRank = topCard.getRank();
                int index = ranks.IndexOf(currentRank);

                if (index >= 0 && index < ranks.Count - 1)
                {
                    return ranks[index + 1];
                }
            }
            return null;
        }

        public bool stockTotableau(Cards card, Stacks tableau)
        {
            if (tableau.isEmpty())
            {
                if (card.getRank() == "King")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Cards topCard = tableau.peek();
                if (card.getColor() != topCard.getColor() && ranks.IndexOf(card.getRank()) == ranks.IndexOf(topCard.getRank()) - 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }




        public int cardTotableau(Cards card, List<Stacks> tableau , int i)
        {
            List<int> teml = new List<int> { };
            teml = gettempl(i, teml);
            for (int j = 1; j<teml.Count; j++)
            {
                if ((tableau[teml[j]].isEmpty() || tableau[teml[j]].getLength() == 0) && card.getRank() == "King")
                {
                    return teml[j];
                }
                else if(tableau[teml[j]].isEmpty() == false)
                {
                    string expectedRank = getNextRankInTableau(tableau[teml[j]]);
                    string nextColor = getNextColorInTableau(tableau[teml[j]]);
                    if(expectedRank != null && card.getRank() == expectedRank && card.getColor() == nextColor)
                    {
                        return teml[j];
                    }
                }
            }
            return 10;
        }

        public int cardTotableauModern(Cards card, List<Stacks> tableau, int i)
        {
            List<int> teml = new List<int> { };
            teml = gettempl(i, teml);
            for (int j = 1; j < teml.Count; j++)
            {
                if (tableau[teml[j]].isEmpty() || tableau[teml[j]].getLength() == 0)
                {
                    return teml[j];
                }
                else if (tableau[teml[j]].isEmpty() == false)
                {
                    string expectedRank = getNextRankInTableau(tableau[teml[j]]);
                    string nextColor = getNextColorInTableau(tableau[teml[j]]);
                    if (expectedRank != null && card.getRank() == expectedRank && card.getColor() == nextColor)
                    {
                        return teml[j];
                    }
                }
            }
            return 10;
        }




        public string getNextRankInTableau(Stacks tableau)
        {
            

            Cards topCard = tableau.peek();
            string currentRank = topCard.getRank();
            int index = rankstab.IndexOf(currentRank);

            if (index >= 0 && index < rankstab.Count - 1)
            {
                return rankstab[index + 1];
            }
            return null;
        }

        public string getNextColorInTableau(Stacks tableau)
        {
            Cards topCard = tableau.peek();
            string currentColor = topCard.getColor();
            if(currentColor == "Red")
            {
                return "Black";
            }
            else
            {
                return "Red"; 
            }
        }


        public List<int> gettempl(int j , List<int> teml)
        {
            bool starter = false;
            for (int i = 0 ; i < tabnum.Count; i++)
            {
                if(tabnum[i] == j)
                {
                    starter = true;
                }
                if(starter)
                {
                    teml.Add(tabnum[i]);
                }
            }
            for (int i = 0; i<j; i++)
            {
                teml.Add(tabnum[i]);
            }
            return teml;
        }

        public bool WinCondition()
        {
            if(Main.getSpadeFoundation().isEmpty() || Main.getClubFoundation().isEmpty() || Main.getHeartFoundation().isEmpty() || Main.getDiamondFoundation().isEmpty())
            {
                return false;
            }
            if (Main.getSpadeFoundation().peek().getRank() != "King" || Main.getClubFoundation().peek().getRank() != "King" || Main.getHeartFoundation().peek().getRank() != "King" || Main.getDiamondFoundation().peek().getRank() != "King")
            {
                return false;
            }
            
            return true;
        }

        public bool allUp()
        {
            for (int i = 0; i < 7; i++)
            {
                int length = Main.getTableau()[i].getLength();
                for(int j = 1; j < length;j++ )
                {
                    if (Main.getTableau()[i].peekat(j).isFacedown())
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}

