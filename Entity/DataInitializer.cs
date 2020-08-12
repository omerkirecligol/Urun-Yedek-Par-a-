using MyChallenge.Entitiy;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyChallenge.Entity
{
    public class DataInitializer:CreateDatabaseIfNotExists<DataContext>
    {
        //Veritabanına ilk değerleri atamak için oluşturdumuz sınıf
        protected override void Seed(DataContext context)
        {
            var products = new List<Product>()
            {
                new Product() { ProductCode = "WERSGXB" , ProductName= "TV",ProductPrice = 16.5},
                new Product() { ProductCode = "WERSGXC" , ProductName= "MobilePhone",ProductPrice = 200},
                new Product() { ProductCode = "WERSGXD" , ProductName= "Furniture",ProductPrice = 400},

            };

            foreach (var item in products)
            {
                context.Products.Add(item);
            }

            context.SaveChanges();

            var spareParts = new List<SparePart>()
            {
                new SparePart() { PartCode = "YDPWER" , PartName= "asdf",PartPrice = 20,ProductId = 1},
                new SparePart() { PartCode = "YDPWEW" , PartName= "asdf",PartPrice =30,ProductId = 2},
                new SparePart() {  PartCode = "YDPWERKSJ" , PartName= "qwert",ProductId = 3},
                new SparePart() { PartCode = "YDPWERSSBS" , PartName= "asdf",PartPrice = 20,ProductId = 1},
                new SparePart() { PartCode = "YDPWERSNBS" , PartName= "asdf",PartPrice =30,ProductId = 2},
                new SparePart() {  PartCode = "YDPWERSNSV" , PartName= "qwert",ProductId = 3},
                new SparePart() { PartCode = "YDPWERBSHS" , PartName= "asdf",PartPrice = 20,ProductId = 1},
                new SparePart() { PartCode = "YDPWERJLOJ" , PartName= "asdf",PartPrice =30,ProductId = 2},
                new SparePart() {  PartCode = "YDPWERFSGYU" , PartName= "qwert",ProductId = 3},
            };

            foreach (var item in spareParts)
            {
                context.SpareParts.Add(item);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}