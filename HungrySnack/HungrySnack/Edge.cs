using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungrySnack
{
    class Edge:Sprite
    {
        GamePoint leftUp = new GamePoint();
        GamePoint leftDown = new GamePoint();
        GamePoint rightUp = new GamePoint();
        int length;
        int high;

        public Edge()
        {
            leftUp.setPointXY(0,0);
            leftDown.setPointXY(GameProperty.ROW,0);
            rightUp.setPointXY(0,GameProperty.COL);
            length = GameProperty.COL;
            high = GameProperty.ROW;
        }

        //输出一个墙壁
        private void PrintBlock()
        {
            System.Console.Write("■");
        }

        override public void Print()
        {
            //先输出顶部边框
            GameProperty.SetCursor(leftUp);
            for (int i = 0; i < length; i++ )
                PrintBlock();

            System.Console.Write('\n');

            //输出中间的边框
            for (int i = 0; i < high - 2; i++)
            {
                PrintBlock();
                for (int j = 0; j < length - 2; j++ )
                    System.Console.Write("  ");
                PrintBlock();
                System.Console.Write('\n');
            }
            //输出底部边框
            for (int i = 0; i < length; i++ )
                PrintBlock();
        }

        override public void SetToLogicBoard(SpriteType [,]logicBoard)
        {
            for(int i=0;i<GameProperty.COL;i++)
            {
                logicBoard[0,i] = SpriteType.WALL;
                logicBoard[GameProperty.ROW - 1 , i] = SpriteType.WALL;
            }
            for (int i = 0; i < high - 2; i++)
            {
                logicBoard[i + 1,0] = SpriteType.WALL;
                logicBoard[i + 1, GameProperty.COL - 1] = SpriteType.WALL;
            }
        }
    }
}
