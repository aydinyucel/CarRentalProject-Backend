using Core.DataAcces.EntityFramwork;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentACarProjectContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (RentACarProjectContext context = new RentACarProjectContext())
            {
                var result = from uoc in context.UserOperationClaims
                             join oc in context.OperationClaims
                             on uoc.OperationClaimId equals oc.Id
                             where uoc.UserId == user.Id
                             select new OperationClaim()
                             {
                                 Id = uoc.Id,
                                 Name = oc.Name
                             };
                return result.ToList();

            }
        }
    }
}
