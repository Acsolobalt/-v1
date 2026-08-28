using System;

namespace Дуэль
{
    public class Duel
    {
        static public Random rand = new Random((int)DateTime.Now.Ticks);
        private string lastHeroMove; //атака.защита нанесено_урона
        private string lastEnemyMove; //атака.защита нанесено_урона

        private CharControl _hero = new CharControl();
        private CharControl _enemy = new CharControl();

        private int _heroHealth;
        private int _heroStamina;

        private int _enemyHealth;
        private int _enemyStamina;

        public CharControl Hero
        {
            get { return _hero; }
        }
        public CharControl Enemy
        {
            get { return _enemy; }
        }

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
        private void checkHealth(ref int health)
        {
            if (health < 0)
            {
                health = 0;
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
                return (double)rand.Next(4, 7)/10;
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
            int heroDamage = attackDamage(_hero.GetPower, ref _heroStamina, _hero.GetLuck, heroPos);
            int enemyPos = rand.Next(1, 3);
            int enemyDamage = attackDamage(_enemy.GetPower, ref _enemyStamina, _enemy.GetLuck, enemyPos);

            int heroReceived = receivedDamage(enemyDamage, _hero.GetAgility, heroPos, _enemy.GetIntelligence, ref _heroStamina);
            int enemyReceived = receivedDamage(heroDamage, _enemy.GetAgility, enemyPos, _hero.GetIntelligence, ref _enemyStamina);

            _heroHealth -= heroReceived;
            checkHealth(ref _heroHealth);
            _enemyHealth -= enemyReceived;
            checkHealth(ref _enemyHealth);

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

        public Duel(Character hero, int heroIndex, Character enemy)
        {
            lastEnemyMove = "";
            lastHeroMove = "";

            _hero.setCharacter(hero, heroIndex);
            _enemy.setCharacter(enemy, -1);

            _heroHealth = _hero.GetHealth;
            _heroStamina = _hero.GetStamina;

            _enemyHealth = _enemy.GetHealth;
            _enemyStamina = _enemy.GetStamina;
        }
    }
}
