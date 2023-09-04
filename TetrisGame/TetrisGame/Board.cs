using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisGame;
using static System.Reflection.Metadata.BlobBuilder;

namespace TetrisGame
{
    public class Board
    {
        public int width, height, points;

        List<Block> shape = new List<Block>();
        List<Block> blocks = new List<Block>();
        ShapeCreator shapeCreator;

        public Board(int width, int height)
        {
            this.width = width;
            this.height = height;
            shapeCreator = new ShapeCreator(width, height);
            this.shape = shapeCreator.CreateShape();
        }

        public void Read()
        {
            while (true)
            {
                var input = Console.ReadKey(true).Key;
                if (input == ConsoleKey.LeftArrow)
                {
                    var newShape = MoveShape(-1, 0);
                    if (isEverythingInsideBox(newShape))
                    {
                        shape.ForEach(item => item.Clear());
                        shape = newShape;
                        shape.ForEach(item => item.Print());
                    }
                }
                else if (input == ConsoleKey.RightArrow)
                {
                    var newShape = MoveShape(1, 0);
                    if (isEverythingInsideBox(newShape))
                    {
                        shape.ForEach(item => item.Clear());
                        shape = newShape;
                        shape.ForEach(item => item.Print());
                    }
                }
            }
        }

        //[(10,10), (10,11), (11,10), (11,11)]
        //a=-1,b=0
        //[(9,10),(9,11),(10,10),(10,11)]
        public List<Block> MoveShape(int a, int b)
        {
            var newShape = new List<Block>();
            foreach (var item in shape)
            {
                var newItem = new Block(item.x + a, item.y + b, item.ch, item.color);
                newShape.Add(newItem);
            }
            return newShape;
        }

        public void Play()
        {
            shape.ForEach(item => item.Print());
            var isGameOver = false;
            while (!isGameOver)
            {
                Console.SetCursorPosition(0, height + 2);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Points = " + points);
                Console.ForegroundColor = ConsoleColor.White;
                var newShape = MoveShape(0, 1);
                if (isEverythingInsideBox(newShape))
                {
                    shape.ForEach((item) => item.Clear());
                    shape = newShape;
                    shape.ForEach(item => item.Print());
                }
                else
                {
                    foreach (var item in shape)
                    {
                        item.ch = shapeCreator.blockChar;
                        item.color = shapeCreator.blockColor;
                        item.Print();
                    }
                    blocks.AddRange(shape);
                    shape = shapeCreator.CreateShape();
                    if (isEverythingInsideBox(shape))
                    {
                        shape.ForEach(item => item.Print());
                        ClearRow();
                    }

                    else
                    {
                        Console.SetCursorPosition(0, height + 4);
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("GameOver");
                        Console.ForegroundColor = ConsoleColor.White;
                        isGameOver = true;
                    }
                }

                Thread.Sleep(400);
            }
        }
        public void ClearRow()
        {
            for (int y = 0; y < height; y++)
            {
                var isRowFull = true;
                for (int x = 0; x < width; x++)
                {
                    if (!blocks.Any(item => item.x == x && item.y == y))
                    {
                        isRowFull = false;
                        break;
                    }
                }
                if (isRowFull)
                {
                    blocks.ForEach(item =>
                    {
                        if (item.y == y)
                        {
                            item.Clear();
                        }
                    });
                    blocks.RemoveAll(item => item.y == y);
                    blocks.ForEach(item =>
                    {
                        if (item.y < y)
                        {
                            item.Clear();
                            item.y += 1;
                            //item.Print();
                        }
                    });
                    blocks.ForEach(item =>
                    {
                        if (item.y <= y)
                        {
                            item.Print();
                        }
                    });
                    points += 10;
                }
            }
        }
        public bool isEverythingInsideBox(List<Block> newShape)
        {
            foreach (var block in newShape)
            {
                if (block.x >= 0 && block.y >= 0 &&
                    block.x < width && block.y < height)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            foreach (var block in newShape)
            {
                if (blocks.Any(item => item.x == block.x && item.y == block.y))
                {
                    return false;
                }
            }

            return true;
        }

    }
}
