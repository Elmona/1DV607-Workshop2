namespace Model
{
    class Member
    {
        private string _firstName;
        private string _lastName;
        private int _age;

        public Member(string firstName, string lastName, int age)
        {
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
        }
        public string firstName
        {
            get { return _firstName; }
        }

        public string lastName
        {
            get { return _lastName; }
        }

        public int age
        {
            get { return _age; }
        }

        public override string ToString() =>
            $"First name: {this.firstName}, Last name: {this.lastName}, Age: {this.age}";
    }
}