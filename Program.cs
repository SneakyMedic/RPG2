using System;

namespace RPG2
{
    class Program
    {
        public static string[] pubargs;
        public static void Main(string[] args)
        {
            pubargs = args;
            Console.WriteLine("Project RPG2 - RPG 1v1 BattleSimulator.\n");subMain();
        }
        public static void subMain()
        {
            string FPn, SPn;int FPL, SPL;//FirstPlayername,SecondPlayername,FirstPlayerLevel,SecondPlayername
            Console.Write("1st Player: Name:");FPn = Console.ReadLine();
            Console.Write("1st Player: Level:");Int32.TryParse(Console.ReadLine(),out FPL);
            Console.Write("2nd Player: Name:"); SPn = Console.ReadLine();
            Console.Write("2nd Player: Level:"); Int32.TryParse(Console.ReadLine(), out SPL);
            Hero PlayerOne = new Hero(FPn,FPL);
            Hero PlayerTwo = new Hero(SPn,SPL);
            Battle newBattle = new Battle(PlayerOne, PlayerTwo); 
            while(true)
            {
                Console.Write("\nRestart?(Yy/Nn):"); string ans = Console.ReadLine();
                if (ans == "Y" || ans == "y")
                {
                    Console.Clear();
                    subMain();
                }
                else if (ans == "N" || ans == "n")
                {
                    break;
                }
            }
        }
    }
}