using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Badge;

namespace _03_BadgeUI
{
    public class ProgramUI
    {
        protected readonly BadgeRepository _badgeRepo = new BadgeRepository();
        public void Run()
        {
            //SeedContentList();
            DisplayMenu();
        }
        private void DisplayMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "Hello Security Admin, What woudl you like to do? (1-3)\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit\n");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        EditABadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number betweeb 1 and 4");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void AddABadge()
        {
            Console.Clear();
            Console.WriteLine("What is the number on the badge: ");
            int badgeid = int.Parse(Console.ReadLine());
            Console.WriteLine("List a door that it needs access to: ");
            List<string>doorAccess = new List<string>doorAccess.ToArray();
                doorAccess.Join(Console.ReadLine());
            Console.WriteLine("Any other doors? (y/n) ");
            char userInput = char.Parse(Console.ReadLine());
            if (userInput == 'y')
            {
                Console.WriteLine("List a door that it needs access to: ");
                List<string> doorAccess = new List<string>doorAccess.ToArray();
                doorAccess.Join(Console.ReadLine());
            }
            else
            {
                DisplayMenu();
            }
        }
        private void EditABadge()
        {
            Console.Clear();
            Console.WriteLine("What is the number on the badge you would like to update? ");
            int badgeid = int.Parse(Console.ReadLine());
            Console.WriteLine();
            List<string> doorAccess = Console.ReadLine();
            Console.WriteLine("What would you like to do? (1-2)\n" +
            "1. Remove a door\n" +
            "2. Add a door");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    RemoveDoor();
                    break;
                case "2":
                    AddDoor();
                    break;
                default:
                    Console.WriteLine("Please enter a valid number between 1 and 2");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }

        }
        private void ListAllBadges()
        {
            var table = new ConsoleTable("BadgeID", "DoorAccess");
            table.AddRow(content.BadgeID, content.DoorAccess);
            table.Write();
        }
        private void RemoveDoor()
        {

        }
        private void AddDoor()
        {

        }
        private void SeedContentList()
        {
            Dictionary<int, List<string>> _doorAccessList = new Dictionary<int, List<string>>();
            _doorAccessList.Add(12345, "A7");
            _doorAccessList.Add(22345, "A1,A4,B1,B2");
            _doorAccessList.Add(32345, "A4,A5");
            foreach (int key in _doorAccessList.Keys)
            {
                Console.WriteLine(key);
            }
        }
        //{
        //    public Key
        //    List<string> keyList = new List<string>(this._doorAccessList.Keys);
        //    data.Add("abc", 123);
        //    data.Add("def", 456);
        //    foreach (string key in data.Keys)
        //    {
        //        Console.WriteLine(key);
        //    }
        //}
        private void DisplayBadges(Badges content)
        {
            var table = new ConsoleTable("BadgeID", "DoorAccess");
            table.AddRow(content.BadgeID, content.DoorAccess);
            table.Write();
        }
    }
}
