using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ITrainerService
    {
        void Add(Trainer trainer);
        void Update(Trainer trainer);
        void Delete(int trainerId);
        List<Trainer> GetList();
        Trainer GetById(int trainerId);
    }
}