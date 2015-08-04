using System;
using System.Globalization;

namespace xoProd
{
    public class Area
    {
        int [,] pole = new int[3,3];

        public Area()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    pole[i, j] = 0;
                }   
            }
        }

        public void PrintPole()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (pole[i, j] == 1)
                        Console.Write("[X] ");
                    if(pole[i,j] == 2)
                        Console.Write("[O] ");
                    if (pole[i, j] == 0)
                        Console.Write("[] ");


                }
                Console.WriteLine();
            }
           
        }

        public bool UpdatePole(int x, int y, int value)
        {
            bool result = false;
            if (pole[x, y] == 0)
            {
                pole[x, y] = value;
                result = true;
            }
            else
                result = false;

            return result;
        }

        public bool CheckRows()
        {
            bool result =false;

            for (int i = 0; i < 3; i++)
            {
                if ((pole[i, 0] ==1  && pole[i, 1] == 1 && pole[i, 2] == 1)
                    || (pole[i, 0] == 2 && pole[i, 1] == 2 && pole[i, 2] == 2))
                    result = true;
            }
            return result;
        }

        public bool CheckCollumns()
        {
            bool result = false;

            for (int i = 0; i < 3; i++)
            {
                if ((pole[0, i] == 1 && pole[1, i] == 1 && pole[2, i] == 1) ||
                (pole[0, i] == 2 && pole[1, i] == 2 && pole[2, i] == 2))
                    result = true;
            }
            return result;
        }

        public bool CheckDiagonal()
        {
            if ((pole[0, 0] == 1 && pole[1, 1] == 1 && pole[2, 2] == 1)||
                (pole[0, 0] == 2 && pole[1, 1] == 2 && pole[2, 2] == 2))
                return true;
            if ((pole[2, 0] == 1 && pole[1, 1] == 1 && pole[0, 2] == 1)||
                (pole[2, 0] ==2 && pole[1, 1] ==2 && pole[0, 2] ==2))
                return true;

            return false;
        }

        public bool CheckNombers()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (pole[i, j] == 0)
                        return false;
                }
            }
            return true;
        }
    }

}