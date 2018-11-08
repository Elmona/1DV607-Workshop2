using System;
using System.Collections.Generic;

namespace View
{
    class UserView
    {
        public enum Event
        {
            ViewCompactList,
            ViewDetailedList,
            ViewSpecificMember,
            AddMember,
            RemoveMember,
            EditMember,
            AddBoat,
            RemoveBoat,
            ChangeBoatData,
            None,
            Quit
        }

        public enum Errors
        {
            MemberDontExist,
            InvalidAction,
            InvalidBoat,
            UserHasNoBoats
        }

        public void displayInstructions()
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
            Console.WriteLine("5. Edit member");
            Console.WriteLine("6. Add boat");
            Console.WriteLine("7. Remove boat");
            Console.WriteLine("8. Change boat information");
            Console.WriteLine("9. View specific member");
            Console.WriteLine("x. Quit");
            Console.Write("? ");

        }

        public Event getInputEvent()
        {
            char inputtedCharacter = Console.ReadKey().KeyChar;

            if (inputtedCharacter == '1') return Event.ViewCompactList;
            if (inputtedCharacter == '2') return Event.ViewDetailedList;
            if (inputtedCharacter == '3') return Event.AddMember;
            if (inputtedCharacter == '4') return Event.RemoveMember;
            if (inputtedCharacter == '5') return Event.EditMember;
            if (inputtedCharacter == '6') return Event.AddBoat;
            if (inputtedCharacter == '7') return Event.RemoveBoat;
            if (inputtedCharacter == '8') return Event.ChangeBoatData;
            if (inputtedCharacter == '9') return Event.ViewSpecificMember;
            if (inputtedCharacter == 'x') return Event.Quit;

            return Event.None;
        }

        public void viewMemberListCompact(IEnumerable<Model.Member> members)
        {
            Console.WriteLine("\nViewing Compact");

            foreach (var member in members)
            {
                viewMemberCompact(member);
            }
        }

        public void viewMemberListVerbose(IEnumerable<Model.Member> members)
        {
            Console.WriteLine("\nViewing Verbose");

            foreach (var member in members)
            {
                viewMemberVerbose(member);
            }
        }

        public void viewMemberVerbose(Model.Member m)
        {
            Console.WriteLine($"ID: {m.MemberId,-2} Name: {m.Name,-10} Social security number: {m.SocialId} Number of boats: {m.Boats.Count}");
            viewBoats(m.Boats);
        }

        public void viewMemberCompact(Model.Member m)
        {
            Console.WriteLine($"ID: {m.MemberId,-2} Name: {m.Name,-10} Social security number: {m.SocialId} Number of boats: {m.Boats.Count}");
        }

        public void viewBoats(List<Model.Boat> boats)
        {
            for (int i = 0; i < boats.Count; i++)
            {
                Console.WriteLine($"Boat ID: {i} {boats[i].Type,15} {boats[i].Length} cm");
            }
        }

        public Model.Member addMember(int id)
        {
            string name;
            long socialNumber;

            Console.WriteLine("\n");
            Console.WriteLine("\nPlease enter a name.");
            Console.Write("? ");
            name = Console.ReadLine();

            do
            {
                Console.WriteLine("\nPlease enter members social security number.");
                Console.WriteLine("Format: yymmddxxxx.\n");
                Console.Write(": ");
            } while (!long.TryParse(Console.ReadLine(), out socialNumber));

            Console.WriteLine("\n--------------------------------\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Member was successfully added!");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();

            return new Model.Member(name, id, socialNumber);
        }

        public Model.Member editMember(int id)
        {
            long newSocialId = 1;

            Console.WriteLine("\n");
            Console.WriteLine("Enter a name to change it, or leave it blank to not change it.");
            Console.Write(": ");
            string newName = Console.ReadLine();

            if (newName == "")
                newName = "x";

            do
            {
                Console.WriteLine("\n");
                Console.WriteLine("Please enter members social security number.");
                Console.WriteLine("Format: yymmddxxxx.");
                Console.WriteLine("Enter '1' to not change it.");
                Console.Write(": ");
            } while (!long.TryParse(Console.ReadLine(), out newSocialId));

            return new Model.Member(newName, id, newSocialId);
        }

