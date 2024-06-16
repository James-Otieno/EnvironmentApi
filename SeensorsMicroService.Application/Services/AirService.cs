using SeensorsMicroService.Application.Dtos;
using SeensorsMicroService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeensorsMicroService.Application.Services
{
    public class AirPollutionService : ISensorDataService<AirDto>
    {
        private readonly IAirPollutionRepository airPollutionRepository;

        public AirPollutionService(IAirPollutionRepository airPollutionRepository)
        {
            this.airPollutionRepository = airPollutionRepository ?? throw new ArgumentNullException(nameof(airPollutionRepository));
        }

        public void AddNewAirPollutionData(AirDto data)
        {
            // Basic data validation
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "Air pollution data cannot be null.");
            }

            // More complex validation logic can be added here if needed

            // Call the repository method to add data
            airPollutionRepository.AddAirPollutionData(data);
        }

        public void AddData(AirDto data)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AirDto> GetAllData()
        {
            // Call the repository method to get all air pollution data
            return airPollutionRepository.GetAllAirPollutionData();
        }

        public IEnumerable<AirDto> GetDataInRange(DateTime startDate, DateTime endDate)
        {
            // Basic data validation
            if (startDate > endDate)
            {
                throw new ArgumentException("Start date cannot be after end date.");
            }

            // Call the repository method to get air pollution data within the specified range
            return airPollutionRepository.GetAirPollutionDataInRange(startDate, endDate);
        }

        IEnumerable<AirDto> ISensorDataService<AirDto>.GetAllData()
        {
            throw new NotImplementedException();
        }

        IEnumerable<AirDto> ISensorDataService<AirDto>.GetDataInRange(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }

    public interface IAirPollutionRepository
    {
        void AddAirPollutionData(AirDto data);
        IEnumerable<AirDto> GetAllAirPollutionData();
        IEnumerable<AirDto> GetAirPollutionDataInRange(DateTime startDate, DateTime endDate);
    }

    // Example implementation of IAirPollutionRepository using in-memory storage
    public class InMemoryAirPollutionRepository : IAirPollutionRepository
    {
        private List<AirDto> airPollutionData = new List<AirDto>();

        public void AddAirPollutionData(AirDto data)
        {
            airPollutionData.Add(data);
        }

        public IEnumerable<AirDto> GetAllAirPollutionData()
        {
            return airPollutionData;
        }

        public IEnumerable<AirDto> GetAirPollutionDataInRange(DateTime startDate, DateTime endDate)
        {
            return airPollutionData.Where(d => d.Timestamp >= startDate && d.Timestamp <= endDate);
        }
    }
}
