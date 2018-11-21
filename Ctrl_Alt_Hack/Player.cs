using System;
namespace Ctrl_Alt_Hack
{
    public class Player
    {
        private String name;
        private int hackerCred;
        private int money;

        public Player(String name, int hackerCred, int money)
        {
            this.name = name;
            this.hackerCred = hackerCred;
            this.money = money;
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

        public int GetMoney(){
            return money;
        }

        public void SetMoney(int money){
            this.money = money;
        }
    }
}