        public int removeMember()
        {
            int memberToBeRemoved;

            Console.WriteLine("\nYou chose to remove a member.");
            Console.WriteLine("--------------------------------");
            do
            {
                Console.WriteLine("Please enter the id of the member you want to delete.");
                Console.Write(": ");
            } while (!int.TryParse(Console.ReadLine(), out memberToBeRemoved));

            return memberToBeRemoved;

        }

        public bool removeBoat(Model.Member member)
        {
            bool successfullyRemoved = false;
            int boatIdToBeDeleted;
            bool memberHasBoats = false;

            Console.WriteLine("\nYou chose to remove a boat.");
            Console.WriteLine("--------------------------------\n");
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

                    viewMemberVerbose(member);

                    Console.ResetColor();
                    Console.WriteLine("\nPlease enter the id of the boat you want to delete.");
                    Console.Write(": ");
                } while (!int.TryParse(Console.ReadLine(), out boatIdToBeDeleted));

                successfullyRemoved = member.removeBoat(boatIdToBeDeleted);

                while (!successfullyRemoved && boatIdToBeDeleted != 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("\n--------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("No boat with that Id exists, please enter the id of the boat you want to delete.");
                    Console.ResetColor();
                    Console.WriteLine("\n--------------------------------");
                    do
                    {
                        Console.WriteLine("Please enter the id of the boat you want to delete.");
                        Console.WriteLine("Enter '0' to return.");
                        Console.Write(": ");
                    } while (!int.TryParse(Console.ReadLine(), out boatIdToBeDeleted));

                    successfullyRemoved = member.removeBoat(boatIdToBeDeleted);
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nBoat was successfully removed from member!");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("\nPress any key to return to main menu.");
            Console.ReadKey();

            return successfullyRemoved;
        }

        public Model.Boat addBoat()
        {
            int boatLength;
            int correctChoice;

            Console.WriteLine("\nYou chose to add a boat.");
            Console.WriteLine("--------------------------------");
            do
            {
                Console.WriteLine("\nPlease enter the length of the boat you want to add (in centimeters)");
                Console.Write(": ");
            } while (!int.TryParse(Console.ReadLine(), out boatLength));
            do
            {
                Console.WriteLine("\nPlease select what type of the boat you want to add.\n");
                Console.WriteLine("1. Sailboat");
                Console.WriteLine("2. MotorSailer");
                Console.WriteLine("3. Kayak/Canoe");
                Console.WriteLine("4. Other");
                Console.Write(": ");
            } while (!int.TryParse(Console.ReadLine(), out correctChoice) && (correctChoice > 0 && correctChoice < 5));

            Model.BoatType returnType = (Model.BoatType)Enum.ToObject(typeof(Model.BoatType), correctChoice);

            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("\nBoat was successfully added to member!");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("\nPress any key to return to main menu.");
            Console.ReadKey();

            return new Model.Boat(returnType, boatLength);
        }

        public int selectBoat(Model.Member member)
        {
            int boatIndex;

            viewMemberVerbose(member);
            do
            {
                Console.WriteLine("Select which boat to change.");
                Console.Write(": ");
            } while (!int.TryParse(Console.ReadLine(), out boatIndex));

            return boatIndex;
        }

        public int getUserId()
        {
            int userId;
            do
            {
                Console.WriteLine("Enter member ID:");
                Console.Write(": ");
            } while (!int.TryParse(Console.ReadLine(), out userId));
            return userId;
        }

        public void viewSpecificMember(Model.Member member)
        {
            Console.WriteLine("\nShowing specific member:");
            Console.ForegroundColor = ConsoleColor.Green;
            viewMemberVerbose(member);
            Console.ResetColor();
        }

        public void pause() => Console.ReadKey();

        public void errorInput(Enum Errors)
        {
            Console.WriteLine("\n--------------------------------\n");
            Console.ForegroundColor = ConsoleColor.Red;

            switch (Errors)
            {
                case View.UserView.Errors.MemberDontExist:
                    Console.WriteLine("A Member with that ID does not exist!");
                    break;

                case View.UserView.Errors.InvalidBoat:
                    Console.WriteLine("There is no boat with that id.");
                    break;

                case View.UserView.Errors.UserHasNoBoats:
                    Console.WriteLine("That user has no boats to be removed!");
                    break;

                case View.UserView.Errors.InvalidAction:
                    Console.WriteLine("Please press one of the characters that corresponds to your desired action");
                    break;

                default:
                    Console.WriteLine("Default case");
                    break;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPress any key to return to continue.");
            Console.ReadKey();
        }
    }
}
