using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

//游戏主类
namespace HungrySnack
{

    enum SpriteType
    {
        EMPTY,
        SNACK_HEAD,
        SNACK_BODY,
        WALL,
        FOOD
    }

    class Game
    {
        int CleanCount = 0;

        const int ROW = GameProperty.ROW ;
        const int COL = GameProperty.COL ;

        int Interval = 500;

        Food nowFood = new Food();

        SpriteType [,]LogicBoard = new SpriteType[ROW,COL];

        Random rand = new Random();
        Edge edge ;
        Snack snack ;

        Timer aTimer;

        public Game()
        {
            
         edge = new Edge();
         edge.SetToLogicBoard(LogicBoard);
         snack = new Snack();
         snack.SetToLogicBoard(LogicBoard);
         Console.ForegroundColor = ConsoleColor.Gray;

         Console.BackgroundColor = ConsoleColor.White;
         for (int i = 0; i < 1000; i++)
             Console.WriteLine("              ");
        }
            
        public SpriteType getLogicBoardType(int x,int y)
        {
            return LogicBoard[x, y]; 
        }

        public void run()
        {
            nowFood = new Food(getFoodPosition());
            BeginTimer();
            while (true)
            {
                Paint();
                ConsoleKeyInfo keyval = Console.ReadKey(true);
                Direction dir = judgeDirection(keyval.KeyChar);
                if (dir != Direction.INVALID)
                {
                    snack.ChangeDirection(dir);
                }
            }
        }

        private void EatFood()
        {
            snack.AddLength();
            nowFood = new Food(getFoodPosition());
        }

        private void GameOver()
        {
            System.Console.Clear();
            System.Console.WriteLine("G a m e   O v e r !");
            System.Console.ReadLine();
        }

        private void UpDateLogicBoard()
        {
            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    LogicBoard[i, j] = SpriteType.EMPTY;
                }
            }

            edge.SetToLogicBoard(LogicBoard);
            snack.SetToLogicBoard(LogicBoard);
            nowFood.SetToLogicBoard(LogicBoard);
        }

        private void BeginTimer()
        {
            aTimer = new System.Timers.Timer(10000);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = Interval;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            SnackAutoMove();
        }

        //生成一个随机点
        private GamePoint getRandomPoint()
        {
            GamePoint ret = new GamePoint();
            ret.posX = 1 + rand.Next() % (ROW - 2);
            ret.posY = 1 + rand.Next() % (COL - 2);
            return ret;
        }
        private GamePoint getFoodPosition()
        {
            GamePoint ret ;
            SpriteType nowType ;
            do
            {
            ret = getRandomPoint();
            nowType = LogicBoard[ret.posX, ret.posY];
            }while( nowType != SpriteType.EMPTY );

            return ret;
        }

        //自动移动
        private void SnackAutoMove() {
            Situation situation = new Situation();
            situation = CheckSituation();
            if (situation.Equals(Situation.DIE))
            {
                GameOver();
            }
            else if (situation.Equals(Situation.EATFOOD))
            {
                EatFood();
            }else
            {
                snack.SnackMove();
                UpDateLogicBoard();
            }
            Paint();
        }

        public void Paint()
        {
            if (++CleanCount >= 10)
            {
                System.Console.Clear();
                CleanCount = 0;
            }
            edge.Print();
            snack.Print();
            nowFood.Print();
        }

        private Direction judgeDirection(char keyval)
        {
            Direction ret = new Direction();
            ret = Direction.INVALID;
            switch (keyval)
            {
                case 'W':case'w':
                    if(snack.head.nowDirection != Direction.DOWN)
                        ret = Direction.UP;
                    break;
                case 'A':case'a':
                    if(snack.head.nowDirection != Direction.RIGHT)
                        ret = Direction.LEFT;
                    break;
                case 'S':case's':
                    if(snack.head.nowDirection != Direction.UP)
                        ret = Direction.DOWN;
                    break;
                case 'D':case'd':
                    if(snack.head.nowDirection != Direction.LEFT)
                        ret = Direction.RIGHT;
                    break;
            }

            return ret;

    }
       

        private Situation CheckPoint(GamePoint point)
        {
            Situation ret = new Situation();
            SpriteType nowType = LogicBoard[point.posX, point.posY];

            if (nowType == SpriteType.WALL  )
            {
                ret = Situation.DIE;
            }
            else if (nowType== SpriteType.SNACK_BODY)
            {
                ret = Situation.DIE;
            }
            else if (nowType == SpriteType.FOOD) 
            {
                ret = Situation.EATFOOD;
            }
            else if (nowType == SpriteType.EMPTY) 
            {
                ret = Situation.NORMAL;
            }
            return ret;
        }

        //检测移动的状态
        private Situation CheckSituation()
        {
            GamePoint nextPoint = new GamePoint();
            nextPoint.setPointXY(snack.head.position.posX,snack.head.position.posY);

            switch (snack.head.nowDirection)
            {
                case Direction.UP: nextPoint.posX -= 1;
                    break;
                case Direction.DOWN: nextPoint.posX += 1;
                    break;
                case Direction.LEFT: nextPoint.posY -= 1;
                    break;
                case Direction.RIGHT: nextPoint.posY += 1;
                    break;
            }
            return CheckPoint(nextPoint);
        }

    }
}
