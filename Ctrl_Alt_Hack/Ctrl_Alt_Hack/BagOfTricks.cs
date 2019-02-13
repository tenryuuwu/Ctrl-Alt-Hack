using System;
using System.Collections.Generic;
namespace Ctrl_Alt_Hack
{
    public class BagOfTricks : Entropy
    {
        private string skillName = null;
        private Dictionary<string, int> skillStats = new Dictionary<string, int>();
        private int botType;
        private int cost = 0;
        private bool perm; //If this card can be kept in play or be discarded after use
        private bool specialPerm; //In certain conditions, card has to be discarded after use
        private bool instantSucess;
        private int thisIsOnlyForLockpick;
       //private static bool[] currBeingUsed = new bool[4];

        public BagOfTricks(int num)
        {
            name = GetName(num);
            cardType = 1;

            if(GetName(num) == "Lockpicking Startup")
            {
                cost = 20000;
                botType = 4;
                perm = false;
                specialPerm = true;
                timing[1] = true;
                instantSucess = false;
                inPlayersHand = true;
                //currBeingUsed[0] = true;
            }
            else if(GetName(num) == "Dumpster Diving")
            {
                cost = 4000;
                botType = 3;
                perm = false;
                specialPerm = false;
                timing[0] = true;
                instantSucess = true;
                inPlayersHand = true;
                //currBeingUsed[1] = true;

                skillName = "Hardware Hacking";
            }
            else if(GetName(num) == "Dial-a-Consultant")
            {
                cost = 7000;
                botType = 1;
                perm = true;
                specialPerm = false;
                timing[1] = true;
                instantSucess = false;
                inPlayersHand = true;
                //currBeingUsed[2] = true;

                skillStats.Add("Software Wizardry", 2);
                skillStats.Add("Hardware Hacking", 1);
            }
            else if(GetName(num) == "Awesome Antenna")
            {
                cost = 1000;
                botType = 2;
                perm = false;
                specialPerm = true;
                timing[0] = true;
                instantSucess = false;
                inPlayersHand = true;
                //currBeingUsed[3] = true;

                skillName = "Network Ninja";
            }
        }

        public string GetName(int num)
        {
             string[] bagOfTricks = new string[] { "Lockpicking Startup", "Dumpster Diving", "Dial-a-Consultant", "Awesome Antenna" };

             return bagOfTricks[num];
        }

        public void ActivateSpecial(Player player, Mission mission, int num)
        {
            if(num == 1)
            {
                StatChange(player, GetSkillStatNames()[0], GetSkillStatNames()[1], skillStats[GetSkillStatNames()[0]], skillStats[GetSkillStatNames()[1]]);
            }
            else if(num == 2)
            {
                Reroll();
            }
            else if(num == 3)
            {
                InstantSucc();
            }
            else if(num == 4)
            {
                thisIsOnlyForLockpick = player.GetHacker().GetSkill("Lockpicking");
                player.GetHacker().SetSkill("Lockpicking", 16);
            }
        }

        public void StatChange(Player player, string skill1, string skill2, int num1, int num2)
        {
            if(skill1 == null)
            {
                player.GetHacker().AddToSkill(skill2, num2);
            }
            else if(skill2 == null)
            {
                player.GetHacker().AddToSkill(skill1, num1);
            }
            else
            {
                player.GetHacker().AddToSkill(skill1, num1);
                player.GetHacker().AddToSkill(skill2, num2);
            }
        }

        public void CardDesc()
        {
            if(name == "Lockpicking Startup")
            {
                Console.WriteLine("Your Lockpicking skill becomes 16.But\n" +
                                  "if you fail a Lockpicking roll anyway, you\n" +
                                  "must discard this card.\n\nKeep this card in play.");
            }
            else if(name == "Dumpster Diving")
            {
                Console.WriteLine("Play this card during a Mission\n" +
                                  "All your Hardware Hacking rolls for the Mission\n" +
                                  "are automatic successes\n\nDiscard this card after use");
            }
            else if(name == "Dial-a-Consultant")
            {
                Console.WriteLine("+2 Software Wizardry\n\n+1 Hardware Hacking\n\nKeep this card in play.");
            }
            else if(name == "Awesome Antenna")
            {
                Console.WriteLine("Once per turn, you may re-roll a failed\n" +
                                  "Network Ninja roll. If you fail this second\n" +
                                  "roll, you must discard this card.\n\nKeep this card in play.");
            }
        }

        public string Reroll()
        {
            return skillName;
        }

        public bool InstantSucc()
        {
            return instantSucess;
        }

        public bool IsPerm()
        {
            return perm;
        }

        public bool IsSpecialPerm()
        {
            return specialPerm;
        }

        public bool IsInstantSucc()
        {
            return instantSucess;
        }

        public string GetSkillName()
        {
            return skillName;
        }

        public int GetCost()
        {
            return cost;
        }

        public string[] GetSkillStatNames()
        {
            string[] keyArray = new string[2];
            List<string> keys = new List<string>(skillStats.Keys);
            int i = 0;

            foreach(string key in keys)
            {
                keyArray[i] = key;
                i++;
            }

            return keyArray;
        }

        public string GetBagName()
        {
            return name;
        }

        public int GetBotType()
        {
            return botType;
        }
    }
}
