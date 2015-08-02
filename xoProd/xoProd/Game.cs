using System;

namespace xoProd
{
    public class Game
    {
        private Area GameArea;
        private bool IsFinish;

        private void CheckGameStatus()
        {
            var checkCollumns = GameArea.CheckCollumns();
            var checkDiagonal = GameArea.CheckDiagonal();
            var checkNombers = GameArea.CheckNombers();
            var checkRows = GameArea.CheckRows();

            if (checkCollumns || checkDiagonal || checkNombers || checkRows)
                IsFinish = true;
        }

       

        public Game()
        {
            GameArea = new Area();
            Console.WriteLine("Start Game");
            GameArea.PrintPole();

            int gameNumber = 1;

            while (!IsFinish)
            {
                string xy = Console.ReadLine();
                int x = int.Parse(xy[0].ToString());
                int y = int.Parse(xy[2].ToString());

                int value = 0;
                if (gameNumber == 1)
                    value = 1;
                else
                    value = 2;

                var updateResult = GameArea.UpdatePole(x - 1, y - 1, value);

                if (!updateResult)
                {
                    Console.WriteLine("select other x, y");
                    Console.ReadLine();
                    continue;
                }
                Console.Clear();
                GameArea.PrintPole();

                gameNumber++;
                if (gameNumber > 2)
                    gameNumber = 1;
                CheckGameStatus();
            }

            Console.WriteLine("Game over");
            
        }


    }
}