namespace Controller
{
    class MainController
    {
        public bool Start(View.MainView v, Model.MemberList m)
        {
            v.DisplayInstructions();

            View.MainView.Event e;

            e = v.GetEvent();

            if (e == View.MainView.Event.Add)
            {
                return false;
            }

            if (e == View.MainView.Event.View)
            {
                return false;
            }

            return true;
        }
    }
}