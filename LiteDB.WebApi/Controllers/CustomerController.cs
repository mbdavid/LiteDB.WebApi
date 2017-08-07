using LiteDB.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LiteDB.WebApi.Controllers
{
    /// <summary>
    /// Multi Process - Each request use a new database instance
    /// </summary>
    public class CustomerController : ApiController
    {
        private LiteRepository _repo = new LiteRepository(ConfigurationManager.AppSettings["dbpath"]);

        // GET api/customer
        public IEnumerable<Customer> Get()
        {
            return _repo.Query<Customer>()
                .Limit(1000)
                .ToEnumerable();
        }

        // GET api/customer/5
        public Customer Get(int id)
        {
            return _repo.Query<Customer>()
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        // POST api/customer
        public void Post([FromBody]Customer customer)
        {
            _repo.Insert(customer);
        }

        // PUT api/customer/5
        public void Put(int id, [FromBody]Customer customer)
        {
            customer.Id = id;

            _repo.Update(customer);
        }

        // DELETE api/customer/5
        public void Delete(int id)
        {
            _repo.Delete<Customer>(id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
