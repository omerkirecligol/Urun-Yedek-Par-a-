using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using MyChallenge.Entitiy;

namespace MyChallenge.Entity
{
    public class DataContext:DbContext
    {
            public DbSet<Product> Products { get; set; }
            public DbSet<SparePart> SpareParts { get; set; }

            public DataContext() : base("dataConnection")
            {
                Database.SetInitializer(new DataInitializer());
            }



        
    }
}