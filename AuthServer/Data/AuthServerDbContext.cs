using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthServer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.Data
{
    public class AuthServerDbContext: IdentityDbContext
    {
   
        public AuthServerDbContext(DbContextOptions<AuthServerDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=sql.bsite.net\\MSSQL2016;Database=liveserver_Databse;pwd=Password01;user Id=liveserver_Databse;MultipleActiveResultSets=true");
        }

        public DbSet<SignInRequest>  SignInRequests { get; set; }
    }
}
