using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сортировка
{
    class Program
    {
        public static class Objects
        {
            private const string unlive = "u";
            private const string live = "l";
            private static string answer = " ";
            private static int correctly = 0, incorrectly = 0;
            private static  Dictionary<string, string> my_dic = new Dictionary<string, string>();

            public static void new_objects(string a,string b)//На случай добавления пары
            {
                try
                {
                    my_dic.Add(a, b);                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error 1 " +ex.Message );
                }
            }
            private static void Fill_objects()
            {
                new_objects("Stone", unlive);
                new_objects("Flower", live);
                new_objects("Board", unlive);
                new_objects("Mount", unlive);
                new_objects("Bus", unlive);
                new_objects("Cat", live);
                new_objects("Dog", live);
                new_objects("Three", live);
                new_objects("Car", unlive);
                new_objects("Iron", unlive);
                new_objects("Human", live);
                new_objects("Table", unlive);
                new_objects("Elephant", live);
                new_objects("Refrigerator", unlive);
                new_objects("Smartphone", unlive);
                new_objects("TV", unlive);
                new_objects("Lion", live);
                new_objects("Pen", unlive);
                new_objects("Hippopotamus", live);
                new_objects("Street", unlive);
            }
            public static void input_answer()
            {
                Fill_objects();
                Console.WriteLine("Push l(live) or u(unlive)");
                foreach (var it in my_dic)
                {
                    Console.WriteLine(it.Key);
                    while (answer != live || answer != unlive)
                    {
                        answer = Console.ReadLine();
                        if (answer != live && answer != unlive)
                            Console.WriteLine("No correctly data");
                        else if (answer == it.Value)
                        {
                            ++correctly;
                            Console.WriteLine("True"); break;
                        }
                        else if (answer != it.Value)
                        {
                            ++incorrectly;
                            Console.WriteLine("False"); break;
                        }
                    }
                }
                Console.WriteLine("correctly answers = " + correctly);
                Console.WriteLine("incorrectly answers = " + incorrectly);
            }
        }
        static void Main(string[] args)
        {
            Objects.new_objects("Cup", "u");
            Objects.input_answer();
        }
    }
}
