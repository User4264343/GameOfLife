namespace UnitTest
{
    class Program
    {
        static void Main()
        {
        }
    }

    public class Game
        {
        public bool[,] Play(bool[,] originalBoard)
        {
            bool[,] populatedBoard = new bool[originalBoard.GetLength(0), originalBoard.GetLength(1)];
            PopulateBoard(originalBoard, ref populatedBoard);
            return populatedBoard;
        }
        public bool[,] PopulateBoard(bool[,] originalBoard, ref bool[,] populatedBoard)
        {
            for (int i = 0; i < originalBoard.GetLength(0); i++)
            {
                for (int j = 0; j < originalBoard.GetLength(1); j++)
                {
                    populatedBoard[i, j] = CheckLiveness(originalBoard, i, j);
                }
            }
            return populatedBoard;
        }

        public bool CheckLiveness(bool[,] board, int x, int y)
        {
            int liveNeighbours = CountLiveNeighbours(board, x, y);
            return ApplyRules(IsLiving(board, x, y), liveNeighbours);
        }
        public bool ApplyRules(bool living, int liveNeighbours)
        {
            if ((living && liveNeighbours == 2) || liveNeighbours == 3)
            {
                return true;
            }
            return false;
        }
        public int CountLiveNeighbours(bool[,] board, int x, int y)
        {
            int liveNeighbours = 0;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i == x && j == y)
                    {
                        continue;
                    }
                    if (IsLiving(board, i, j))
                    {
                        liveNeighbours++;
                    }
                }
            }
            return liveNeighbours;
        }
        public bool IsLiving(bool[,] board, int x, int y)
        {
            if (x < 0 || y < 0 || x >= board.GetLength(0) || y >= board.GetLength(1))
            {
                return false;
            }
            return board[x, y];
        }

    }
}
