
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
			//("Joe bets 8 on dog #4").
			//If the amount is zero, no bet was placed
			//"Joe hasnt placed a bet"
			return ("Joe hasnt placed a bet");
		}

		public int PayOut(int Winner)
		{
			//the paramter is the winner of the race
			//if the dog won, return the amount bet
			//otherwise return the negative of the amount bet
			return 1;
		}
	}
}
