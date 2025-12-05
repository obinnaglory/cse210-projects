using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        // Encapsulated fields
        private string _title;
        private string _description;
        private int _points;

        protected Goal(string title, string description, int points)
        {
            _title = title;
            _description = description;
            _points = points;
        }

        // Read-only properties for derived classes / other code
        public string Title => _title;
        public string Description => _description;
        public int Points => _points;

        // Whether the goal is complete (only meaningful for Simple and Checklist)
        public abstract bool IsComplete { get; }

        // When the user records this goal, subclasses return how many points are earned
        public abstract int RecordEvent();

        // A short display string used when listing goals (e.g. "[X] Title (desc)")
        public virtual string GetStatusString()
        {
            string status = IsComplete ? "[X]" : "[ ]";
            return $"{status} {Title} ({Description})";
        }

        // Serialize to a single-line string for saving; subclasses append their own fields
        public abstract string GetStringRepresentation();

        // Factory method to create a Goal from a saved string
        public static Goal CreateFromString(string line)
        {
            // Format: Type|Title|Description|Points|... (type-specific extra fields)
            // We'll be defensive with parsing.
            var parts = line.Split('|');
            if (parts.Length < 4) throw new FormatException("Invalid goal line.");

            string type = parts[0];
            string title = parts[1];
            string desc = parts[2];
            if (!int.TryParse(parts[3], out int points)) points = 0;

            switch (type)
            {
                case "SimpleGoal":
                    // SimpleGoal|Title|Desc|Points|IsComplete
                    bool isComplete = parts.Length >= 5 && parts[4] == "1";
                    var sg = new SimpleGoal(title, desc, points);
                    if (isComplete) sg.ForceComplete(); // internal helper to set complete
                    return sg;

                case "EternalGoal":
                    // EternalGoal|Title|Desc|Points
                    return new EternalGoal(title, desc, points);

                case "ChecklistGoal":
                    // ChecklistGoal|Title|Desc|Points|TimesCompleted|Target|Bonus|IsComplete
                    int times = parts.Length >= 5 && int.TryParse(parts[4], out var t) ? t : 0;
                    int target = parts.Length >= 6 && int.TryParse(parts[5], out var tg) ? tg : 1;
                    int bonus = parts.Length >= 7 && int.TryParse(parts[6], out var b) ? b : 0;
                    bool clComplete = parts.Length >= 8 && parts[7] == "1";
                    var cg = new ChecklistGoal(title, desc, points, target, bonus);
                    cg.ForceTimesCompleted(times);
                    if (clComplete) cg.ForceComplete();
                    return cg;

                default:
                    throw new NotSupportedException($"Unknown goal type '{type}'");
            }
        }
    }
}
