using System;
using System.IO;

namespace DogKennel
{
    class Program
    {
        static void Main(string[] args)
        {
            //Menu to call methods           
            while (true)
            {
                //Gathers input from user.
                Console.Clear();
                Console.WriteLine(" Press 1 to add a dog: \n Press 2 to retrieve dog: \n Press 3 to Exit:");
                string userInput = Console.ReadLine();

                switch (userInput)//Checks menu selection.
                {
                    case "1"://User selected to add dog.
                        AddDog();
                        break;
                    case "2"://User selected to view dogs.
                        GetDog();
                        break;
                    case "3"://User selected to exit application.
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
        //--------------------Methods-----------------------//
        //Adds dog info gathered from user into text file.
        static void AddDog()
        {
            //Declaring variables.
            bool isValid = false;
            string name = "",
                breed = "",
                color = "";
            int size = 0,
                age = 0;
            //Gathering information.
            while (!isValid)
            {
                Console.Clear();
                Console.WriteLine("Enter dog's name: ");
                name = Console.ReadLine();
                Console.WriteLine("Enter dog's breed: ");
                breed = Console.ReadLine();
                Console.WriteLine("Enter dog's weight in pounds: ");
                isValid = int.TryParse(Console.ReadLine(), out size);
                Console.WriteLine("Enter dog's age: ");
                isValid = int.TryParse(Console.ReadLine(), out age);
                Console.WriteLine("Enter dog's color: ");
                color = Console.ReadLine();

                //Checking to make sure user input was valid.
                if (isValid && name.Length >= 3 && breed.Length >= 3 && color.Length >= 3)
                {
                    //input valid breaking menu loop.
                    isValid = true;
                }
                else
                {
                    //input not valid returning to the start of the menu.
                    isValid = false;
                }
            }
            //Save to text file
            using (StreamWriter writer = new StreamWriter("DogKennel.txt", true))
            {
                //Puts strings into one string.
                string dogList = string.Join(",", name, breed, size, age.ToString(), color, ".");
                writer.WriteLine(dogList);//writing string to text file
                writer.Dispose();//Disposes of object when finished.
                writer.Close();
            }
        }


        //Gets stored dog info from text file.
        static void GetDog()
        {
            Console.Clear();
            //Reading data from text file into string array.
            string[] dogs = File.ReadAllLines("DogKennel.txt");

            Console.WriteLine("");//Putting an extra line at the top for readability.
            //Reading individual dogs properties.
            foreach (string dog in dogs)
            {
                string[] dogProperties = dog.Split(',');
                //Displaying Dogs and their properties using formatting.
                Console.WriteLine(" Name: {0,-10} Breed: {1,-10} Size: {2,-4} Age: {3,-3} Color: {4,-4}", 
                    dogProperties[0], dogProperties[1], dogProperties[2], dogProperties[3], dogProperties[4]);
            }
            Console.WriteLine("\n\t\t\tPress Enter to continue.");
            Console.ReadLine();
        }
    }
}
