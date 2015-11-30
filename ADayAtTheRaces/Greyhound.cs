using System;
using System.Windows.Forms;
using System.Drawing;

namespace ADayAtTheRaces
{
	class Greyhound
	{
		public int StartinPosition;
		public int RacetrackLength;
        public PictureBox MyPictureBox = null;
		public int Location = 0;
		public Random Randomizer;
		public string Name;

		public bool Run()
		{
			//run forward 1,2,3 or 4 spaces at random
			int distance;
			Randomizer = new Random();
			distance = Randomizer.Next(1,4); 

			//update the postion of the my picturebox
			Point p = MyPictureBox.Location;
			p.X += distance;
			MyPictureBox.Location = p;

			//return true if i won the race
			if (p.X >= 400)
				return (true);
			else
			{
				return (false);
			}
		}
		public void TakeStartingPostion()
		{
			//reset my position to the starting point
			Point p = MyPictureBox.Location;
			p.X = 0;
			MyPictureBox.Location = p;
		}
	}
}
