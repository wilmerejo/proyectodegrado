using proyecto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace proyecto.Controllers
{
    [Authorize]
    public class OwnersAPIController : ApiController
    {
        private UniversityEntities db = new UniversityEntities();

        /// <summary>
        /// Metodo para consultar
        /// </summary>
        /// <returns>si se retorna</returns>
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var Owners = db.Owners.ToList().Select(x => OwnerToOwnerDTO(x));
            return Ok(Owners);
        }

        /// <summary>
        /// Metodo para consultar por ID
        /// </summary>
        /// <returns>si se retorna</returns>
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {

            var Owners = db.Owners.Find(id);
            if (Owners == null)
                return NotFound();

            var OwnersDTO = OwnerToOwnerDTO(db.Owners.Find(id));
            return Ok(OwnersDTO);
        }

        /// <summary>
        /// Metodo para Insertar
        /// </summary>
        /// <returns>no se retorna</returns>
        [HttpPost]
        public IHttpActionResult Post(Owner Owners)
        {
            Owners = db.Owners.Add(Owners);
            db.SaveChanges();
            return Ok(Owners);
        }

        /// <summary>
        /// Metodo para Editar
        /// </summary>
        /// <returns>no se retorna</returns>
        [HttpPut]
        public IHttpActionResult Put(Owner Owners)
        {
            db.Owners.AddOrUpdate(Owners);
            db.SaveChanges();
            return Ok(Owners);
        }

        /// <summary>
        /// Metodo para Borrar
        /// </summary>
        /// <returns>no se retorna</returns>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var Owners = db.Owners.Find(id);
            if (Owners == null)
                return NotFound();
            db.Owners.Remove(Owners);
            db.SaveChanges();
            return Ok();
        }

        private OwnersDTO OwnerToOwnerDTO(Owner Owners)
        {
            return new OwnersDTO
            {
                Id_Owners = Owners.Id_Owners,
                Names = Owners.Names,
                Surnames = Owners.Surnames,
                Mobile = Owners.Mobile,
                Email = Owners.Email
            };
        }
        public class OwnersDTO
        {
            public int Id_Owners { get; set; }
            public string Names { get; set; }
            public string Surnames { get; set; }
            public string Mobile { get; set; }
            public string Email { get; set; }
        }

    }
}
