using System;
using System.Collections.Generic;

namespace Ctrl_Alt_Hack
{
    public class HackerCard
    {
        private string name;
        private Dictionary<string, int> skills = new Dictionary<string, int>();
        //implement the special abilities later
        //hardware hacking, network ninja, lockpicking, kitchen sink 

        public HackerCard(int num)
        {
            this.name = GetPresetName(num);
            int[] skillVal = GetSkillSet(num);
            skills.Add("Hardware Hacking", skillVal[0]);
            skills.Add("Network Ninja", skillVal[1]);
            skills.Add("Lockpicking", skillVal[2]);
            skills.Add("Kitchen Sink", skillVal[3]);
        }

        public string GetPresetName(int num)
        {
            string[] hackerNames = new string[] { "Harry", "Jane", "Adam" };

            return hackerNames[num];
        }

        public int[] GetSkillSet(int num){
            if(num == 0){
                int[] skillSet1 = new int[] { 11, 12, 10, 9 };
                return skillSet1;
            }
            if (num == 1)
            {
                int[] skillSet2 = new int[] { 7, 15, 0, 16 };
                return skillSet2;
            }
            if (num == 2)
            {
                int[] skillSet3 = new int[] { 0, 13, 8, 14 };
                return skillSet3;
            }

            return null;
        }

        public string GetName(){
            return name;
        }

        public int GetSkill(string skillName){
            return skills[skillName];
        }

        public void SetSkill(string skill, int num)
        {
            skills[skill] = num;
        }

        public void AddToSkill(string skill, int num)
        {
            skills[skill] += num;
        }
    }
}
