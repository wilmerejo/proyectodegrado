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
    public class Pet_TypeAPIController : ApiController
    {
        private UniversityEntities db = new UniversityEntities();

        /// <summary>
        /// Metodo para consultar
        /// </summary>
        /// <returns>si se retorna</returns>
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var PetTypes = db.Pet_Types.ToList().Select(x => PetTypesToPetTypesDTO(x));
            return Ok(PetTypes);
        }

        /// <summary>
        /// Metodo para consultar por ID
        /// </summary>
        /// <returns>si se retorna</returns>
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {

            var PetTypes = db.Pet_Types.Find(id);
            if (PetTypes == null)
                return NotFound();

            var PetTypesDTO = PetTypesToPetTypesDTO(db.Pet_Types.Find(id));
            return Ok(PetTypesDTO);
        }

        /// <summary>
        /// Metodo para Insertar
        /// </summary>
        /// <returns>no se retorna</returns>
        [HttpPost]
        public IHttpActionResult Post(Pet_Type PetTypes)
        {
            PetTypes = db.Pet_Types.Add(PetTypes);
            db.SaveChanges();
            return Ok(PetTypes);
        }

        /// <summary>
        /// Metodo para Editar
        /// </summary>
        /// <returns>no se retorna</returns>
        [HttpPut]
        public IHttpActionResult Put(Pet_Type PetTypes)
        {
            db.Pet_Types.AddOrUpdate(PetTypes);
            db.SaveChanges();
            return Ok(PetTypes);
        }

        /// <summary>
        /// Metodo para Borrar
        /// </summary>
        /// <returns>no se retorna</returns>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var PetTypes = db.Pet_Types.Find(id);
            if (PetTypes == null)
                return NotFound();
            db.Pet_Types.Remove(PetTypes);
            db.SaveChanges();
            return Ok();
        }

        private PetTypesDTO PetTypesToPetTypesDTO(Pet_Type PetTypes)
        {
            return new PetTypesDTO
            {
                Id_Pet_Type = PetTypes.Id_Pet_Type,
                Descript = PetTypes.Descript
            };
        }
        public class PetTypesDTO
        {
            public int Id_Pet_Type { get; set; }
            public string Descript { get; set; }
        }

    }
}
