using ENSEK.DataAccess;
using ENSEK.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ENSEK.Services
{
    public class AccountService
    {
        public List<Account> GetAccountList()
        {
            try
            {
                var context = new EnsekDbContext();
                return context.Account.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
