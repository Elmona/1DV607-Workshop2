
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

        public bool start(View.UserView v, Model.MemberList m)
        {
            v.displayInstructions();

            View.UserView.Event e;

            e = v.getInputEvent();

            switch (e)
            {
                case View.UserView.Event.ViewCompactList:
                    v.viewMembers(m.toStringCompact());
                    v.pause();
                    break;

                case View.UserView.Event.ViewDetailedList:
                    v.viewMembers(m.toStringVerbose());
                    v.pause();
                    break;

                case View.UserView.Event.AddMember:
                    m.addMember(v.addMember(m.getNextId()));
                    _fs.saveData(m.getMemberList());
                    break;

                case View.UserView.Event.EditMember:
                    v.viewMembers(m.toStringCompact());
                    int userIdToEdit = v.getUserId("Enter user ID to edit");
                    Model.Member memberToEdit = m.getMemberById(userIdToEdit);
                    if (memberToEdit == null)
                    {
                        v.errorInput(View.UserView.Errors.MemberDontExist);
                    }
                    else
                    {
                        Model.Member updatedMember = v.editMember(memberToEdit.MemberId);
                        memberToEdit.updateMember(updatedMember);
                        _fs.saveData(m.getMemberList());
                    }
                    break;

                case View.UserView.Event.ViewSpecificMember:
                    v.viewMembers(m.toStringCompact());
                    int userIdToView = v.getUserId("Enter member ID to view that specific member");
                    Model.Member memberToView = m.getMemberById(userIdToView);
                    if (memberToView == null) {
                        v.errorInput(View.UserView.Errors.MemberDontExist);
                    } else {
                      v.viewSpecificMember(memberToView.toStringVerbose());
                      v.pause();
                    }
                    
                    break;

                case View.UserView.Event.RemoveMember:
                    v.viewMembers(m.toStringCompact());
                    int userIdToRemove = v.removeMember();
                    bool removedUser = m.removeMember(userIdToRemove);
                    if (!removedUser) 
                    {
                        v.errorInput(View.UserView.Errors.MemberDontExist);
                    }
                    _fs.saveData(m.getMemberList());
                    break;

                case View.UserView.Event.AddBoat:
                    v.viewMembers(m.toStringCompact());
                    int userIdToAddBoat = v.getUserId("Please enter the id of the user for which you want to add a boat.");
                    if (m.getMemberById(userIdToAddBoat) == null)
                    {
                        v.errorInput(View.UserView.Errors.MemberDontExist);
                    }
                    else
                    {
                        m.getMemberById(userIdToAddBoat).addBoat(v.addBoat());
                        _fs.saveData(m.getMemberList());
                    }

                    break;

                case View.UserView.Event.RemoveBoat:
                    v.viewMembers(m.toStringCompact());
                    int userIdToRemoveBoat = v.getUserId("Please enter the id of the user for which you want to remove a boat.");
                    Model.Member memberToRemoveBoat = m.getMemberById(userIdToRemoveBoat);
                    if (memberToRemoveBoat == null)
                    {
                        v.errorInput(View.UserView.Errors.MemberDontExist);
                    }
                    else if (v.removeBoat(memberToRemoveBoat) == false)
                    {
                        v.errorInput(View.UserView.Errors.UserHasNoBoats);
                    }
                    else
                    {
                        _fs.saveData(m.getMemberList());
                    }
                    break;

                case View.UserView.Event.ChangeBoatData:
                    v.viewMembers(m.toStringCompact());
                    int userId = v.getUserId("Please enter the id of the user to change boat information on.");
                    var member = m.getMemberById(userId);


                    if (member == null)
                    {
                        v.errorInput(View.UserView.Errors.MemberDontExist);
                    }
                    else
                    {
                        var oldBoat = v.selectBoat(member);
                        if (oldBoat == null)
                        {
                            v.errorInput(View.UserView.Errors.UserHasNoBoats);
                        }
                        else
                        {
                            member.removeBoat(oldBoat.Id);
                            m.getMemberById(userId).addBoat(v.addBoat());
                            _fs.saveData(m.getMemberList());
                        }

                    }

                    break;

                case View.UserView.Event.Quit:
                    return false;


                case View.UserView.Event.None:
                    v.errorInput(View.UserView.Errors.InvalidAction);
                    break;

                default:
                    return true;

            }
            return true;
        }
    }
}