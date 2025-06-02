namespace AccountBlueprint
{
    class Account
    {
        private static int nextAccountNumber = 1;
        private int accountNumber;
        private string name;
        private string accountType;
        private string password;

        public Account(String name, String password, String accountType)
        {
            this.accountNumber = nextAccountNumber++;
            this.name = name;
            this.accountType = accountType;
            this.password = password;
        }

        public override string ToString()
        {
            return $"Account Number: {accountNumber}\n" +
                   $"Name: {name}\n" +
                   $"Account Type: {accountType}\n";
        }

        public string GetName()
        {
            return name;
        }

        public bool VerifyPassword(string input)
        {
            return password == input;
        }

    }
}
