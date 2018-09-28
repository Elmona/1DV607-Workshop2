namespace Controller
{
    class MainController
    {
        public bool Start(View.MainView v, Model.MemberList m)
        {
            v.DisplayInstructions();

            View.MainView.Event e;

            e = v.GetEvent();

            if (e == View.MainView.Event.View)
            {
                v.ViewMembers(m.ToString());
            }

            if (e == View.MainView.Event.AddMember)
            {
                m.AddMember(v.AddMember());
            }

            return true;
        }
    }
}