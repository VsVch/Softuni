using System;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isValid = ValidNumbersOfCharacers(password) 
                        && ValidOnlyLettersAndDigits(password) 
                        && ValidateRightNumberOfDigits(password);

            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (!ValidNumbersOfCharacers(password))
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }
                if (!ValidOnlyLettersAndDigits(password))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }
                if (!ValidateRightNumberOfDigits(password))
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }
            }
        }

        private static bool ValidateRightNumberOfDigits(string password)
        {
            int counterDigits = 0;

            foreach (var c in password)
            {
                if (char.IsDigit(c))
                {
                    counterDigits++;
                }
            }
            if (counterDigits > 2)
            {
                return true;
            }
            return false;
        }

        private static bool ValidOnlyLettersAndDigits(string password)
        {
            foreach (char c in password)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool ValidNumbersOfCharacers(string password)
        {
            if (password.Length >= 6 && password.Length <= 10)
            {
                return true;
            }
            return false;
        }
    }
}
