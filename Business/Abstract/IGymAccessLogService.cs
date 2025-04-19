using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IGymAccessLogService
    {
        IDataResult<List<GymAccessLog>> GetAll();
        IDataResult<GymAccessLog> GetById(int logId);
        void Add(GymAccessLog gymAccessLog);
        void Update(GymAccessLog gymAccessLog);
        void Delete(GymAccessLog gymAccessLog);
    }
}