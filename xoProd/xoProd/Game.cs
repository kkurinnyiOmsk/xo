using System;

namespace xoProd
{
    public class Game
    {
        private Area GameArea;

        public Game()
        {
            GameArea = new Area();
            Console.WriteLine("Start Game");
            GameArea.PrintPole();

            string xy = Console.ReadLine();
            int x = int.Parse(xy[0].ToString());
            int y = int.Parse(xy[2].ToString());

            GameArea.UpdatePole(x-1, y-1, 1);
            Console.Clear();
            GameArea.PrintPole();
        }


    }
}