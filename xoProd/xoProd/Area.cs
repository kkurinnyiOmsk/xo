using System;

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
                    Console.Write(pole[i,j] + " ");
                }

                Console.WriteLine();
            }
           
        }

        public void UpdatePole(int x, int y, int result)
        {
            pole[x, y] = result;
        }
    }
}