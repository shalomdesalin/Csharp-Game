using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    class Move 
    {
        //מגדיר משתנה בשם דגל מסוג בולייאני
        private bool flagPlayers = false;
        //מגדיר אובייקט מסוג כלי משחק
        private PlyersTools playersTools;
        //פונקציה להגדרת כלי משחק חדש
        public Move()
        {
            playersTools = new PlyersTools();
        }

        //גט וסט למשתנה הדגל
        public bool FlagPlayers
        {
            get { return flagPlayers; }
            set { flagPlayers = value; }
        }
        //פונקציה להחזרת התו שמייצג כלי
        public char getTool(int i, int j)
        {
            return playersTools.getArray()[i, j];
        }

        //פונקציה לקביעה איזה כלים יזוזו של שחקן  הראשון או השני
        public bool move(Index idx, int moveI, int moveJ)
        {
            idx.setCh( playersTools.getArray()[idx.getI(), idx.getJ()]);
            List<Index> player;
            //אם הדגל==אמת שחקן ראשון 
            if (flagPlayers)
            {
                player = playersTools.PlayerA;
            }
            //אחרת השחקן השני
            else
            {
                player = playersTools.PlayerB;
            }

            

            if (playersTools.existsToolPlayer(player, idx))
            { 
                //בודק האם המשתמש בחר בקלי תקין ואיזה סוג הוא בחר
                if (!playersTools.existsToolPlayer(player, new Index(moveI, moveJ, idx.getCh())))
                {                   
                    bool b = false;
                    switch (idx.getCh())
                    {
                        case 'A':
                            b = simpleMove(idx, moveI, moveJ);//מחזיר אמת או שקר

                            break;
                        case 'B':
                            b = sophisticatedMove(idx, moveI, moveJ);//מחזיר אמת או שקר
                            break;
                        case 'S':
                            b = superMove(player,idx, moveI, moveJ);//מחזיר אמת או שקר
                            break;                     
                    }
                    if (b)//אם נבחר אחד הכלים אז
                    {
                        if (flagPlayers)//בודק איזה שחקן נבחר
                        {
                            //נבחר השחקן הראשון לכן נעדכן את התזוזה שלו ברשימת האינדקסים
                            playersTools.updateAndCheckRemoveFromToolsPlayers(playersTools.PlayerA, playersTools.PlayerB, idx, moveI, moveJ);
                        }
                        else
                        {
                            //במידה והדגל מחזיר שקר נבחר השחקן השני לכן נעדכן את רשימת האינדקסים של השחקן השני
                            playersTools.updateAndCheckRemoveFromToolsPlayers(playersTools.PlayerB, playersTools.PlayerA, idx, moveI, moveJ);

                        }
                        flagPlayers = !flagPlayers;//מעבר בין שחקנים כדי לחייב מהלך אחד בכול תור
                        Console.Clear();
                        playersTools.print(playersTools.PlayerA);//הדפסה מחדש לאחר תזוזה
                        if (playersTools.checkWin(playersTools.PlayerA ,playersTools.PlayerB))//בדיקה האם אחד השחקנים ניצח
                        {
                            return true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("cannot move");
                    }

                }
                else
                {
                    Console.WriteLine("allready Exists");
                }
            }
            else
            {
                Console.WriteLine("Tool not Exists");
            }
            return false;
        }

        //מגדיר את התנאים והחוקים איתם אפשר להשתמש בסופר כלי
        public bool superMove(List<Index> player, Index idx, int moveI, int moveJ)
        {
            if (flagPlayers)
            {
                if (idx.getI() + 2 == moveI && idx.getJ() == moveJ || idx.getJ() - 2 == moveJ && idx.getI() == moveI)
                {
                    return true;
                }

                if (idx.getI() - 2 == moveI && idx.getJ() == moveJ || idx.getJ() + 2 == moveJ && idx.getI() == moveI)
                {
                    return true;
                }


                else
                {
                    Console.WriteLine("Canno't move check movI movJ");
                }
                return false;
            }
            else
            {
                if (idx.getI() - 2 == moveI && idx.getJ() == moveJ || idx.getJ() + 2 == moveJ && idx.getI() == moveI)
                {
                    return true;
                }
                //////בודק האם ההכלי הנבחר יכול לזוז לנקודה
                else
                {
                    Console.WriteLine("Canno't move check movI movJ");
                }
                return false;
            }



        }


        //מגדיר את התנאים והחוקים איתם אפשר להשתמש בכלי משחק הפשוט
        public bool simpleMove(Index idx, int moveI, int moveJ)
        {
            if (flagPlayers)
            {
                if (idx.getI() + 1 == moveI && idx.getJ() == moveJ || idx.getJ() - 1 == moveJ && idx.getI() == moveI)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Canno't move check movI /////////////////////movJ");
                }
                return false;
            }
            else
            {
                if (idx.getI() - 1 == moveI && idx.getJ() == moveJ || idx.getJ() + 1 == moveJ && idx.getI()  == moveI)
                {
                    return true;
                }
                //////בודק האם ההכלי הנבחר יכול לזוז לנקודה
                else
                {
                    Console.WriteLine("Canno't move check movI movJ");
                }
                return false;
            }
                   
            
        }

        //מגדיר את התנאים והחוקים איתם אפשר להשתמש בכלי משחק המשוכלל
        public bool sophisticatedMove(Index idx, int moveI, int moveJ)
            {

            if (idx.getI() + 1 == moveI && idx.getJ() + 1 == moveJ ||
                idx.getJ() - 1 == moveJ && idx.getI() - 1 == moveI ||
                idx.getI() + 1 == moveI && idx.getJ() - 1 == moveJ ||
                idx.getJ() + 1 == moveJ && idx.getI() - 1 == moveI)
            {
                return true;

            }
            else
            {
                Console.WriteLine("Canno't move check movI movJ");

            }
            return false;
            
        }
      
    }

    

        
}

