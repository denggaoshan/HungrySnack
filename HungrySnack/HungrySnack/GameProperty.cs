using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungrySnack
{
    class GameProperty
    {
        public const int ROW = 18;//行
        public const int COL = 30; //列

        public GamePoint DefaultPoint = new GamePoint(ROW,COL);


        public static void retCursor()
        {
            System.Console.SetCursorPosition(COL*2,ROW);
        }

        //将光标移动到准备绘制 point 处
        public static void SetCursor(GamePoint point)
        {
            System.Console.SetCursorPosition(point.posY*2 , point.posX);
        }
    }
}
