using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungrySnack
{
    class Food:Sprite
    {
        
        public GamePoint position = new GamePoint();

        public Food()
        { 
        }

        public Food(GamePoint pos)
        {
            position = pos;
        }

        public override void Print()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            GameProperty.SetCursor(position);
            System.Console.Write("☆");
            GameProperty.retCursor();
            Console.ForegroundColor = ConsoleColor.Gray;               
        }

        public override void SetToLogicBoard(SpriteType[,] logicBoard)
        {
            logicBoard[position.posX, position.posY] = SpriteType.FOOD;
        }
    }
}
