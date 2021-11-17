using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    /// <summary>
    ///  This class represents the playable character
    /// </summary>
    public class Player
    {
        /// <summary>
        /// This represents the player's health value.
        /// </summary>
        public int Health { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// The klingon family the player will belong to
        /// </summary>
        public string House { get; set; }

        public bool IsDead { get; set; }

        public bool isGuarding { get; set; }

        /// <summary>
        /// Sets which house in the Klingon empire the user belongs to.
        /// </summary>
        public void playerHouse()
        {
            // the different houses
            string dGor = "D'Gor";
            string duras = "Duras";
            string quark = "Quark";
            string martok = "Martok";
            string mogh = "Mogh";

            Random random = new Random();
            int houseNumber = random.Next(1, 5);

            if (houseNumber == 1)
            {
                House = dGor;
            } else if (houseNumber == 2)
            {
                House = duras;
            }
            else if (houseNumber == 3)
            {
                House = quark;
            }
            else if (houseNumber == 4)
            {
                House = martok;
            }
            else if (houseNumber == 5)
            {
                House = mogh;
            }

        }

        /// <summary>
        /// The default constructor
        /// </summary>
        public Player()
        {
            // default health is 100.
            Health = 100;

            // Set player's house
            playerHouse();

        }

        /// <summary>
        /// Gets called everytime the opponent attacks
        /// </summary>
        /// <param name="hitValue">The amount of damage the player should take</param>
        public void HitDamage(int hitValue)
        {
            Random random = new Random();
            int chanceToDodge = random.Next(0,3);

            // check if the player was guarding
            if (isGuarding == true)
            {
                Console.WriteLine("You've successfully parried the blow!\n");

                // reset player guarding status
                isGuarding = false;
            }
            else if (chanceToDodge > 0)
            {
                // the player was not guarding
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You successfully dodge the attack!\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (chanceToDodge == 0)
            {
                // subtract the hit damage value from total health
                Health = Health - hitValue;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Name + " took " + hitValue + " damage.\n");

                if (Health > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(Health + " remaining.\n");
                }

                Console.ForegroundColor = ConsoleColor.White;

                // check if the player is dead (per iteration)
                if (Health <= 0)
                {
                    // declare enemy dead
                    Die();
                }
            }
        }

        /// <summary>
        /// Heals the player with the amount to heal
        /// </summary>
        /// <param name="amount_to_heal">The quantity of healing</param>
        public void Heal(int amount_to_heal)
        {
            Health = (Health + amount_to_heal > 100) ? 100 : (Health + amount_to_heal);

            if (Health > 100)
            {
                Health = 100;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You've healed " + amount_to_heal + " health.\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine( Health + " health now remains\n");
        }

        /// <summary>
        /// Called when the players's health <= 0
        /// </summary>
        private void Die()
        {
            Console.WriteLine(Name + " has been slain!\n");
            IsDead = true;
        }
    }
}
