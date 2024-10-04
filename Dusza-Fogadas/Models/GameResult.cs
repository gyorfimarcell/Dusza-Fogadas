using System;
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

        public string SubjectName { get; set; }
        public string EventName { get; set; }

        public GameResult(int subjectId, int eventId, string outcome)
        {
            SubjectId = subjectId;
            EventId = eventId;
            Outcome = outcome;
        }

        public GameResult(GameEvent gameEvent, GameSubject subject)
        {
            SubjectId = subject.Id;
            SubjectName = subject.Name;
            EventId = gameEvent.Id;
            EventName = gameEvent.Name;
        }
    }
}
