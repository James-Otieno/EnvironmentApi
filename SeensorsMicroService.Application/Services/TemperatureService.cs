using SeensorsMicroService.Application.Dtos;
using SeensorsMicroService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SeensorsMicroService.Application.Services
{
    public class TemperatureService : ISensorDataService<TemperatureDto>
    {
        private readonly ITemperatureRepository temperatureRepository;
        private readonly SensorsContext _sensorsContext;

        public TemperatureService(SensorsContext sensorsContext)
        {
            _sensorsContext = sensorsContext ?? throw new ArgumentNullException(nameof(SensorsContext));
        }

        public TemperatureService(ITemperatureRepository temperatureRepository)
        {
            this.temperatureRepository = temperatureRepository ?? throw new ArgumentNullException(nameof(temperatureRepository));
        }

        public void AddData(TemperatureDto data)
        {
            throw new NotImplementedException();
        }

        public void AddNewTemperatureData(TemperatureDto data)
        {
            // Basic data validation
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "Temperature data cannot be null.");
            }

            // More complex validation logic can be added here if needed

            // Call the repository method to add data
            temperatureRepository.AddNewTemperatureData(data);
        }

        //public void AddData(TemperatureDto data)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<TemperatureDto> GetAllData()
        {
            // Call the repository method to get all temperature data
            return temperatureRepository.GetAllTemperatureData();
        }

        public IEnumerable<TemperatureDto> GetDataInRange(DateTime startDate, DateTime endDate)
        {
            // Basic data validation
            if (startDate > endDate)
            {
                throw new ArgumentException("Start date cannot be after end date.");
            }

            // Call the repository method to get temperature data within the specified range
            return temperatureRepository.GetTemperatureDataInRange(startDate, endDate);
        }
    }

    public interface ITemperatureRepository
    {
      public  void AddNewTemperatureData(TemperatureDto data);
        IEnumerable<TemperatureDto> GetAllTemperatureData();
        IEnumerable<TemperatureDto> GetTemperatureDataInRange(DateTime startDate, DateTime endDate);
    }

    // Example implementation of ITemperatureRepository using in-memory storage
    public class TemperatureRepository : ITemperatureRepository
    {
        private List<TemperatureDto> temperatureData = new List<TemperatureDto>();

        public void AddNewTemperatureData(TemperatureDto data)
        {
            temperatureData.Add(data);
        }

        //public void AddNewTemperatureData(TemperatureDto data)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<TemperatureDto> GetAllTemperatureData()
        {
            return temperatureData;
        }

        public IEnumerable<TemperatureDto> GetTemperatureDataInRange(DateTime startDate, DateTime endDate)
        {
            return temperatureData.Where(d => d.Timestamp >= startDate && d.Timestamp <= endDate);
        }
    }
}