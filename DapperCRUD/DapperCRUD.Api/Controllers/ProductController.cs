using Autofac;
using DapperCRUD.Data.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DapperCRUD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;
        private readonly ILifetimeScope _scope;

        public ProductController(
            IProductService productService,
            ILifetimeScope scope,
            ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
            _scope = scope;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_productService.GetAll());
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _productService.GetById(id);
        }

        [HttpGet("{ProductName},{Id}")]
        public JsonResult Get(string ProductName,int Id)
        {
            return new JsonResult(_productService.GetByName(ProductName));
        }

        [HttpPost]
        public JsonResult Post([FromBody] Product product)
        {
            product.LocalTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                try
                {
                    _productService.Add(product);
                    return new JsonResult("success");
                }
                catch
                {   
                    return new JsonResult("Error");
                }
            }
            else { return new JsonResult("model error"); }
        }

        [HttpPut]
        public JsonResult Put([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _productService.Update(product);
                    return new JsonResult("success");
                }
                catch
                {
                    return new JsonResult("Error");
                }
            }
            else { return new JsonResult("Model Error"); }
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int Id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _productService.Delete(Id);
                    return new JsonResult("success");
                }
                catch
                {
                    return new JsonResult("Error");
                }
            }
            else { return new JsonResult("Model Error"); }
        }
    }
}
