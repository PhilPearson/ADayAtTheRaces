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

		//Update labels on form, depends if a bet has been placed or not.
		public void UpdateLabels()
		{
			//set my label to my bets desc
			if (MyBet != null)
			{
				MyLabel.Text = MyBet.GetDescription();
                
				//radio button to show my cash ("Joe has 43 bucks")
				MyRadioButton.Text = Name + " has " + (Cash - MyBet.Amount).ToString() + " bucks";
			}
			else
			{
				MyLabel.Text = Name + " hasn't placed a bet";
				//radio button to show my cash ("Joe has 43 bucks")
				MyRadioButton.Text = Name + " has " + Cash.ToString() + " bucks";
			}			
		}

		public bool PlaceBet(int Amount, Greyhound Dog)
		{
			//check to see if we have enough cash first
			if (Amount < Cash)
			{
				//create the bet, assign the amount, dog and who placed the bet. Finish up by updating labels
				MyBet = new Bet();
				MyBet.Amount = Amount;
				MyBet.Dog = Dog;
				MyBet.Bettor = this;
				UpdateLabels();
                return (true);
			}
			else
			{
				//sorry, you are broke
				return (false);
			}
		}

		public void ClearBet()
		{
			//reset my bet so its 0
			MyBet = null;
			UpdateLabels();
		}

		public void Collect(Greyhound Winner)
		{
			//did you place a bet? if so check to see if you won or lost
			if (MyBet != null)
				Cash += MyBet.PayOut(Winner);
		}
	}
}
