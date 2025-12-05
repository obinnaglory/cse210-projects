using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string title, string description, int points) 
            : base(title, description, points)
        {
            _isComplete = false;
        }

        public override bool IsComplete => _isComplete;

        // Marks complete the first time and returns points only once.
        public override int RecordEvent()
        {
            if (_isComplete) return 0;
            _isComplete = true;
            return Points;
        }

        public override string GetStringRepresentation()
        {
            // SimpleGoal|Title|Desc|Points|IsComplete
            return $"SimpleGoal|{Title}|{Description}|{Points}|{(_isComplete ? "1" : "0")}";
        }

        // Helpers for loading
        public void ForceComplete() => _isComplete = true;
    }
}
