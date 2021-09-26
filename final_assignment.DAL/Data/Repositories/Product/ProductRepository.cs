﻿using final_assignment.Common.Models;
using final_assignment.DAL.Data.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_assignment.DAL.Data.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ProductModel> GetAllProduct()
        {
            // Adding foods and non foods into 1 IEnumerable
            // Also makes sure either are not null
            //IEnumerable<ProductModel> AllProducts = ((IEnumerable<ProductModel>)_context.FoodProducts ?? Enumerable.Empty<FoodModel>())
            //    .Concat((IEnumerable<ProductModel>)_context.NonFoodProducts ?? Enumerable.Empty<NonFoodModel>()); 
            IEnumerable<ProductModel> AllProducts = _context.Products;

            return AllProducts;
        }

        public ProductModel GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(x => x.ProductId == id);
        }
    }
}
