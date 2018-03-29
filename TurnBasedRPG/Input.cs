using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedRPG
{
    public delegate void OnKeyPressedHandler(ConsoleKey key);

    /// <summary>
    /// Class responcible for input.
    /// This class contains two patterns:
    /// 1. Singletone
    /// 2. Observer
    /// </summary>
    class Input
    {
        #region Singletone
        public static Input Instance => instance ?? (instance = new Input());
       
        private static Input instance;

        private Input() { }
        
        #endregion

        #region Observer
        public static event OnKeyPressedHandler OnKeyPressed;

        /// <summary>
        /// Updates our input.
        /// </summary>
        /// <returns>
        /// Currently pressed button.
        /// </returns>
        public ConsoleKey Update()
        {
            ConsoleKey key = Console.ReadKey().Key;

            //if (OnKeyPressed != null)
            //    OnKeyPressed.Invoke(key);
            OnKeyPressed?.Invoke(key);
            return key;
        }
        #endregion
    }
}
