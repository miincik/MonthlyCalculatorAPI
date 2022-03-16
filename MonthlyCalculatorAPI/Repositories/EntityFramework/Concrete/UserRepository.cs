using MonthlyCalculatorAPI.Contexts;
using MonthlyCalculatorAPI.Models.Entities;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Base;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Interfaces;

namespace MonthlyCalculatorAPI.Repositories.EntityFramework.Concrete
{
    public class UserRepository : EfEntityRepositoryBase<User, MonthlyCalculatorDbContext>, IUserRepository
    {
        public List<OperationClaim> GetClaims(User user)
        {
                using (var context = new MonthlyCalculatorDbContext())
                {
                    var result = from operationClaim in context.OperationClaims
                                 join userOperationClaim in context.UserOperationClaims
                                     on operationClaim.Id equals userOperationClaim.OperationClaimId
                                 where userOperationClaim.UserId == user.Id
                                 select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                    return result.ToList();

                }    
        }
    }
}
