using System;

public class AirPollutionSensor : Sensor
{
    public AirPollutionSensor(double minValue, double maxValue) : base(minValue, maxValue)
    {
    }

    public override double GenerateData()
    {
        // Simulate air pollution variation
        double currentPollution = random.NextDouble() * (maxValue - minValue) + minValue;
        double randomChange = random.NextDouble() * 2 - 1; // Random value between -1 and 1
        return currentPollution + randomChange;
    }
}