using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using classLibrary.DL;
using classLibrary.UI;
using classLibrary.BL;

namespace solitaireUI
{
    public partial class Form1 : Form
    {
        main Main = new main();
        MovementLimits canmove = new MovementLimits();
        Cards card;
        int diff = 0;
        private int Moves = 0;
        public Form1()
        {
            InitializeComponent();
            callFunctions();
        }


        private void callFunctions()
        {
            this.DoubleBuffered = true;
            this.WindowState = FormWindowState.Maximized;
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.Green;
            addButton();
            addEmptySlot();
            addColorButton();
            addDiffButton();
            addHintButton();
            addMoves();
            showStockPile(20, 50);
            showTableau(500, 200);
            showFoundation(500, 50);
        }

        private void addButton()
        {
            Button b1 = new Button
            {
                Width = 100,
                Height = 40,
                Location = new Point(1000, 60),
                Text = "Restart",
                ForeColor = Color.Red,
                BackColor = Color.DarkGreen,
                TextAlign = ContentAlignment.MiddleCenter
                
            };

            b1.Click += (e, sender) =>
            {
                Application.Restart();
            };

            this.Controls.Add(b1);
            b1.BringToFront();

        }
        public void addHintButton()
        {
            Button b1 = new Button
            {
                Width = 100,
                Height = 40,
                Location = new Point(1000, 110),
                Text = "Hint",
                ForeColor = Color.Red,
                BackColor = Color.DarkGreen,
                TextAlign = ContentAlignment.MiddleCenter

            };

            b1.Click += (e, sender) =>
            {
                Hintmove();
            };

            this.Controls.Add(b1);
            b1.BringToFront();
        }
        public void addColorButton()
        {
            PictureBox b = new PictureBox
            {
                Width = 30,
                Height = 30,
                Location = new Point(1200, 60),
                Image = Image.FromFile("E:/semester 3/DSA lab/projects/Solitaire project/Images/backColor.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            b.Click += (e, sender) =>
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.BackColor = colorDialog1.Color;
                }
            };
            this.Controls.Add(b);

        }

