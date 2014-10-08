using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*所有需要在屏幕上输出的物体*/
namespace HungrySnack
{
   class Sprite
   {
       virtual public void Print(){}
       virtual public void SetToLogicBoard(SpriteType[,] logicBoard) { }
    }
}
