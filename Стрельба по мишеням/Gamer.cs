using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Стрельба_по_мишеням
{
    class Gamer
    {
        public Gamer() { }

        public int Id {get; set;}
        public string Nickname { get; set; }
        public int Score { get; set; }
        
        public string Complexity { get; set; }


        public Gamer(string Nickname, int Score, string Complexity)
        {
            this.Nickname = Nickname;
            this.Score = Score;
            this.Complexity = Complexity;
        }

    }
}
