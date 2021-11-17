using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    /// <summary>
    ///  Represents the boss enemy in the game
    /// </summary>
    public class Boss : Enemy
    {
        /// <summary>
        ///  The default constructor
        /// </summary>
        public Boss() : base("Big Boss")
        {
            Health = 200;
        }
    }
}
