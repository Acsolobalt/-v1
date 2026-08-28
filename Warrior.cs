namespace Дуэль
{
    public class Warrior : Character
    {
        public Warrior(string name, string sex, int health, int power, int agility, int intelligence, int luck) 
            : base(name, sex, health + 20, power + 4, agility, intelligence, luck) 
        {

        }
    }
}
