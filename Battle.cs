using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace RPG2
{
    class Battle
    {
        Hero a,b; Random ran = new Random();
        private bool battleStatus = true;
        public Battle(Hero h1, Hero h2)
        {
            a = h1;b = h2;
            start(h1,h2);
        }
        private byte nextHeroIndex = 0;
        private Hero nextHero(Hero h1, Hero h2)
        {
            if (nextHeroIndex == 0) { nextHeroIndex++; return h1; } else { nextHeroIndex--; return h2; }
        }
        private void start(Hero h1,Hero h2)
        {
            while(battleStatus)
            {
                if (h1.hp > 0 && h2.hp > 0)
                {
                    turn(nextHero(h1, h2), nextHero(h1, h2));
                    nextHero(h1,h2); //Anti-nextHero_pairing-Debug
                }
                else
                {
                    if (h1.hp <= 0)
                    {
                        h1 = a;
                        h2 = b;
                        h2.level++;
                        Console.WriteLine("{0} won. {0} is now at {1} level", h2.name, h2.level);
                        battleStatus = false;
                    }
                    else
                    {
                        h1 = a;
                        h2 = b;
                        h1.level++;
                        Console.WriteLine("{0} won. {0} is now at {1} level", h1.name, h1.level);
                        battleStatus = false;
                    }
                }
            }
            Console.WriteLine("The battle ends.");
        }
        private void turn(Hero h, Hero h2)
        {
            Console.Write("\n@{0}>", h.name);
            string input = Console.ReadLine();
            switch(input)
            {
                case "Attack":
                    attack(h,h2);
                    break;
                case "Guard":
                    guard(h);
                    break;
                case "Heal":
                    heal(h);
                    break;
                case "Status":
                    status(h,h2);
                    turn(h, h2);
                    break;
                case "Special":
                    if(h.specialsLeft>0)
                    {
                        h.specialsLeft--;
                        special(h, h2);
                    }
                    else
                    {
                        Console.WriteLine("You have used all your specials.");
                        turn(h,h2);
                    }
                    break;
                default:
                    Console.WriteLine("You can only use Attack/Guard/Heal/Special/Status");
                    turn(h,h2);
                    break;
            }
        }
        private void heal(Hero h)
        {
            int MPH = h.maxHP() - h.hp; //Maximum Possible Health
            int MLPH = h.minAttack(); //Maximum Lowest Possible Health
            if (MLPH>MPH) { MLPH = MPH / 10;}
            int thisHP = ran.Next(MLPH, MPH);
            if (MPH == 1) { thisHP = 1; }
            h.hp += thisHP;
            Console.WriteLine("{0} restored {1} hp.\nNow {0} has {2} HP.",h.name,thisHP,h.hp);
        }
        private void attack(Hero h, Hero h2)
        {
            int atk;
            if (!(h2.guardingStatus))
            {
                atk = ran.Next(h.minAttack(), h.maxAttack()); h2.hp -= atk;
            }
            else
            {
                atk = (ran.Next(h.minAttack(), h.maxAttack())/2); h2.hp -= atk;
                h2.guardingStatus = false;
            }
            Console.WriteLine("{0} has taken {1} damage from {2}.\nNow {2} has {3} HP.",h.name,atk,h2.name,h2.hp);
        }
        private void guard(Hero h)
        {
            h.guardingStatus = true;
            Console.WriteLine("{0} is guarding.",h.name);
        }
        private void special(Hero h,Hero h2)
        {
            int thisSpecial = ran.Next(0, 6);
            switch (thisSpecial)
            {
                case 0:
                    h.hp = h.maxHP();
                    Console.WriteLine("{0} used FullHP Special.\nNow {0} has {1} HP.", h.name, h.hp);
                    break;
                case 1:
                    h2.hp -= h.maxAttack();
                    Console.WriteLine("{0} used MaxAttack Special on {1} and has taken {2} damage.\nNow {1} has {3} HP.", h.name, h2.name, h.maxAttack(), h2.hp);
                    break;
                case 2:
                    h2.hp = 0;
                    Console.WriteLine("{0} used InstantKill Special on {1}.", h.name, h2.name);
                    break;
                case 3:
                    h.hp = 0;
                    Console.WriteLine("{0} used Suicide Special on {0}.", h.name);
                    break;
                default:
                    Console.WriteLine("{0} missed his special!", h.name);
                    break;
            }
        }
        public void status(Hero h, Hero h2)
        {
            Console.WriteLine("You:\n -name:{0}\n -hp:{1}\n -level:{2}\n\nEnemy:\n -name:{3}\n -hp:{4}\n -level:{5}\n",h.name,h.hp,h.level,h2.name,h2.hp,h2.level);
        }
    }
}
