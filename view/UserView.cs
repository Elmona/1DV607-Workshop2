using System;

namespace View
{
    class UserView
    {
        public enum Event
        {
            ViewCompactList,
            ViewDetailedList,
            AddMember,
            RemoveMember,
            AddBoat,
            RemoveBoat,
            None,
            Quit
        }

        public void DisplayInstructions()
        {
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("######################################");
            Console.WriteLine("#      Welcome to the Boat club.     #");
            Console.WriteLine("######################################");
            Console.WriteLine("");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. View Compact list of members");
            Console.WriteLine("2. View Detailed list of members");
            Console.WriteLine("3. Add member");
            Console.WriteLine("4. Remove member");
            Console.WriteLine("5. Add boat");
            Console.WriteLine("6. Remove boat");
            Console.WriteLine("x. Quit");
            Console.Write("? ");

        }

        public Event GetInputEvent()
        {
            char inputtedCharacter = Console.ReadKey().KeyChar;

            if (inputtedCharacter == '1') return Event.ViewCompactList;
            if (inputtedCharacter == '2') return Event.ViewDetailedList;
            if (inputtedCharacter == '3') return Event.AddMember;
            if (inputtedCharacter == '4') return Event.RemoveMember;
            if (inputtedCharacter == '5') return Event.AddBoat;
            if (inputtedCharacter == '6') return Event.RemoveBoat;
            if (inputtedCharacter == 'x') return Event.Quit;

            return Event.None;
        }

        public Model.Member AddMember(int id)
        {
            string name;
            long socialNumber;


            Console.WriteLine("\n");
            Console.WriteLine("You chose to add a member.");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Please enter a name.");
            Console.Write("? ");

            name = Console.ReadLine();

            do
            {
                Console.WriteLine("");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("");
                Console.WriteLine("Please enter members social security number.");
                Console.WriteLine("Format: yymmddxxxx.");
                Console.WriteLine("");
                Console.Write(": ");
            } while (!long.TryParse(Console.ReadLine(), out socialNumber));

            Console.WriteLine("");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Member was successfully added!");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();

            return new Model.Member(name, id, socialNumber);
        }

        public int RemoveMember()
        {
            int memberToBeRemoved;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n");
            Console.WriteLine("You chose to remove a member.");
            Console.WriteLine("--------------------------------");
            do
            {
                Console.WriteLine("Please enter the id of the member you want to delete.");
                Console.Write(": ");
            } while (!int.TryParse(Console.ReadLine(), out memberToBeRemoved));

            return memberToBeRemoved;
        }

        public bool RemoveBoat(Model.Member member)
        {
            bool successfullyRemoved = false;
            int boatIdToBeDeleted;
            bool memberHasBoats = false;

            Console.WriteLine("\n");
            Console.WriteLine("You chose to remove a boat.");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("");
            if (!member.hasBoats())
            {
                return memberHasBoats;
            }
            else if (member.hasBoats())
            {
                do
                {
                    Console.WriteLine("You're currently editing this member:");
                    Console.WriteLine("--------------------------------");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("");
                    Console.WriteLine(member.toStringVerbose());
                    Console.ResetColor();
                    Console.WriteLine("Please enter the id of the boat you want to delete.");
                    Console.WriteLine("Enter '0' to return.");
                    Console.Write(": ");
                } while (!int.TryParse(Console.ReadLine(), out boatIdToBeDeleted));

                successfullyRemoved = member.removeBoat(boatIdToBeDeleted);

                while (!successfullyRemoved && boatIdToBeDeleted != 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("--------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("No boat with that Id exists, please enter the id of the boat you want to delete.");
                    Console.WriteLine("");
                    Console.ResetColor();
                    Console.WriteLine("--------------------------------");
                    do
                    {
                        Console.WriteLine("Please enter the id of the boat you want to delete.");
                        Console.WriteLine("Enter '0' to return.");
                        Console.Write(": ");
                    } while (!int.TryParse(Console.ReadLine(), out boatIdToBeDeleted));

                    successfullyRemoved = member.removeBoat(boatIdToBeDeleted);

                }
            }

            // If Removal was successful
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("Boat was successfully removed from member!");
            Console.WriteLine("--------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();

            return successfullyRemoved;
        }

        public Model.Boat AddBoat()
        {
            int boatId;
            int boatLength;
            // int answer;
            int correctChoice;

            Console.WriteLine("\n");
            Console.WriteLine("You chose to add a boat.");
            Console.WriteLine("--------------------------------");
            do
            {
                Console.WriteLine("");
                Console.WriteLine("Please enter the id of the boat you want to add.");
                Console.Write(": ");
            } while (!int.TryParse(Console.ReadLine(), out boatId));
            do
            {
                Console.WriteLine("");
                Console.WriteLine("Please enter the length of the boat you want to add.");
                Console.Write(": ");
            } while (!int.TryParse(Console.ReadLine(), out boatLength));
            do
            {
                Console.WriteLine("");
                Console.WriteLine("Please select what type of the boat you want to add.");
                Console.WriteLine("");
                Console.WriteLine("1. Sailboat");
                Console.WriteLine("2. MotorSailer");
                Console.WriteLine("3. Kayak/Canoe");
                Console.WriteLine("4. Other");
                Console.Write(": ");
            } while (!int.TryParse(Console.ReadLine(), out correctChoice) && (correctChoice > 0 && correctChoice < 5));

            Model.BoatType returnType = (Model.BoatType)Enum.ToObject(typeof(Model.BoatType), correctChoice);
            Console.WriteLine("Blaha" + returnType);

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("Boat was successfully added to member!");
            Console.WriteLine("--------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();

            return new Model.Boat(boatId, returnType, boatLength);
        }

        public int GetUserId()
        {
            int userId;
            do
            {
                Console.WriteLine("\n");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("");
                Console.WriteLine("Please enter the id of the user for which you want to add or remove a boat.");
                Console.Write(": ");
            } while (!int.TryParse(Console.ReadLine(), out userId));
            return userId;
        }

        public void ViewMembers(string members)
        {

            Console.WriteLine("\n");
            Console.WriteLine("You chose to view all current members.");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Showing all members:");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(members);
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();

        }

        public void ErrorInput(int Error)
        {
            int caseSwitch = Error;
            switch (caseSwitch)
            {

                case 1:
                    Console.WriteLine("");
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A Member with that ID does not exist!");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Press any key to return to main menu.");
                    Console.ReadKey();
                    break;

                case 2:
                    Console.WriteLine("");
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please press one of the characters that corresponds to your desired action");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Press any key to return to main menu.");
                    Console.ReadKey();
                    break;

                case 3:
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("That user has no boats to be removed!");
                    Console.WriteLine("--------------------------------");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to return to main menu.");
                    Console.ReadKey();
                    break;


                default:
                    Console.WriteLine("Default case");
                    break;
            }


        }
    }
}
