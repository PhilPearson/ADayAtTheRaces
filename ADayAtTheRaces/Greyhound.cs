using System;
using System.Windows.Forms;
using System.Drawing;

namespace ADayAtTheRaces
{
	class Greyhound
	{
		public int StartingPosition;
		public int RacetrackLength;
        public PictureBox MyPictureBox = null;
		public int Location = 0;
        public Random Randomizer;					//the same Random object gets assigned to all dogs
		public string Name;

		public bool Run()
		{
			//run forward 1,2,3 or 4 spaces at random
			int distance;
			distance = Randomizer.Next(1,4); 

			//update the postion of the my picturebox
			Point p = MyPictureBox.Location;
			p.X += distance;
			MyPictureBox.Location = p;

			//return true if i won the race
			if (p.X >= RacetrackLength)
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
			p.X = StartingPosition;
			MyPictureBox.Location = p;
		}
	}
}
