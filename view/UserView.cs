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
            None,
            Quit
        }

        public void DisplayInstructions()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
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
            Console.WriteLine("Please fill in name.");
            Console.Write("? ");

            name = Console.ReadLine();

            do
            {
                Console.WriteLine("");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Please fill in social security number.");
                Console.WriteLine("Format: yymmddxxxx.");
                Console.Write(": ");
            } while (!long.TryParse(Console.ReadLine(), out socialNumber));

            return new Model.Member(name, id, socialNumber);
        }

        public int RemoveMember()
        {
            int memberToBeRemoved;
            Console.WriteLine("\n");
            Console.WriteLine("You chose to remove a member.");
            Console.WriteLine("--------------------------------");
            do
            {
                Console.WriteLine("Please fill in the id of the member you want to delete.");
                Console.Write(": ");
            } while (!int.TryParse(Console.ReadLine(), out memberToBeRemoved));

            return memberToBeRemoved;
        }

        public Model.Boat AddBoat()
        {
            int boatId;
            int boatLength;
            string answer;
            int correctChoice;
            Console.WriteLine("\n");
            Console.WriteLine("You chose to add a boat.");
            Console.WriteLine("--------------------------------");
            do
            {
                Console.WriteLine("Please fill in the id of the boat you want to add.");
                Console.Write(": ");
            } while (!int.TryParse(Console.ReadLine(), out boatId));
            do
            {
                Console.WriteLine("Please fill in the length of the boat you want to add.");
                Console.Write(": ");
            } while (!int.TryParse(Console.ReadLine(), out boatLength));
            do
            {
                Console.WriteLine("Please select what type of the boat you want to add.");
                Console.WriteLine("1. Sailboat");
                Console.WriteLine("2. MotorSailer");
                Console.WriteLine("3. Kayak/Canoe");
                Console.WriteLine("4. Other");
                Console.Write(": ");
                answer = Console.ReadLine();;
            } while (!int.TryParse(answer, out correctChoice) && (correctChoice > 0 && correctChoice < 5));

            Model.BoatType returnType = (Model.BoatType) Enum.Parse(typeof(Model.BoatType), answer);

            return new Model.Boat(boatId, returnType, boatLength);
        }

        public int GetUserId()
        {
            int userId;
            do
            {
                Console.WriteLine("Please fill in the id of the user you want to add the boat to.");
                Console.Write(": ");
            } while (!int.TryParse(Console.ReadLine(), out userId));
            return userId;
        }

        public void ViewMembers(string members)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("You chose to view all current members");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Showing all members");
            Console.WriteLine("--------------------------------");
            Console.WriteLine(members);
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

        }

        public void ErrorInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("Error in input");
            Console.WriteLine("Please press a character corresponding to one of the choices above.");
            
        }
    }
}
