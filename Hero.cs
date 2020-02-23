using System;
using System.Collections.Generic;
using System.Text;

namespace RPG2
{
    class Hero
    {
        public int hp, level,specialsLeft;public string name;public bool AliveStatus;
        public int maxHP() { return 50 * level; }
        public int minAttack() { return maxHP() / 10; }
        public int maxAttack() { return maxHP() - (maxHP() / 10); }
        public bool guardingStatus = false;
        public Hero(string nm,int lvl)
        {
            name = nm;
            level = lvl;
            specialsLeft = lvl;
            hp = maxHP();
        }
    }
}
