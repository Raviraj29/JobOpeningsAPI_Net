using JobOpeningAPI.DataContext;
using JobOpeningAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobOpeningAPI.Repositories
{
    public class UserValidateRepository : IDisposable
    {
        JobsOpeningContext dbContext = new JobsOpeningContext();

        public User ValidateUser(string username, string password)
        {
            try
            {
                return dbContext.Users.FirstOrDefault(user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password == password);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}