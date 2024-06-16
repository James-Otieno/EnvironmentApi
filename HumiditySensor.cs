using System;

public class HumiditySensor : Sensor
{
    public HumiditySensor(double minValue, double maxValue) : base(minValue, maxValue)
    {
    }

    public override double GenerateData()
    {
        // Simulate humidity variation
        double currentHumidity = random.NextDouble() * (maxValue - minValue) + minValue;
        double randomChange = random.NextDouble() * 2 - 1; // Random value between -1 and 1
        return currentHumidity + randomChange;
    }
}




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