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
    /// Multi Thread - All requests share a same database instance (static instance)
    /// </summary>
    public class CustomerShareController : ApiController
    {
        private static LiteRepository _repo = new LiteRepository(ConfigurationManager.AppSettings["dbpath"]);

        // GET api/customershare
        public IEnumerable<Customer> Get()
        {
            return _repo.Query<Customer>()
                .Limit(1000)
                .ToEnumerable();
        }

        // GET api/customershare/5
        public Customer Get(int id)
        {
            return _repo.Query<Customer>()
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        // POST api/customershare
        public void Post([FromBody]Customer customer)
        {
            _repo.Insert(customer);
        }

        // PUT api/customershare/5
        public void Put(int id, [FromBody]Customer customer)
        {
            customer.Id = id;

            _repo.Update(customer);
        }

        // DELETE api/customershare/5
        public void Delete(int id)
        {
            _repo.Delete<Customer>(id);
        }
    }
}
