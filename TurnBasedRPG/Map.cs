using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedRPG
{
    class Map
    {
        #region Singletone
        public static Map Instance => instance ?? (instance = new Map());
        private static Map instance;

        private Map()
        {

        }
        #endregion

        private List<string> symbolLayer = new List<string>();
        private List<bool[]> collisionLayer = new List<bool[]>();
        private char wall = 'X';
        private char WIN = '#';
        private char obstacle = '█';

        public void Initialize()
        {
            string temp;
            using (FileReader reader = new FileReader())
            {
                reader.Open("Map.txt");
                
                while((temp = reader.ReadLine()) != null)
                {
                    symbolLayer.Add(temp);
                    collisionLayer.Add(CheckCollisions(temp));
                }
            }
        }

        private bool[] CheckCollisions(string mapPart)
        {
            bool[] result = new bool[mapPart.Length];

            for (int i = 0; i < mapPart.Length; i++)
            {
                result[i] = ((mapPart[i] == wall) || (mapPart[i] == obstacle));
            }

            return result;
        }

        public string GetMapLine(int index)
        {
            return index < symbolLayer.Count ? symbolLayer[index] : null;
        }

        public bool IsAbleToMove(int x, int y)
        {
            return !collisionLayer[y][x];
        }
    }
}
