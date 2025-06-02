namespace AccountBlueprint
{
    class Account
    {
        protected static int nextAccountNumber = 1;
        protected int accountNumber;
        protected string name;
        protected string accountType;
        protected string password;
        protected double balance;

        public Account(String name, String password, String accountType)
        {
            this.accountNumber = nextAccountNumber++;
            this.name = name;
            this.accountType = accountType;
            this.password = password;
            this.balance = 10;
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
        public string GetAccountType()
        {
            return accountType;
        }
        public double GetBalance()
        {
            return balance;
        }
        public bool WithdrawBalance(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount.");
                return false;
            }

            if (amount > balance)
            {
                Console.WriteLine("Insufficient funds.");
                return false;
            }

            balance -= amount;
            return true;
        }
        public void DepositBalance(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
        }

        public bool VerifyPassword(string input)
        {
            return password == input;
        }

    }
}
