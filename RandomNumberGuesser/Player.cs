using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumberGuesser
{
    public class Player
    {
        public string Name { get; set; }
        public int BestScore { get; set; }

        public Player(string name, int bestScore)
        {
            Name = name;
            BestScore = bestScore;
        }

        public override string ToString()
        {
            return $"{Name}              Best Score: {BestScore}";
        }
    }
}
