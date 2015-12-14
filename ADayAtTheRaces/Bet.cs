
namespace ADayAtTheRaces
{
	class Bet
	{
		public int Amount;
		public int Dog;
		public Guy Bettor;

		public string GetDescription()
		{
			//return a string that says who placed the bet,
			//how much was bet and which dog he bet on 
			if(Amount != 0)
				return(Bettor.Name + " bets " + Amount + " on dog #" + (Dog+1));
			//If the amount is zero, no bet was placed
			//"Joe hasnt placed a bet"
			else
				return (Bettor.Name + " hasnt placed a bet");
		}

		public int PayOut(int Winner)
		{
			//the parameter is the winner of the race
			//if the dog won, return the amount bet
			if(Winner == Dog)
			{
				return Amount * 2;
			}
			//otherwise return the negative of the amount bet
			else return 0;
		}
	}
}
