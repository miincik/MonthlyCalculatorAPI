﻿using MonthlyCalculatorAPI.Contexts;
using MonthlyCalculatorAPI.Models.Entities;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Base;
using MonthlyCalculatorAPI.Repositories.EntityFramework.Interfaces;

namespace MonthlyCalculatorAPI.Repositories.EntityFramework.Concrete
{
    public class UserRepository : EfEntityRepositoryBase<User, MonthlyCalculatorDbContext>, IUserRepository
    {
    }
}
