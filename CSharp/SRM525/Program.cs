using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SRM525
{

    public class RainyRoad
    {
        public string isReachable(string[] road)
        {
            for (int i = 0; i < road[0].Length; i++)
            {
                if (road[0][i] == 'W' && road[1][i] == 'W')
                {
                    return "NO";
                }
            }
            return "YES";
        }
    }

    public class DropCoins
    {
        public int getMinimum(string[] bStr, int K)
        {
            var startBoard = new Board(bStr);

            //int minMoves = Int32.MaxValue;

            int minMoves = MoveUntilK(startBoard, K);

            return minMoves;
        }

        private int MoveUntilK(Board startBoard, int k)
        {
            Board prevBoard = new Board(startBoard);
            int n = startBoard.B.Length;
            int m = startBoard.B[0].Length;

            int minMoves = Int32.MaxValue;

            for (int i = 0; i < n; i++)
            {
                var upBoard = new Board(startBoard);

                for (int __i = 0; __i < i; __i++) upBoard.Up();

                if (upBoard.TotalSum < k)
                    continue;

                for (int j = 0; j < m; j++)
                {
                    var leftBoard = new Board(upBoard);

                    for (int ___i = 0; ___i < j; ___i++) leftBoard.Left();

                    if (leftBoard.TotalSum < k)
                        continue;


                    for (int kk = 0; kk < n; kk++)
                    {
                        var downBoard = new Board(leftBoard);

                        for (int ___i = 0; ___i < kk; ___i++) downBoard.Down();

                        if (downBoard.TotalSum < k)
                            continue;


                        for (int kkk = 0; kkk < m; kkk++)
                        {
                            var rightBoard = new Board(downBoard);

                            for (int ___i = 0; ___i < kkk; ___i++) rightBoard.Right();

                            if (rightBoard.TotalSum < k)
                                continue;

                            ///////

                            if (rightBoard.TotalSum == k)
                            {
                                int moves = i + j + kk + kkk;
                                if (moves < minMoves)
                                {
                                    minMoves = moves;
                                }
                            }

                        }
                    }

                }


            }


            return minMoves;
        }


        public class Board
        {
            public Board(Board board)
            {
                B = new bool[board.B.Length][];
                for (int i = 0; i < board.B.Length; i++)
                {
                    B[i] = new bool[board.B[i].Length];
                    board.B[i].CopyTo(B[i], 0);
                }
                

                UpPos = board.UpPos;
                LeftPos = board.LeftPos;
                RightPos = board.RightPos;
                DownPos = board.DownPos;

                TotalSum = board.TotalSum;
            }

            public Board(string[] board)
            {
                int totalSum = 0;
                B = new bool[board.Length][];

                for (int i = 0; i < B.Length; i++)
                {
                    B[i] = new bool[board[i].Length];
                    for (int j = 0; j < board[i].Length; j++)
                    {
                        if (board[i][j] == 'o')
                        {
                            B[i][j] = true;
                            totalSum++;
                        }
                    }
                }
                UpPos = 0;
                LeftPos = 0;
                RightPos = B[0].Length-1;
                DownPos = B.Length-1;

                TotalSum = totalSum;
            }

            public bool[][] B { get; set; }

            public int UpPos { get; set; }
            public int DownPos { get; set; }
            public int LeftPos { get; set; }
            public int RightPos { get; set; }

            public int TotalSum { get; set; }

            public int Up()
            {
                UpPos += 1;
                DownPos += 1;
                if (UpPos < 0)
                {
                    return TotalSum;
                }

                int rowSum = 0;
                for (int i = 0; i < B[UpPos].Length; i++)
                {
                    if (B[UpPos][i])
                    {
                        rowSum++;
                        // get rid of it
                        B[UpPos][i] = false;
                    }
                }
                TotalSum -= rowSum;

                return TotalSum;
            }

            public int Down()
            {
                DownPos -= 1;
                UpPos -= 1;
                if (DownPos >= B.Length)
                {
                    return TotalSum;
                }

                int rowSum = 0;
                for (int i = 0; i < B[DownPos].Length; i++)
                {
                    if (B[DownPos][i])
                    {
                        rowSum++;
                        // get rid of it
                        B[DownPos][i] = false;
                    }
                }
                TotalSum -= rowSum;

                return TotalSum;
            }

            public int Left()
            {
                LeftPos += 1;
                RightPos += 1;
                if (LeftPos < 0)
                {
                    // we will need few more times to move it left till coins drop
                    return TotalSum;
                }

                int colSum = 0;
                for (int i = 0; i < B.Length; i++)
                {
                    if (B[i][LeftPos])
                    {
                        colSum++;
                        // get rid of it
                        B[i][LeftPos] = false;
                    }
                }
                TotalSum -= colSum;

                return TotalSum;
            }

            public int Right()
            {
                RightPos -= 1;
                LeftPos -= 1;
                if (RightPos >= B[0].Length)
                {
                    // try more times to the right...
                    return TotalSum;
                }

                int colSum = 0;
                for (int i = 0; i < B.Length; i++)
                {
                    if (B[i][RightPos])
                    {
                        colSum++;
                        // get rid of it
                        B[i][RightPos] = false;
                    }
                }
                TotalSum -= colSum;

                return TotalSum;
            }

        }
    }

    [TestFixture]
    internal class TopCoderTests
    {
        [Test]
        public void Problem1_Test1()
        {
            var target = new DropCoins();

            string[] board = new string[]
                                 {
                                     ".o.."
                                     , "oooo"
                                     , "..o."
                                 };

            long result = target.getMinimum(board, 3);

            var expected = 2;
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Problem1_Test2()
        {
            var target = new DropCoins();

            string[] board = new string[]
                                 {
                                     ".o.."
                                     , "oooo"
                                     , "..o."
                                 };

            long result = target.getMinimum(board, 3);

            var expected = 2;
            Assert.That(result, Is.EqualTo(expected));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
