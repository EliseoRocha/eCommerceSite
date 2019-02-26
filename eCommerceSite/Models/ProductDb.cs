using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceSite.Models
{
    public static class ProductDb
    {
        public static Product Add(Product p, CommerceContext db)
        {
            db.Products.Add(p);
            db.SaveChanges();
            return p;
        }

        public static List<Product> GetProducts(CommerceContext context)
        {
            //LINQ Query Syntax
            return (from p in context.Products
                    select p).ToList();

            //LINQ Method Syntax
            //return context.Products.ToList();
        }

        public static Product GetProduct(CommerceContext context, int id)
        {
            //LINQ method syntax - grab product by id
            Product p2 = context
                .Products
                .Where(product => product.ProductID == id)
                .Single();
            return p2;

            //LINQ Query Syntax - Grabbing a single product by id
            Product p = (from prods in context.Products
                         where prods.ProductID == id
                         select prods).Single();

            return p;
        }

        public static List<Product> GetProductsByPage(CommerceContext context, int pageNum, int pageSize)
        {
            int pageOffset = 1;

            //The page number must be offset to get the correct page of products
            int numRecordsToSkip = (pageNum - pageOffset) * pageSize;

            //MAKE SURE SKIP IS CALLED BEFORE TAKE!
            return context.Products.OrderBy(p => p.Name).Skip(numRecordsToSkip).Take(pageSize).ToList();
            
        }
    }
}
