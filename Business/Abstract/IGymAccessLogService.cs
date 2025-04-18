using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IGymAccessLogService
    {
        List<GymAccessLog> GetAll();
        GymAccessLog GetById(int logId);
        void Add(GymAccessLog gymAccessLog);
        void Update(GymAccessLog gymAccessLog);
        void Delete(GymAccessLog gymAccessLog);
    }
}