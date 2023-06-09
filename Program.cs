﻿using System;
using System.Collections.Generic;

namespace Heist_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Hacker hannah = new Hacker("Hannah", 100, 100);
            Muscle matt = new Muscle("Matt", 2, 100);
            LockSpecialist davis = new LockSpecialist("Davis", 80, 10);
            Hacker alex = new Hacker("Alex", 20, 100);
            Muscle charlie = new Muscle("Charlie", 40, 5);

            List<IRobber> rolodex = new List<IRobber>()
            {
                hannah, matt, davis, alex, charlie
            };

            while (true)
            {
                Console.WriteLine($"Your team includes {rolodex.Count} members");
                Console.WriteLine("Would you like to add a member? (Y/N)");
                string response = Console.ReadLine().ToLower();
                if (response == "n") { break; }
                Console.WriteLine("What is their name?");
                string theirName = Console.ReadLine().ToLower();
                Console.WriteLine("Select a type: Hacker (disables alarms), Muscle (Chokeslams guards), LockSpecialist (cracks vault)");
                string theirType = Console.ReadLine().ToLower();
                Console.WriteLine("Enter Skill Level (1-100)");
                int theirSkillLevel = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Cut Percentage (1-100)");
                int theirPercentageCut = int.Parse(Console.ReadLine());

                if (theirType == "hacker")
                {
                    Hacker newMember = new Hacker(theirName, theirSkillLevel, theirPercentageCut);
                    rolodex.Add(newMember);
                }
                else if (theirType == "lockspecialist")
                {
                    LockSpecialist newMember = new LockSpecialist(theirName, theirSkillLevel, theirPercentageCut);
                    rolodex.Add(newMember);
                }
                else if (theirType == "muscle")
                {
                    Muscle newMember = new Muscle(theirName, theirSkillLevel, theirPercentageCut);
                    rolodex.Add(newMember);
                }
                else
                {
                    Console.WriteLine("Please retype their Type");
                }
            }
            Bank thisBank = new Bank();
            Random r = new Random();
            thisBank.CashOnHand = r.Next(50000, 1000001);
            thisBank.AlarmScore = r.Next(0, 101);
            thisBank.VaultScore = r.Next(0, 101);
            thisBank.SecurityGuardScore = r.Next(0, 101);

            Console.WriteLine($"Vault: {thisBank.VaultScore}");
            Console.WriteLine($"Alarm: {thisBank.AlarmScore}");
            Console.WriteLine($"SecurityGuard: {thisBank.SecurityGuardScore}");
            if (thisBank.AlarmScore > thisBank.VaultScore && thisBank.AlarmScore > thisBank.SecurityGuardScore)
            {
                Console.WriteLine("Most secure: Alarm");
            }
            else if (thisBank.VaultScore > thisBank.AlarmScore && thisBank.VaultScore > thisBank.SecurityGuardScore)
            {
                Console.WriteLine("Most secure: Vault");
            }
            else if (thisBank.SecurityGuardScore > thisBank.AlarmScore && thisBank.SecurityGuardScore > thisBank.VaultScore)
            {
                Console.WriteLine("Most secure: Security Guard");
            }

            if (thisBank.AlarmScore < thisBank.VaultScore && thisBank.AlarmScore < thisBank.SecurityGuardScore)
            {
                Console.WriteLine("Least secure: Alarm");
            }
            else if (thisBank.VaultScore < thisBank.AlarmScore && thisBank.VaultScore < thisBank.SecurityGuardScore)
            {
                Console.WriteLine("Least secure: Vault");
            }
            else if (thisBank.SecurityGuardScore < thisBank.AlarmScore && thisBank.SecurityGuardScore < thisBank.VaultScore)
            {
                Console.WriteLine("Least secure: Security Guard");
            }

        }


    }

}
