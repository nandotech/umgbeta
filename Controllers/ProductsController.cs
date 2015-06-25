using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.OData;
using UmgBeta.Models;

namespace UmgBeta.Controllers
{
    [EnableCorsAttribute("http://localhost:2529","*","*")]
    [Authorize]
    public class ProductsController : ApiController
    {
        // GET: api/Products
        [EnableQuery()]
        [ResponseType(typeof(Product))]
        public IHttpActionResult Get()
        {

            try
            {
                var productRepository = new ProductRepository();
                return Ok(productRepository.Retrieve().AsQueryable());
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

/// <summary>
/// Get single product by Product ID
/// </summary>
/// <param name="id"></param>
/// <returns></returns>

      [ResponseType(typeof(Product))]
        public IHttpActionResult Get(int id)
        {
            
            try
            {
                Product product;
                var productRepository = new ProductRepository();
                if (id > 0)
                {
                    var products = productRepository.Retrieve();
                    product = products.FirstOrDefault(p => p.ProductId == id);
                    if (product == null)
                    {
                        return NotFound();
                    }
                }
                else
                {
                    product = productRepository.Create();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                
                return InternalServerError(ex);
            }
        }

        

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult Post([FromBody]Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product cannot be null");
                }
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var productRepository = new ProductRepository();
                var newProduct = productRepository.Save(product);
                if (newProduct == null)
                {
                    return Conflict();
                }
                return Created<Product>(Request.RequestUri + newProduct.ProductId.ToString(),
                    newProduct);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        // PUT: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult Put(int id, [FromBody]Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product cannot be null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var productRepository = new ProductRepository();
                var updatedProduct = productRepository.Save(id, product);
                if (updatedProduct == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
