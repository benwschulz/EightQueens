using System;
using System.Collections.Generic;
using System.Linq;

namespace EightQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            int boardSize = 8;

            Board board = new Board(boardSize);

            board.Solve(0);  
            board.drawBoard();
        }
    }

    public class Queen
    {
        public int x;
        public int y;

        public Queen(int X, int Y)
        {
            x = X;
            y = Y;
        }
    }

    public class Board
    {
       public List<Queen> placements;
       public int boardSize;

        public Board(int size) 
        {
            boardSize = size;
            placements = new List<Queen>();
        }

        public bool Solve(int x)
        {          
            if (placements.Count == boardSize)
                return true; 
            
            for (int y = 0; y < boardSize; y++)
            {
                if (isLegal(x, y))
                {
                    placeQueen(x, y);

                    if (Solve(x + 1))
                    {
                        return true;
                    }
                       
                    placements.Remove(
                    placements.Where(p => p.x == x && p.y == y).First());
                        
                }
            }
            
            return false;
        }
           
    

        public void placeQueen(int x, int y) => placements.Add(new Queen(x, y));

        public bool isLegal(int x, int y)
        {       
            for (int i = 1; i < boardSize; i++)
            {
                if (placements.Where(p => p.y == y).Any())
                {
                    return false;
                }

                // up and to the left
                if (placements.Where(p => 
                p.x == x - i && p.y == y + i).Any())
                {
                    return false;
                }

                // down and to the left
                if (placements.Where(p => 
                p.x == x - i && p.y == y - i).Any())
                {
                    return false;
                }

            }       

            return true;
        }

        public void drawBoard() 
        {
            for (int y = boardSize - 1; y >= 0; y--)
            {
                placements = placements.OrderBy(p => p.x).ToList();

                for (int x = 0; x < boardSize; x++)
                {
                    if (placements.Where(p => p.x == x && p.y == y).Any())
                    {   
                        Console.Write("[Q]");
                    }
                    else
                    {
                        Console.Write("[ ]");
                    }

                    if (x == boardSize - 1)
                    {
                        Console.WriteLine("\n");
                    }
                }                
            }   

            foreach (var q in placements)
            {
                Console.WriteLine(string.Format("({0},{1})", q.x, q.y));
            }       
        }
    }
}
