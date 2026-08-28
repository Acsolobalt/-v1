namespace Дуэль
{
    public class CharControl
    {
        private Character _character;
        private int _index;

        public string GetName
        {
            get { return _character.Name; }
        }
        public string GetSex
        {
            get { return _character.Sex; }
        }
        public int GetHealth
        {
            get { return _character.Health; }
        }
        public int GetStamina
        {
            get { return _character.Stamina; }
        }
        public int GetPower
        {
            get { return _character.Power; }
        }
        public int GetAgility
        {
            get { return _character.Agility; }
        }
        public int GetIntelligence
        {
            get { return _character.Intelligence; }
        }
        public int GetLuck
        {
            get { return _character.Luck; }
        }
        public int GetLevel
        {
            get { return _character.Level; }
        }
        public int GetFightCount
        {
            get { return _character.FightsCount; }
        }
        public int GetUpdatePoints
        {
            get { return _character.UpdatePoints; }
        }
        public int GetIndex
        {
            get { return _index; }
        }

        public void updateSkill (int skillNum)
        {
            switch(skillNum)
            {
                case 1:
                    ++_character.Health;
                    break;
                case 2:
                    ++_character.Stamina;
                    break;
                case 3:
                    ++_character.Power;
                    break;
                case 4:
                    ++_character.Agility;
                    break;
                case 5:
                    ++_character.Intelligence;
                    break;
                case 6:
                    ++_character.Luck;
                    break;
                default:
                    return;
            }
            --_character.UpdatePoints;
        }
        public void levelUp()
        {
            if(_character.FightsCount == 5)
            {
                ++_character.UpdatePoints;
                _character.FightsCount = 0;
                ++_character.Level;
            }
        }
        public void victory()
        {
            ++_character.FightsCount;
        }
        public void setCharacter(Character character, int index)
        {
            _character = character;
            _index = index;
        }
    }
}
