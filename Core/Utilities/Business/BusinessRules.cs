using System;
using System.Linq.Expressions;
using Core.DataAccess;
using Core.Entities;
using Core.Utilities.Results;
using Core.Constants.Messages;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            
            return null;
        }
        
        public static IResult ValidateEntityExistence<T>(IEntityRepository<T> repository, 
            int id, Expression<Func<T, bool>> predicate) 
            where T : class, IEntity      
        {
            if (id <= 0)
            {
                return new ErrorResult(TurkishMessages.ErrorOccurred);
            }

            if (repository.Get(predicate) == null)
            {
                return new ErrorResult(TurkishMessages.ErrorOccurred);
            }

            return new SuccessResult();
        }
    }
}