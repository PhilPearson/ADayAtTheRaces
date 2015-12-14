using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADayAtTheRaces
{
	public partial class Form1 : Form
	{
		Guy[] Girls = new Guy[3];
		Greyhound[] Dogs = new Greyhound[4];
		Random myRandom = new Random();

		public Form1()
		{
			InitializeComponent();

			Girls[0] = new Guy()
			{
				Name = "Hannah",
				MyLabel = betsLabel1,
				MyRadioButton = radioButton1,
				Cash = 400
			};
			Girls[1] = new Guy()
			{
				Name = "Elissa",
				MyLabel = betsLabel2,
				MyRadioButton = radioButton2,
				Cash = 400
			};
			Girls[2] = new Guy()
			{
				Name = "Teagan",
				MyLabel = betsLabel3,
				MyRadioButton = radioButton3,
				Cash = 400
			};
			foreach(Guy g in Girls)
			{
				g.UpdateLabels();
			}

			Dogs[0] = new Greyhound()
			{
				Name = "Skipper",
				MyPictureBox = dogPictureBox1,
				Randomizer = myRandom
			};
			Dogs[1] = new Greyhound()
			{
				Name = "Prancer",
				MyPictureBox = dogPictureBox2,
                Randomizer = myRandom
			};
			Dogs[2] = new Greyhound()
			{
				Name = "Stinker",
				MyPictureBox = dogPictureBox3,
                Randomizer = myRandom
			};
			Dogs[3] = new Greyhound()
			{
				Name = "Speedy Gonzalez",
				MyPictureBox = dogPictureBox4,
                Randomizer = myRandom
			};

			betAmount.Minimum = 5;
            minimumBet.Text = "Minimum bet: " + betAmount.Minimum + " bucks";
		}

		private void button2_Click(object sender, EventArgs e)
		{
            bool winner = false;
			button2.Enabled = false;
            while (!winner)
            {
				int count = 0;
                foreach (Greyhound g in Dogs)
                {
					count += 1;
                    winner = g.Run();
                    System.Threading.Thread.Sleep(10);
                    if(winner)
                    {
                        MessageBox.Show(g.Name + " won the race");
                        Dogs[0].TakeStartingPostion();
                        Dogs[1].TakeStartingPostion();
                        Dogs[2].TakeStartingPostion();
                        Dogs[3].TakeStartingPostion();
						foreach(Guy f in Girls)
						{
							f.Collect(count);
						}
                        break;
                    }
                }
            }
			button2.Enabled = true;
		}

		private void btnBets_Click(object sender, EventArgs e)
		{
			if (radioButton1.Checked)
				Girls[0].PlaceBet((int)betAmount.Value, (int)dogNumber.Value-1);
			else if (radioButton2.Checked)
				Girls[1].PlaceBet((int)betAmount.Value, (int)dogNumber.Value-1);
			else if (radioButton3.Checked)
				Girls[2].PlaceBet((int)betAmount.Value, (int)dogNumber.Value-1);
		}

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
