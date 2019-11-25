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

        public Score ScoreTake(string userId)
        {
            var back = _ScoreSql.ScoreTake(userId);

            if (userId == "")
            {
                return null;
            }
            return back;
        }



        public void ScoreInput(string score)
        {
            _ScoreSql.ScoreInput(score);
        }
    }
}
