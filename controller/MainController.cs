
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

                case View.UserView.Event.EditMember:
                  v.ViewMembers(m.toStringCompact());
                  int userIdToEdit          = v.GetUserId("Enter user ID to edit");
                  Model.Member memberToEdit = m.getMemberById(userIdToEdit);
                  if (memberToEdit == null)
                  {
                    v.ErrorInput(1);
                  } else {
                    Model.Member updatedMember = v.EditMember(memberToEdit.MemberId);
                    memberToEdit.updateMember(updatedMember);
                    _fs.SaveData(m.getMemberList());
                  }
                  break;
                case View.UserView.Event.RemoveMember:
                  int response = v.RemoveMember();
                  while(!m.removeMember(response))
                  {
                    v.ErrorInput(1);
                    response = v.RemoveMember();
                  }
                  _fs.SaveData(m.getMemberList());
                  break;

                case View.UserView.Event.AddBoat:
                  int userIdToAddBoat = v.GetUserId("Enter user ID to change from");
                  if (m.getMemberById(userIdToAddBoat) == null) {
                    v.ErrorInput(1);
                  } else {
                    m.getMemberById(userIdToAddBoat).addBoat(v.AddBoat());
                  _fs.SaveData(m.getMemberList());
                  }
                  
                  break;

                case View.UserView.Event.RemoveBoat:
                  int userIdToRemoveBoat = v.GetUserId("Enter user ID to change from");
                  Model.Member memberToRemoveBoat = m.getMemberById(userIdToRemoveBoat);
                  if (memberToRemoveBoat == null) {
                    v.ErrorInput(1);
                  }
                  else if(v.RemoveBoat(memberToRemoveBoat) == false){
                    v.ErrorInput(3);
                  } else {
                  _fs.SaveData(m.getMemberList());
                  }
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