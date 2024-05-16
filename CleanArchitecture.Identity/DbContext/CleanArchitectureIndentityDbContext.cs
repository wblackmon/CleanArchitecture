using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Identity.Models;

namespace CleanArchitecture.Identity.DbContext;

public class CleanArchitectureIdentityDbConext : IdentityDbContext<ApplicationUser>
{
    public CleanArchitectureIdentityDbConext(DbContextOptions<CleanArchitectureIdentityDbConext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
    }
}