        public void addMoves()
        {
            Button b = new Button
            {
                Width = 50,
                Height = 30,
                Location = new Point(100, 500),
                Text = Moves.ToString(),
                Tag = "moves"
            };
            this.Controls.Add(b);

        }
        public void addEmptySlot()
        {
            int x = 500;
            PictureBox p1 = new PictureBox
            {
                Width = 70,
                Height = 100,
                Location = new Point(x, 200),
                Image = Image.FromFile("E:/semester 3/DSA lab/projects/Solitaire project/Images/empty_slot.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            PictureBox p2 = new PictureBox
            {
                Width = 70,
                Height = 100,
                Location = new Point(x = x + 100, 200),
                Image = Image.FromFile("E:/semester 3/DSA lab/projects/Solitaire project/Images/empty_slot.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            PictureBox p3 = new PictureBox
            {
                Width = 70,
                Height = 100,
                Location = new Point(x = x + 100, 200),
                Image = Image.FromFile("E:/semester 3/DSA lab/projects/Solitaire project/Images/empty_slot.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            PictureBox p4 = new PictureBox
            {
                Width = 70,
                Height = 100,
                Location = new Point(x = x + 100, 200),
                Image = Image.FromFile("E:/semester 3/DSA lab/projects/Solitaire project/Images/empty_slot.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            PictureBox p5 = new PictureBox
            {
                Width = 70,
                Height = 100,
                Location = new Point(x = x + 100, 200),
                Image = Image.FromFile("E:/semester 3/DSA lab/projects/Solitaire project/Images/empty_slot.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            PictureBox p6 = new PictureBox
            {
                Width = 70,
                Height = 100,
                Location = new Point(x = x + 100, 200),
                Image = Image.FromFile("E:/semester 3/DSA lab/projects/Solitaire project/Images/empty_slot.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            PictureBox p7 = new PictureBox
            {
                Width = 70,
                Height = 100,
                Location = new Point(x = x + 100, 200),
                Image = Image.FromFile("E:/semester 3/DSA lab/projects/Solitaire project/Images/empty_slot.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            this.Controls.Add(p1);
            this.Controls.Add(p2);
            this.Controls.Add(p3);
            this.Controls.Add(p4);
            this.Controls.Add(p5);
            this.Controls.Add(p6);
            this.Controls.Add(p7);
        }

        public void addDiffButton()
        {
            Button b1 = new Button
            {
                Width = 50,
                Height = 30,
                Location = new Point(200, 150),
                Text = "Classic"

            };
            Button b2 = new Button
            {
                Width = 55,
                Height = 30,
                Location = new Point(123, 150),
                Text = "Modern"

            };
            b1.Click += (sender, e) =>
            {
                diff = 1;
                b1.Hide();
                b2.Hide();
            };
            b2.Click += (sender, e) =>
            {
                diff = 2;
                b1.Hide();
                b2.Hide();
            };
            this.Controls.Add(b1);
            this.Controls.Add(b2);
            b1.BringToFront();
            b2.BringToFront();
        }
       


        private void showTableau(int x, int y)
        {
            for (int i = 0; i < 7; i++)
            {
                y = 200;
                int length = Main.getTableau()[i].getLength();
                for (int j = 1; j <= length; j++)
                {
                    Cards card = Main.getTableau()[i].peekat(j);
                    if (j == length)
                    {
                        if(card.isFacedown())
                        {
                            card.flip();
                        }
                    }
                    makePictureBoxTableau(card, x, y, "right", Main.getSpadeFoundation(), Main.getClubFoundation(), Main.getHeartFoundation(), Main.getDiamondFoundation() , Main.getTableau()[i] , i);

                    y += 30;
                }
                x += 100;
            }
        }


        private void showFoundation(int x , int y)
        {
            if(Main.getSpadeFoundation() != null && !Main.getSpadeFoundation().isEmpty())
            {
                Cards card = Main.getSpadeFoundation().peek();
                makePictureBoxFoundation(card.giveImage(), x, y, "right" , Main.getSpadeFoundation() , 0);
                x += 100;
                
            }
            else
            {
                makePictureBoxFoundation(Main.giveSpadeFoundation(), x, y, "right" , Main.getSpadeFoundation() , 0);
                x += 100;
            }

            if (Main.getClubFoundation() != null && !Main.getClubFoundation().isEmpty())
            {
                Cards card = Main.getClubFoundation().peek();
                makePictureBoxFoundation(card.giveImage(), x, y, "right" , Main.getClubFoundation() , 0);
                x += 100;

            }
            else
            {
                makePictureBoxFoundation(Main.giveClubFoundation(), x , y, "right" , Main.getClubFoundation() , 0);
                x += 100;
            }

            if (Main.getHeartFoundation() != null && !Main.getHeartFoundation().isEmpty())
            {
                Cards card = Main.getHeartFoundation().peek();
                makePictureBoxFoundation(card.giveImage(), x, y, "right" , Main.getHeartFoundation() , 0);
                x += 100;

            }
            else
            {
                makePictureBoxFoundation(Main.giveHeartFoundation(), x, y, "right" , Main.getHeartFoundation() , 0);
                x += 100;
            }

            if (Main.getDiamondFoundation() != null && !Main.getDiamondFoundation().isEmpty())
            {
                Cards card = Main.getDiamondFoundation().peek();
                makePictureBoxFoundation(card.giveImage(), x, y, "right" , Main.getDiamondFoundation() , 0);
                x += 100;

            }
            else
            {
                makePictureBoxFoundation(Main.giveDiamondFoundation(), x, y, "right" , Main.getDiamondFoundation() , 0);
                x += 100;
            }
        }

       

        private void showStockPile(int x , int y)
        {
            if(!Main.GetStockPileHide().isEmpty())
            {
                foreach (Cards card in Main.GetStockPileHide())
                {
                    makePictureBoxStockPile(card.giveImage(), x, y, "left" , card , Main.GetStockPileHide() , Main.GetStockPileShow());
                }
            }
            else
            {
                makePictureBoxStockPile(Main.giveReloadImage(), x, y, "left", card, Main.GetStockPileHide(), Main.GetStockPileShow());
            }
                    

            if(!Main.GetStockPileShow().isEmpty())
            {
                Cards showncard = Main.GetStockPileShow().peekend();
                makePictureBoxStockPileShown(showncard, x + 100, y, "left" , Main.getSpadeFoundation() , Main.getDiamondFoundation() , Main.getClubFoundation() , Main.getHeartFoundation() , Main.GetStockPileShow() , Main.getTableau());
            }
            
        }



        

        private void makePictureBoxTableau(Cards card , int x  , int y , string anc , Stacks spadefoundation , Stacks clubfoundation , Stacks heartfoundation , Stacks diamondfoundation , Stacks giventableau , int ind)
        {
            PictureBox pictureBox = new PictureBox
            {
                Width = 70,
                Height = 100,
                Location = new Point(x, y),
                Image = Image.FromFile(card.giveImage()),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Tag = "tableau"
            };
            pictureBox.MouseEnter += (sender, e) =>
            {
                pictureBox.Width = 80; 
                pictureBox.Height = 110;
                pictureBox.Location = new Point(x - 5, y - 5); 

                pictureBox.Paint += DrawBorderShadow;
                pictureBox.Invalidate();
            };

            pictureBox.MouseLeave += (sender, e) =>
            {
                pictureBox.Width = 70;
                pictureBox.Height = 100;
                pictureBox.Location = new Point(x, y);

                pictureBox.Paint -= DrawBorderShadow;
                pictureBox.Invalidate(); 
            };
            pictureBox.DoubleClick += (sender, e) =>
            {
                if (canmove.cardTofoundation(card, spadefoundation) == true && card == giventableau.peek())
                {
                    
                    Cards poppedCard = giventableau.pop();
                    spadefoundation.push(poppedCard);
                    clearUI();
                }
                else if (canmove.cardTofoundation(card, clubfoundation) == true && card == giventableau.peek())
                {
                    Cards poppedCard = giventableau.pop();
                    clubfoundation.push(poppedCard);
                    clearUI();
                }
                else if (canmove.cardTofoundation(card, heartfoundation) == true && card == giventableau.peek())
                {
                    Cards poppedCard = giventableau.pop();
                    heartfoundation.push(poppedCard);
                    clearUI();
                }
                else if (canmove.cardTofoundation(card, diamondfoundation) == true && card == giventableau.peek())
                {
                    Cards poppedCard = giventableau.pop();
                    diamondfoundation.push(poppedCard);
                    clearUI();
                }
            };
            pictureBox.Click += (sender, e) =>
            {
                if(card.isFacedown() == false)
                {
                    if(diff == 0)
                    {
                        MessageBox.Show("Please select the difficulty first");
                        return; ;
                    }
                    if (diff == 1)
                    {
                        if(!canmove.allUp())
                        {

                        if (card.isFacedown() == false && canmove.cardTotableau(card, Main.getTableau(), ind) != 10)
                        {
                            int num = canmove.cardTotableau(card, Main.getTableau(), ind);
                            int idx = 0;
                            Stacks tempStack = new Stacks();
                            for (int i = giventableau.getLength(); i > 0; i--)
                            {
                                if (giventableau.peekat(i).getName() == card.getName())
                                {
                                    idx = i;
                                    break;
                                }
                            }
                            for (int i = giventableau.getLength(); i >= idx; i--)
                            {
                                Cards poppedCard = giventableau.pop();
                                tempStack.push(poppedCard);
                            }

                            while (tempStack.isEmpty() == false)
                            {
                                Cards poppedCard = tempStack.pop();
                                Main.getTableau()[num].push(poppedCard);

                            }
                            clearUI();
                        }
                        }
                    }
                    if (diff == 2)
                    {
                        
                        if (card.isFacedown() == false && canmove.cardTotableauModern(card, Main.getTableau() , ind) !=  10)
                        {
                            int num = canmove.cardTotableauModern(card, Main.getTableau(), ind);
                            int idx = 0;
                            Stacks tempStack = new Stacks();
                            for(int i = giventableau.getLength(); i>0; i--)
                            {
                                if (giventableau.peekat(i).getName() == card.getName())
                                {
                                    idx = i;
                                    break;
                                }
                            }
                            for(int i = giventableau.getLength(); i >= idx; i--)
                            {
                                Cards poppedCard = giventableau.pop();
                                tempStack.push(poppedCard);
                            }
                            
                            while(tempStack.isEmpty() == false)
                            {
                                Cards poppedCard = tempStack.pop();
                                Main.getTableau()[num].push(poppedCard);

                            }
                            clearUI();
                        }
                    }
                    
                    
                }
            };
            this.Controls.Add(pictureBox);
            pictureBox.BringToFront();

        }
        private void DrawBorderShadow(object sender, PaintEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            using (Pen colorPen = new Pen(Color.SaddleBrown, 3))
            {
                Rectangle rect = pb.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;
                e.Graphics.DrawRectangle(colorPen, rect);
            }
        }
        private void makePictureBoxFoundation(string file, int x, int y, string anc , Stacks givenFoundation , int ind)
        {
            PictureBox pictureBox = new PictureBox
            {
                Width = 70,
                Height = 100,
                Location = new Point(x, y),
                Image = Image.FromFile(file),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Tag = "foundation"
            };
            

            this.Controls.Add(pictureBox);
            pictureBox.BringToFront();
            

        }

        private void makePictureBoxStockPile(string file, int x, int y, string anc , Cards card , Queue hidden , Queue shown)
        {
            PictureBox pictureBox = new PictureBox
            {
                Width = 70,
                Height = 100,
                Location = new Point(x, y),
                Image = Image.FromFile(file),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Tag = "stockpile"

            };
            pictureBox.MouseEnter += (sender, e) =>
            {
                pictureBox.Width = 80;
                pictureBox.Height = 110;
                pictureBox.Location = new Point(x - 5, y - 5);

                pictureBox.Paint += DrawBorderShadow;
                pictureBox.Invalidate();
            };

            pictureBox.MouseLeave += (sender, e) =>
            {
                pictureBox.Width = 70;
                pictureBox.Height = 100;
                pictureBox.Location = new Point(x, y);

                pictureBox.Paint -= DrawBorderShadow;
                pictureBox.Invalidate();
            };
            pictureBox.Click += (sender, e) =>
            {
                if (diff == 0)
                {
                    MessageBox.Show("select dificulty");
                    return;
                }
                if (hidden != null && !hidden.isEmpty() && hidden.getLength() != 0)
                {
                    Cards poppedCard = hidden.dequeue();
                    poppedCard.flip();
                    shown.enqueue(poppedCard);
                    showStockPile(20, 50);
                    clearUI();
                }
                else if (hidden.isEmpty())
                {
                    int length = 0;
                    while (!shown.isEmpty())
                    {
                        Cards poppedCard = shown.dequeue();
                        poppedCard.flip();
                        hidden.enqueue(poppedCard);
                        this.Controls.Remove(pictureBox);
                        length++;
                    }
                    clearUI();


                }
            };

            this.Controls.Add(pictureBox);
            pictureBox.BringToFront();


        }
        private void makePictureBoxStockPileShown(Cards card, int x, int y, string anc,Stacks spadefoundation ,  Stacks diamondfoundation , Stacks clubfoundation , Stacks heartfoundation, Queue shown, List<Stacks> tableaus)
        {
            if (Main.GetStockPileShow().isEmpty())
            {
                return;
            }

            PictureBox pictureBox = new PictureBox
            {
                Width = 70,
                Height = 100,
                Location = new Point(x, y),
                Image = Image.FromFile(card.giveImage()),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Tag = "shown"
            };
            pictureBox.MouseEnter += (sender, e) =>
            {
                pictureBox.Width = 80;
                pictureBox.Height = 110;
                pictureBox.Location = new Point(x - 5, y - 5);

                pictureBox.Paint += DrawBorderShadow;
                pictureBox.Invalidate();
            };

            pictureBox.MouseLeave += (sender, e) =>
            {
                pictureBox.Width = 70;
                pictureBox.Height = 100;
                pictureBox.Location = new Point(x, y);

                pictureBox.Paint -= DrawBorderShadow;
                pictureBox.Invalidate();
            };
            pictureBox.Click += (sender, e) =>
            {
                if(diff ==0)
                {
                    MessageBox.Show("select dificulty");
                    return;
                }
                for (int i = 0; i < tableaus.Count; i++)
                {
                    if (canmove.stockTotableau(card, tableaus[i]))
                    {
                        MoveCardToTableau(shown, tableaus[i]);
                        clearUI();
                        return;
                    }
                }
                if (TryMoveCardToFoundation(card, spadefoundation , shown) || TryMoveCardToFoundation(card, diamondfoundation , shown) || TryMoveCardToFoundation(card, clubfoundation, shown) || TryMoveCardToFoundation(card, heartfoundation, shown))
                {
                    clearUI();
                    return;
                }

                HighlightPictureBox(pictureBox);
            };

            this.Controls.Add(pictureBox);
            pictureBox.BringToFront();
        }

        private bool TryMoveCardToFoundation(Cards card, Stacks foundation , Queue shown)
        {
            if (canmove.cardTofoundation(card, foundation))
            {
                MoveCard(shown, foundation);
                return true;
            }
            return false;
        }

        private void MoveCardToTableau(Queue shown, Stacks tableau)
        {
            MoveCard(shown, tableau);
        }

        private void MoveCard(Queue shown, Stacks destination)
        {
            int length = shown.getLength();

            if (length == 0)
            {
                return;
            }

            Cards poppedCard;
            if (length == 1)
            {
                poppedCard = shown.dequeue();
                destination.push(poppedCard);
            }
            else
            {
                Queue temp = new Queue();
                for (int i = 0; i < length - 1; i++)
                {
                    temp.enqueue(shown.dequeue());
                }
                poppedCard = shown.dequeue();
                destination.push(poppedCard);
                while (!temp.isEmpty())
                {
                    shown.enqueue(temp.dequeue());
                }
            }
        }

        private void HighlightPictureBox(PictureBox pictureBox)
        {
            pictureBox.BorderStyle = BorderStyle.None;
            pictureBox.Paint += (s, pe) =>
            {
                using (Pen pen = new Pen(Color.Yellow, 5))
                {
                    Rectangle rect = pictureBox.ClientRectangle;
                    rect.Width -= 1;
                    rect.Height -= 1;
                    pe.Graphics.DrawRectangle(pen, rect);
                }
            };

            pictureBox.Invalidate();
        }

        private void clearStockPileUI()
        {
            foreach (Control control in this.Controls.OfType<PictureBox>().ToList())
            {
                if (control.Tag != null && (control.Tag.ToString() == "stockpile"))
                {
                    this.Controls.Remove(control);
                }
            }
        }
        private void clearFoundation()
        {
            foreach (Control control in this.Controls.OfType<PictureBox>().ToList())
            {
                if (control.Tag != null && (control.Tag.ToString() == "foundation"))
                {
                    this.Controls.Remove(control);
                }
            }
        }
        private void clearTableau()
        {
            foreach (Control control in this.Controls.OfType<PictureBox>().ToList())
            {
                if (control.Tag != null && (control.Tag.ToString() == "tableau"))
                {
                    this.Controls.Remove(control);
                }
            }
        }
        private void clearShownPile()
        {
            foreach (Control control in this.Controls.OfType<PictureBox>().ToList())
            {
                if (control.Tag != null && (control.Tag.ToString() == "shown"))
                {
                    this.Controls.Remove(control);
                }
            }
        }
        private void UpdateMovesDisplay()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button && control.Tag != null && control.Tag.ToString() == "moves")
                {
                    control.Text = Moves.ToString();
                    break;
                }
            }
        }

        public void Hintmove()
        {
            if(diff == 0)
            {
                MessageBox.Show("First select the difficulty");
                return;
            }
            for(int i = 0; i<7; i++)
            {
                if(Main.getTableau()[i].isEmpty())
                {
                    continue;
                }
                if (Main.getTableau()[i].peek().isFacedown() == false)
                {
                    card = Main.getTableau()[i].peek();
                }
                else
                {
                    continue;
                }
                if (canmove.cardTofoundation(card, Main.getSpadeFoundation()) == true)
                {
                    Cards poppedCard = Main.getTableau()[i].pop();
                    Main.getSpadeFoundation().push(poppedCard);
                    clearUI();
                    return;
                }
                else if (canmove.cardTofoundation(card, Main.getClubFoundation()) == true)
                {
                    Cards poppedCard = Main.getTableau()[i].pop();
                    Main.getClubFoundation().push(poppedCard);
                    clearUI();
                    return;
                }
                else if (canmove.cardTofoundation(card, Main.getHeartFoundation()) == true)
                {
                    Cards poppedCard = Main.getTableau()[i].pop();
                    Main.getHeartFoundation().push(poppedCard);
                    clearUI();
                    return;
                }
                else if (canmove.cardTofoundation(card, Main.getDiamondFoundation()) == true)
                {
                    Cards poppedCard = Main.getTableau()[i].pop();
                    Main.getDiamondFoundation().push(poppedCard);
                    clearUI();
                    return;
                }

                if (diff == 1)
                {

                    if (card.isFacedown() == false && canmove.cardTotableau(card, Main.getTableau(), i) != 10)
                    {
                        int num = canmove.cardTotableau(card, Main.getTableau(), i);
                        int idx = 0;
                        Stacks tempStack = new Stacks();
                        for (int j = Main.getTableau()[i].getLength(); i > 0; i--)
                        {
                            if (Main.getTableau()[i].peekat(j).getName() == card.getName())
                            {
                                idx = i;
                                break;
                            }
                        }
                        for (int j = Main.getTableau()[i].getLength(); i >= idx; i--)
                        {
                            Cards poppedCard = Main.getTableau()[i].pop();
                            tempStack.push(poppedCard);
                        }

                        while (tempStack.isEmpty() == false)
                        {
                            Cards poppedCard = tempStack.pop();
                            Main.getTableau()[num].push(poppedCard);

                        }
                        clearUI();
                        return;
                    }
                }
                if (diff == 2)
                {

                    if (card.isFacedown() == false && canmove.cardTotableauModern(card, Main.getTableau(), i) != 10)
                    {
                        int num = canmove.cardTotableauModern(card, Main.getTableau(), i);
                        int idx = 0;
                        Stacks tempStack = new Stacks();
                        for (int j = Main.getTableau()[i].getLength(); i > 0; i--)
                        {
                            if (Main.getTableau()[i].peekat(j).getName() == card.getName())
                            {
                                idx = i;
                                break;
                            }
                        }
                        for (int j = Main.getTableau()[i].getLength(); i >= idx; i--)
                        {
                            Cards poppedCard = Main.getTableau()[i].pop();
                            tempStack.push(poppedCard);
                        }

                        while (tempStack.isEmpty() == false)
                        {
                            Cards poppedCard = tempStack.pop();
                            Main.getTableau()[num].push(poppedCard);
                        }
                        clearUI();
                        return;
                    }
                }


            }
        }
        private void clearUI()
        {
            clearFoundation();
            clearTableau();
            clearStockPileUI();
            clearShownPile();

            showStockPile(20, 50);
            showTableau(500, 200);
            showFoundation(500, 50);
            IncrementMoves();
            if (canmove.WinCondition())
            {
                MessageBox.Show("Congratulations! You have won the game");
            }
            
        }
        private void IncrementMoves()
        {
            Moves++;
            UpdateMovesDisplay();
        }


    }
}
