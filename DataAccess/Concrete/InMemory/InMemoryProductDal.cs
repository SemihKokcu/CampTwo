using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product { ProductId=1,CategoryId=1,ProductName="Bilgisayar", UnitPrice=155, UnitsInStock=15},
                new Product { ProductId=2,CategoryId=1,ProductName="Telefon", UnitPrice=55, UnitsInStock=5},
                new Product { ProductId=3,CategoryId=2,ProductName="Klavye", UnitPrice=45, UnitsInStock=25},
                new Product { ProductId=4,CategoryId=2,ProductName="Mouse", UnitPrice=50, UnitsInStock=13},
                new Product { ProductId=5,CategoryId=3,ProductName="Kamera", UnitPrice=25, UnitsInStock=1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
            
        }

        public void Delete(Product product)
        {
            //Don't LINQ
            Product productToDelete = null;
            foreach (var p in _products)
            {
                if (product.ProductId ==p.ProductId)
                {
                    productToDelete = p;
                }
            }

            //With LINQ
            productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();

        }

        public void Update(Product product)
        {
            Product productToUpdate;  
            productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
