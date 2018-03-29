using System;

namespace TurnBasedRPG
{
    public class Player: IMovable
    {
        public static char Sign = '>';      
        public Vector2 Position => position;
        private Vector2 position;

        public Player()
        {
            Input.OnKeyPressed += ProcessInput; // Subscription on OnKeyPressed event.
        }

        private void Fall_down()
        {         
           while (Map.Instance.IsAbleToMove(position.X, position.Y + 1))//fall left
           {
                Move(new Vector2(0, 1));
           }
        }
        private void ProcessInput(ConsoleKey key)
        {
            switch (key)
            {

                case ConsoleKey.LeftArrow:
                    Sign = '<';
                    Move(new Vector2(-1, 0));
                    Fall_down();
                    break;
                case ConsoleKey.RightArrow:
                    Sign = '>';
                    Move(new Vector2(1, 0));
                    Fall_down();
                    break;
                case ConsoleKey.Spacebar:
                    if ((Map.Instance.IsAbleToMove(position.X+1, position.Y)) && (!Map.Instance.IsAbleToMove(position.X + 2, position.Y)))
                    {
                        Move(new Vector2(2, -1));
                    }
                    else if ((Map.Instance.IsAbleToMove(position.X-1, position.Y)) && (!Map.Instance.IsAbleToMove(position.X - 2, position.Y)))
                    {
                        Move(new Vector2(-2, -1));
                    }
                    else if ((!Map.Instance.IsAbleToMove(position.X + 1, position.Y)) && (!Map.Instance.IsAbleToMove(position.X + 2, position.Y)))//Запрыгивание на вверх, когда невозможно перепрыгнуть
                    {
                        Move(new Vector2(1, -1));
                    }
                    else if ((!Map.Instance.IsAbleToMove(position.X - 1, position.Y)) && (!Map.Instance.IsAbleToMove(position.X - 2, position.Y)))//Запрыгивание на вверх, когда невозможно перепрыгнуть
                    {
                        Move(new Vector2(-1, -1));
                    }
                    else if ((!Map.Instance.IsAbleToMove(position.X + 1, position.Y)) && (Map.Instance.IsAbleToMove(position.X + 1, position.Y-1)) && (Map.Instance.IsAbleToMove(position.X + 2, position.Y)))//перепрыгнуть
                    {
                        Sign = '>';
                        Move(new Vector2(2, 0));
                    }
                    else if ((!Map.Instance.IsAbleToMove(position.X - 1, position.Y)) && (Map.Instance.IsAbleToMove(position.X - 1, position.Y-1)) && (Map.Instance.IsAbleToMove(position.X -2, position.Y)))//перепрыгнуть
                    {
                        Sign = '<';
                        Move(new Vector2(-2, 0));
                        
                    }
                    break;
            }
        }
        
        public void Move(Vector2 offset)
        {
            int x = position.X + offset.X;
            int y = position.Y + offset.Y;

            if (!Map.Instance.IsAbleToMove(x, y))
                return;

            position.X = x;
            position.Y = y;

            position.X = Math.Min(Math.Max(0, position.X), Console.WindowWidth - 1);
            position.Y = Math.Min(Math.Max(0, position.Y), Console.WindowHeight - 2);
            check_win();
        }
        private void check_win()
        {
            if (position.X == 31 && position.Y ==4)
            {
                Console.Clear();
                Sign = ' ';
                Console.WriteLine("You win!!!");
                Environment.Exit(0);
            }          
        }
    }
}