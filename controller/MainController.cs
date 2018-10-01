
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
                case View.UserView.Event.ViewSpecificMember:
                  int userIdToView = v.GetUserId("Enter user ID to view");
                  Model.Member memberToView = m.getMemberById(userIdToView);
                  v.ViewMember(memberToView.toStringVerbose());
                  break;
                    int response = v.RemoveMember();
                    while (!m.removeMember(response))
                    {
                        v.ErrorInput(View.UserView.Errors.MemberDontExist);
                        response = v.RemoveMember();
                    }
                    _fs.SaveData(m.getMemberList());
                    break;

                case View.UserView.Event.AddBoat:
                    int userIdToAddBoat = v.GetUserId("Please enter the id of the user for which you want to add or remove a boat.");
                    if (m.getMemberById(userIdToAddBoat) == null)
                    {
                        v.ErrorInput(View.UserView.Errors.MemberDontExist);
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
                        v.ErrorInput(View.UserView.Errors.MemberDontExist);
                    }
                    else if (v.RemoveBoat(memberToRemoveBoat) == false)
                    {
                        v.ErrorInput(View.UserView.Errors.UserHasNoBoats);
                    }
                    else
                    {
                        _fs.SaveData(m.getMemberList());
                    }
                    break;

                case View.UserView.Event.ChangeBoatData:
                    int userId = v.GetUserId("Please enter the id of the user to change boat information on.");
                    var member = m.getMemberById(userId);
                    var oldBoat = v.SelectBoat(member);

                    if (oldBoat == null)
                    {
                        v.ErrorInput(View.UserView.Errors.UserHasNoBoats);
                    }
                    else
                    {
                        member.removeBoat(oldBoat.Id);
                        m.getMemberById(userId).addBoat(v.AddBoat());

                        _fs.SaveData(m.getMemberList());
                    }

                    break;

                case View.UserView.Event.Quit:
                  return false;
                

                case View.UserView.Event.None:
                    v.ErrorInput(View.UserView.Errors.InvalidAction);
                    break;

                default:
                  return true;
                
            }
            return true;
        }
    }
}