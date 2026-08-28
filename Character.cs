namespace Дуэль
{
    public class Character
    {
        protected string _name;
        protected string _sex;

        protected int _health;
        protected int _stamina;
        protected int _power;
        protected int _agility;
        protected int _intelligence;
        protected int _luck;

        protected int _level;
        protected int _fightsCount;
        protected int _updatePoints;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        public int Stamina
        {
            get { return _stamina; }
            set { _stamina = value; }
        }
        public int Power
        {
            get { return _power; }
            set { _power = value; }
        }
        public int Agility
        {
            get { return _agility; }
            set { _agility = value; }
        }
        public int Intelligence
        {
            get { return _intelligence; }
            set { _intelligence = value; }
        }
        public int Luck
        {
            get { return _luck; }
            set { _luck = value; }
        }
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
        public int FightsCount
        {
            get { return _fightsCount; }
            set { _fightsCount = value; }
        }
        public int UpdatePoints
        {
            get { return _updatePoints; }
            set { _updatePoints = value; }
        }
        protected Character(string name, string sex, int health, int power, int agility, int intelligence, int luck, int level = 0)
        {
            _name = name;
            _sex = sex;
            _health = health;
            _stamina = power * 4;
            _power = power;
            _agility = agility;
            _intelligence = intelligence;
            _luck = luck;
            _level = level;
            _fightsCount = 0;
            _updatePoints = 0;
        }
    }
}
