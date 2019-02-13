using System;
namespace Ctrl_Alt_Hack
{
    public class Entropy
    {
        public string name;
        public int cardType; //Numerical identifier for the type of card e.g. Meta, Bag Of Tricks etc.
        public bool[] timing = new bool[] {false, false}; //If card can be used during mission or anytime
        public bool inPlayersHand, isCurrentlyUsed = false;

        public string GetCardName(){
            return name;
        }

        public int GetCardType()
        {
            return cardType;
        }

        public bool GetTiming(int num)
        {
            return timing[num];
        }

        public void SetInPlayersHand(bool value)
        {
            inPlayersHand = value;
        }

        public bool GetInPlayersHand()
        {
            return inPlayersHand;
        }

        public void SetCurrUsed(bool value)
        {
            isCurrentlyUsed = value;
        }

        public bool GetCurrUsed()
        {
            return isCurrentlyUsed;
        }
    }
}
