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
			if (MyBet != null)
				MyLabel.Text = MyBet.GetDescription();
			else
				MyLabel.Text = Name + " hasn't placed a bet";

			//radio button to show my cash ("Joe has 43 bucks")
			MyRadioButton.Text = Name + " has " + Cash.ToString() + " bucks";
		}

		public bool PlaceBet(int Amount, int Dog)
		{
			if (Amount < Cash)
			{
				MyBet = new Bet();
				MyBet.Amount = Amount;
				MyBet.Dog = Dog;
				MyBet.Bettor = this;
				UpdateLabels();
                return (true);
			}
			else
			{
				return (false);
			}
		}

		public void ClearBet()
		{
			//reset my bet so its 0
			MyBet = null;
			UpdateLabels();
		}

		public void Collect(int Winner)
		{
			//ask my bet to pay out
			MyBet.PayOut(Winner);
		}
	}
}
