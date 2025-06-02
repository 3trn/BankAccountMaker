using System.Security.Cryptography.X509Certificates;

namespace BankingSimulation
{
    class Bank
    {
        static void Main (String [] args)
        {
            List<AccountBlueprint.Account> accounts = new List<AccountBlueprint.Account>();
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("-- BANKING SIMULATION ---\n" +
                "1) LOGIN\n" +
                "2) SIGN UP\n" +
                "3) EXIT\n" +
                "-------------------------\n");
                int menuNavigationInput = Convert.ToInt32(Console.ReadLine());
                switch (menuNavigationInput)
                {
                    case 1:
                        Console.WriteLine("-- LOGIN ---\n" +
                        "ENTER YOUR FULL NAME\n");
                        string nameInput = Console.ReadLine().ToLower();
                        Console.WriteLine("ENTER YOUR PASSWORD\n");
                        string passwordInput = Console.ReadLine();
                        Console.WriteLine("-----------------------\n");

                        var foundAccount = accounts.FirstOrDefault(a => a.GetName() == nameInput && a.VerifyPassword(passwordInput));

                        if (foundAccount != null)
                        {
                            Console.WriteLine("--- LOGIN SUCCESSFUL ---\n");
                            Console.WriteLine(foundAccount.ToString());
                            Console.WriteLine("---------------\n");
                        }
                        else
                        {
                            Console.WriteLine("--- LOGIN UNSUCCESSFUL ---\n");
                        }
                            break;
                    case 2:
                        Console.WriteLine("-- SIGN UP ---\n" +
                        "ENTER YOUR FULL NAME");
                        string nameCreation = Console.ReadLine().ToLower();
                        Console.WriteLine("\nENTER A PASSWORD");
                        string passwordCreation = Console.ReadLine();
                        Console.WriteLine("\nENTER AN ACCOUNT TYPE");
                        string accountTypeCreation = Console.ReadLine();
                        Console.WriteLine("---------------\n" +
                            "\n--- ACCOUNT DETAILS ---\n");
                        AccountBlueprint.Account account = new AccountBlueprint.Account(nameCreation, passwordCreation, accountTypeCreation);
                        accounts.Add(account);
                        Console.WriteLine(account.ToString());
                        Console.WriteLine("-----------------------\n");
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("INCORRECT OPTION");
                        break;

                }
            }
        }
    }
}
