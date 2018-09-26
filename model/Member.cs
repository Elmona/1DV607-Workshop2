namespace Model
{
    class Member
    {
        private string _surename;
        private string _lastname;
        private int _age;

        public Member(string surename, string lastname, int age)
        {
            _surename = surename;
            _lastname = lastname;
            _age = age;
        }
        public string surename
        {
            get { return _surename; }
        }

        public string lastname
        {
            get { return _lastname; }
        }

        public int age
        {
            get { return _age; }
        }

        public override string ToString() =>
            $"Surename: {this.surename}, Lastname: {this.lastname}, Age: {this.age}";
    }
}