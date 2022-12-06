using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class PlyersTools : Model 
    {
        //מגדיר רשימה של מיקומי כלים לשחקן הראשון
       //פרטית
        private List<Index> playerA = new List<Index>();
        //מגדיר רשימה של מיקומי כלים לשחקן שני
        //פרטית
        private List<Index> playerB = new List<Index>();
        public PlyersTools()
        {

            // מכניס את המיקומים של הכלים לרשימת האינדקסים של השחקן הראשון
            playerA.Add(new Index(0, 5, 'S'));
            playerA.Add(new Index(0, 3, 'B'));
            playerA.Add(new Index(0, 1, 'B'));
            playerA.Add(new Index(1, 5, 'A'));
            playerA.Add(new Index(1, 4, 'A'));
           playerA.Add(new Index(1, 2, 'A'));
            // מכניס את המיקומים של הכלים לרשימת האינדקסים של השחקן השני
           playerB.Add(new Index(5, 0, 'S'));
         playerB.Add(new Index(5, 2, 'B'));
            playerB.Add(new Index(5, 4, 'B'));
            playerB.Add(new Index(4, 0, 'A'));
            playerB.Add(new Index(4, 1, 'A'));
            playerB.Add(new Index(4, 3, 'A'));

            //שולח להדפסה על לוח המשחק את הכלים לשחקן הראשון
            for (int i = 0; i < playerA.Count; i++)
            {
                array[playerA[i].getI(), playerA[i].getJ()] = playerA[i].getCh();
            }

            //שולח להדפסה את הכלים של השחקן השני
            for (int i = 0; i < playerB.Count; i++)
            {
                array[playerB[i].getI(), playerB[i].getJ()] = playerB[i].getCh();
            }
            //מדפיס את לוח המשחק
            print(playerA);
        }
        //ציבורית
        public List<Index> PlayerA
        {
            get { return playerA; }
            set { playerA = value; }
        }
        //ציבורית
        public List<Index> PlayerB
        {
            get { return playerB; }
            set { playerB = value; }
        }  
         //מעדכן את רשימת האינדקסים של הכלים לאחר תנועה ותנאי בדיקה
        public void updateAndCheckRemoveFromToolsPlayers(List<Index> playerUpdate, List<Index> playerRemove, Index idx, int moveI, int moveJ)
        {
            //שימוש בהורשה
            updateMove(idx,moveI,moveJ);
            //מוסיף לרשימה
            for (int i = 0; i < playerUpdate.Count; i++)
            {
                if (playerUpdate[i].getCh() == idx.getCh() && playerUpdate[i].getJ() == idx.getJ() && playerUpdate[i].getI() == idx.getI())
                {
                    playerUpdate[i] = new Index(moveI, moveJ, idx.getCh());
                }
            }

            //מסיר מהרשימה
            for (int i = 0; i < playerRemove.Count; i++)
            {
                if (playerRemove[i].getJ() == moveJ && playerRemove[i].getI() == moveI)
                {
                    playerRemove.RemoveAt(i);
                }

            }

          

        }

     
    }
}
