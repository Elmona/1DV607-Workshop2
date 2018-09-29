
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

            if (e == View.UserView.Event.ViewCompactList)
            {
                v.ViewMembers(m.toStringCompact());
            }

             if (e == View.UserView.Event.ViewDetailedList)
            {
                v.ViewMembers(m.toStringVerbose());
            }

            if (e == View.UserView.Event.AddMember)
            {
                m.addMember(v.AddMember(m.getNextId()));
                _fs.SaveData(m.getMemberList());
            }

            if (e == View.UserView.Event.RemoveMember)
            {
                int response = v.RemoveMember();
                while(!m.removeMember(response))
                {
                    response = v.RemoveMember();
                }
                _fs.SaveData(m.getMemberList());
            }

            if (e == View.UserView.Event.AddBoat)
            {
                // First, get the member object to add the boat to.
                int userIdToAddBoat = v.GetUserId();
                m.getMemberById(userIdToAddBoat).addBoat(v.AddBoat());
                _fs.SaveData(m.getMemberList());
            }

            if (e == View.UserView.Event.Quit) 
            {
                return false;
            }

            if (e == View.UserView.Event.None) 
            {
                v.ErrorInput();  
            }

            return true;
        }
    }
}