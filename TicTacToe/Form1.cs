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
                    winner = "O";
                else
                    winner = "X";
               MessageBox.Show(winner+" Wins!","Hooray!");
            }
            else if(turnCount==9)
            {
                MessageBox.Show("Draw!","Bummer!");
            }
        } //end CheckForWinner()

        private void DisableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }//end foreach
            }
            catch { }  //end try
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turnCount = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }  //end foreach
            }
            catch { }  //end try
        }
    }
}
