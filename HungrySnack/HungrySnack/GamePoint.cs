using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungrySnack
{
    class GamePoint
    {
        public int posX;    //在数组中的X坐标
        public int posY;    //在数组中的Y坐标

        public void setPointXY(int x, int y)
        {
            posX = x;
            posY = y;
        }
        public GamePoint(int x, int y) {
            posX = x;
            posY = y;
        }

        public GamePoint()
        {
            posX = 0;
            posY = 0;
        }
    }
}
