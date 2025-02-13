namespace PasswordChecker
{
    internal class Program
    { /// <summary>
      /// This is a Password checker program. Developed for a block project for the CS3090 Ethics in computing
      /// This should not be used to accuratly determine if you password is strong or not.
      /// This program
      /// </summary>
      /// <param name="args"></param>
        static void Main(string[] args)
        {
            string ans = "";
            string password = "";
            Console.WriteLine("Welcome this is a simple password checker.");
            bool loop = true;
            //list of contains for whether it contains Uppercase letters, lowercase letters, numbers, punctuation, or symbols
            bool[] c = { false, false, false, false, false };
            int strength = 0;
            while (loop)
            {
                Console.WriteLine("Please enter a password");
                password = Console.ReadLine();
                //use the built in char method to detect if any of the characters match
                c[0] = password.Any(char.IsUpper);
                c[1] = password.Any(char.IsLower);
                c[2] = password.Any(char.IsNumber);
                c[3] = password.Any(char.IsPunctuation);
                c[4] = password.Any(char.IsSymbol);
                for (int i = 0; i < c.Length; i++)
                {
                    if (c[i] == true)
                        strength++;
                }
                //weak - if password is less than 8 digits or more than 8 but all of one case with no numbers or special characters
                //decent - if greater than 8 characters but only letters or numbers
                //strong - if greater than 8 characters a mix of upper lower and special characters

                // weak password - all of one type or length is to short
                if (strength == 1 || password.Length < 8)
                {
                    if (strength == 1 && password.Length < 8)
                    {
                        Console.WriteLine("Password is Weak. The Password is too short and isn't complex enough");
                        Console.WriteLine("To stregthen your password make sure it is at least 8 characters, contains upper and lower case letters, numbers and special characters");
                    }
                    else if (strength == 1)
                    {
                        Console.WriteLine("Password is weak. The Password isn't complex enough");
                        Console.WriteLine("To stregthen your password make sure it contains upper and lower case letters, numbers and special characters");
                    }
                    else
                    {
                        Console.WriteLine("Password is Weak. Password is too short please make sure it is at least 8 characters");
                    }
                }
                //Strong Password - more than 8 characters and 4 types
                //there is a distinction between punctiation and symbols but for the purpose of this software the distinction is unneeded
                //therefore we only have to check if it is greater than 4
                else if (password.Length >= 8 && strength == 4)
                    Console.WriteLine("Is a strong password");
                else
                {
                    Console.WriteLine("Password is Moderate.");
                    Console.WriteLine("To strengthen your password make sure it contains upper and lower case letters, numbers, and special characters.");
                }
                Console.WriteLine("Would you like to check another password? (Yes/No)");
                ans = Console.ReadLine();
                if (ans.ToLower() == "yes" || ans.ToLower() == "y")
                {
                    c[0] = false;
                    c[1] = false;
                    c[2] = false;
                    c[3] = false;
                    c[4] = false;
                    password = "";
                    ans = "";
                    strength = 0;
                }
                else
                    loop = false;
            }
            Console.WriteLine("Thank you for using this password checker.");
        }
    }
}