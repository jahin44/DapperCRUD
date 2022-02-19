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

        private readonly IRepository productRepository;
        private readonly ILogger<ProductController> _logger;
        private readonly ILifetimeScope _scope;

        public ProductController(
            IRepository repository,
            ILifetimeScope scope,
            ILogger<ProductController> logger)
        {
            productRepository = repository;
            _logger = logger;
            _scope = scope;
        }

        [HttpGet]
        [Route("getall")]
        public IEnumerable<Product> Get()
        {
            return productRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return productRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] Product prod)
        {
            if (ModelState.IsValid)
                productRepository.Add(prod);
        }

        [HttpPut]
        public void Put([FromBody] Product prod)
        {
            //prod.ID = id;
            if (ModelState.IsValid)
                productRepository.Update(prod);
        }

        [HttpPost]
        [Route("delete")]
        public void Delete([FromBody] Product prod)
        {
            productRepository.Delete(prod.ID);
        }
    }
}
