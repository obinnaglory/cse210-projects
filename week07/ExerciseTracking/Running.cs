using System;

public class Running : Activity
{
    private double _distanceMiles;

    public Running(DateTime date, int minutes, double distanceMiles)
        : base(date, minutes)
    {
        _distanceMiles = distanceMiles;
    }

    public override double GetDistance()
    {
        return _distanceMiles;
    }

    public override double GetSpeed()
    {
        return (_distanceMiles / Minutes) * 60;
    }

    public override double GetPace()
    {
        return Minutes / _distanceMiles;
    }
}
