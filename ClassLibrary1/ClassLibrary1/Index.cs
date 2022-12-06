using System;

namespace ClassLibrary1
{
    class Index
    {
        private int i, j;
        private char ch ;
        //בנאי ריק
        public Index()
        {


        }
        // בנאי אינדקס
        public Index(int i, int j, char ch)
        {
            this.i = i;
            this.j = j;
            this.ch = ch;

        }

      
        public int getI()
        {
            return i;
        }

        public void setI(int i)
        {
            this.i = i;
        }

        public int getJ()
        {
            return j;
        }

        public void setJ(int j)
        {
            this.j = j;
        }

        public char getCh()
        {
            return ch;
        }

        public void setCh(char ch)
        {
            this.ch = ch;
        }


    }
}
