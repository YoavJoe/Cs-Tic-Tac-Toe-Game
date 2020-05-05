using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tic_tac_toe_Game
{
    public partial class tic_tac_toe : Form
    {
        const string X = "x";
        const string O = "O";
        private string[,] board = new string[3, 3];
        private int player = 1;
        private int CountWins_P1 = 0;
        private int CountWins_P2 = 0;
        private string[] Combination = new string[] 
        {
            "0,0|0,1|0,2","1,0|1,1|1,2","2,0|2,1|2,2","0,0|1,0|2,0","0,1|1,1|2,2","0,2|1,2|2,2","0,0|1,1|2,2","0,2|1,1|2,0"
        };
        public tic_tac_toe()
        {
            InitializeComponent();
            this.BackgroundImage = null;
        }

        private void b_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string id = b.Name;
            int positionX = int.Parse(id.Split('_')[1]);
            int positionY = int.Parse(id.Split('_')[2]);
            if (board[positionX, positionY] != null)
            {
                return;
            }
            board[positionX, positionY] = player == 1 ? X : O;
            b.BackgroundImage = ((player == 1) ? Image.FromFile(@"C:\Users\yoav\Desktop\tic_tac_toe_Game\tic_tac_toe_Game\images\axis.jpg") : Image.FromFile(@"C:\Users\yoav\Desktop\tic_tac_toe_Game\tic_tac_toe_Game\images\circle.jpg"));
            b.ImageAlign = ContentAlignment.MiddleRight;
            b.TextAlign = ContentAlignment.MiddleLeft;
            // Give the button a flat appearance.
            b.FlatStyle = FlatStyle.Flat;
            if (player == 1)
                Turns_Players.Text = O;
            else
                Turns_Players.Text = X;
            if (CheckWin())
            {
                MessageBox.Show("player:" + player + " has won!!");
                b_0_0.Enabled = false;
                b_0_1.Enabled = false;
                b_0_2.Enabled = false;
                b_1_0.Enabled = false;
                b_1_1.Enabled = false;
                b_1_2.Enabled = false;
                b_2_0.Enabled = false;
                b_0_0.Enabled = false;
                b_2_2.Enabled = false;
                if (player == 1)
                {
                    CountWins_P1++;
                    player1_wins.Text = CountWins_P1.ToString();
                }
                else
                {
                    CountWins_P2++;
                    player2_wins.Text = CountWins_P2.ToString();
                }
            }
            else if (!IsBoardFull())
            {
                player = (player == 1) ? 2 : 1;
            }
            else
            {
                MessageBox.Show("Tite");
            }
        }

        private bool IsBoardFull()
        {
            bool isFull = true;
            for (int rows = 0; rows < board.GetLength(0); rows++)
            {
                for (int cols = 0; cols < board.GetLength(1); cols++)
                {
                    if (board[rows, cols] == null)
                    {
                        isFull = false;
                        break;
                    }
                }

            }

            return isFull;
        }
        private bool CheckCombination(string win)
        {
            string[] win_new = new string[3];
            win_new = win.Split('|');


            int pos0X = int.Parse(win_new[0].Split(',')[0]);
            int pos0Y = int.Parse(win_new[0].Split(',')[1]);
            int pos1X = int.Parse(win_new[1].Split(',')[0]);
            int pos1Y = int.Parse(win_new[1].Split(',')[1]);
            int pos2X = int.Parse(win_new[2].Split(',')[0]);
            int pos2Y = int.Parse(win_new[2].Split(',')[1]);
            if (board[pos0X, pos0Y] == null && board[pos1X, pos1Y] == null && board[pos2X, pos2Y] == null) return false;


            return (board[pos0X, pos0Y] == board[pos1X, pos1Y] && board[pos1X, pos1Y] == board[pos2X, pos2Y]) ? true : false;
        }
        private bool CheckWin()
        {
            bool isWon = false;

            for (int i = 0; i < Combination.Length; i++)
            {
                if (CheckCombination(Combination[i]))
                {
                    isWon = true;
                    break;
                }
            }
            return isWon;
        }

        private void btnQuite_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            b_0_0.BackgroundImage = null;
            b_0_1.BackgroundImage = null;
            b_0_2.BackgroundImage = null;
            b_1_0.BackgroundImage = null;
            b_1_1.BackgroundImage = null;
            b_1_2.BackgroundImage = null;
            b_2_0.BackgroundImage = null;
            b_0_0.BackgroundImage = null;
            b_2_2.BackgroundImage = null;

            b_0_0.Enabled = true;
            b_0_1.Enabled = true;
            b_0_2.Enabled = true;
            b_1_0.Enabled = true;
            b_1_1.Enabled = true;
            b_1_2.Enabled = true;
            b_2_0.Enabled = true;
            b_0_0.Enabled = true;
            b_2_2.Enabled = true;


            for (int rows = 0; rows < board.GetLength(0); rows++)
            {
                for (int cols = 0; cols < board.GetLength(1); cols++)
                {
                    board[rows, cols] = null;

                }

            }
        }
    }
}


