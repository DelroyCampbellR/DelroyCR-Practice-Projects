using System.Drawing.Drawing2D;
using System.Numerics;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private bool _turnOrder;
        bool _oWinner = false;
        bool _xWinner = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            ((Button)sender).Text = _turnOrder ? "X" : "O";
            ((Button)sender).Enabled = false;
            MatchChecker();
            _turnOrder = !_turnOrder;
        }

        private void MatchChecker()
        {
            Button[,] buttonGrid = new Button[3, 3];

            bool winnerFound = false;

            buttonGrid[0, 0] = button1;
            buttonGrid[0, 1] = button2;
            buttonGrid[0, 2] = button3;
            buttonGrid[1, 0] = button4;
            buttonGrid[1, 1] = button5;
            buttonGrid[1, 2] = button6;
            buttonGrid[2, 0] = button7;
            buttonGrid[2, 1] = button8;
            buttonGrid[2, 2] = button9;

            // X Verificar filas
            for (int row = 0; row < 3; row++)
            {
                if ((buttonGrid[row, 0].Text == "X" && buttonGrid[row, 1].Text == "X" && buttonGrid[row, 2].Text == "X"))
                {
                    winnerFound = true;
                    _xWinner = true;
                    break;
                }
            }

            // X Verificar columnas
            if (!winnerFound)
            {
                for (int col = 0; col < 3; col++)
                {
                    if ((buttonGrid[0, col].Text == "X" && buttonGrid[1, col].Text == "X" && buttonGrid[2, col].Text == "X"))
                    {
                        winnerFound = true;
                        _xWinner = true;

                        break;
                    }
                }
            }

            // O Verificar filas
            if (!winnerFound)
            {
                for (int row = 0; row < 3; row++)
                {

                    if ((buttonGrid[row, 0].Text == "O" && buttonGrid[row, 1].Text == "O" && buttonGrid[row, 2].Text == "O"))
                    {
                        winnerFound = true;
                        _oWinner = true;
                        break;
                    }

                }
            }

            // O Verificar columnas
            if (!winnerFound)
            {
                for (int col = 0; col < 3; col++)
                {
                    if ((buttonGrid[0, col].Text == "O" && buttonGrid[1, col].Text == "O" && buttonGrid[2, col].Text == "O"))
                    {
                        winnerFound = true;
                        _oWinner = true;
                        break;
                    }
                }
            }

            //Verificar diagonales
            //X
            if (!winnerFound)
            {
                if (((buttonGrid[0, 0].Text == "X" && buttonGrid[1, 1].Text == "X" && buttonGrid[2, 2].Text == "X")) ||
                ((buttonGrid[0, 2].Text == "X" && buttonGrid[1, 1].Text == "X" && buttonGrid[2, 0].Text == "X")))
                {
                    _xWinner = true;
                    winnerFound = true;
                }
            }

            //O
            if (!winnerFound)
            {
                if (((buttonGrid[0, 0].Text == "O" && buttonGrid[1, 1].Text == "O" && buttonGrid[2, 2].Text == "O")) ||
                ((buttonGrid[0, 2].Text == "O" && buttonGrid[1, 1].Text == "O" && buttonGrid[2, 0].Text == "O")))
                {
                    _oWinner = true;
                    winnerFound = true;
                }
            }

            if (winnerFound == true)
            {
                if (_oWinner == true)
                    MessageBox.Show("Player 'O' won!");
                else if (_xWinner == true)
                    MessageBox.Show("Player 'X' won!");

                Application.Restart();
            }
        }
    }
}