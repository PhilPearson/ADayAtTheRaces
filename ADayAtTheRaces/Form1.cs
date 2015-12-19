using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
My solution to the Head First C# 2nd edition 'A Day at the Races' Lab.
Note that I modified my solution slightly to represent dogs as names rather than numbers
*/

namespace ADayAtTheRaces
{
	public partial class Form1 : Form
	{
		//create arrays of objects, this way we can loop
		//my guys are all girls :-P
		Guy[] Girls = new Guy[3];
		Greyhound[] Dogs = new Greyhound[4];
		RadioButton[] radioSelections = new RadioButton[3];

		//create a single instance of random
		Random myRandom = new Random();
		

		public Form1()
		{
			InitializeComponent();

			//fill array
			radioSelections[0] = radioButton1;
			radioSelections[1] = radioButton2;
			radioSelections[2] = radioButton3;

			//create the guys
			Girls[0] = new Guy(){	Name = "Hannah",
									MyLabel = betsLabel1,
									MyRadioButton = radioButton1,
									Cash = 50};
			Girls[1] = new Guy(){	Name = "Elissa",
									MyLabel = betsLabel2,
									MyRadioButton = radioButton2,
									Cash = 75};
			Girls[2] = new Guy(){	Name = "Teagan",
									MyLabel = betsLabel3,
									MyRadioButton = radioButton3,
									Cash = 45};

			//and initialise their labels
			foreach (Guy g in Girls)	{
				g.UpdateLabels();
			}

			//create the dogs, my kids insisted I give them names
			Dogs[0] = new Greyhound(){	Name = "Skipper",
										MyPictureBox = dogPictureBox1,
										Randomizer = myRandom,
										StartingPosition = 20,
										RacetrackLength = 480};
			Dogs[1] = new Greyhound(){	Name = "Prancer",
										MyPictureBox = dogPictureBox2,
										Randomizer = myRandom,
										StartingPosition = 20,
										RacetrackLength = 480};
			Dogs[2] = new Greyhound(){	Name = "Stinker",
										MyPictureBox = dogPictureBox3,
										Randomizer = myRandom,
										StartingPosition = 20,
										RacetrackLength = 480};
			Dogs[3] = new Greyhound(){	Name = "Speedy Gonzalez",
										MyPictureBox = dogPictureBox4,
										Randomizer = myRandom,
										StartingPosition = 20,
										RacetrackLength = 480};

			//add each dog to the combo box
			foreach(Greyhound g in Dogs)
			{
				comboBox1.Items.Add(g.Name);
			}
			comboBox1.SelectedIndex = 0;	//default select the first dog

			//set minimum bet to a value of 5 and update label
			betAmount.Minimum = 5;
            minimumBet.Text = "Minimum bet: " + betAmount.Minimum + " bucks";
		}

		//start racing!
		private void button2_Click(object sender, EventArgs e)
		{
			//create a flag for the winner and disable the start button
            bool winner = false;
			button2.Enabled = false;
			
			//loop till we get a winner
            while (!winner)
            {
				Application.DoEvents();	//added to clean up interface
				int count = 0;			//counter for the following loop
                foreach (Greyhound g in Dogs)
                {
					winner = g.Run();					//makes the dog run, returns false if not yet won
                    System.Threading.Thread.Sleep(8);	//slows things down
					
					//we have a winner so..
                    if(winner)
                    {
                        MessageBox.Show(g.Name + " won the race");		//messagebox who won

						//reset dogs to starting gate
                        Dogs[0].TakeStartingPostion();
                        Dogs[1].TakeStartingPostion();
                        Dogs[2].TakeStartingPostion();
                        Dogs[3].TakeStartingPostion();

						//loop though each guy and collect winnings then reset the betting
						foreach(Guy f in Girls)
						{
							f.Collect(Dogs[count]);
							f.ClearBet();
						}
                        break;
                    }
					count += 1;
				}
            }
			//race is over so reset the start button
			button2.Enabled = true;
		}

		//place a bet
		private void btnBets_Click(object sender, EventArgs e)
		{
			int count = 0;
			//loop through radio buttons, if selected then thats who is trying to place a bet
			foreach (RadioButton r in radioSelections)
			{
				if (r.Checked)
				{
					//place the bet, if it returns false then you dont have enough money
					if (!Girls[count].PlaceBet((int)betAmount.Value, Dogs[comboBox1.SelectedIndex]))
						MessageBox.Show("You dont have that much money");
				}
				count += 1;
			}
		}

		//i should see if this can be stacked somehow?
		//update each label when checking the buttons
		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			betterLabel.Text = Girls[0].Name;
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			betterLabel.Text = Girls[1].Name;
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			betterLabel.Text = Girls[2].Name;
		}
	}
}
