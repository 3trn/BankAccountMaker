namespace AccountMaker
{
    class Banking
    {
        static void Main (String [] args)
        {
            AccountBlueprint.Account BankAccount1 = new AccountBlueprint.Account("Max Middleton", "Sharing", "Pasword");
            AccountBlueprint.Account BankAccount2 = new AccountBlueprint.Account("Violet Whetton", "Investing", "Pasword");
            AccountBlueprint.Account BankAccount3 = new AccountBlueprint.Account("Finley Clements", "Personal", "Pasword");

            Console.WriteLine(BankAccount1.ToString());
            Console.WriteLine(BankAccount2.ToString());
            Console.WriteLine(BankAccount3.ToString());
        }
    }
}
