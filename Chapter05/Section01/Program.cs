namespace Section01 {
    internal class Program {
        static void Main(string[] args) {






            public string GivenName { get; private set; }

            public string FamilyName { get; private set; }

        public Person(string familyName,string givenName) {
            FamilyName = familyName;
            GivenName = givenName;
        }

        //メソッド内でプロパティの値を変更できる
        public void ChangeFamilyName(string name) => FamilyName = name;

    }
    }
}
