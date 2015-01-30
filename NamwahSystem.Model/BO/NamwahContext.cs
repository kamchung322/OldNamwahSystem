using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace NamwahSystem.Model.BO
{
    public class NamwahContext : DbContext
    {
        public NamwahContext()
            : base("name=OldNamwahSystem")
        {

        }

        public DbSet<SalesOrderLine> SalesOrderLines { get; set; }

    }
}
