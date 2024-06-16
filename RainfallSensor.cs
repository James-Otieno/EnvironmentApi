using System;

public class RainfallSensor : Sensor
{
    public RainfallSensor(double minValue, double maxValue) : base(minValue, maxValue)
    {
    }

    public override double GenerateData()
    {
        // Simulate rainfall variation
        double currentRainfall = random.NextDouble() * (maxValue - minValue) + minValue;
        double randomChange = random.NextDouble() * 2 - 1; // Random value between -1 and 1
        return currentRainfall + randomChange;
    }
}