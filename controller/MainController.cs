
using System;
namespace Controller
{
    class MainController
    {
        Model.Filesystem _fs;
        public MainController(Model.Filesystem fs)
        {
            _fs = fs;
        }

        public bool start(View.UserView v, Model.MemberList m)
        {
            v.displayInstructions();

            View.UserView.Event e;
            e = v.getInputEvent();

            switch (e)
            {
                case View.UserView.Event.ViewCompactList:
                    v.viewMemberListCompact(m.getMemberList());
                    v.pause();
                    break;

                case View.UserView.Event.ViewDetailedList:
                    v.viewMemberListVerbose(m.getMemberList());
                    v.pause();
                    break;

                case View.UserView.Event.AddMember:
                    m.addMember(v.addMember());
                    _fs.saveData(m.getMemberList());
                    break;

                case View.UserView.Event.EditMember:
                    v.viewMemberListCompact(m.getMemberList());

                    int userIdToEdit = v.getUserId();
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
                    v.viewMemberListCompact(m.getMemberList());

                    int userIdToView = v.getUserId();
                    Model.Member memberToView = m.getMemberById(userIdToView);
                    if (memberToView == null)
                    {
                        v.errorInput(View.UserView.Errors.MemberDontExist);
                    }
                    else
                    {
                        v.viewSpecificMember(memberToView);
                        v.pause();
                    }

                    break;

                case View.UserView.Event.RemoveMember:
                    v.viewMemberListCompact(m.getMemberList());

                    int userIdToRemove = v.removeMember();
                    bool removedUser = m.removeMember(userIdToRemove);
                    if (!removedUser)
                    {
                        v.errorInput(View.UserView.Errors.MemberDontExist);
                    }
                    _fs.saveData(m.getMemberList());
                    break;

                case View.UserView.Event.AddBoat:
                    v.viewMemberListCompact(m.getMemberList());

                    int userIdToAddBoat = v.getUserId();
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
                    v.viewMemberListCompact(m.getMemberList());

                    int userIdToRemoveBoat = v.getUserId();
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
                    v.viewMemberListCompact(m.getMemberList());

                    int userId = v.getUserId();
                    var member = m.getMemberById(userId);


                    if (member == null)
                    {
                        v.errorInput(View.UserView.Errors.MemberDontExist);
                    }
                    else
                    {
                        int boatIndex = v.selectBoat(member);
                        var oldBoat = member.GetBoat(boatIndex);
                        if (oldBoat == null)
                        {
                            v.errorInput(View.UserView.Errors.UserHasNoBoats);
                        }
                        else
                        {
                            member.removeBoat(boatIndex);
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