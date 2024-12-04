namespace XLN_TechTalk.UpdatedP4CS
{
    using System;

    class MiniApps
    {

        //square root calculator testing table:
        //inputs - {5 to 3dp}, {64 to 2}
        //expected outputs - {2.236}, {8}
        //actual outputs - {on first iteration and before refinement, it outputted 1 since my code wasnt working fully because the bounds weren't being refined properly. however after refinemnt, it first outputted 2.23602294921875 and then after some more it did the correct answer but not to expected decimal points}, {8.00390625 again because of decimal points}

        //main method that contains menu system
        public static void Main2(string[] args)
        {
            bool running = true;

            do
            {
                //menu system that displays messages to the user giving them options to choose what function they want
                Console.WriteLine("\nP4CS Mini Applications");
                Console.WriteLine("----------------------");
                Console.WriteLine("1) Keep Counting");
                Console.WriteLine("2) Square Root Calculator");
                Console.WriteLine("3) Encrypt Text (Caesar Cipher)");
                Console.WriteLine("4) Decrypt Text (Caesar Cipher)");
                Console.WriteLine("9) Quit");
                Console.Write("\nPlease select an option ");

                int choice = int.Parse(Console.ReadLine());
                //switch case that checks user choice input against different cases to match what function is opened
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("You have selected the keep counting application");
                        running = false;
                        counting();
                        break;
                    case 2:
                        Console.WriteLine("You have selected the square root calculator");
                        running = false;
                        squareRoot();
                        break;
                    case 3:
                        Console.WriteLine("You have selected the Caesar cipher encryption");
                        running = false;
                        encrypt();
                        break;
                    case 4:
                        break;
                    case 9:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("You have not selected a valid option, please try again");
                        break;
                }
            } while (running == true);
        }


        //first app, user is asked multiple addition/subtraction questions and is told how many they got correct at the end 
        //doesn't use the answer from the last question as operand for the next question 
        public static void counting()
        {
            {
                //set variables used later
                var userScore = 0;
                var questionCount = 1;
                const int total = 10;


                Console.WriteLine("\nKeep Counting\n-------------\nYou will be presented with 10 arithmetic questions. After the first question , the left-hand operand is the result of the previous addition.");

                //keeps running until the amount of questions reaches 10
                while (questionCount != 11)
                {
                    //allows for creation of random numbers using random method
                    Random rand = new Random();
                    //creates 2 random numbers in between range of 1 and 10 
                    var num1 = rand.Next(1, 11);
                    var num2 = rand.Next(1, 11);
                    //creates a random number that will be used to dictate what operation is used in each question
                    var operation = rand.Next(1, 3);
                    string operatorString;
                    int answer;

                    //switch case that dictates what operation is used depending on the random operation variable set beforehand
                    //also dictates what the answer is depending on the operation
                    switch (operation)
                    {
                        case 1:
                            answer = num1 + num2;
                            operatorString = "+";
                            break;
                        case 2:
                            answer = num1 - num2;
                            operatorString = "-";
                            break;
                        default:
                            answer = 0;
                            operatorString = "?";
                            break;
                    }

                    //Outputs the question to the user and asks user to input an answer for the question
                    Console.WriteLine("\nQuestion " + questionCount + ": " + num1 + operatorString + num2);
                    Console.Write("Enter your answer here: ");


                    //parses the user input from a string into an integer that can be used to check against the answer
                    int check = int.Parse(Console.ReadLine());

                    //if statement that checks if the user input is the same as the answer and if it is an incorrect answer
                    //and also displays an appropriate message to the user
                    if (check != answer)
                    {
                        Console.WriteLine("\nIncorrect: the correct answer is: " + answer);
                    }

                    //if the answer is correct it updates the user score variable to keep track of how many questions the user got right
                    else
                    {
                        userScore++;
                        //num1 = answer;
                    }

                    //updates the amount of questions
                    questionCount++;
                }

                //after the while loop has finished, the user is told how many questions they got correct out of the total amount
                Console.Write("\nYou got " + userScore + " out of " + total + " correct!");

                //optional statement that just displays an extra message depending on how many questions the user got correct
                if (userScore >= 8)
                {
                    Console.WriteLine(" Superb!");
                }
                else if (userScore >= 5)
                {
                    Console.WriteLine(" Good Job!");
                }
                else
                {
                    Console.WriteLine(" Better luck next time!");

                }

                /*
                Console.WriteLine("Do you want to return to the main menu ? Y or N?");

                string userReturn = Console.ReadLine();

                if (userReturn == "Y")
                {
                    return;
                }

                else
                {
                    quit();
                }
                */


            }
        }


        //second app that is used to calculate the square root of a user input
        //altough it does calculate the decimal refinement point, the number doesn't cap off at whatever decimal point needed i.e. doesn't stop at 3dp
        public static void squareRoot()
        {
            //displays message to user asking for a user input of what they want to be square rooted
            Console.WriteLine("\nSquare Root Calculator\n----------------------");
            Console.WriteLine("Please enter a positive number");

            //takes the string input from the user and parses it into a double data type
            double sqrtInput = double.Parse(Console.ReadLine());

            //asks how many decimal points wants to be calculated to, although current version doesn't stop after a certain decimal point
            Console.WriteLine("How many decimal points do you want the solution calculated to ?");

            //takes the string input and parses it to a double data type 
            double decimalInput = double.Parse(Console.ReadLine());

            //sets two variables of double data type, one created to become a negative number that is to be used in the next variable
            //the next variable uses the Math method to raise 10 to the power of the user input
            double decimalConvert = 0 - decimalInput;
            double actualDecimal = Math.Pow(10, decimalConvert);

            //sets two variables of double data types that are used to initialise the lower and upper bounds
            double lowerBound = 0;
            double upperBound = sqrtInput / 2;

            //sets a variable of boolean data type and is set to false 
            bool foundRoot = false;

            //while loop that keeps iterating as long as the root hasn't been found yet 
            while (foundRoot == false)
            {
                //sets two variables of double data type that are used whilst in the while loop to constantly refine the bounds
                double average = (upperBound + lowerBound) / 2;
                double averageSquared = average * average;

                //if statement that checks if the difference between the bounds id less than the decimal point value from earlier that the user inputted
                if ((upperBound - lowerBound) < actualDecimal)
                {
                    //creates a new variable named answer and sets its value to whatever the average was if it passes the if statement
                    double answer = average;
                    //outputs an appropriate message to the user consisting of their input rounded to however many decimal places
                    //and then what the actual root is 
                    Console.WriteLine("The square root of " + sqrtInput + " to " + decimalInput + " decimal places is " + answer);
                    //sets the found root variable to true so that the while loop stops once the root has been found
                    foundRoot = true;
                    break;
                }

                //if statement that is used to update boundaries if the previous if statement does not find the root 
                if (averageSquared > sqrtInput)
                {
                    upperBound = average;
                }

                else
                {
                    lowerBound = average;
                }

            }
        }


        //encryption found online, left too long to fully finish to the spec of assignment guidelines
        public static void encrypt()
        {
            string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", " " };

            //user is prompted to enter a message that they want to be encrypted
            Console.WriteLine("Enter a message:");
            string message = Console.ReadLine();

            message.ToUpper();

            int key = 0;
            //try catch that checks if the user has inputted the key as a valid data type
            try
            {
                //user is prompted to enter a key that they want their message to be shifted by 
                Console.WriteLine("Enter a key:");
                //key is stored as an integer in variable 'key'
                key = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("\nKey must be of type: 'Integer'");
            }

            //character array that is used to store the message
            char[] characters = new char[message.Length];

            //for loop that copies the contents of the message to the characters array
            for (int i = 0; i < characters.Length; i++)
            {
                characters[i] = message[i];
            }

            int temp = 0;

            //for loop that goes through every element in 'characters' and alters it by adding key to it 
            for (int j = 0; j < characters.Length; j++)
            {

                temp = message[j] + key;

                if (temp > 'z')
                {
                    temp -= 26;
                }
                else if (temp < 'a')
                {
                    temp += 26;
                }

                characters[j] = (char)temp;
            }

            Console.WriteLine("Encoded message:");
            Console.Write(characters);

            Console.ReadLine();

        }

        /*
        public static string decrypt(string message, int key)
        {
            Console.WriteLine("Decrypt text\n------------");

            Console.WriteLine("Please enter text to decrypt:");

            return encrypt(message, 26 - key);

        */

    }
}
