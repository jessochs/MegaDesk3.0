using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDesk3._0.Models;

namespace MegaDesk3._0.Data
{
    public class MegaDesk3_0Context : DbContext
    {
        public MegaDesk3_0Context (DbContextOptions<MegaDesk3_0Context> options)
            : base(options)
        {
        }

        public DbSet<MegaDesk3._0.Models.Desk> Desk { get; set; } = default!;
    }
}
