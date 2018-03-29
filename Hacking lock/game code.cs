using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
namespace Взлом_замка
{
    class Program
    { 
        class Player
        {
            private static int count = 1;
            private static int a = 0;
            private static Random rnd;
            private static int n = 6;//кол-во цифр
            private static char[] password;
            public static string[] surprise;
            private static int[] num;

            private static void Fill()
            {
                surprise = new string[10];
                surprise[0] = "Arcane";
                surprise[1] = "Sword";
                surprise[2] = "Boots of speed";
                surprise[3] = "Blade of alacrity";
                surprise[4] = "Point booster";
                surprise[5] = "Energy booster";
                surprise[6] = "Hammer";
                surprise[7] = "Butterfly";
                surprise[8] = "Manta style";
                surprise[9] = "Satanic";
                rnd = new Random(); //Рандом для замка
                a = rnd.Next(0, 10);//Этот рандом на предмет при выигрыше
            }
            private static void Fill_password()
            {
                password = new char[n];
                for (int i = 0; i < n; ++i)
                {
                    a = rnd.Next(0, 10);
                    string b = Convert.ToString(a);//Пришлось по строчно конвертировать так как ошибка.
                    password[i] = Convert.ToChar(b);
                }
                 for (int i = 0; i < n; ++i)//Если нужно посмотреть пароль
                     Console.Write(password[i]);
                     Console.Write("\n");             
            }
            public static void Enter_password()
            {
                Console.WriteLine("                              Game Hack the Lock");
                Console.WriteLine("You have the lock. It has 6 digits.\n" +
                    "You should input digit by press Enter,\n" +
                    "if you input the wrong digit you will\n" +
                    "have to start at the begining\nGoodLuck!\n");
                Player.Fill();//Делаю метод в прайвите т.к. пользователь не должен касаться заполнения данных
                Player.Fill_password();//Делаю метод в прайвите т.к. пользователь не должен касаться заполнения пароля
                num = new int[n];
                for (int i = 0; i < n; ++i)
                {
                    num[i] = Convert.ToChar(Console.ReadLine());//Ввод первой цифры
                    if (num[i] != password[i])//Проверка равен ли символ символу замка
                    {
                        ++count;//Сетчик попыток
                        Console.Clear();
                        i = -1;//Делаю -1 т.к. после инкремента i будет равняться 0
                    }
                }
                //Если пароль не правильный то из цикла не выйдет и дальше не пойдет
                Console.WriteLine("you have finished the game with " + count + " attempts.");
                Console.WriteLine("Your subject the " + surprise[a]);
            }
        }
        static void Main(string[] args)
        {
            Player.Enter_password();
        }
    }
}
