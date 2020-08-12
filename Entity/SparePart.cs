using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyChallenge.Entitiy
{
    public class SparePart
    {
        public int Id { get; set; }
        public string PartCode { get; set; }
        public string PartName { get; set; }
        public double PartPrice { get; set; }


        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}