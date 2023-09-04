using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisGame;

namespace TetrisGame
{
    public class ShapeCreator
    {
        public int width, height;
        public char shapeChar = '@';
        public char blockChar = '#';
        public ConsoleColor shapeColor = ConsoleColor.Red;
        public ConsoleColor blockColor = ConsoleColor.Green;
        Random rand = new Random();

        public ShapeCreator(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public List<Block> CreateShape()
        {
            var r = rand.Next(9);
            switch (r)
            {
                case 0:
                    return CreateLineVertical();
                case 1:
                    return CreateLineHorizondal();
                case 2:
                    return CreateHShape();
                case 3:
                    return CreateLeftHShape();
                case 4:
                    return CreateLineVertical();
                case 5:
                    return CreateLineHorizondal();
                case 6:
                    return CreateSquare();
                case 7:
                    return CreateSquare();
                default:
                    break;
            }
            return CreateSquare();
        }
        public List<Block> CreateSquare()
        {
            var square = new List<Block>();
            int w = rand.Next(width - 1);
            square.Add(new Block(w, 0, shapeChar, shapeColor));
            square.Add(new Block(w + 1, 0, shapeChar, shapeColor));
            square.Add(new Block(w, 1, shapeChar, shapeColor));
            square.Add(new Block(w + 1, 1, shapeChar, shapeColor));
            return square;
        }
        public List<Block> CreateLineVertical()
        {
            var line = new List<Block>();
            int w = rand.Next(width);
            line.Add(new Block(w, 0, shapeChar, shapeColor));
            line.Add(new Block(w, 1, shapeChar, shapeColor));
            line.Add(new Block(w, 2, shapeChar, shapeColor));
            line.Add(new Block(w, 3, shapeChar, shapeColor));
            return line;
        }
        public List<Block> CreateLineHorizondal()
        {
            var line = new List<Block>();
            int w = rand.Next(width - 3);
            line.Add(new Block(w, 0, shapeChar, shapeColor));
            line.Add(new Block(w + 1, 0, shapeChar, shapeColor));
            line.Add(new Block(w + 2, 0, shapeChar, shapeColor));
            line.Add(new Block(w + 3, 0, shapeChar, shapeColor));
            return line;
        }
        public List<Block> CreateHShape()
        {
            var line = new List<Block>();
            int w = rand.Next(width - 1);
            line.Add(new Block(w, 0, shapeChar, shapeColor));
            line.Add(new Block(w, 1, shapeChar, shapeColor));
            line.Add(new Block(w + 1, 1, shapeChar, shapeColor));
            line.Add(new Block(w + 1, 2, shapeChar, shapeColor));
            return line;
        }
        public List<Block> CreateLeftHShape()
        {
            var line = new List<Block>();
            int w = rand.Next(width - 1);
            line.Add(new Block(w + 1, 0, shapeChar, shapeColor));
            line.Add(new Block(w, 1, shapeChar, shapeColor));
            line.Add(new Block(w + 1, 1, shapeChar, shapeColor));
            line.Add(new Block(w, 2, shapeChar, shapeColor));
            return line;
        }
    }
}
