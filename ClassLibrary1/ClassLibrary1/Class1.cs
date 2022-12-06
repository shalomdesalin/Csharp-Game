using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    class Tool:Model
    {
        private List<Index> playerA = new List<Index>();
        private List<Index> playerB = new List<Index>();
        public Tool() { }
        public void simpleToolA(Index Index)
        {
            playerA.Add( Index);
        }
        public void SpecialToolA(Index Index)
        {
            playerA.Add(Index);
        }
        public void superToolA(Index Index)
        {
            playerA.Add(Index);
        }
        public void simpleToolB(Index Index)
        {
            playerB.Add(Index);
        }
        public void SpecialToolB(Index Index)
        {
            playerB.Add(Index);
        }
        public void superToolB(Index Index)
        {
            playerB.Add(Index);
        }
    }
    
}
