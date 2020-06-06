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
        } //end CheckForWinner()

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
    }
}
