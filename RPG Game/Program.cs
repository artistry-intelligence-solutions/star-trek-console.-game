using System;

namespace RPG_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            //  Output the text stating we want the players name
            Console.WriteLine("What is your name?\n");

            // Create the player character and store name
            Player player = new Player()
            {
                Name = Console.ReadLine()
            };

            // Get stardate
            Stardate stardate = new Stardate();
            stardate.CurrentStarDate = stardate.GetStardate();

            Console.WriteLine("\nWelcome " + player.Name + ", of the house of " + player.House + "! Your journey begins on star date " + stardate.CurrentStarDate + ".\n");
            Console.WriteLine(player.Name + ", today you have come of age. To celebrate you've gone hunting on Praxis. A moon of your homeworld, Qo'NoS.\n");

            // track the first enemey
            Enemy firstEnemy = new Enemy("Tribble");

            // print out enemy attack
            Console.WriteLine(player.Name + " you've encountered a " + firstEnemy.Name + "! The mortal enemies of all Klingons.\nDefend the empire, QAPLA'!\n");

            EnemyEncounter(firstEnemy, random, player, 16);


            while (!player.IsDead && firstEnemy.IsDead)
            {
                Console.WriteLine("You are barely fatigued, your heart pounds as you feel the call of battle! You take a calm, steadying breath and continue, silently through the under brush...\n");
                // Create the boss character
                Boss boss = new Boss();
                boss.Name = "Romulan Tal Shiar";

                Console.WriteLine("You suddenly encounter a " + boss.Name + "! You must defeat this mortal foe and find out what the Romulans are doing in Federation space!\n");

                EnemyEncounter(boss, random, player, 26);

                if (!player.IsDead && boss.IsDead)
                {
                    Console.WriteLine("Well done mighty warrior, you have the makings of a mighty Klingon warrior and you've earned your blood wine tonight. Who knows, perhaps you will even be lucky enough to have a glorious, violent, bloody death! haha, QAPLA'!\n");
                }
            }
        }

        /// <summary>
        /// Handles events when a player encounters an enemy
        /// </summary>
        /// <param name="enemy">The enemy the player will attack</param>
        /// <param name="random">Generated random number, attacks etc</param>
        /// <param name="player">The main playable character</param>
        /// <param name="max_attack_power">Max attack power of the enemy</param>
        private static void EnemyEncounter(Enemy enemy, Random random, Player player, int max_attack_power)
        {
            int threeStrike = 0;

            // store player decision
            string playerAction;

            // run snippet while isFirstEnemy and the player are not dead
            while (!enemy.IsDead && !player.IsDead)
            {
                Console.WriteLine("What would you like to do?\n1 - Single Attack\n2 - Three Strike Attack\n3 - Defend\n4 - Heal\n");

                playerAction = Console.ReadLine();

                // Check what action the player took
                if (playerAction == "1")
                {

                    Console.WriteLine(player.Name + " chose to single attack " + enemy.Name + "\n");

                    // Apply damage to the enemy
                    enemy.HitDamage(random.Next(1, 16));

                }
                else if (playerAction == "2")
                {
                    threeStrike = random.Next(0, 4);

                    Console.WriteLine(player.Name + " chose to three strike attack " + enemy.Name + ". You successfully land " + threeStrike + " hits!\n");

                    for (int i = 0; i < threeStrike; i++)
                    {
                        enemy.HitDamage(random.Next(1, 16));

                        if (enemy.IsDead)
                        {
                            break;
                        }
                    }
                }
                else if (playerAction == "3")
                {
                    Console.WriteLine(player.Name + " chose to defend against the " + enemy.Name + "\n");

                    // set player as guarding
                    player.isGuarding = true;
                }
                else if (playerAction == "4")
                {
                    Console.WriteLine(player.Name + " chose to heal\n");
                    player.Heal(random.Next(1, 16));
                }
                else
                {
                    Console.WriteLine("You're decision is invalid\n");
                }

                if (!enemy.IsDead)
                {
                    // The enemy returns attack
                    Console.WriteLine("\nGet ready " + enemy.Name + ", prepares to strike!\n");
                    player.HitDamage(random.Next(1, max_attack_power));
                }

                if (player.IsDead)
                {
                    GameOver();
                }
            }
        }

        /// <summary>
        /// Handles Game Over
        /// </summary>
        private static void GameOver()
        {
            Console.WriteLine("You have been slain in battle! You're song shall be sung for all eternity in the halls of Sto-vo-kor!\n\n\n");
        }
    }
}
