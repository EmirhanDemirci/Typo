using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using Typo.Dal.Database;
using Typo.Model.Models;
namespace Typo.Logic.Services
{
    public class ScoreService
    {
        private readonly ScoreSQL _ScoreSql;

        public ScoreService()
        {
            _ScoreSql = new ScoreSQL();
        }



        public void ScoreCreate(string score)
        {
            _ScoreSql.ScoreCreate(score);
        }




        public Score ScoreTake(string userId)
        {
            var Take = _ScoreSql.ScoreTake(userId);

            if (userId == "")
            {
                return null;
            }
            return Take;
        }



        public void ScoreInput(string score)
        {
            _ScoreSql.ScoreInput(score);
        }





        public Score ScoreHigh(string userId)
        {
            var High = _ScoreSql.ScoreHigh(userId);

            if (userId == "")
            {
                return null;
            }
            return High;
        }


        

        public Score ScoreAvg(string userId)
        {
            var Avg = _ScoreSql.ScoreAvg(userId);

            if (userId == "")
            {
                return null;
            }
            return Avg;
        }

    


        public Score ScoreCurrent(string userId)
        {
            var Current = _ScoreSql.ScoreCurrent(userId);

            if (userId == "")
            {
                return null;
            }
            return Current;
        }
    }
}
