namespace Дуэль
{
    public class Wizard : Character
    {
        public Wizard(string name, string sex, int health, int power, int agility, int intelligence, int luck)
            : base(name, sex, health, power + 2, agility, intelligence + 3, luck)
        {

        }
    }
}
