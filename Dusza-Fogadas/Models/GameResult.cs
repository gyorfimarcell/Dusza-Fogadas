﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dusza_Fogadas.Models
{
    public class GameResult
    {
        public int SubjectId { get; set; }
        public int EventId { get; set; }
        public string Outcome { get; set; }

        public GameResult(int subjectId, int eventId, string outcome)
        {
            SubjectId = subjectId;
            EventId = eventId;
            Outcome = outcome;
        }
    }
}
