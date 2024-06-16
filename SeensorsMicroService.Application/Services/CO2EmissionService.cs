using SeensorsMicroService.Application.Dtos;
using SeensorsMicroService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeensorsMicroService.Application.Services
{
    public class CO2EmissionsService : ISensorDataService<CO2Dto>
    {
        private readonly ICO2EmissionsRepository co2EmissionsRepository;

        public CO2EmissionsService(ICO2EmissionsRepository co2EmissionsRepository)
        {
            this.co2EmissionsRepository = co2EmissionsRepository ?? throw new ArgumentNullException(nameof(co2EmissionsRepository));
        }

        public void AddData(CO2Dto data)
        {
            // Basic data validation
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "CO2 emissions data cannot be null.");
            }

            // More complex validation logic can be added here if needed

            // Call the repository method to add data
            co2EmissionsRepository.AddCO2EmissionsData(data);
        }

        public void AddNewCO2EmissionsData(CO2Dto data)
        {
            throw new NotImplementedException();
        }

        //public void AddData(CO2Dto data)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<CO2Dto> GetAllData()
        {
            // Call the repository method to get all CO2 emissions data
            return co2EmissionsRepository.GetAllCO2EmissionsData();
        }

        public IEnumerable<CO2Dto> GetDataInRange(DateTime startDate, DateTime endDate)
        {
            // Basic data validation
            if (startDate > endDate)
            {
                throw new ArgumentException("Start date cannot be after end date.");
            }

            // Call the repository method to get CO2 emissions data within the specified range
            return co2EmissionsRepository.GetCO2EmissionsDataInRange(startDate, endDate);
        }

        IEnumerable<CO2Dto> ISensorDataService<CO2Dto>.GetAllData()
        {
            throw new NotImplementedException();
        }

        //IEnumerable<CO2Dto> ISensorDataService<CO2Dto>.GetAllData()
        //{
        //    throw new NotImplementedException();
        //}

        IEnumerable<CO2Dto> ISensorDataService<CO2Dto>.GetDataInRange(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        //IEnumerable<CO2Dto> ISensorDataService<CO2Dto>.GetDataInRange(DateTime startDate, DateTime endDate)
        //{
        //    throw new NotImplementedException();
        //}
    }

    public interface ICO2EmissionsRepository
    {
        void AddCO2EmissionsData(CO2Dto data);
        IEnumerable<CO2Dto> GetAllCO2EmissionsData();
        IEnumerable<CO2Dto> GetCO2EmissionsDataInRange(DateTime startDate, DateTime endDate);
    }

    // Example implementation of ICO2EmissionsRepository using in-memory storage
    public class InMemoryCO2EmissionsRepository : ICO2EmissionsRepository
    {
        private List<   CO2Dto> co2EmissionsData = new List<CO2Dto>();

        public void AddCO2EmissionsData(CO2Dto data)
        {
            co2EmissionsData.Add(data);
        }

        public IEnumerable<CO2Dto> GetAllCO2EmissionsData()
        {
            return co2EmissionsData;
        }

        public IEnumerable<CO2Dto> GetCO2EmissionsDataInRange(DateTime startDate, DateTime endDate)
        {
            return co2EmissionsData.Where(d => d.Timestamp >= startDate && d.Timestamp <= endDate);
        }
    }
}
