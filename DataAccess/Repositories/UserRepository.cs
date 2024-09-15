using Core.Models;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : Repository<AppUser>, IUserRepository
    {
        public UserRepository(BlogDbContext context) : base(context)
        {
        }
    }
}
