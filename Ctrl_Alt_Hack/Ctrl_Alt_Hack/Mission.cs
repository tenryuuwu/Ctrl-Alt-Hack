using System;
using System.Collections.Generic;

namespace Ctrl_Alt_Hack
{
    public class Mission
    {
        private string missionName;
        private string[] missionSteps = new string[5];
        private Dictionary<string, int> rewards = new Dictionary<string, int>();

        public Mission(int num)
        {
            missionName = GetMissionName(num);
            missionSteps = GetStepNames(num);
            rewards = GetPresetRewards(num);
        }

        public Dictionary<string, int> GetPresetRewards(int num)
        {
            if(num == 0)
            {
                Dictionary<string, int> rewards1 = new Dictionary<string, int>();
                rewards1.Add("Add Hacker Cred", 1);
                rewards1.Add("Add Money", 50);

                return rewards1;
            }
            if(num == 1)
            {
                Dictionary<string, int> rewards2 = new Dictionary<string, int>();
                rewards2.Add("Add Hacker Cred", 3);
                rewards2.Add("Add Money", 100);

                return rewards2;
            }
            if(num == 2)
            {
                Dictionary<string, int> rewards3 = new Dictionary<string, int>();
                rewards3.Add("Add Hacker Cred", 2);

                return rewards3;
            }

            return null;
        }

        public string GetMissionName(int num)
        {
            string[] names = new string[] { "Hack The Pentagon", "Infinite Diamonds in Minecraft", "My Wife is an Android" };

            return names[num];
        }

        public string[] GetStepNames(int num)
        {
            if(num == 0)
            {
                string[] stepNames1 = new string[] { "Network Ninja", "Hardware Hacking" };

                return stepNames1;
            }
            if(num == 1)
            {
                string[] stepNames2 = new string[] { "Social Engineering", "Hardware Hacking", "Network Ninja" };

                return stepNames2;
            }
            if(num == 2)
            {
                string[] stepNames3 = new string[] { "Hardware Hacking", "Network Ninja", "Social Engineering" };

                return stepNames3;
            }

            return null;
        }

        public string GetMissionName()
        {
            return missionName;
        }

        public string[] GetMissionStepName()
        {
            return missionSteps;
        }

        public Dictionary<string, int> GetDictionaryRewards()
        {
            return rewards;
        }
    }
}
