using System;

namespace _1.WarmUp.Easy
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             
               Write code that meets the following requirements:
                   - loops through all integers from 1 to 100 and prints to the console according to the following rules
                       - where the integer is a multiple of 3, the console prints the word 'Sockeye'
                       - where the integer is a multiple of 5, the console prints the word 'Consulting' 
                       - where the integer is a multiple of both 3 and 5, the console prints the words 'Sockeye Consulting'
                       - otherwise the console simply prints the integer value
              
             
                   - example output:
             
                   1
                   2
                   Sockeye
                   4
                   Consulting

               Please do this work yourself - you should be able to do this easily without any 3rd party libraries
             
             */

            // YOUR CODE GOES HERE :)

            for (var i = 1; i <= 100; i++)
            {
                var message = i.ToString();
                if(DivisibleBy(i, 3)) 
                {
                    message = "Sockeye";
                }
                if(DivisibleBy(i, 5))
                {
                    message = "Consulting";
                }
                if(DivisibleBy(i, 3) && DivisibleBy(i, 5)) 
                {
                    message = "Sockeye Consulting";
                }
                Console.WriteLine(message);
            }


            Console.WriteLine("\r\n\r\nCompleted -- Press any key to quit");


            Console.ReadKey();
        }

        public static bool DivisibleBy(int number, int divisor)
        {
            return (number % divisor == 0);
        }
    }
}
