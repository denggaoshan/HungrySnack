using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungrySnack
{
    class Head:Sprite
    {
        public GamePoint position;

        public Direction nowDirection;

        public Head()
        {
            position = new GamePoint();
        }

        public Head(Head preHead)
        {
            position = preHead.position;
            nowDirection = preHead.nowDirection;
        }

        public int getPositionX()
        {
            return position.posX;
        }

        public int getPositionY()
        {
            return position.posY;
        }
        //设置头的位置 ， 注意 x,y是在数组中的位置
        public void setPosition(int x, int y) 
        {
            position.posX = x;
            position.posY = y;
        }
        override public void Print()
        {
            GameProperty.SetCursor(position);

            Console.ForegroundColor = ConsoleColor.Green;
            if (nowDirection == Direction.UP)
            {
                System.Console.Write("∩");
            }
            else if (nowDirection == Direction.DOWN)
            {
                System.Console.Write("∪");
            }
            else if (nowDirection == Direction.LEFT)
            {
                System.Console.Write("∈");
            }
            else { 
                System.Console.Write("D");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            GameProperty.retCursor();
        }
        public override void SetToLogicBoard(SpriteType[,] logicBoard)
        {
            logicBoard[position.posX, position.posY] = SpriteType.SNACK_HEAD;
        }
    }
}
