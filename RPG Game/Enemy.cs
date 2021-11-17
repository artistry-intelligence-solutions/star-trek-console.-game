using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    /// <summary>
    /// Represents the base elements of an enemy
    /// </summary>
    public class Enemy
    {
        public int Health { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Determines if this enemy is dead
        /// </summary>
        public bool IsDead { get; set; }

        /// <summary>
        ///  The default constructor for enemies
        /// </summary>
        /// <param name="name">The name as set according to situation</param>
        public Enemy(string name)
        {
            Health = 100;
            Name = name;
        }

        /// <summary>
        /// Gets called everytime to player lands a hit
        /// </summary>
        /// <param name="hitValue">The amount of damage the enemy should take</param>
        public void HitDamage(int hitValue)
        {
            Random random = new Random();
            int chanceToDodge = random.Next(0, 3);

            if (chanceToDodge > 1)
            {
                Console.WriteLine("Oh no! " + Name + " dodges your attack!\n");
            } else if (chanceToDodge <= 1)
            {
                // subtract the hit damage value from total health
                Health = Health - hitValue;

                Console.WriteLine("You strike with your Bat'leth!\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Name + " took " + hitValue + " damage.\n");

                if (Health > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(Health + " remaining.\n");
                }

                Console.ForegroundColor = ConsoleColor.White;

                // check if enemy is dead (per iteration)
                if (Health <= 0)
                {
                    // declare enemy dead
                    Die();
                }
            }
        }

        /// <summary>
        /// Called when the enemy's health <= 0
        /// declared private because Program class should not be able to control when the enemy dies only the attack event
        /// </summary>
        private void Die()
        {
            Console.WriteLine(Name + " has been slain! The silence of the night shatters as your cry rents the cold night air. The ruined corpse of your enemy, lies at your feet.\n");
            IsDead = true;
        }
    }
}
