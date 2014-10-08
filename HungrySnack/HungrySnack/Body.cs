using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungrySnack
{
    class Body:Sprite
    {

        public GamePoint position;

        public Body()
        {
            position = new GamePoint();
        }

        public void setPositionX(int val)
        {
            position.posX = val;
        }
        public void setPositionY(int val)
        {
            position.posY = val;
        }

        //设置身体的位置 ， 注意 x,y是在数组中的位置
        public void setPosition(int x, int y)
        {
            position.posX = x;
            position.posY = y;
        }

        override public void Print()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            GameProperty.SetCursor(position);
            System.Console.Write("⊙");
            GameProperty.retCursor();
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public override void SetToLogicBoard(SpriteType[,] logicBoard)
        {
            logicBoard[position.posX,position.posY] = SpriteType.SNACK_BODY;
        }
    }
}
