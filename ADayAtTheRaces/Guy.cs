using System;
using System.Windows.Forms;

namespace ADayAtTheRaces
{
	class Guy
	{
		public string Name;
		public Bet MyBet;
		public int Cash;

		public RadioButton MyRadioButton;
		public Label MyLabel;

		public void UpdateLabels()
		{
			//set my label to my bets desc
			//radio button to show my cash ("Joe has 43 bucks")
		}

		public void ClearBet()
		{
			//reset my bet so its 0
		}

		public void Collect(int Winner)
		{
			//ask my bet to pay out
		}
	}
}
