using System;

namespace xoProd
{
    public class PlayerInfo
    {
        public PlayerType PlayerType { get; set; }
        public ValueToInsertType ValueToInsert { get; set; }
    }

    public class Game
    {
        private readonly Area _gameArea;
        private bool _isFinish;
        private readonly AbstractBot _bot;

        private readonly PlayerInfo[] _whoPlayNow = new PlayerInfo[2];

        //todo добавить валидацию на вводимые значения(Андрей)
        public Game(BotFactory botFactory)
        {
            _whoPlayNow[0] = new PlayerInfo {PlayerType = PlayerType.Person, ValueToInsert = ValueToInsertType.X};
            _whoPlayNow[1] = new PlayerInfo {PlayerType = PlayerType.Computer, ValueToInsert = ValueToInsertType.O};

            _bot = botFactory.CreateBot();

            _gameArea = new Area();
            Console.WriteLine("Start Game");
            _gameArea.PrintPole();

            GameProcess();
        }

        private void GameProcess()
        {
            int playerNumber = 0;
            while (!_isFinish)
            {
                int whatInsertInArea = 0;

                if (_whoPlayNow[playerNumber].PlayerType == PlayerType.Person)
                {
                    string xyAsString = Console.ReadLine();
                    int x = int.Parse(xyAsString[0].ToString());
                    int y = int.Parse(xyAsString[2].ToString());

                    whatInsertInArea = WhatInsertInArea(playerNumber, whatInsertInArea);
                    var insertResult = _gameArea.UpdatePole(x, y, whatInsertInArea);
                    
                    if (!insertResult)
                    {
                        Console.WriteLine("select other x, y");
                        Console.ReadLine();
                        continue;
                    }
                }
                else
                {
                    whatInsertInArea = WhatInsertInArea(playerNumber, whatInsertInArea);

                    var botXy = _bot.ChooseStep(_gameArea.pole, whatInsertInArea);
                 
                    int x = int.Parse(botXy[0].ToString());
                    int y = int.Parse(botXy[2].ToString());
                    
                    _gameArea.UpdatePole(x, y, whatInsertInArea);

                }
               
                Console.Clear();
                Console.WriteLine();
                _gameArea.PrintPole();

                CheckGameStatus();
                if (_isFinish)
                {
                    Console.WriteLine("{0} is win", playerNumber == 0 ? "player" : "computer");
                }

                playerNumber++;
                if (playerNumber > 1)
                    playerNumber = 0;
            }
        }

        private int WhatInsertInArea(int playerNumber, int whatInsertInArea)
        {
            if (_whoPlayNow[playerNumber].ValueToInsert == ValueToInsertType.X)
                whatInsertInArea = 1;
            if (_whoPlayNow[playerNumber].ValueToInsert == ValueToInsertType.O)
                whatInsertInArea = 2;
            return whatInsertInArea;
        }

        private void CheckGameStatus()
        {
            var checkCollumns = _gameArea.CheckCollumns();
            var checkDiagonal = _gameArea.CheckDiagonal();
            var checkNombers = _gameArea.CheckNombers();
            var checkRows = _gameArea.CheckRows();

            if (checkCollumns || checkDiagonal || checkNombers || checkRows)
                _isFinish = true;
        }
    }
}