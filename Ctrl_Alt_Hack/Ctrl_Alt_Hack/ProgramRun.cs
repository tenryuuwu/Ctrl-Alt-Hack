using System;

namespace Ctrl_Alt_Hack
{
    class ProgramRun
    {
        static void Main(string[] args)
        {
            string userInput;
            Player player = new Player("Default", 2, 100000, 1);
            int[] flags = new int[] { 0, 0, 0, 0 };
            string[] entropyCardTypes = new string[] { "Bag Of Tricks", "Meta", "Extensive Experience" };
            Entropy[] discarded = new Entropy[50];
            int hacker;
            bool finish = false, failure;
            int choice = 0, i = 0, roll, skillChoice;

            //BagOfTricks trick = new BagOfTricks(0);
            //player.GetEntropyArr()[0] = trick;

            Console.WriteLine("Welcome to Ctrl Alt Hack!");
            while (choice != 5){
                Console.WriteLine("Select a choice");
                Console.WriteLine("1. Create a new player\n2. Check your Hacker Card\n3. Play game\n4. Add Entropy Card\n5. Quit\n6. Show Entropy Card");
                userInput = Console.ReadLine();
                choice = Convert.ToInt32(userInput);
                if(choice == 1){
                    Console.WriteLine("Please enter your name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Hackers:\n - Harry\n - Jane\n - Adam");
                    Console.WriteLine("Please choose your hacker (input the number): ");
                    userInput = Console.ReadLine();
                    hacker = Convert.ToInt32(userInput);
                        //else{
                        //    error = true;
                        //}
                    player = new Player(name, 2, 100, hacker);
                    //error = false;
                    Console.WriteLine("Hacker Created");
                }
                if(choice == 2){
                    //if(player.GetHacker() != null){
                    Console.WriteLine("Hacker name: " + player.GetHacker().GetName());
                    Console.WriteLine("Hacker skill stats:\n" +
                                      "Hardware Hacking: " + player.GetHacker().GetSkill("Hardware Hacking") +
                                      "\nNetwork Ninja: " + player.GetHacker().GetSkill("Network Ninja") +
                                      "\nLockpicking: " + player.GetHacker().GetSkill("Lockpicking") +
                                      "\nKitchen Sink: " + player.GetHacker().GetSkill("Kitchen Sink"));
                    Console.WriteLine("Hacker Cred: " + player.GetHackerCred());
                    Console.WriteLine("Money: " + player.GetMoney());
                    //}
                   // else {
                        //Console.WriteLine("Hacker Card does not exist");
                    //}
                }
                if(choice == 3)
                {
                    while(finish == false)
                    {

                        Console.WriteLine("\n\n");
                        Console.WriteLine("Start a mission?\n1.Yes\n2.No");
                        userInput = Console.ReadLine();
                        int missionChoice = Convert.ToInt32(userInput);
                        if(missionChoice == 1)
                        {
                            Console.WriteLine("Receiving mission.....");
                            Random r = new Random();
                            Mission currMission = new Mission(r.Next(0, 3));
                            string[] missionSteps = new string[currMission.GetMissionStepName().Length];
                            missionSteps = currMission.GetMissionStepName();
                            Console.WriteLine("Your Mission: \"" + currMission.GetMissionName() + "\"");
                            i = 0;
                            Console.WriteLine("Activities:");
                            while(i < missionSteps.Length)
                            {
                                Console.WriteLine(missionSteps[i] + "\n");
                                i++;
                            }
                            i = 0;
                            failure = false;
                            /*Console.WriteLine("\n");
                            Console.WriteLine("Would you like to use an Entropy Card?\n1. Yes\n2. No");
                            userInput = Console.ReadLine();
                            skillChoice = Convert.ToInt32(userInput);
                            if(skillChoice == 1)
                            {
                                Console.WriteLine("Choose your Entropy card:");
                                int k = 0;
                                while(k != player.GetEntropyArr().Length)
                                {
                                    if(player.GetEntropyArr()[k] != null)
                                    {
                                        Console.WriteLine();
                                    }
                                }
                            }*/
                            while (i < missionSteps.Length && failure != true)
                            {
                                Console.WriteLine("Start " + missionSteps[i] + "?");
                                if(player.GetHacker().GetSkill(missionSteps[i]) == 0)
                                {
                                    Console.WriteLine("Your " + missionSteps[i] +
                                                      " is " + player.GetHacker().GetSkill("Kitchen Sink") +
                                                      "\n1. Yes\n2. No");
                                }   
                                else
                                {
                                    Console.WriteLine("Your " + missionSteps[i] +
                                                      " is " + player.GetHacker().GetSkill(missionSteps[i]) +
                                                      "\n1. Yes\n2. No");
                                    
                                }
                                userInput = Console.ReadLine();
                                missionChoice = Convert.ToInt32(userInput);
                                if(missionChoice == 1)
                                {
                                    int success = 0;

                                    roll = r.Next(1, 19);
                                    Console.WriteLine("You have rolled " + roll + ".\n");

                                    if(player.GetHacker().GetSkill(missionSteps[i]) == 0)
                                    {
                                        if(roll > player.GetHacker().GetSkill("Kitchen Sink"))
                                        {
                                            Console.WriteLine("You have failed the mission :(");
                                            failure = true;
                                        }
                                        else
                                        {
                                            success = 1;
                                        }
                                    }
                                    else
                                    {
                                        if (roll > player.GetHacker().GetSkill(missionSteps[i]))
                                        {
                                            Console.WriteLine("You have failed the mission :(");
                                            failure = true;
                                        }
                                        else
                                        {
                                            success = 1;
                                        }
                                    }

                                    if(success == 1)
                                    {
                                        Console.WriteLine("Your roll is a success!\n");
                                        i++;
                                    }
                                }
                                else if(missionChoice == 2)
                                {
                                    Console.WriteLine("Returning to Main Menu....");
                                    failure = true;
                                }
                                else
                                {
                                    Console.WriteLine("Please input either 1 or 2.");
                                }
                            }
                            if(failure != true)
                            {
                                Console.WriteLine("Your mission was a success!");
                                int value;
                                if(currMission.GetDictionaryRewards().TryGetValue("Add Hacker Cred", out value))
                                {
                                    player.AddHackerCred(value);

                                    Console.WriteLine("Added " + value + " Hacker Cred");
                                }
                                if(currMission.GetDictionaryRewards().TryGetValue("Add Money", out value))
                                {
                                    player.AddMoney(value);

                                    Console.WriteLine("Added " + value + " $$$");
                                }
                                
                            }
                            finish = true;
                            Console.WriteLine("With your mission over, you will be returning to the Main Menu....");
                        }
                        else if(missionChoice == 2)
                        {
                            Console.WriteLine("Returning to Main Menu.....");
                            finish = true;
                        }
                        else
                        {
                            Console.WriteLine("Please input either 1 or 2.");
                        }
                    }

                    finish = false;
                }
                if(choice == 4)
                {
                    int count = 0;
                    int fuckThis = 0;
                    for (int l = 0; l < player.GetEntropyArr().Length; l++)
                    {
                        if(player.GetEntropyCard(l) != null)
                        {
                            count++;
                        }
                    }
                    if(count == player.GetEntropyArr().Length - 1)
                    {
                        Console.WriteLine("\n\nYou already have enough Entropy cards.");

                    }
                    else
                    {
                        //Random type = new Random(); //Index for entropyCardTypes array
                        Random num = new Random();
                        string[] cardNames = new string[4];
                        //entropyCardTypes[type.Next(0,3)]
                        if(count == 0)
                        {
                            fuckThis = num.Next(0, 4);
                            BagOfTricks bag = new BagOfTricks(fuckThis);
                            player.GetEntropyArr()[0] = bag;
                            player.SetCurrBeingUsed(fuckThis, true);

                        }
                        else if (entropyCardTypes[0] == "Bag Of Tricks")
                        {
                            int countThis = 0;
                            int[] dontUseThisNumber = new int[10];
                            for (int k = 0; k < player.GetCurrUsedArr().Length && countThis != 1; k++)
                            {
                                if(player.GetCurrUsedArr()[k] == false)
                                {
                                    fuckThis = k;
                                    countThis = 1;
                                }
                            }
                            countThis = 0;
                            for (int k = 0; k < player.GetEntropyArr().Length && countThis != 1; k++)
                            {
                                if(player.GetEntropyArr()[k] == null)
                                {
                                    Console.WriteLine(k);
                                    BagOfTricks bag = new BagOfTricks(fuckThis);
                                    player.GetEntropyArr()[k] = bag;
                                    player.SetCurrBeingUsed(fuckThis, true);
                                    countThis = 1;
                                }
                            }

                        }

                    }

                    Console.WriteLine("\nReturning to Main Menu.....");
                }
                if(choice == 6)
                {
                    int count = 0;
                    for (int l = 0; l < player.GetEntropyArr().Length; l++)
                    {
                        if(player.GetEntropyCard(l) != null)
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        Console.WriteLine("You have no Entropy cards");
                    }
                    else
                    {
                        for (int l = 0; l < player.GetEntropyArr().Length; l++)
                        {
                            if (player.GetEntropyCard(l) != null && player.GetEntropyCard(l).GetCardType() == 1)
                            {
                                BagOfTricks temp = (BagOfTricks)player.GetEntropyCard(l);
                                Console.WriteLine("Type: Bag Of Tricks\n" + "Name: " + temp.GetCardName() +
                                                  "\n-----------------------------------------------------\n");
                                temp.CardDesc();
                                Console.WriteLine("\n-----------------------------------------------------\n");
                            }
                        }
                    }
                    //Console.WriteLine(player.GetEntropyCard(0).GetBagName());
                }
                if(choice < 1 || choice > 6){
                    Console.WriteLine("Please enter the correct value");
                }
                Console.WriteLine("\n\n\n");
            }

        }
    }
}