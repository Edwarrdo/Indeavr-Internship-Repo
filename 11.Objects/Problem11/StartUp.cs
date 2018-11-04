using System;

namespace Problem11
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] phrase = { "Great product", "Perfect product", "I use this product all the     time", "The best product ever" };
            string[] thingsHappened = { "I feel good now", "I've changed myself", "He've done a miracle", "You should try too" };
            string[] firstName = { "Alex", "Dimiter", "Ivan", "Georgi", "Petko" };
            string[] lastName = { "Djenkov", "Petrov", "Nenov" };
            string[] city = { "Sofia", "Plovdiv", "Elhovo" };
            var rndGenerator = new Random();
            int rndPhrase = rndGenerator.Next(0, phrase.Length);
            int rndHappened = rndGenerator.Next(0, thingsHappened.Length);
            int rndFirstName = rndGenerator.Next(0, firstName.Length);
            int rndlastName = rndGenerator.Next(0, lastName.Length);
            int rndCity = rndGenerator.Next(0, city.Length);

            Console.WriteLine($"{phrase[rndPhrase]}.{thingsHappened[rndHappened]}--{firstName[rndFirstName]} {lastName[rndlastName]},{city[rndCity]}");
        }
    }
}
