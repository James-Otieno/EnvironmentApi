using SeensorsMicroService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeensorsMicroService.Application.Services
{
    public class HumidityService : ISensorDataService<HumidityDto>
    {
        private readonly IHumidityRepository humidityRepository;

        public HumidityService(IHumidityRepository humidityRepository)
        {
            this.humidityRepository = humidityRepository ?? throw new ArgumentNullException(nameof(humidityRepository));
        }

        public void AddData(HumidityDto data)
        {
            throw new NotImplementedException();
        }

        public void AddNewHumidityData(HumidityDto data)
        {
            // Basic data validation
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "Humidity data cannot be null.");
            }

            // More complex validation logic can be added here if needed

            // Call the repository method to add data
            humidityRepository.AddHumidityData(data);
        }

        //public void AddData(HumidityDto data)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<HumidityDto> GetAllData()
        {
            // Call the repository method to get all humidity data
            return humidityRepository.GetAllHumidityData();
        }

        public IEnumerable<HumidityDto> GetDataInRange(DateTime startDate, DateTime endDate)
        {
            // Basic data validation
            if (startDate > endDate)
            {
                throw new ArgumentException("Start date cannot be after end date.");
            }

            // Call the repository method to get humidity data within the specified range
            return humidityRepository.GetHumidityDataInRange(startDate, endDate);
        }

        IEnumerable<HumidityDto> ISensorDataService<HumidityDto>.GetAllData()
        {
            throw new NotImplementedException();
        }

        IEnumerable<HumidityDto> ISensorDataService<HumidityDto>.GetDataInRange(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }

    public interface IHumidityRepository
    {
        void AddHumidityData(HumidityDto data);
        IEnumerable<HumidityDto> GetAllHumidityData();
        IEnumerable<HumidityDto> GetHumidityDataInRange(DateTime startDate, DateTime endDate);
    }

    // Example implementation of IHumidityRepository using in-memory storage
    public class InMemoryHumidityRepository : IHumidityRepository
    {
        private List<HumidityDto> humidityData = new List<HumidityDto>();

        public void AddHumidityData(HumidityDto data)
        {
            humidityData.Add(data);
        }

        public IEnumerable<HumidityDto> GetAllHumidityData()
        {
            return humidityData;
        }

        public IEnumerable<HumidityDto> GetHumidityDataInRange(DateTime startDate, DateTime endDate)
        {
            return humidityData.Where(d => d.Timestamp >= startDate && d.Timestamp <= endDate);
        }
    }
}
