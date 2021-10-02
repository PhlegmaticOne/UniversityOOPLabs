using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareMatrix.Lab3.View
{
    public class SquareMatrixView
    {
        public IEnumerable<string> Input(char terminateChar)
        {
            var resultRows = new List<string>();
            string inputRow;
            while (true)
            {
                inputRow = Console.ReadLine();
                if(char.TryParse(inputRow, out char breakInput))
                {
                    if(breakInput == terminateChar)
                    {
                        break;
                    }
                }
                resultRows.Add(inputRow);
            }
            return resultRows;
        }

        public void Output(SquareMatrix matrix)
        {
            int i = 1;
            foreach (var num in matrix)
            {
                Console.Write("{0} ", num);
                if (i % matrix.Size == 0) Console.WriteLine();
                ++i;
            }
            Console.WriteLine();
        }
    }
}
