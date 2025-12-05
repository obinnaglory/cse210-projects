using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string title, string description, int points)
            : base(title, description, points)
        {
        }

        // Eternal goals are never "complete"
        public override bool IsComplete => false;

        // Each record gives the configured points
        public override int RecordEvent()
        {
            return Points;
        }

        public override string GetStringRepresentation()
        {
            // EternalGoal|Title|Desc|Points
            return $"EternalGoal|{Title}|{Description}|{Points}";
        }
    }
}
