using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeensorsMicroService.Application.Services
{
  public interface ISensorDataService<T>
    {
        void AddData(T data);
        IEnumerable<T> GetAllData();
        IEnumerable<T> GetDataInRange(DateTime startDate, DateTime endDate);
    }
}
