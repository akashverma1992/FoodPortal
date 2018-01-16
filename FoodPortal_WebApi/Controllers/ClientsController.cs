using FoodPortal_Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace FoodPortal_WebApi.Controllers {
    [EnableCors(origins: "*", headers:"*", methods:"*")]
    public class ClientsController : ApiController
    {
        private FoodOrderingConnStr db = new FoodOrderingConnStr();

        // GET: api/Clients
        public IHttpActionResult GetClients()
        {
            var clients = db.Clients.FirstOrDefault();
            return Ok(clients);
        }

        // GET: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClient(string id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(string id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.ClientId)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Clients
        [HttpPost]
        [ResponseType(typeof(Client))]
        public IHttpActionResult PostClient(Client client) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            //db.Clients.Add(client);
            try {
                string sqlInsert = "EXEC upsertClients "
                    + client.ClientId 
                    + "," + client.Name
                    + "," + client.Password
                    + "," + client.Email
                    + "," + client.Address
                    + "," + client.Contact;
                db.Database.ExecuteSqlCommand(sqlInsert);
                db.SaveChanges();
            } catch (DbUpdateException) {
                if (ClientExists(client.ClientId)) {
                    return Conflict();
                }
                else {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = client.ClientId }, client);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult DeleteClient(string id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Clients.Remove(client);
            db.SaveChanges();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(string id)
        {
            return db.Clients.Count(e => e.ClientId == id) > 0;
        }
    }
}