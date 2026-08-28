namespace Дуэль
{
    public class Archer : Character
    {
        public Archer(string name, string sex, int health, int power, int agility, int intelligence, int luck)
            : base(name, sex, health, power, agility + 3, intelligence, luck + 2)
        {

        }
    }
}
