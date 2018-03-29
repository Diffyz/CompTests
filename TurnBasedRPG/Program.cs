using System;

namespace TurnBasedRPG
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Map map = Map.Instance;
            map.Initialize();
            
            Player player = new Player();
            player.Move(new Vector2(1,17));

            ConsoleKey key;

            string mapLine;
            int index = 0;
            while ((mapLine = map.GetMapLine(index++)) != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(mapLine);
            }

            do
            {
                // Render
                Console.SetCursorPosition(player.Position.X, player.Position.Y);
                Console.Write(Player.Sign + "\b");

                // Get input
                // key = Console.ReadKey().Key;
                key = Input.Instance.Update();
                
                // Process input
                // No processing in main

            } while (key != ConsoleKey.Escape);
        }
    }
}