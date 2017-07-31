using System;
using System.Linq;

namespace AtestMatrixData
{
    public interface IAmatrix
    {
        int[][] Matrix { get; set; }
        int Number { get; set; }

        void GenerateMatrix(int number);
        void ReadMatrix(string[] textLines);
        void RotateMatrix();
    }
    public class Amatrix : IDisposable, IAmatrix
    {
        public int Number { get; set; }
        public int[][] Matrix { get; set; }

        public void ReadMatrix(string[] textLines)
        {
            Number = textLines.Length;
            Matrix = new int[Number][];
            for (int i = 0; i < Number; ++i)
            {
                string[] texts = textLines[i].Split(new char[] { ';' });
                int number = texts.Length;
                Matrix[i] = new int[number];
                for (int j = 0; j < number; ++j)
                {
                    int intResult;
                    int.TryParse(texts[j], out intResult);
                    Matrix[i][j] = intResult;
                }
            }
        }

        public void GenerateMatrix(int number)
        {
            Number = number;
            var count = number * number;
            var min = 0;
            var max = count * 5;
            var random = new Random();
            int[] randomInt = new int[count];
            int n = 0;
            for (int i = 0; i < count; ++i)
            {
                do
                {
                    n = random.Next(min, max);
                } while (randomInt.Contains(n));
                randomInt[i] = n;
            }

            Matrix = new int[number][];
            for (int i = 0; i < number; ++i)
            {
                Matrix[i] = new int[number];
                for (int j = 0; j < number; ++j)
                {
                    Matrix[i][j] = randomInt[i * number + j];                    
                }
            }
        }

        public void RotateMatrix()
        {
            if (Matrix != null)
            {
                int vt = 0;
                int num = 0;
                if (Number > 1)
                {
                    num = Number / 2;
                    for (int i = 0; i < num; ++i)
                    {
                        int n = Number - 2 * i - 1;
                        for (int j = 0; j < n; ++j)
                        {
                            vt = Matrix[n + i - j][i];
                            Matrix[n + i - j][i] = Matrix[n + i][n + i - j];
                            Matrix[n + i][n + i - j] = Matrix[i + j][n + i];
                            Matrix[i + j][n + i] = Matrix[i][i + j];
                            Matrix[i][i + j] = vt;
                        }
                    }
                }
            }
        }

        public void Dispose()
        {
            if(this != null)
            {
                Matrix = null;
            }
        }
    }
}
