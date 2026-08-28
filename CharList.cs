using System.Collections.Generic;
using System.Linq;

namespace Дуэль
{
    public class CharList
    {
        private List<Character> _list;

        public int Count
        {
            get { return _list.Count(); }
        }
        public Character this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }
        public void add(Character character)
        {
            if(!exist(character))
            {
                _list.Add(character);
            } 
        }
        public bool exist(Character character)
        {
            for(int i = 0; i < _list.Count; ++i)
            {
                if(_list[i] == character)
                {
                    return true;
                }
            }
            return false;
        }
        public void save(int health,int stamina, int power, int agility, int intelligence, int luck, int level, int fightsCount, int updatePoints, int index)
        {
            _list[index].Health = health;
            _list[index].Stamina = stamina;
            _list[index].Power = power;
            _list[index].Agility = agility;
            _list[index].Intelligence = intelligence;
            _list[index].Luck = luck;
            _list[index].Level = level;
            _list[index].FightsCount = fightsCount;
            _list[index].UpdatePoints = updatePoints;
        }
        public void clear()
        {
            int index = 0;
            while (_list[index] != null)
            {
                _list.RemoveAt(index);
                ++index;
            }
        }
        public CharList()
        {
            _list = new List<Character>();
        }
    }
}
