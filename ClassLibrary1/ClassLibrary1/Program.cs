using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//shalom
namespace ClassLibrary1
{
    class Program
    {
        public static void play()
        {
            //מגדיר אובייקט חדש של המחלקה MOVE
            Move move = new Move();
            //מגריל בין שני השחקנים מי ישחק ראשון
            Random rng = new Random();
            move.FlagPlayers = rng.Next(0, 2) > 0;
            //מגדיר אובייקט חדש של המחלקה INDEX
            Index idx = new Index();
            int moveI , moveJ;
            string name;
            do
            {
                string z;
                int num;
                if (move.FlagPlayers)
                    name = "playerA";
                else
                    name = "playerB";

                //מציג הודעות לשחקנים וקולט מהן מידע
                Console.WriteLine("X refers to up and down  Y refers to right and left");
                Console.WriteLine("PlayerB refers to the blue tools and PlayerA refers to the green tools");
                do
                {
                    Console.WriteLine("enter x " + name);
                    z = Console.ReadLine();
                    if (int.TryParse(z, out num)) ;
                    num = Convert.ToInt32(num);
                    idx.setI(num);
                } while (num > 6 || num < -1 || z.Length < 1);

                do
                {
                    Console.WriteLine("enter y " + name);
                    z = Console.ReadLine();
                    if (int.TryParse(z, out num)) ;
                        num = Convert.ToInt32(num);
                    idx.setJ(num);
                } while (num > 6 || num < -1 || z.Length < 1);

                do
                {
                    Console.WriteLine("enter move to X " + name);
                    z = Console.ReadLine();
                    if (int.TryParse(z, out moveI))
                        moveI = Convert.ToInt32(moveI);
                } while (moveI > 6 || moveI < -1 || z.Length < 1);

                do
                {
                    Console.WriteLine("enter move to Y " + name);
                    z = Console.ReadLine();
                    if (int.TryParse(z, out moveJ))
                        moveJ = Convert.ToInt32(moveJ);
                } while (moveJ > 6 || moveJ < -1 || z.Length < 1);

            } while (!move.move(idx, moveI, moveJ));

        }

        static void Main(string[] args)
        {
            play();
            Console.ReadLine();
        }
    }
}
