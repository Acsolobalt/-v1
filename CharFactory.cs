using System;

namespace Дуэль
{
    public class CharFactory
    {
        static public Random rand = new Random((int)DateTime.Now.Ticks);
        public Character CreateChar(string name, string sex, int classNum)
        {
            switch (classNum)
            {
                case 1:
                    Warrior charWa = new Warrior(name, sex, 50, 5, 5, 0, 5);
                    return charWa;
                case 2:
                    Archer charAr = new Archer(name, sex, 50, 5, 5, 0, 5);
                    return charAr;
                case 3:
                    Wizard charWi = new Wizard(name, sex, 50, 5, 5, 0, 5);
                    return charWi;
                default:
                    return null;
            }
        }
        public Enemy CreateEnemy(int level)
        {
            string[] enemyNames = new string[] { "Бродяга", "Разбойник", "Наемник", "Некромант", "Оборотень" };
            string[] enemySex = new string[] { "Мужской", "Женский" };

            string name = enemyNames[rand.Next(enemyNames.Length)];
            string sex = enemySex[rand.Next(enemySex.Length)];
            int health = rand.Next(30, 71) + (level / 5);
            int power = rand.Next(5, 10) + (level / 5);
            int agility = rand.Next(5, 9) + (level / 5);
            int intelligence = rand.Next(0, 4) + (level / 5);
            int luck = rand.Next(5, 8) + (level / 5);

            Enemy enemy = new Enemy(name, sex, health, power, agility, intelligence, luck);
            return enemy;
        }
    }
}
