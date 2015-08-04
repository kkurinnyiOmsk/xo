using System;

namespace xoProd
{
    public class Game
    {
        private Area GameArea;
        private bool IsFinish;

        public Game()
        {
            GameArea = new Area();
            Console.WriteLine("Start Game");
            GameArea.PrintPole();

            int playerNumber = 1;

            while (!IsFinish)
            {
                string xyAsString = Console.ReadLine();
                int x = int.Parse(xyAsString[0].ToString());
                int y = int.Parse(xyAsString[2].ToString());

                int whatInsertInArea = 0;

                if (playerNumber == 1)
                    whatInsertInArea = 1;
                else
                    whatInsertInArea = 2;

                var insertResult = GameArea.UpdatePole(x - 1, y - 1, whatInsertInArea);

                if (!insertResult)
                {
                    Console.WriteLine("select other x, y");
                    Console.ReadLine();
                    continue;
                }
                Console.Clear();
                GameArea.PrintPole();

              
                CheckGameStatus();
                if (IsFinish)
                {
                    Console.WriteLine("{0} is win", playerNumber ==1 ? "player" :"computer");
                }
              
                playerNumber++;
                if (playerNumber > 2)
                    playerNumber = 1;
            }
        }
    
        private void CheckGameStatus()
        {
            var checkCollumns = GameArea.CheckCollumns();
            var checkDiagonal = GameArea.CheckDiagonal();
            var checkNombers = GameArea.CheckNombers();
            var checkRows = GameArea.CheckRows();

            if (checkCollumns || checkDiagonal || checkNombers || checkRows)
                IsFinish = true;
        }

    }
}