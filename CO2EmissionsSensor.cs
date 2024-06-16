using System;

public class CO2EmissionsSensor : Sensor
{
    public CO2EmissionsSensor(double minValue, double maxValue) : base(minValue, maxValue)
    {
    }

    public override double GenerateData()
    {
        // Simulate CO2 emissions variation
        double currentCO2Emissions = random.NextDouble() * (maxValue - minValue) + minValue;
        double randomChange = random.NextDouble() * 2 - 1; // Random value between -1 and 1
        return currentCO2Emissions + randomChange;
    }
}
