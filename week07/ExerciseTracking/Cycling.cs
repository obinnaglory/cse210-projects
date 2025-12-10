using System;

public class Cycling : Activity
{
    private double _speedMph;

    public Cycling(DateTime date, int minutes, double speedMph)
        : base(date, minutes)
    {
        _speedMph = speedMph;
    }

    public override double GetDistance()
    {
        return (_speedMph * Minutes) / 60;
    }

    public override double GetSpeed()
    {
        return _speedMph;
    }

    public override double GetPace()
    {
        return Minutes / GetDistance();
    }
}
