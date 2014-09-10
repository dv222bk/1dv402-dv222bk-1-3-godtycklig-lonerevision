using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S1.L03C
{
    class Program
    {
        /// <summary>
        /// Core of the program
        /// </summary>
        /// <param name="args">Command-line arguments</param>
        private static void Main(string[] args)
        {
            Console.Title = Properties.Resources.Console_Title;
            do
            {
                int numberOfSalaries;
                while (true)
                {
                    numberOfSalaries = ReadInt(Properties.Resources.Salary_Prompt);
                    if (numberOfSalaries < 2)
                    {
                        ViewMessage(Properties.Resources.Salary_Number_Error, ConsoleColor.Red);
                    }
                    else
                    {
                        break;
                    }
                }
                int[] salaries = ReadSalaries(numberOfSalaries);
                Console.WriteLine();
                ViewResult(salaries);
            } while (IsContinuing());
        }

        /// <summary>
        /// Asks the user if the program should continue to run.
        /// </summary>
        /// <returns>Retúrns true if the program should continue to run, false if it shouldn't</returns>
        private static bool IsContinuing()
        {
            Console.WriteLine();
            ViewMessage(String.Format(Properties.Resources.Continue_Prompt, char.ConvertFromUtf32(8594))); //http://stackoverflow.com/questions/12519144/c-sharp-button-with-text-and-down-arrow
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Asks the user for an Int value and returns it.
        /// Will continue to ask the user for a correct Int value until given.
        /// </summary>
        /// <param name="prompt">The prompt shown to the user</param>
        /// <returns>Returns the int the user submitted</returns>
        private static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string number = Console.ReadLine();
                try
                {
                    if (int.Parse(number) < 0)
                    {
                        throw new Exception();
                    }
                    return int.Parse(number);
                }
                catch (OverflowException)
                {
                    ViewMessage(String.Format(Properties.Resources.High_Number_Error, number), ConsoleColor.Red);
                }
                catch
                {
                    ViewMessage(String.Format(Properties.Resources.Number_Error, number), ConsoleColor.Red);
                }
            }
        }

        /// <summary>
        /// Asks the user for a defined number of int values.
        /// </summary>
        /// <param name="count">The number of int values the user should submit</param>
        /// <returns>Returns an array of the int values the user submitted</returns>
        private static int[] ReadSalaries(int count)
        {
            int[] salaries;
            while (true)
            {
                try
                {
                    salaries = new int[count];
                    for (int salaryNumber = 0; salaryNumber < salaries.Length; salaryNumber++)
                    {
                        salaries[salaryNumber] = ReadInt(String.Format(Properties.Resources.Salary_Number_Prompt, salaryNumber + 1));
                    }
                    return salaries;
                }
                catch (OutOfMemoryException) //If the array holds too many items, an OutOfMemoryException will be thrown. No one should enter that many salaries anyway though.
                {
                    ViewMessage(String.Format(Properties.Resources.OutOfMemory_Error, count, count / 10), ConsoleColor.Red);
                    count /= 10; //This solution will, if the user REALLY wants to enter that many salaries, probably be pretty annoying. It's a feature though, not a bug.
                }
            }
        }

        /// <summary>
        /// Shows a message to the user with a colored background and text
        /// </summary>
        /// <param name="message">The message that should be shown to the user</param>
        /// <param name="backgroundColor">The background color to be used for the text. Default is blue</param>
        /// <param name="foregroundColor">The color to be used for the text. Default is white</param>
        private static void ViewMessage(string message,
            ConsoleColor backgroundColor = ConsoleColor.Blue,
            ConsoleColor foregroundColor = ConsoleColor.White)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine();
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Makes calculations with the salaries given and shows the result
        /// </summary>
        /// <param name="salaries">The salaries that should be included in the calculation</param>
        private static void ViewResult(int[] salaries)
        {
            Console.WriteLine(Properties.Resources.Result_Line);
            Console.WriteLine(String.Format(Properties.Resources.Median_Salary, MyExtensions.Median(salaries)));
            Console.WriteLine(String.Format(Properties.Resources.Average_Salary, Math.Round(salaries.Average(), MidpointRounding.AwayFromZero)));
            Console.WriteLine(String.Format(Properties.Resources.Wage_Dispertion, MyExtensions.Dispersion(salaries)));
            Console.WriteLine(Properties.Resources.Result_Line);
            for (int i = 0; i < salaries.Length; i++)
            {
                Console.Write("{0, 8}", salaries[i]);
                if ((i + 1) % 3 == 0)
                {
                    Console.Write("\n");
                }
            }
        }
    }
}
