using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classLibrary.DL;


namespace classLibrary.BL
{
    public class Cards
    {
        private string rank;
        private string suite;
        private string color;
        private string name;
        private string image;
        private bool isfaceUp;
        public Cards(string rank , string suite)
        {
            this.rank = rank;
            this.suite = suite;
            this.color = AssignColor();
            this.name = this.rank + this.suite;
            this.isfaceUp = false;
            this.image = GetbackImage();
        }
        public Cards(Cards card)
        {
            this.rank = card.rank;
            this.suite = card.suite;
            this.color = card.color;
            this.name = card.name;
            this.isfaceUp = card.isfaceUp;
            this.image = GetbackImage();
            if(isfaceUp)
            {
                flip();
            }
        }
        Images newImage = new Images();
        private string AssignColor()
        {
            if(this.suite == "Hearts" || this.suite == "Diamonds")
            {
                return "Red";
            }
            else
            {
                return "Black";
            }
        }
        public string giveImage()
        {
            return this.image;
        }
        public string GetbackImage()
        {
            return newImage.giveBackSide();
        }
        public string GetreloadImage()
        {
            return newImage.giveReloadImage();
        }
        public void flip()
        {
            if(isfaceUp == false)
            {
                this.image = newImage.GetImage(this.name);
            }
            else
            {
                this.image = GetbackImage();
            }
            isfaceUp = !isfaceUp;
        }
        public string getName()
        {
            return this.name;
        }
        public string getRank()
        {
            return this.rank;
        }
        public string getSuite()
        {
            return this.suite;
        }
        public string getColor()
        {
            return this.color;
        }
        public bool isFacedown()
        {
            if (isfaceUp == false)
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
