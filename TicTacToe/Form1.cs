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
		public Form1()
		{
			InitializeComponent();
		}


		public String currPlayer;
		public String player = "X";
		public String opponent = "O";
		public int turns = 0;
		public int c1, c2, cd;

		//who goes first
		private void btnPlayer_CheckedChanged(object sender, EventArgs e)
		{
			newGame();
			if (currPlayer == player && turns != 0 && btnWith.Checked)
			{
				panelRotationOptions.Visible = true;
				grid.Enabled = false;
			}
		}
		private void btnOpon_CheckedChanged(object sender, EventArgs e)
		{
			newGame();
			if(btnComp.Checked)
			{
				computerMove();

				/*if (btnWith.Checked)
				{
					if (currPlayer == player && turns != 0)
					{
						panelRotationOptions.Visible = true;
						grid.Enabled = false;
					}
				}*/

			}
		}

		//human vs human
		private void btnHum_CheckedChanged(object sender, EventArgs e)
		{
			label1.Text = menuPlayer1.Text;
			label2.Text = menuPlayer2.Text;
			newGame();
		}
		//human vs computer
		private void btnComp_CheckedChanged(object sender, EventArgs e)
		{
			label1.Text = "Player:";
			label2.Text = "Computer:";
			newGame();
		}

		//difficulty
		private void btnEasy_CheckedChanged(object sender, EventArgs e)
		{
			newGame();
			if (btnComp.Checked && btnOpon.Checked)
			{
				randomMove().PerformClick();
			}
			/*if (currPlayer == player && turns != 0 && btnWith.Checked)
			{
				panelRotationOptions.Visible = true;
				grid.Enabled = false;
			}*/
		}
		private void btnMedium_CheckedChanged(object sender, EventArgs e)
		{
			newGame();
			if (btnComp.Checked && btnOpon.Checked)
			{
				cornerMove().PerformClick();
			}
			/*if (currPlayer == player && turns != 0 && btnWith.Checked)
			{
				panelRotationOptions.Visible = true;
				grid.Enabled = false;
			}*/
		}
		private void btnHard_CheckedChanged(object sender, EventArgs e)
		{
			newGame();
			if (btnComp.Checked && btnOpon.Checked)
			{
				middleMove().PerformClick();
			}
			/*if (currPlayer == player && turns != 0 && btnWith.Checked)
			{
				panelRotationOptions.Visible = true;
				grid.Enabled = false;
			}*/
		}

		//enabling rotations
		private void btnWith_CheckedChanged(object sender, EventArgs e)
		{
			newGame();
			if (btnComp.Checked && btnOpon.Checked)
			{
				computerMove();
				
			}
			/*if (currPlayer == player && turns != 0)
			{
				panelRotationOptions.Visible = true;
				grid.Enabled = false;
			}*/
		}

		private void btnWithout_CheckedChanged(object sender, EventArgs e)
		{
			newGame();
			if (btnComp.Checked && btnOpon.Checked) computerMove();
		}

		//new game
		private void buttonNG_Click(object sender, EventArgs e)
		{
			panelPocetni.Visible = false;
			panelGame.Visible = true;
			grid.Visible = true;
			panelOptions.Visible = true;
			panelRotationOptions.Visible = false;

			setInitial();
			setScoreBoard();
		}

		private void move(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			if (btn.Text == "")
			{
				if (currPlayer == "X")
				{
					btn.Text = "X";
					turns++;
				}
				else
				{
					btn.Text = "O";
					turns++;
				}

				gameOver();

				//continue playing
				if (endCond() == 0) togglePlayer();

				if (btnComp.Checked == true)
				{
					computerMove();

						if (currPlayer == player && turns != 0 && btnWith.Checked)
						{
							panelRotationOptions.Visible = true;
							grid.Enabled = false;
							highlightButtons();
							gameOver();
						}
		
				} else
				{
					if (currPlayer == player && turns != 0 && btnWith.Checked)
					{
						panelRotationOptions.Visible = true;
						grid.Enabled = false;
						highlightButtons();
						gameOver();
					}
				}
				
			}
			else
			{
				return;
			}
		}

		private void resetBoard()
		{
			turns = 0;
			A00.Text = A01.Text = A02.Text = A10.Text = A11.Text = A12.Text = A20.Text = A21.Text = A22.Text = "";
			count1.Text = c1.ToString();
			count2.Text = c2.ToString();
			countDraws.Text = cd.ToString();
			resetButtonsColor();
			panelRotationOptions.Visible = false;
		}

		private void newGame()
		{
			c1 = c2 = cd = 0;
			resetBoard();
			setInitial();
			setScoreBoard();
			grid.Enabled = true;
		}

		private void setInitial()
		{
			if (btnOpon.Checked)
			{
				currPlayer = opponent;
			}
			else
			{
				currPlayer = player;
			}
		}

		private void setScoreBoard()
		{
			if (btnHum.Checked == true)
			{
				label1.Text = menuPlayer1.Text;
				label2.Text = menuPlayer2.Text;
			}
			else
			{
				label1.Text = "Player:";
				label2.Text = "Computer:";
			}
		}

		private void togglePlayer()
		{
			if (currPlayer == player)
			{
				currPlayer = opponent;
			}
			else
			{
				currPlayer = player;
			} 
		}

		private int endCond()
		{
			if ((A00.Text == player && A10.Text == player && A20.Text == player) ||
				(A01.Text == player && A11.Text == player && A21.Text == player) ||
				(A02.Text == player && A12.Text == player && A22.Text == player) ||
				(A00.Text == player && A01.Text == player && A02.Text == player) ||
				(A10.Text == player && A11.Text == player && A12.Text == player) ||
				(A20.Text == player && A21.Text == player && A22.Text == player) ||
				(A00.Text == player && A11.Text == player && A22.Text == player) ||
				(A20.Text == player && A11.Text == player && A02.Text == player) )
			{
				return 1; //X won
			}

			if ((A00.Text == opponent && A10.Text == opponent && A20.Text == opponent) ||
				(A01.Text == opponent && A11.Text == opponent && A21.Text == opponent) ||
				(A02.Text == opponent && A12.Text == opponent && A22.Text == opponent) ||
				(A00.Text == opponent && A01.Text == opponent && A02.Text == opponent) ||
				(A10.Text == opponent && A11.Text == opponent && A12.Text == opponent) ||
				(A20.Text == opponent && A21.Text == opponent && A22.Text == opponent) ||
				(A00.Text == opponent && A11.Text == opponent && A22.Text == opponent) ||
				(A20.Text == opponent && A11.Text == opponent && A02.Text == opponent))
			{
				return 2; //Y won
			}

			if (turns == 9)
			{
				return 3; //tie
			}

			return 0; //incomplete
		}

		private int endCond (String[,] board)
		{
			if ((board[0, 0] == player && board[1, 0] == player && board[2, 0] == player) || 
				(board[0, 1] == player && board[1, 1] == player && board[2, 1] == player) ||
				(board[0, 2] == player && board[1, 2] == player && board[2, 2] == player) ||
				(board[0, 0] == player && board[0, 1] == player && board[0, 2] == player) ||
				(board[1, 0] == player && board[1, 1] == player && board[1, 2] == player) ||
				(board[2, 0] == player && board[2, 1] == player && board[2, 2] == player) || 
				(board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) ||
				(board[2, 0] == player && board[1, 1] == player && board[0, 2] == player))
			{
				return 1; //X won
			}

			if ((board[0, 0] == opponent && board[1, 0] == opponent && board[2, 0] == opponent) ||
				(board[0, 1] == opponent && board[1, 1] == opponent && board[2, 1] == opponent) ||
				(board[0, 2] == opponent && board[1, 2] == opponent && board[2, 2] == opponent) ||
				(board[0, 0] == opponent && board[0, 1] == opponent && board[0, 2] == opponent) ||
				(board[1, 0] == opponent && board[1, 1] == opponent && board[1, 2] == opponent) ||
				(board[2, 0] == opponent && board[2, 1] == opponent && board[2, 2] == opponent) ||
				(board[0, 0] == opponent && board[1, 1] == opponent && board[2, 2] == opponent) ||
				(board[2, 0] == opponent && board[1, 1] == opponent && board[0, 2] == opponent))
			{
				return 2; //Y won
			}

			if (turns == 9)
			{
				return 3; //tie
			}

			return 0; //incomplete
		}

		private void gameOver()
		{
			int res = endCond();
			if (res == 1)
			{
				if (btnComp.Checked)
				{
					MessageBox.Show("You won!\n");
				}
				else
				{
					MessageBox.Show("Player 1 won!\n");
				}
				c1++;
				resetBoard();
			}
			else if (res == 2)
			{
				if (btnComp.Checked)
				{
					MessageBox.Show("Computer won!\n");
				}
				else
				{
					MessageBox.Show("Player 2 won!\n");
				}
				c2++;
				resetBoard();
			}
			else if (res == 3)
			{
				MessageBox.Show("Tie!\n");
				cd++;
				resetBoard();
			}
		}


		//AI moves
		private void computerMove()
		{
			if (btnEasy.Checked == true)
			{
				if (currPlayer == opponent)
					randomMove().PerformClick();
			}
			else if (btnMedium.Checked == true)
			{
				if (currPlayer == opponent)
					averageMove().PerformClick();
			}
			else if (btnHard.Checked == true)
			{
				if (currPlayer == opponent)
					optimalMove().PerformClick();

			}
		}

		private Button randomMove()
		{
			Random rand = new Random();
			int r = rand.Next(9);
			int i = 0;
			Button btn = null;
			foreach (Control C in grid.Controls)
			{
				btn = C as Button;
				if (btn != null)
				{
					if (btn.Text == "" && i==r)
					{
						return btn;
					}
				}
				i++;
			}
			foreach (Control C in grid.Controls)
			{
				btn = C as Button;
				if (btn != null)
				{
					if (btn.Text == "")
					{
						return btn;
					}
				}
				i++;
			}
			return null;
		}

		private Button averageMove()
		{
			Button btn = null;
			foreach (Control C in grid.Controls)
			{
				btn = C as Button;
				if (btn != null)
				{
					//MessageBox.Show("btn = " + btn.Name);
					if (btn.Text == "")
					{
						btn.Text = opponent;
						if (endCond() == 2)
						{
							btn.Text = "";
							return btn;
						}
						else
						{
							Button btn2 = null;
							foreach (Control C2 in grid.Controls)
							{
								btn2 = C2 as Button;
								//MessageBox.Show("btn2 = " + btn2.Name);
								if (btn2 != null)
								{
									if (btn2.Text == "")
									{
										btn2.Text = player;
										if(endCond() == 1)
										{
											btn.Text = "";
											btn2.Text = "";
											return btn2;
										}
										btn2.Text = "";
									}
								}
							}
							btn.Text = "";
						}
					}
				}
			}
			return randomMove();
		}

		private Button optimalMove()
		{
			String[,] board = gridCopy();
			if(turns == 1)
			{
				if (board[1,1] == "")
				{
					return middleMove();	
				}
				else
					return cornerMove();
			}
			
			if (turns == 3)
			{
				if((board[0,2] == player && board[2,0] == player) ||
				   (board[0,0] == player && board[2,2] == player))
				{
					return edgeMove();
				} 
				if ((board[0, 1] == player && (board[1, 0] == player || board[1, 2] == player) ||
				   (board[2, 1] == player && (board[1, 2] == player || board[1,0] == player))))
				{
					return cornerMove();
				}
				
			}
			return averageMove();
		}

		private Button middleMove()
		{
			Button btn = null;
			foreach (Control C in grid.Controls)
			{
				btn = C as Button;
				if (btn != null)
				{
					if (btn.Name == "A11")
					{
						return btn;
					}
				}
			}
			return null;
		}

		private Button cornerMove()
		{
			String[,] board = gridCopy();
			Button btn = null;
			foreach (Control C in grid.Controls)
			{
				btn = C as Button;
				if (btn != null)
				{
					if (btn.Text == "")
					{
						//connect two
						if (btn.Name == "A00" && (board[0, 2] == opponent || board[2, 0] == opponent || board[2, 2] == opponent))
							return btn;

						if (btn.Name == "A02" && (board[0, 0] == opponent || board[2, 2] == opponent || board[2, 0] == opponent))
							return btn;

						if (btn.Name == "A20" && (board[0, 0] == opponent || board[0, 2] == opponent || board[2, 2] == opponent))
							return btn;

						if (btn.Name == "A22" && (board[0, 2] == opponent || board[2, 0] == opponent || board[0, 0] == opponent))
							return btn;

						//stop player from making a fork
						if (btn.Name == "A00" && (board[0, 1] == player && board[1, 0] == player))
							return btn;

						if (btn.Name == "A02" && (board[0, 1] == player && board[1, 2] == player))
							return btn;

						if (btn.Name == "A20" && (board[2, 1] == player && board[1, 0] == player))
							return btn;

						if (btn.Name == "A22" && (board[2, 1] == player && board[1, 2] == player))
							return btn;

					}
				}
			}
			
			foreach (Control C in grid.Controls)
			{
				btn = C as Button;
				if (btn != null)
				{
					if (btn.Text == "")
					{
						if (btn.Name == "A02" || btn.Name == "A00" || btn.Name == "A20" || btn.Name == "A22")
							return btn;
					}
				}
			}
			return null;
		}

		private Button edgeMove()
		{
			Button btn = null;
			foreach (Control C in grid.Controls)
			{
				btn = C as Button;
				if (btn != null)
				{
					if (btn.Text == "")
					{
						if (btn.Name == "A01" || btn.Name == "A10" || btn.Name == "A12" || btn.Name == "A21")
							return btn;
					}
				}
			}
			return null;
		}



		private String[,] gridCopy()
		{
			String[,] board = new String[3,3]; 
			Button btn = null;
			foreach (Control C in grid.Controls)
			{
				btn = C as Button;
				if (btn != null)
				{
					if (btn.Name == "A00") board[0, 0] = btn.Text;
	
					if (btn.Name == "A01") board[0, 1] = btn.Text;

					if (btn.Name == "A02") board[0, 2] = btn.Text;

					if (btn.Name == "A10") board[1, 0] = btn.Text;

					if (btn.Name == "A11") board[1, 1] = btn.Text;

					if (btn.Name == "A12") board[1, 2] = btn.Text;

					if (btn.Name == "A20") board[2, 0] = btn.Text;

					if (btn.Name == "A21") board[2, 1] = btn.Text;

					if (btn.Name == "A22") board[2, 2] = btn.Text;

				}
			}
			return board;
		}

		/*
		private int minimax(int depth,double alpha, double beta, String pl)
		{
			//if game ends
			if (endCond() != 0 || depth == 0) return score();

			if (pl == opponent)
			{
				Button btn = null;
				foreach (Control C in grid.Controls)
				{
					btn = C as Button;
					if (btn != null)
					{
						if (btn.Text == "")
						{
							btn.Text = opponent;
							alpha = Math.Max(alpha, minimax(depth-1,alpha,beta,player));
							
							if (beta < alpha)
							{
								break;
							}
							
						}
						btn.Text = "";
					}
				}
				return (int) alpha;
			}
			else
			{
				Button btn = null;
				foreach (Control C in grid.Controls)
				{
					btn = C as Button;
					if (btn != null)
					{
						if (btn.Text == "")
						{
							btn.Text = player;
							beta = Math.Min(beta, minimax(depth - 1, alpha, beta, opponent));
							
							if (beta < alpha)
							{
								break;
							}

						}
						btn.Text = "";
					}
				}
				return (int) beta;
			}


		}

		private int score()
		{
			int res = endCond();

			if (res == 1)
			{
				return -10;
			}
			if (res == 2)
			{
				return 10;
			}
			if (res == 3)
			{
				return 0;
			}
			return -1;
		}

		private int score(String[,] board)
		{
			int res = endCond(board);

			if (res == 1)
			{
				return -10;
			}
			if (res == 2)
			{
				return 10;
			}
			if (res == 3)
			{
				return 0;
			}
			return -1;
		}*/


		//panel rotation options
		private void btnRotLeft_Click(object sender, EventArgs e)
		{
			grid.Enabled = true;
			String[,] board = rotateLeft();
			Button btn = null;
			foreach (Control C in grid.Controls)
			{
				btn = C as Button;
				if (btn != null)
				{
					if (btn.Name == "A11") btn.Text = board[1, 1];

					if (btn.Name == "A12") btn.Text = board[1, 2];

					if (btn.Name == "A21") btn.Text = board[2, 1];

					if (btn.Name == "A22") btn.Text = board[2, 2];

				}
			}
			togglePlayer();
			if (btnComp.Checked) computerMove();
			if (currPlayer == opponent)
			{
				panelRotationOptions.Visible = false;
				resetButtonsColor();
			}
		}

		private void btnRightRot_Click(object sender, EventArgs e)
		{
			grid.Enabled = true;
			String[,] board = rotateRight();
			Button btn = null;
			foreach (Control C in grid.Controls)
			{
				btn = C as Button;
				if (btn != null)
				{
					if (btn.Name == "A11") btn.Text = board[1, 1];

					if (btn.Name == "A12") btn.Text = board[1, 2];

					if (btn.Name == "A21") btn.Text = board[2, 1];

					if (btn.Name == "A22") btn.Text = board[2, 2];

				}
			}
			togglePlayer();
			if (btnComp.Checked) computerMove();
			if (currPlayer == opponent)
			{
				panelRotationOptions.Visible = false;
				resetButtonsColor();
			}
		}

		private void btnMakeMove_Click(object sender, EventArgs e)
		{
			grid.Enabled = true;
			panelRotationOptions.Visible = false;
			resetButtonsColor();
			if (btnComp.Checked) computerMove();
		}

		private void highlightButtons()
		{
			Button btn = null;
			foreach (Control C in grid.Controls)
			{
				btn = C as Button;
				if (btn != null)
				{
					if (btn.Name == "A11") btn.BackColor = Color.Bisque;

					if (btn.Name == "A12") btn.BackColor = Color.Bisque;

					if (btn.Name == "A21") btn.BackColor = Color.Bisque;

					if (btn.Name == "A22") btn.BackColor = Color.Bisque;

				}
			}
		}

		private void resetButtonsColor()
		{
			Button btn = null;
			foreach (Control C in grid.Controls)
			{
				btn = C as Button;
				if (btn != null)
				{
					if (btn.Name == "A11") btn.BackColor = Color.Gainsboro;

					if (btn.Name == "A12") btn.BackColor = Color.Gainsboro;

					if (btn.Name == "A21") btn.BackColor = Color.Gainsboro;

					if (btn.Name == "A22") btn.BackColor = Color.Gainsboro;

				}
			}
		}

		private String[,] rotateLeft()
		{
			String[,] board = gridCopy();

			String btn1 = board[1, 1];
			String btn2 = board[1, 2];
			String btn3 = board[2, 1];
			String btn4 = board[2, 2];

			board[1, 1] = btn2;
			board[1, 2] = btn4;
			board[2, 1] = btn1;
			board[2, 2] = btn3;

			return board;

		}

		private String[,] rotateRight()
		{
			String[,] board = gridCopy();

			String btn1 = board[1, 1];
			String btn2 = board[1, 2];
			String btn3 = board[2, 1];
			String btn4 = board[2, 2];

			board[1, 1] = btn3;
			board[1, 2] = btn1;
			board[2, 1] = btn4;
			board[2, 2] = btn2;

			return board;

		}


		//menues
		private void restartToolStripMenuItem_Click(object sender, EventArgs e)
		{
			newGame();
		}

		private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void menuPlayer1_Click(object sender, EventArgs e)
		{
			label1.Text = menuPlayer1.Text;
		}

		private void menuPlayer2_Click(object sender, EventArgs e)
		{
			label2.Text = menuPlayer2.Text;
		}

		private void goBackToolStripMenuItem_Click(object sender, EventArgs e)
		{
			panelPocetni.Visible = true;
			panelGame.Visible = false;
			panelOptions.Visible = false;
			panelRotationOptions.Visible = false;
			newGame();
		}

		private void gameRulesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Depending on your choice you can play a regular \r\nTic-Tac-Toe game with three different levels of\r\ndifficulty, or a version of this game with rotations " +
				"\r\nin which your move count as either regular move or rotation of \r\n4 bottom right squares one side or another. This can \r\nchange the " +
				"complete outcome of the game.\r\n\r\nThe goal is to collect 3 of your figures ( mark \"X\") \r\ninto one line in any direction - horizontally,\r\n vertically or diagonally. If both " +
				"players fail to do \r\nso and there are no more available places, the \r\ngame results in a draw.\r\n\r\nAlso, you can choose if you want to go first or let \r\nthe computer make the first" +
				" move. If you chose to play against another player, you can customize score board by entering desired names. You should go to Options in menu bar, and type in" +
				"your names into appropriate text box. Anyhow, you can play multiple rounds one after another and score will be displayed.\nGood luck! ");
		}

		private void contactToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("You can contact me on : vmarijana3@gmail.com\r\n\r\nI would be happy to get your feedback.");
		}

		
	

	}

}
