
using System;

namespace Controller
{
    class MainController
    {
        Model.Filesystem _fs;
        public MainController()
        {
            _fs = new Model.Filesystem() { };
        }

        public bool Start(View.UserView v, Model.MemberList m)
        {
            v.DisplayInstructions();

            View.UserView.Event e;

            e = v.GetInputEvent();

            switch (e)
            {
                case View.UserView.Event.ViewCompactList:
                    v.ViewMembers(m.toStringCompact());
                    break;

                case View.UserView.Event.ViewDetailedList:
                    v.ViewMembers(m.toStringVerbose());
                    break;

                case View.UserView.Event.AddMember:
                    m.addMember(v.AddMember(m.getNextId()));
                    _fs.SaveData(m.getMemberList());
                    break;

                case View.UserView.Event.RemoveMember:
                    int response = v.RemoveMember();
                    while (!m.removeMember(response))
                    {
                        v.ErrorInput(1);
                        response = v.RemoveMember();
                    }
                    _fs.SaveData(m.getMemberList());
                    break;

                case View.UserView.Event.AddBoat:
                    int userIdToAddBoat = v.GetUserId("Please enter the id of the user for which you want to add or remove a boat.");
                    if (m.getMemberById(userIdToAddBoat) == null)
                    {
                        v.ErrorInput(1);
                    }
                    else
                    {
                        m.getMemberById(userIdToAddBoat).addBoat(v.AddBoat());
                        _fs.SaveData(m.getMemberList());
                    }

                    break;

                case View.UserView.Event.RemoveBoat:
                    int userIdToRemoveBoat = v.GetUserId("Please enter the id of the user for which you want to add or remove a boat.");
                    Model.Member memberToRemoveBoat = m.getMemberById(userIdToRemoveBoat);
                    if (memberToRemoveBoat == null)
                    {
                        v.ErrorInput(1);
                    }
                    else if (v.RemoveBoat(memberToRemoveBoat) == false)
                    {
                        v.ErrorInput(3);
                    }
                    else
                    {
                        _fs.SaveData(m.getMemberList());
                    }
                    break;

                case View.UserView.Event.ChangeBoatData:
                    v.ChangeBoatData();
                    break;

                case View.UserView.Event.Quit:
                    return false;


                case View.UserView.Event.None:
                    v.ErrorInput(2);
                    break;

                default:
                    return true;

            }
            return true;
        }
    }
}