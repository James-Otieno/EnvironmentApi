using System;

public class TemperatureSensor : Sensor
{
    public TemperatureSensor(double minValue, double maxValue) : base(minValue, maxValue)
    {
    }

    public override double GenerateData()
    {
        // Simulate temperature fluctuation over time
        double currentTemperature = random.NextDouble() * (maxValue - minValue) + minValue;
        double randomChange = random.NextDouble() * 2 - 1; // Random value between -1 and 1
        return currentTemperature + randomChange;
    }
}


