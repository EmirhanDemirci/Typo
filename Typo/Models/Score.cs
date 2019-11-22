using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Typo.Models
{
    public class Score
    {
        public static Score Scores { get; set; }
        public int scoreId { get; set; }
        public string score { get; set; }
    }
}
