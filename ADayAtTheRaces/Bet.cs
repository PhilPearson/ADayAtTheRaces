
namespace ADayAtTheRaces
{
	class Bet
	{
		public int Amount;
		public Greyhound Dog;	//pass in a greyhound object instead of an int
		public Guy Bettor;

		//return a string that says who placed the bet, how much was bet and which dog he bet on 
		public string GetDescription()
		{
			if (Amount != 0)
				return (Bettor.Name + " bets " + Amount + " on " + Dog.Name);

			//If the amount is zero, no bet was placed
			else
				return (Bettor.Name + " hasnt placed a bet");
		}


		public int PayOut(Greyhound Winner)
		{
			//if the dog won, return the amount bet
			if(Winner == Dog)
			{
				return Amount;
			}
			//otherwise return the negative of the amount bet
			else return 0-Amount;
		}
	}
}
