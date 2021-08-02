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
    public class PetsAPIController : ApiController
    {
        private UniversityEntities db = new UniversityEntities();

        /// <summary>
        /// Metodo para consultar
        /// </summary>
        /// <returns>si se retorna</returns>
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var Articles = db.Pets.ToList().Select(x => PetsToPetsDTO(x));
            return Ok(Articles);
        }

        /// <summary>
        /// Metodo para consultar por ID
        /// </summary>
        /// <returns>si se retorna</returns>
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {

            var Article = db.Pets.Find(id);
            if (Article == null)
                return NotFound();

            var PetsDTO = PetsToPetsDTO(db.Pets.Find(id));
            return Ok(PetsDTO);
        }

        /// <summary>
        /// Metodo para Insertar
        /// </summary>
        /// <returns>no se retorna</returns>
        [HttpPost]
        public IHttpActionResult Post(Pet Pets)
        {
            Pets = db.Pets.Add(Pets);
            db.SaveChanges();
            return Ok(Pets);
        }

        /// <summary>
        /// Metodo para Editar
        /// </summary>
        /// <returns>no se retorna</returns>
        [HttpPut]
        public IHttpActionResult Put(Pet Pets)
        {
            db.Pets.AddOrUpdate(Pets);
            db.SaveChanges();
            return Ok(Pets);
        }

        /// <summary>
        /// Metodo para Borrar
        /// </summary>
        /// <returns>no se retorna</returns>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var Pets = db.Pets.Find(id);
            if (Pets == null)
                return NotFound();
            db.Pets.Remove(Pets);
            db.SaveChanges();
            return Ok();
        }

        private PetsDTO PetsToPetsDTO(Pet Pets)
        {
            return new PetsDTO
            {
                Id_Pets = Pets.Id_Pets,
                Pet_Name = Pets.Pet_Name,
                Birth_Date = Pets.Birth_Date,
                Id_Pet_Type = Pets.Id_Pet_Type,
                Id_Owners = Pets.Id_Owners.Value
            };
        }
        public class PetsDTO
        {
            public int Id_Pets { get; set; }
            public string Pet_Name { get; set; }
            public string Birth_Date { get; set; }
            public Nullable<int> Id_Pet_Type { get; set; }
            public Nullable<int> Id_Owners { get; set; }
        }

    }
}
