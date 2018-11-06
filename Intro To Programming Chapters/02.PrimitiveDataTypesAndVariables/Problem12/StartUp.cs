using System;

namespace Problem12
{
    public class FirmEmployees
    {
        public static void Main()
        {
            string firstName = "Dimitar";
            string familyName = "Atanasov";
            byte age = 21;
            char sex = 'm';
            uint uniqueEmployeeNumber = 27560000;
            Console.WriteLine($"{firstName}: {firstName.GetType().Name}");
            Console.WriteLine($"{familyName}: {familyName.GetType().Name}");
            Console.WriteLine($"{age}: {age.GetType().Name}");
            Console.WriteLine($"{sex}: {sex.GetType().Name}");
            Console.WriteLine($"{uniqueEmployeeNumber}: {uniqueEmployeeNumber.GetType().Name}");
        }
    }

}
