using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S1.L03C
{
    class Program
    {
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
                catch
                {
                    ViewMessage(String.Format(Properties.Resources.Number_Error, number), ConsoleColor.Red);
                }
            }
        }

        private static int[] ReadSalaries(int count)
        {
            int[] salaries = new int[count];
            for (int salaryNumber = 0; salaryNumber < salaries.Length; salaryNumber++)
            {
                salaries[salaryNumber] = ReadInt(String.Format(Properties.Resources.Salary_Number_Prompt, salaryNumber + 1));
            }
            return salaries;
        }

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
