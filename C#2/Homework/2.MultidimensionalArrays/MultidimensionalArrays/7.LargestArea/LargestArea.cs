using System;

class LargestArea
{
    static void Main()
    {
        int[,] matrix ={{1,3,2,2,2,4},
                        {3,3,3,2,4,4},
                        {4,3,1,2,3,3},
                        {4,3,1,3,3,1},
                        {4,3,3,3,1,1}
                      };
        int N = 5;
        int M = 6;
        int max = 0;

        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < M; col++)
            {
                int count=1;
                int compare = matrix[row, col];
                Area(matrix, row,col,row,col, N, M,ref count,compare);
                if (max < count)
                    max = count;
            }
        }

        Console.WriteLine(max);
    }

    static void Area(int[,] matrix, int row, int col,int nRow,int nCol, int N, int M,ref int count,int compare)
    {
        if (matrix[nRow, nCol] != int.MinValue)
        {
            if (nRow == 0 && nCol == 0)
            {
                matrix[nRow, nCol] = int.MinValue;
                if (matrix[nRow, nCol + 1] == compare)
                {
                    count++;
                    Area(matrix, row, col, nRow, nCol + 1, N, M,ref count, compare);
                }
                if(matrix[nRow+1, nCol] == compare)
                {
                    count++;
                    Area(matrix, row, col, nRow+1, nCol, N, M, ref count, compare);
                }
                
            }
            else if (nRow == 0 && nCol == M - 1)
            {
                matrix[nRow, nCol] = int.MinValue;
                if (matrix[nRow, nCol - 1] == compare)
                {
                    count++;
                    Area(matrix, row, col, nRow, nCol - 1, N, M, ref count, compare);
                }
                if (matrix[nRow + 1, nCol] == compare)
                {
                    count++;
                    Area(matrix, row, col, nRow + 1, nCol, N, M, ref count, compare);
                }
            }
            else if (nRow == N - 1 && nCol == 0)
            {
                matrix[nRow, nCol] = int.MinValue;
                if (matrix[nRow, nCol + 1] == compare)
                {
                    count++;
                    Area(matrix, row, col, nRow, nCol + 1, N, M, ref count, compare);
                }
                if (matrix[nRow - 1, nCol] == compare)
                {
                    count++;
                    Area(matrix, row, col, nRow - 1, nCol, N, M, ref count, compare);
                }
            }
            else if (nRow == N - 1 && nCol == M - 1)
            {
                matrix[nRow, nCol] = int.MinValue;
                if (matrix[nRow, nCol - 1] == compare)
                {
                    count++;
                    Area(matrix, row, col, nRow, nCol - 1, N, M, ref count, compare);
                }
                if (matrix[nRow - 1, nCol] == compare)
                {
                    count++;
                    Area(matrix, row, col, nRow - 1, nCol, N, M, ref count, compare);
                }
            }
            else if (nRow == 0)
            {
                matrix[nRow, nCol] = int.MinValue;
                if (matrix[nRow, nCol - 1] == compare)
                {
                    count++;
                    Area(matrix, row, col, nRow, nCol - 1, N, M, ref count, compare);
                }
                if (matrix[nRow, nCol + 1] == compare)
                {
                    count++;
                    Area(matrix, row, col, nRow, nCol + 1, N, M, ref count, compare);
                }
                if (matrix[nRow + 1, nCol] == compare)
                {
                    count++;
                    Area(matrix, row, col, nRow + 1, nCol, N, M, ref count, compare);
                }
            }
            else if (nRow == N - 1)
            {
                matrix[nRow, nCol] = int.MinValue;
                if (matrix[nRow, nCol - 1] == compare)
                {
                    count++;
                    Area(matrix, row, col, nRow, nCol - 1, N, M, ref count, compare);
                }
                if (matrix[nRow, nCol + 1] == compare)
                {
                    count++;
                    Area(matrix, row, col, nRow, nCol + 1, N, M, ref count, compare);
                }
                if (matrix[nRow - 1, nCol] == compare)
                {
                    count++;
                    Area(matrix, row, col, nRow - 1, nCol, N, M, ref count, compare);
                }
            }
            else if (nCol == 0)
            {
                matrix[nRow, nCol] = int.MinValue;
                if (matrix[nRow - 1, nCol] == compare)
                {
                    count++;
                    Area(matrix, row, col, nRow - 1, nCol, N, M, ref count, compare);
                }
                if (matrix[nRow, nCol + 1] == compare)
                {
                    count++;
                    Area(matrix, row, col, nRow, nCol + 1, N, M, ref count, compare);
                }
                if (matrix[nRow + 1, nCol] == compare)
                {
                    count++;
                    Area(matrix, row, col, nRow + 1, nCol, N, M, ref count, compare);
                }
            }
            else if (nCol == M - 1)
            {
                matrix[nRow, nCol] = int.MinValue;
                if (matrix[nRow - 1, nCol] == compare)
                {
                    count++;
                    Area(matrix, row, col, nRow - 1, nCol, N, M, ref count, compare);
                }
                if (matrix[nRow, nCol - 1] == compare)
                {
                    count++;
                    Area(matrix, row, col, nRow, nCol - 1, N, M, ref count, compare);
                }
                if (matrix[nRow + 1, nCol] == compare)
                {
                    count++;
                    Area(matrix, row, col, nRow + 1, nCol, N, M, ref count, compare);
                }
            }
            else
            {
                matrix[nRow, nCol] = int.MinValue;
                if (matrix[nRow - 1, nCol] == compare)
                {
                    count++;
                    Area(matrix, row, col, nRow - 1, nCol, N, M, ref count, compare);
                }
                if (matrix[nRow, nCol - 1] == compare)
                {
                    count++;
                    Area(matrix, row, col, nRow, nCol - 1, N, M, ref count, compare);
                }
                if (matrix[nRow + 1, nCol] == compare)
                {
                    count++;
                    Area(matrix, row, col, nRow + 1, nCol, N, M, ref count, compare);
                }
                if (matrix[nRow, nCol + 1] == compare)
                {
                    count++;
                    Area(matrix, row, col, nRow, nCol + 1, N, M, ref count, compare);
                }
            }
        }
        else
        {
            return;
        }
    }
}

