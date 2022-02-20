using Autofac;
using DapperCRUD.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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
        public IEnumerable<Product> Get()
        {
            return _productService.GetAll();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _productService.GetById(id);
        }

        [HttpPost]
        public string Post([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _productService.Add(product);
                    return "Done";
                }
                catch
                {
                    return "ERROR" ;
                }
            }
            else { return "Model Data Error"; }
        }

        [HttpPut]
        public string Put([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _productService.Update(product);
                    return "Done";
                }
                catch
                {
                    return "ERROR";
                }
            }
            else { return "Model Data Error"; }
        }

        [HttpPost]
        [Route("delete")]
        public string Delete([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _productService.Delete(product.ID);
                    return "Done";
                }
                catch
                {
                    return "ERROR";
                }
            }
            else { return "Model Data Error"; }
        }
    }
}
