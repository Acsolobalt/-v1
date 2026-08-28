namespace Дуэль
{
    public class GameControl
    {
        private CharFactory factory = new CharFactory();
        private Duel duel;
        private CharList charList = new CharList();
        private CharControl selectedChar = new CharControl();

        public CharList GetCharList
        {
            get { return charList; }
        }
        public CharControl GetSelected
        {
            get { return selectedChar; }
        }
        public Duel GetDuel
        {
            get { return duel; }
        }
        public void CreateChar(string name, string sex, int classNumber)
        {
            charList.add(factory.CreateChar(name, sex, classNumber));
        }
        public void selectChar(int index)
        {
            selectedChar.setCharacter(charList[index], index);
        }
        public void startDuel(Character hero)
        {
            duel = new Duel(hero, selectedChar.GetIndex, factory.CreateEnemy(selectedChar.GetLevel));
        }
        public bool isBattleEnd()
        {
            if(duel.HeroHealth == 0 || duel.EnemyHealth == 0)
            {
                return true;
            }
            return false;
        }
        public string duelResult()
        {
            if(duel.EnemyHealth == 0)
            {
                return "Победа!";
            }
            else
            {
                return "Поражение!";
            }
        }
        public void charSave()
        {
            charList.save(selectedChar.GetHealth, 
                selectedChar.GetStamina, 
                selectedChar.GetPower, 
                selectedChar.GetAgility, 
                selectedChar.GetIntelligence,
                selectedChar.GetLuck, 
                selectedChar.GetLevel, 
                selectedChar.GetFightCount, 
                selectedChar.GetUpdatePoints, 
                selectedChar.GetIndex);
        }
    }
}
