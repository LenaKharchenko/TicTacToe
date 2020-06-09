using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool turn = true; // true = X turn; false = O turn;
        bool against_computer = false;
        int turnCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn;
            b.Enabled = false;
            turnCount++;
            CheckForWinner();

            //check to see if playing against computer and if it's o's turn
            if ((!turn) && (against_computer))
                ComputerMakeMove(); 
        }

        private void ComputerMakeMove()
        {
            //priority 1: get tic tac toe
            //priority 2: block x tic tac toe
            //priority 3: go for corner space
            //priority 4: pick open space

            Button move = null;

            //look for tic tac toe opportunities
            move = LookForWinOrBlock("O"); //look for win
            if (move==null)
            {
                move = LookForWinOrBlock("X"); //look for block
                if (move==null)
                {
                    move = LookForCorner();
                    if (move ==null)
                    {
                        move = LookForOpenSpace();
                        if (move == null)
                            return;
                    }
                }
            }
            move.PerformClick();           
        }

        private Button LookForOpenSpace()
        {
            Console.WriteLine("Looking for open space");
            Button b = null;
            foreach (Control c in Controls)
            {
                b = c as Button;
                if (b!=null)
                {
                    if (b.Text == "")
                        return b;
                } //end if
            } //end foreach
            return b;
        }

        private Button LookForCorner()
        {
            Console.WriteLine("Looking for corner");
            if (A1.Text == "O")
            {
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }

            if (A3.Text == "O")
            {
                if (A1.Text == "")
                    return A1;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }

            if (C3.Text == "O")
            {
                if (A1.Text == "")
                    return A1;
                if (A3.Text == "")
                    return A3;
                if (C1.Text == "")
                    return C1;
            }

            if (C1.Text == "O")
            {
                if (A1.Text == "")
                    return A1;
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
            }

            if (A1.Text == "")
                return A1;
            if (A3.Text == "")
                return A3;
            if (C1.Text == "")
                return C1;
            if (C3.Text == "")
                return C3;

            return null;
        }

        private Button LookForWinOrBlock(string mark)
        {
            Console.WriteLine("Looking for win or block: "+mark);
            //Horizontal tests
            if ((A1.Text == mark) && (A2.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A2.Text == mark) && (A3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A3.Text == mark) && (A1.Text == mark) && (A2.Text == ""))
                return A2;

            if ((B1.Text == mark) && (B2.Text == mark) && (B3.Text == ""))
                return B3;
            if ((B2.Text == mark) && (B3.Text == mark) && (B1.Text == ""))
                return B1;
            if ((B3.Text == mark) && (B1.Text == mark) && (B2.Text == ""))
                return B2;

            if ((C1.Text == mark) && (C2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((C2.Text == mark) && (C3.Text == mark) && (C1.Text == ""))
                return C1;
            if ((C3.Text == mark) && (C1.Text == mark) && (C2.Text == ""))
                return C2;

            //Vertical tests
            if ((A1.Text == mark) && (B1.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B1.Text == mark) && (C1.Text == mark) && (A1.Text == ""))
                return A1;
            if ((C1.Text == mark) && (A1.Text == mark) && (B1.Text == ""))
                return B1;

            if ((A2.Text == mark) && (B2.Text == mark) && (C2.Text == ""))
                return C2;
            if ((B2.Text == mark) && (C2.Text == mark) && (A2.Text == ""))
                return A2;
            if ((C2.Text == mark) && (A2.Text == mark) && (B2.Text == ""))
                return B2;

            if ((A3.Text == mark) && (B3.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B3.Text == mark) && (C3.Text == mark) && (A3.Text == ""))
                return A3;
            if ((C3.Text == mark) && (A3.Text == mark) && (B3.Text == ""))
                return B3;

            //Diagonal tests
            if ((A1.Text == mark) && (B2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B2.Text == mark) && (C3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((C3.Text == mark) && (A1.Text == mark) && (B2.Text == ""))
                return B2;

            if ((A3.Text == mark) && (B2.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B2.Text == mark) && (C1.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C1.Text == mark) && (B2.Text == ""))
                return B2;

            return null;
        }

        private void CheckForWinner()
        {
            bool thereIsaWinner = false;

            //horizontal checks
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text)&&(!A1.Enabled))
                thereIsaWinner = true;
            else if((B1.Text == B2.Text) && (B2.Text == B3.Text)&& (!B1.Enabled))
                thereIsaWinner = true;
            else if((C1.Text == C2.Text) && (C2.Text == C3.Text)&& (!C1.Enabled))
                thereIsaWinner = true;

            //vertical checks
            else if((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                thereIsaWinner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                thereIsaWinner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                thereIsaWinner = true;

            //diagonal checks
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                thereIsaWinner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                thereIsaWinner = true;

            if (thereIsaWinner)
            {
                DisableButtons();
                string winner;

                if (turn)
                {
                    winner = "O";
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString();
                }
                else
                {
                    winner = "X";
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString();
                }
                    MessageBox.Show(winner+" Wins!","Hooray!");
            }
            else if(turnCount==9)
            {
               draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                MessageBox.Show("Draw!","Bummer!");
            }
        } 

        private void DisableButtons()
        {            
            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
                catch { }  //end try
            }//end foreach            
        }

        private void NewGame()
        {
            turn = true;
            turnCount = 0;

            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }  //end try
            }  //end foreach    
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }//end if
        }

        private void button_leave(object sender, EventArgs e)
        { 
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }//end if
        }

        private void newGameToolStripMenuItem1_Click_1(object sender, EventArgs e)  //New Game Menu
        {
            NewGame();                   
        }

        private void resetWinCountToolStripMenuItem_Click(object sender, EventArgs e) // Reset Count Menu
        {
            o_win_count.Text = "0";
            x_win_count.Text = "0";
            draw_count.Text = "0";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void player1VsComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
            against_computer = true;                     
        }

        private void player1VsPlayer2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
            against_computer = false;            
        }
        
    }
}
