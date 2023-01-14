using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework
{
   public class ProductDal
    {
        public List<Product> GetAll()
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.ToList();


            }

        }
        //Isme gore getirme islemi yapar 
        public List<Product> GetByName(string key)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p=>p.Name.Contains(key)).ToList();


            }
        }

        // Fiyata göre getirme islemi yapar
        public List<Product> GetByUnitPrice(decimal price )
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice >= decimal.MinusOne && p.UnitPrice <= decimal.MaxValue).ToList();  


            }
        }
        ///ID ye göre getirme islemi yapar 
        public Product GetById(int id)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var result = context.Products.FirstOrDefault(p => p.Id == id);
                return result;


            }

        }
        public void Add(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                context.Products.Add(product);
                context.SaveChanges();


            }
        }
        public void Update(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Modified;
                context.SaveChanges();


            }



        }
        public void Delete(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Deleted;
                context.SaveChanges();


            }

        }
    }
}
