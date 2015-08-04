using System;

namespace xoProd
{
    public enum PlayerType
    {
        Person,
        Computer
    }

    public enum ValueToInsertType
    {
        X,
        O
    }

    public class PlayerInfo
    {
        public PlayerType PlayerType { get; set; }
        public ValueToInsertType ValueToInsert { get; set; }
    }

    public class Game
    {
        private Area GameArea;
        private bool IsFinish;
        private readonly AbstractBot Bot;

        private PlayerInfo[] whoPlay = new PlayerInfo[2];

        //todo добавить валидацию на вводимые значения(Андрей)
        public Game(BotFactory botFactory)
        {
            whoPlay[0] = new PlayerInfo {PlayerType = PlayerType.Person, ValueToInsert = ValueToInsertType.X};
            whoPlay[1] = new PlayerInfo {PlayerType = PlayerType.Computer, ValueToInsert = ValueToInsertType.O};

            Bot = botFactory.CreateBot();

            GameArea = new Area();
            Console.WriteLine("Start Game");
            GameArea.PrintPole();

            GameProcess();
        }

        private void GameProcess()
        {
            int playerNumber = 0;
            while (!IsFinish)
            {
                int whatInsertInArea = 0;

                if (whoPlay[playerNumber].PlayerType == PlayerType.Person)
                {
                    string xyAsString = Console.ReadLine();
                    int x = int.Parse(xyAsString[0].ToString());
                    int y = int.Parse(xyAsString[2].ToString());

                    if (whoPlay[playerNumber].ValueToInsert == ValueToInsertType.X)
                        whatInsertInArea = 1;
                    if (whoPlay[playerNumber].ValueToInsert == ValueToInsertType.O)
                        whatInsertInArea = 2;
                    var insertResult = GameArea.UpdatePole(x, y, whatInsertInArea);
                    
                    if (!insertResult)
                    {
                        Console.WriteLine("select other x, y");
                        Console.ReadLine();
                        continue;
                    }
                }
                else
                {
                    if (whoPlay[playerNumber].ValueToInsert == ValueToInsertType.X)
                        whatInsertInArea = 1;
                    if (whoPlay[playerNumber].ValueToInsert == ValueToInsertType.O)
                        whatInsertInArea = 2;

                    var botXY = Bot.ChooseStep(GameArea.pole, whatInsertInArea);
                 
                    int x = int.Parse(botXY[0].ToString());
                    int y = int.Parse(botXY[2].ToString());
                    
                    var insertResult = GameArea.UpdatePole(x, y, whatInsertInArea);

                }
               
                Console.Clear();
                Console.WriteLine();
                GameArea.PrintPole();

                CheckGameStatus();
                if (IsFinish)
                {
                    Console.WriteLine("{0} is win", playerNumber == 0 ? "player" : "computer");
                }

                playerNumber++;
                if (playerNumber > 1)
                    playerNumber = 0;
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