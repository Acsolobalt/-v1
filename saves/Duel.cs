using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дуэль
{
    class Duel
    {
        static public Random rand = new Random((int)DateTime.Now.Ticks);
        private string lastHeroMove; //атака.защита нанесено_урона
        private string lastEnemyMove; //атака.защита нанесено_урона



        private int _heroHealth;
        private int _heroStamina;
        private int _heroPower;
        private int _heroAgility;
        private int _heroIntelligence;
        private int _heroLuck;

        private int _enemyHealth;
        private int _enemyStamina;
        private int _enemyPower;
        private int _enemyAgility;
        private int _enemyIntelligence;
        private int _enemyLuck;

        public int HeroHealth
        {
            get { return _heroHealth; }
            set { _heroHealth = value; }
        }
        public int HeroStamina
        {
            get { return _heroStamina; }
            set { _heroStamina = value; }
        }
        public int HeroPower
        {
            set { _heroPower = value; }
        }
        public int HeroAgility
        {
            set { _heroAgility = value; }
        }
        public int HeroIntelligence
        {
            set { _heroIntelligence = value; }
        }
        public int HeroLuck
        {
            set { _heroLuck = value; }
        }
        public int EnemyHealth
        {
            get { return _enemyHealth; }
            set { _enemyHealth = value; }
        }
        public int EnemyStamina
        {
            get { return _enemyStamina; }
            set { _enemyStamina = value; }
        }
        public int EnemyPower
        {
            set { _enemyPower = value; }
        }
        public int EnemyAgility
        {
            set { _enemyAgility = value; }
        }
        public int EnemyIntelligence
        {
            set { _enemyIntelligence = value; }
        }
        public int EnemyLuck
        {
            set { _enemyLuck = value; }
        }

        public string LastHeroMove
        {
            get { return lastHeroMove; }
        }
        public string LastEnemyMove
        {
            get { return lastEnemyMove; }
        }

        private void checkStamina(ref int stamina)
        {
            if(stamina < 0)
            {
                stamina = 0;
            }
        }
        public int krit(int luck)
        {
            int chance = rand.Next(0, 100) + 1;
            if(luck > chance)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public double staminaDebuff(int stamina)
        {
            if(stamina == 0)
            {
                return rand.Next(4, 7)/10;
            } 
            else
            {
                return 1;
            }
        }
        public int attackDamage(int power, ref int stamina, int luck, int position)
        {
            int damage;
            if (position == 1)
            {
                power = (int)(power * (1 + 0.15));
                luck += 10;
                stamina -= 4;
                checkStamina(ref stamina);
            }
            damage = power;
            damage = (int)(damage * (1 + 0.05 * krit(luck)));
            damage = (int)(damage * staminaDebuff(stamina));
            return damage;
        }
        public int receivedDamage(int enemyDamage, int agility, int position, int enemyIntelligence, ref int stamina)
        {
            int chance = rand.Next(0, 100) + 1;
            int dodge = agility;
            if(position == 2)
            {
                stamina -= 2;
                dodge += 15;
                checkStamina(ref stamina);
            }
            dodge -= enemyIntelligence;
            if(dodge > chance)
            {
                return 0;
            } 
            else
            {
                return enemyDamage;
            }
        }
        public void makeAMove(int heroPos)
        {
            int heroDamage = attackDamage(_heroPower, ref _heroStamina, _heroLuck, heroPos);
            int enemyPos = rand.Next(1, 3);
            int enemyDamage = attackDamage(_enemyPower, ref _enemyStamina, _enemyLuck, enemyPos);

            int heroReceived = receivedDamage(enemyDamage, _heroAgility, heroPos, _enemyIntelligence, ref _heroStamina);
            int enemyReceived = receivedDamage(heroDamage, _enemyAgility, enemyPos, _heroIntelligence, ref _enemyStamina);

            lastHeroMove = "";
            if (heroPos == 1)
            {
                lastHeroMove += "атакует. ";
            }
            else
            {
                lastHeroMove += "защищается. ";
            }
            lastHeroMove += "Нанесено урона: " + enemyReceived;

            lastEnemyMove = "";
            if (enemyPos == 1)
            {
                lastEnemyMove += "атакует. ";
            }
            else
            {
                lastEnemyMove += "защищается. ";
            }
            lastEnemyMove += "Нанесено урона: " + heroReceived;
        }
    }
}
