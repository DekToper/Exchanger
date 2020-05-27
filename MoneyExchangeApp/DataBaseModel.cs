using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace MoneyExchangeApp
{
    
    public partial class Model : DbContext
    {
        public Model()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<ExchangeHistory> ExchangeHistory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
