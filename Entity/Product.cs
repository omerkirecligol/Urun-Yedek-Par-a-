using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyChallenge.Entitiy
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }

        public List<SparePart> SpareParts { get; set; }
    }
}