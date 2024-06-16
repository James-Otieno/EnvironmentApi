using System;

public abstract class Sensor
{
    protected Random random;
    protected double minValue;
    protected double maxValue;

    public Sensor(double minValue, double maxValue)
    {
        random = new Random();
        this.minValue = minValue;
        this.maxValue = maxValue;
    }

    public abstract double GenerateData();
}
