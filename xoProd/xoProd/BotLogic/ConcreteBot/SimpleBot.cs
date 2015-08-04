using System;

namespace xoProd
{
    public class SimpleBot : AbstractBot
    {
        private int x;
        private int y;
        private int[,] pole;
        private bool succes;

        public override string ChooseStep(int[,] _pole, int valueToInsert)
        {
            succes = false;
            pole = _pole;
            
            while (!succes)
            {
                Random random = new Random();
                //wtf?!
                x = random.Next(1, 4);
                y = random.Next(1, 4);
                CheckInsert();
            }
          
            return string.Format("{0} {1}", x, y);
        }

        private void CheckInsert()
        {
            if (pole[x - 1, y - 1] == 0)
                succes = true;
        }
    }
}