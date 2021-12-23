using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Comm.DB.Entities;
using Comm.Model;
using Comm.Model.Pagination;

namespace Comm.Service.Product
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        public ProductService(IMapper _mapper)
        {
            mapper = _mapper;
        }
        public Common<Model.Product.Product> Get(int id)
        {
            var result = new Common<Model.Product.Product>() { IsSuccess = false };
            if (id < 0) return result;
            using (var srv = new CommContext())
            {
                var dbProduct = srv.Product.SingleOrDefault(p => p.Id == id && p.IsDeleted == false);
                if (dbProduct is not null)
                {
                    var mappedProduct = mapper.Map<Model.Product.Product>(dbProduct);
                    result.Entity = mappedProduct;
                    result.IsSuccess = true;
                }
            }

            return result;
        }

        public Common<List<Model.Product.Product>> GetProducts(PaginationParameters pagination, string sortBy, string searchString)
        {
            var result = new Common<List<Model.Product.Product>>();
            using (var srv = new CommContext())
            {
                var dbProducts = from p in srv.Product where p.IsDeleted == false select p;
                var totalProduct = dbProducts.Count();
                result.TotalEntity = totalProduct;
                result.TotalPages = totalProduct % pagination.PageSize == 0 ? totalProduct / pagination.PageSize : totalProduct / pagination.PageSize + 1;
                if (!String.IsNullOrEmpty(searchString))
                {
                    dbProducts = dbProducts.Where(p => p.Name.Contains(searchString));
                }
                switch (sortBy)
                {
                    case "name_desc":
                        dbProducts = dbProducts.OrderByDescending(p => p.Name);
                        break;
                    case "Price":
                        dbProducts = dbProducts.OrderBy(p => p.Price);
                        break;
                    case "price_desc":
                        dbProducts = dbProducts.OrderByDescending(p => p.Price);
                        break;
                    case "Idate":
                        dbProducts = dbProducts.OrderBy(p => p.Idate);
                        break;
                    case "idate_desc":
                        dbProducts = dbProducts.OrderByDescending(p => p.Idate);
                        break;
                    default:
                        dbProducts = dbProducts.OrderBy(p => p.Name);
                        break;
                }
                var Products =
                dbProducts
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                    .Take(pagination.PageSize)
                    .ToList();
                result.Entity = new List<Model.Product.Product>();
                result.IsSuccess = true;
                foreach (var product in Products)
                {
                    var mappedProduct = mapper.Map<Model.Product.Product>(product);
                    result.Entity.Add(mappedProduct);
                }
            }

            return result;
        }
        public Common<Model.Product.Product> Add(Model.Product.Product newProduct)
        {
            var result = new Common<Model.Product.Product>() { IsSuccess = false };
            var mappedProduct = mapper.Map<DB.Entities.Product>(newProduct);
            using (var srv = new CommContext())
            {
                srv.Database.BeginTransaction();
                mappedProduct.Idate = System.DateTime.Now;
                srv.Product.Add(mappedProduct);
                srv.SaveChanges();
                result.Entity = mapper.Map<Model.Product.Product>(mappedProduct);
                result.IsSuccess = true;
                srv.Database.CommitTransaction();
            }

            return result;
        }

        public Common<Model.Product.Product> Update(Model.Product.Product updatedProduct)
        {
            var result = new Common<Model.Product.Product>() { IsSuccess = false };
            var mappedProduct = mapper.Map<DB.Entities.Product>(updatedProduct);
            using (var srv = new CommContext())
            {
                try
                {
                    srv.Database.BeginTransaction();
                    var dbProduct = srv.Product.SingleOrDefault(p => p.Id == updatedProduct.Id && p.IsDeleted == false);
                    dbProduct.Name = mappedProduct.Name != default ? mappedProduct.Name : dbProduct.Name;
                    dbProduct.Description = mappedProduct.Description != default ? mappedProduct.Description : dbProduct.Description;
                    dbProduct.Price = mappedProduct.Price != default ? mappedProduct.Price : dbProduct.Price;
                    dbProduct.Stock = mappedProduct.Stock != default ? mappedProduct.Stock : dbProduct.Stock;
                    dbProduct.Udate = mappedProduct.Udate != default ? mappedProduct.Udate : dbProduct.Udate;
                    srv.SaveChanges();
                    result.Entity = mapper.Map<Model.Product.Product>(mappedProduct);
                    result.IsSuccess = true;
                    srv.Database.CommitTransaction();
                }
                catch (Exception e)
                {
                    srv.Database.RollbackTransaction();
                    result.ExceptionMessage = e.Message;
                }
            }

            return result;
        }
        public bool Delete()
        {
            var result = false;
            return result;
        }

    }
}