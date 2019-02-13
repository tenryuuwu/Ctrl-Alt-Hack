using System;
namespace Ctrl_Alt_Hack
{
    public class Player
    {
        private String name;
        private HackerCard hacker;
        private Entropy[] entropyCards = new Entropy[5];
        private int hackerCred;
        private int money;
        private bool[] currBeingUsed = new bool[] {false, false, false, false};
        //private string[] cardNames = new string[50];
        //private int[] numbers = new int[4]; //Holds the num for Entropy

        public Player(String name, int hackerCred, int money, int hacker)
        {
            this.name = name;
            this.hackerCred = hackerCred;
            this.money = money;
            this.hacker = new HackerCard(hacker);
        }

        public String GetName(){
            return name;
        }

        public void SetName(String name){
            this.name = name;
        }

        public int GetHackerCred(){
            return hackerCred;
        }

        public void SetHackerCred(int cred){
            hackerCred = cred;
        }

        public void AddHackerCred(int num)
        {
            hackerCred += num;
        }

        public int GetMoney(){
            return money;
        }

        public void SetMoney(int money){
            this.money = money;
        }

        public void AddMoney(int money)
        {
            this.money += money;
        }

        public HackerCard GetHacker(){
            return hacker;
        } 

        public void SetEntropyCard(int num, Entropy card)
        {
            entropyCards[num] = card;
        }

        public Entropy GetEntropyCard(int num)
        {
            return entropyCards[num];
        }

        public Entropy[] GetEntropyArr()
        {
            return entropyCards;
        }

        public void SetCurrBeingUsed(int num, bool value)
        {
            currBeingUsed[num] = value;
        }

        public bool[] GetCurrUsedArr()
        {
            return currBeingUsed;
        }
    }
}
