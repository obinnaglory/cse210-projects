using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _timesCompleted;
        private int _targetCount;
        private int _bonus;
        private bool _isComplete;

        public ChecklistGoal(string title, string description, int points, int targetCount, int bonus)
            : base(title, description, points)
        {
            _timesCompleted = 0;
            _targetCount = Math.Max(1, targetCount);
            _bonus = Math.Max(0, bonus);
            _isComplete = false;
        }

        public override bool IsComplete => _isComplete;

        // Each time returns Points; when hitting the target returns Points + Bonus and marks complete.
        public override int RecordEvent()
        {
            if (_isComplete) return 0;

            _timesCompleted++;
            if (_timesCompleted >= _targetCount)
            {
                _isComplete = true;
                return Points + _bonus;
            }
            return Points;
        }

        public override string GetStatusString()
        {
            string baseStatus = _isComplete ? "[X]" : "[ ]";
            return $"{baseStatus} {Title} ({Description}) -- Completed {_timesCompleted}/{_targetCount}";
        }

        public override string GetStringRepresentation()
        {
            // ChecklistGoal|Title|Desc|Points|TimesCompleted|Target|Bonus|IsComplete
            return $"ChecklistGoal|{Title}|{Description}|{Points}|{_timesCompleted}|{_targetCount}|{_bonus}|{(_isComplete ? "1" : "0")}";
        }

        // Helpers for loading
        public void ForceTimesCompleted(int n) => _timesCompleted = Math.Max(0, n);
        public void ForceComplete() => _isComplete = true;
    }
}
