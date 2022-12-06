using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    class  Model
    {
        //מגדיר מערך של תוים לטובת לוח המשחק
     protected  char[,] array = new char[6,6];
        //מציב בכל התאים של המערך כוכבית
        public Model()
        {
            for(int i = 0; i <6; i++)
            {
                for(int j =0; j < 6; j++)
                {
                    array[i,j] = '*';
                }
            }
        }

        //פונקציה להחזרת מערך של תויים
        public char [,] getArray()
        {
            return this.array;
        }
        //פונקציה לבדיקה איפה על לוח המשחק קיים כלי
        public bool existsToolPlayer(List<Index> player, Index idx)
        {
            for (int i = 0; i < player.Count; i++)
            {
                if (player[i].getI() == idx.getI() && player[i].getJ() == idx.getJ())
                {
                    return true;
                }
            }
            return false;
        }
        //בודק האם ואיפה קיים כלי אם כן מדפיס בצבע מתאים אם לא מדפיס כוכבית לבנה
        public void print(List<Index> playerA)
        {     
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if( array[i, j] == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    if (existsToolPlayer(playerA,new Index(i,j, array[i, j])))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    Console.Write(array[i,j]+" ");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
          

        }
        //מעדכן את לוח המשחק לאחר תנועה וממלא את המקום החסר בכוכבית
        public void updateMove(Index idx ,int moveI ,int moveJ)
        {
            array[moveI, moveJ] = array[idx.getI(), idx.getJ()];
            array[idx.getI(), idx.getJ()] = '*';
        }

        //פונקציה לבדיקה האם אחד השחקנים ניצח מתבצעת לאחר כל תזוזה
        public  bool checkWin(List<Index> playerA, List<Index> playerB)
        {
            if (playerA.Count == 0)
            {
                Console.WriteLine("PlayerB win");
                return true;
            }

            if (playerB.Count == 0)
            {
                Console.WriteLine("PlayerA win");
                return true;
            }
            return false;
        }
    }
}
