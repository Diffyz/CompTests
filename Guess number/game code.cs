using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace игра
{
    class Program
    {
        class GuessNumber
        {
            private static int count_steps = 1;
            private static Random rnd = new Random();
            private static TimeSpan ts;
            private static Stopwatch stopWatch;
            public static void ToGame()
            {
                stopWatch = new Stopwatch();
                stopWatch.Start();
                ts = stopWatch.Elapsed;
                Console.WriteLine("                           __Game Guess the Number__");
                int num = rnd.Next(0, 11);
                Console.WriteLine("Guess the number from 0 to 10");
                int answer = -1;
                string y_or_n = " ";
                GuessNumber.toGame(answer, num, y_or_n);
            }

            private static int ConvertTostring(int answer_new) // Использую рекурсию для проверки корректности ввода
            {
                try
                {
                    answer_new = Convert.ToInt32(Console.ReadLine());
                    if (answer_new > 10 || answer_new < 0)
                    {
                        Console.WriteLine("Error 1 Your digit is more or less the limit ");
                        ConvertTostring(answer_new);
                    }
                   else
                    {
                       Convert.ToInt32(answer_new);
                    }
                    return answer_new;
                }
                catch (Exception ex )
                {                  
                    Console.WriteLine("Error 2 " + ex.Message);
                    ConvertTostring(answer_new);
                }
                return answer_new;
            }

            private static void toGame(int answer = 0, int num = 0, string y_or_n = " ")
            {
                while (answer != num)//Цикл работает пока ответ не равен загаданному числу
                {
                    Console.WriteLine("Enter the digit from 0 to 10");
                    answer= ConvertTostring(answer);                   
                    if (answer > num)
                    {
                        ++count_steps;//счетчик для подсчета шагов
                        Console.WriteLine("Your number is more than thought");
                    }
                    else if (answer < num)
                    {
                        ++count_steps;
                        Console.WriteLine("Your number is less than thought");
                    }
                    else if (answer == num)
                    {
                        Console.WriteLine("You Win");
                        Console.WriteLine("You finished the game in " + count_steps + " step(s) and your general spent time is  " + ts);
                        Console.WriteLine("Do you want to continue? ? yes/no");
                        while (y_or_n != "yes" || y_or_n != "no")//Выбирает продолжить игру или нет
                        {
                            y_or_n = Console.ReadLine();
                            if (y_or_n == "yes")
                            {//Обнуляю все параметры и вызываемая фун-ция вызывает саму себя
                                Console.Clear();
                                count_steps = 1;
                                answer = -1;
                                num = rnd.Next(0, 11);
                                y_or_n = " ";
                                toGame(answer, num, y_or_n);
                            }
                            else if (y_or_n == "no")
                            {
                                Console.WriteLine("Goodbay");
                                break;
                            }
                            else                           
                                Console.WriteLine("Wrong input");                           
                        }
                    }
                }
            }

            static void Main(string[] args)
            {
                GuessNumber.ToGame();

            }
        }
    }
}


