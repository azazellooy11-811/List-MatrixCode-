using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static List<List<int>> mainMatrix;
        static void initMatrix(ref List<List<int>> m,int[][] matrix )
        {   
            for (int j = 0; j < matrix.Length; j++)
            {

                List<int> sublist = new List<int>();
                for (int i = 0; i < matrix.Length; i++)
                {

                    sublist.Add(0);

                }

                m.Add(sublist);

            }

        }

        static void MatrixCode(int[][] matrix)
        {

            mainMatrix = new List<List<int>>();
            initMatrix(ref mainMatrix, matrix);
        }


        static int[][] decode()
        {
            int[][] matrix = new int[mainMatrix.Count][];
            for (int j = 0; j < mainMatrix.Count; j++)
            {

                for (int i = 0; i < mainMatrix.Count; i++)
                {

                    matrix[i][j] = 0;

                }


            }


            return matrix;
        }

        static void insert(int i, int j, int value)
        {

            if (mainMatrix == null) mainMatrix = new List<List<int>>();

            mainMatrix[i][j] = value;



        }

        static void delete(int i, int j)
        {
            insert(i, j, 0);
        }

        static ArrayList minList()
        {

            ArrayList minArr = new ArrayList();
            for (int i = 0; i < mainMatrix.Count; i++)
            {
                int minValue = Int32.MaxValue;

                for (int j = 0; j < mainMatrix.Count; j++)
                {
                     
                    int value = mainMatrix[j][i];
                    minValue = Math.Min(minValue,value);
                    Console.WriteLine("значение для строки:" +i+"x"+ j + "=" + value+ " min="+minValue);
                }

                minArr.Add(minValue);
                Console.WriteLine("Минимальное значение для столбца:" + i + "=" + minValue);
            }

                return minArr;

        }

        static int sumDiag()
        {
            int sum = 0;
            for (int i = 0; i < mainMatrix.Count; i++)
            {
                sum += mainMatrix[i][i]; 
            }
                return sum;

        }

        static void transp()
        {
            List<List<int>> tMatrix = new List<List<int>>();
            initMatrix(ref tMatrix, new int[mainMatrix.Count][]);

            for (int row = 0; row < mainMatrix.Count; row++)
            {

                for (int col = 0; col < mainMatrix.Count; col++)
                {
                    tMatrix[row][col] = mainMatrix[col][row];
                }


            }
            mainMatrix = tMatrix;
        }

        static void sumCols(ref int j1, int j2)
        {
            int sum = 0;
            for (int i = 0; i < mainMatrix.Count; i++)
            {
                sum += mainMatrix[i][j1];
            }
            for (int i = 0; i < mainMatrix.Count; i++)
            {
                sum += mainMatrix[i][j2];
            }
            j1 = sum;
            

        }



        static void Display(List<List<int>> list)
        {
            
            Console.WriteLine("Элементы:");
            foreach (var sublist in list)
            {
                foreach (var value in sublist)
                {
                    Console.Write(value);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
            
            int count = 0;
            foreach (var sublist in list)
            {
                count += sublist.Count;
            }
            Console.WriteLine("Количество:");
            Console.WriteLine(count);
        }

        static void Main(string[] args)
        {
            int[][] matrix = new int [3][];


            MatrixCode(matrix);
            Display(mainMatrix);
            insert(0, 0, 2);
            insert(0, 1, 3);
            insert(0, 2, 5);
            insert(1, 0, 1);
            insert(1, 1, 2);
            insert(1, 2, 4);
            insert(2, 0, 1);
            insert(2, 1, 4);
            insert(2, 2, 3);
            Display(mainMatrix);
            delete(0, 0);
            minList();
            Display(mainMatrix);
            Console.WriteLine("Сумма по главной диагонали:" +sumDiag());
            int sum = 0;
            sumCols(ref sum,2);
            Console.WriteLine("Сумма столбцов:" + sum);
            
            transp();
            Display(mainMatrix);
            Console.ReadKey();

        }
    }
}
