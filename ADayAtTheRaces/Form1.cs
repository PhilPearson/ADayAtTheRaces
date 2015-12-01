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

		public Form1()
		{
			InitializeComponent();

			Girls[0] = new Guy()
			{
				Name = "Hannah",
				MyLabel = betsLabel1,
				MyRadioButton = radioButton1
			};
			Girls[1] = new Guy()
			{
				Name = "Elissa",
				MyLabel = betsLabel2,
				MyRadioButton = radioButton2
			};
			Girls[2] = new Guy()
			{
				Name = "Teagan",
				MyLabel = betsLabel3,
				MyRadioButton = radioButton3
			};

			Dogs[0] = new Greyhound()
			{
				Name = "Dog1",
				MyPictureBox = dogPictureBox1
			};
			Dogs[1] = new Greyhound()
			{
				Name = "Dog2",
				MyPictureBox = dogPictureBox2
			};
			Dogs[2] = new Greyhound()
			{
				Name = "Dog3",
				MyPictureBox = dogPictureBox3
			};
			Dogs[3] = new Greyhound()
			{
				Name = "Dog4",
				MyPictureBox = dogPictureBox4
			};
		}

		private void button2_Click(object sender, EventArgs e)
		{
            bool winner = false;
            while (!winner)
            {
                foreach (Greyhound g in Dogs)
                {
                    winner = g.Run();
                    System.Threading.Thread.Sleep(10);
                    if(winner)
                    {
                        MessageBox.Show(g.Name + " won the race");
                        Dogs[0].TakeStartingPostion();
                        Dogs[1].TakeStartingPostion();
                        Dogs[2].TakeStartingPostion();
                        Dogs[3].TakeStartingPostion();
                        break;
                    }
                }
            }
		}
	}
}
