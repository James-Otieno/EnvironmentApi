using SeensorsMicroService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeensorsMicroService.Application.Services
{
    public class RainfallService : ISensorDataService<RainfallDto>
    {
        private readonly IRainfallRepository rainfallRepository;

        public RainfallService(IRainfallRepository rainfallRepository)
        {
            this.rainfallRepository = rainfallRepository ?? throw new ArgumentNullException(nameof(rainfallRepository));
        }

        public void AddData(RainfallDto data)
        {
            throw new NotImplementedException();
        }

        public void AddDataAddNewRainfallData(RainfallDto data)
        {
            // Basic data validation
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "Rainfall data cannot be null.");
            }

            // More complex validation logic can be added here if needed

            // Call the repository method to add data
            rainfallRepository.AddRainfallData(data);
        }

        //public void AddData(RainfallDto data)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<RainfallDto> GetAllData()
        {
            // Call the repository method to get all rainfall data
            return rainfallRepository.GetAllRainfallData();
        }

        public IEnumerable<RainfallDto> GetDataInRange(DateTime startDate, DateTime endDate)
        {
            // Basic data validation
            if (startDate > endDate)
            {
                throw new ArgumentException("Start date cannot be after end date.");
            }

            // Call the repository method to get rainfall data within the specified range
            return rainfallRepository.GetRainfallDataInRange(startDate, endDate);
        }

        IEnumerable<RainfallDto> ISensorDataService<RainfallDto>.GetAllData()
        {
            throw new NotImplementedException();
        }

        IEnumerable<RainfallDto> ISensorDataService<RainfallDto>.GetDataInRange(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }

    public interface IRainfallRepository
    {
        void AddRainfallData(RainfallDto data);
        IEnumerable<RainfallDto> GetAllRainfallData();
        IEnumerable<RainfallDto> GetRainfallDataInRange(DateTime startDate, DateTime endDate);
    }

    // Example implementation of IRainfallRepository using in-memory storage
    public class RainfallRepository : IRainfallRepository
    {
        private List<RainfallDto> rainfallData = new List<RainfallDto>();

        public void AddRainfallData(RainfallDto data)
        {
            rainfallData.Add(data);
        }

        public IEnumerable<RainfallDto> GetAllRainfallData()
        {
            return rainfallData;
        }

        public IEnumerable<RainfallDto> GetRainfallDataInRange(DateTime startDate, DateTime endDate)
        {
            return rainfallData.Where(d => d.Timestamp >= startDate && d.Timestamp <= endDate);
        }
    }
}
