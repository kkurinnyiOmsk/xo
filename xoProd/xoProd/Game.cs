﻿using System;

namespace xoProd
{
    public class Game
    {
        private Area GameArea;
        private bool IsFinish;
        private readonly AbstractBot Bot;
        //todo добавить валидацию на вводимые значения(Андрей)
        public Game(BotFactory botFactory)
        {

            Bot = botFactory.CreateBot();

            GameArea = new Area();
            Console.WriteLine("Start Game");
            GameArea.PrintPole();

            GameProcess();
        }

        private void GameProcess()
        {
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
                Console.WriteLine();
                GameArea.PrintPole();

                CheckGameStatus();
                if (IsFinish)
                {
                    Console.WriteLine("{0} is win", playerNumber == 1 ? "player" : "computer");
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