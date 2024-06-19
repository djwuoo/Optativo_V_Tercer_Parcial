namespace Segundo_Parcial.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Segundo_Parcial.Models;
    using System.Collections.Generic;
    using System.Linq;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>();

        // GET: api/product
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(products);
        }

        // GET api/product/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound("Product not found.");
            }
            return Ok(product);
        }

        // POST api/product
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            product.Id = products.Count > 0 ? products.Max(p => p.Id) + 1 : 1;
            products.Add(product);
            return CreatedAtAction("Get", new { id = product.Id }, product);
        }

        // PUT api/product/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingProduct = products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound("Product not found.");
            }

            existingProduct.NumeroFactura = product.NumeroFactura;
            existingProduct.FechaHora = product.FechaHora;
            existingProduct.Total = product.Total;
            existingProduct.TotalIva5 = product.TotalIva5;
            existingProduct.TotalIva10 = product.TotalIva10;
            existingProduct.TotalIva = product.TotalIva;
            existingProduct.TotalLetras = product.TotalLetras;
            existingProduct.Sucursal = product.Sucursal;

            return NoContent();
        }

        // DELETE api/product/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound("Product not found.");
            }

            products.Remove(product);
            return NoContent();
        }
    }
}
