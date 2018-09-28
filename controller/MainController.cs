namespace Controller
{
    class MainController
    {
        public bool Start(View.UserView v, Model.MemberList m)
        {
            v.DisplayInstructions();

            View.UserView.Event e;

            e = v.GetInputEvent();

            if (e == View.UserView.Event.View)
            {
                v.ViewMembers(m.ToString());
            }

            if (e == View.UserView.Event.AddMember)
            {
                m.AddMember(v.AddMember());
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