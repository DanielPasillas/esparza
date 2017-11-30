using System;
using System.Collections.Generic;
using System.Linq;
using grupoesparza.Models;
using System.Web;

namespace grupoesparza.Classes
{
    
    public class AccountClass
    {
        private readonly esparza_dbEntities _dbContext;

        public AccountClass(esparza_dbEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public bool ValidateUser(Login loginModel)
        {
            using(_dbContext)
            {

            }

            return true;

        }
    }

    

}