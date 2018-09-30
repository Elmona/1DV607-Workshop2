
using System;

namespace Controller
{
    class MainController
    {
        Model.Filesystem _fs;
        public MainController()
        {
            _fs = new Model.Filesystem(){};
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
                  while(!m.removeMember(response))
                  {
                    v.ErrorInput("That user does not exist");
                    response = v.RemoveMember();
                  }
                  _fs.SaveData(m.getMemberList());
                  break;

                case View.UserView.Event.AddBoat:
                  int userIdToAddBoat = v.GetUserId();
                  m.getMemberById(userIdToAddBoat).addBoat(v.AddBoat());
                  _fs.SaveData(m.getMemberList());
                  break;

                case View.UserView.Event.RemoveBoat:
                  int userIdToRemoveBoat = v.GetUserId();
                  Model.Member memberToRemoveBoat = m.getMemberById(userIdToRemoveBoat);
                  v.RemoveBoat(memberToRemoveBoat);
                  break;
                case View.UserView.Event.Quit:
                  return false;
                

                case View.UserView.Event.None:
                  v.ErrorInput("Please press a character corresponding to one of the choices above.");  
                  break;

                default:
                  return true;
                
            }
            return true;
        }
    }
}