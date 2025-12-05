using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals = new List<Goal>();
        private int _score = 0;

        public int Score => _score;
        public IReadOnlyList<Goal> Goals => _goals.AsReadOnly();

        public void AddGoal(Goal g) => _goals.Add(g);

        // Record an event for a specific goal index (returns points gained)
        public int RecordEvent(int goalIndex)
        {
            if (goalIndex < 0 || goalIndex >= _goals.Count) return 0;
            int points = _goals[goalIndex].RecordEvent();
            _score += points;
            return points;
        }

        public void ShowGoals()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals yet.");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetStatusString()}");
            }
        }

        public void SaveToFile(string filename)
        {
            var lines = new List<string>();
            lines.Add(_score.ToString());
            foreach (var g in _goals)
            {
                lines.Add(g.GetStringRepresentation());
            }
            File.WriteAllLines(filename, lines);
        }

        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename)) throw new FileNotFoundException();
            var lines = File.ReadAllLines(filename);
            if (lines.Length == 0) return;

            _goals.Clear();
            if (!int.TryParse(lines[0], out int loadedScore)) loadedScore = 0;
            _score = loadedScore;

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;
                var g = Goal.CreateFromString(lines[i]);
                _goals.Add(g);
            }
        }
    }
}
