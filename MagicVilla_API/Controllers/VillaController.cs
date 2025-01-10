using MagicVilla_API.Datos;
using MagicVilla_API.Modelos;
using MagicVilla_API.Modelos.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {

        private readonly ILogger<VillaController> _logger;
        private readonly ApplicationDbContext _db;
        public VillaController(ILogger<VillaController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        //Se le añade el ActionResult para poder manejar la respuesta Http (estado) y luego se crea la lista tomando los datos del VillaDto
        public ActionResult <IEnumerable<VillaDto>> GetVillas()
        {
            if(VillaStore.VillaList == null || VillaStore.VillaList.Count == 0)
            {
                return NotFound();
            }
            _logger.LogInformation("Se obtienen las villas");
            //Retorna un estato Ok(202) y su contenido es igual a la lista de las villas disponibles en el store
            return Ok(_db.Villas.ToList());
        }

        //No pueden existir dos endpoint con el mismo verbo, en este caso GET, se deben diferenciar e este caso se le añade el ID
        [HttpGet("id:int", Name ="GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult <VillaDto> GetVilla(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Error al traer la villa con Id "+id);
                return BadRequest();
            }

            //Se toma el la lista creada en la clase villastore luego con la funcion FirstOrDefault se busca el primer elemto que cumpla con la condición
            //en este caso se utiliza una expresión lambda que me evalua si la propiedad Id del elemento actual (v) es igual al valor de la variable id.
            //var villa = VillaStore.VillaList.FirstOrDefault(v => v.Id == id);
            var villa = _db.Villas.FirstOrDefault(v => v.Id == id);

            if (villa==null)
            {
                return NotFound();
            }

            return Ok(villa);
        }
        //Se crea metodo post para crear nuevas villas
        [HttpPost]

        //Se crean sus respuestas y se utiliza el estado 201 que significa creado
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //FromBody nos indica que vamos a recibir datos y hay que indicarle el tipo de dato o modelo
        public ActionResult<VillaDto> CrearVilla([FromBody] VillaDto villaDto)
        {   
            //Validación de los DataAnotation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Se hace un model state personalizado para que valide que el nombre ingresado sea nuevo
            if (_db.Villas.FirstOrDefault(v=> v.Nombre.ToLower() == villaDto.Nombre.ToLower()) !=null)
            {
                ModelState.AddModelError("NombreExiste", "La villa con ese nombre ya existe");
                return BadRequest(ModelState);
            }

            //Verifica que los parametros ingresados no sean nulos
            if (villaDto == null)
            {
                return BadRequest(villaDto);
            }

            //Verifica que no se toque el ID al mandar la nueva villa ya que el Id es automatico
            if (villaDto.Id>0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Villa modelo = new ()
            {
                Nombre = villaDto.Nombre,
                Detalle = villaDto.Detalle,
                Tarifa = villaDto.Tarifa,
                ocupantes = villaDto.Ocupantes,
                MetrosCuadrados = villaDto.MetrosCuadrados,
                ImagenUrl = villaDto.ImagenUrl,
                Amenidad = villaDto.Amenidad,
            };

            _db.Villas.Add(modelo);
            _db.SaveChanges();

            //Se returna una redirección a la villa creada al metodo get con Id
            return CreatedAtRoute("GetVilla", new {id=villaDto.Id}, villaDto);
        }

        //Se crea metodo para eliminar villas por medio de su Id 
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        //Se utiliza IActionResult porque no se especifica el tipo de dato que se va a retornar
        public IActionResult DeleteVilla(int id)
        {
            //Valida que el id no sea 0
            if (id==0)
            {
                return BadRequest();
            }
            //Se toma el la lista creada en la clase villastore luego con la funcion FirstOrDefault se busca el primer elemto que cumpla con la condición
            var villa = _db.Villas.FirstOrDefault(v => v.Id == id);

            //Valida que lel id no sea un nulo
            if (villa == null)
            {
                return NotFound();
            }

            //Se elimina la villa con el Id Ingresado en el store
            //VillaStore.VillaList.Remove(villa);

            _db.Villas.Remove(villa);
            _db.SaveChanges();

            //Se retorno NoContent que significa que se elimino correctamente y no hay contenido que mostrar
            return NoContent();
        }

        //Se crea metodo para actualizar villas por medio de su Id
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        // Se utiliza IActionResult porque no se especifica el tipo de dato que se va a retornar
        public IActionResult UpdateVilla(int id, [FromBody] VillaDto villaDto)
        {
            //Valida que el id no sea 0 y que el objeto no sea nulo
            if (villaDto==null || id != villaDto.Id)
            {
                return BadRequest();
            }

            //Se toma el la lista creada en la clase villastore luego con la funcion FirstOrDefault se busca el primer elemto que cumpla con la condición
            var villa = VillaStore.VillaList.FirstOrDefault(v => v.Id == id);

            //Se actuilizan los datos de la villa
            //villa.Nombre = villaDto.Nombre;
            //villa.Ocupantes = villaDto.Ocupantes;
            //villa.MetrosCuadrados = villaDto.MetrosCuadrados;

            Villa modelo = new()
            {
                Id = villaDto.Id,
                Nombre = villaDto.Nombre,
                Detalle = villaDto.Detalle,
                Tarifa = villaDto.Tarifa,
                ocupantes = villaDto.Ocupantes,
                MetrosCuadrados = villaDto.MetrosCuadrados,
                ImagenUrl = villaDto.ImagenUrl,
                Amenidad = villaDto.Amenidad,
            };

            _db.Villas.Update(modelo);
            _db.SaveChanges();

            //Se retonra NoContent que significa que se actualizo correctamente y no hay contenido que mostrar
            return NoContent();

        }

        //Se crea metodo para actualizar parcialmente villas por medio de su Id
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDto> patchDto)
        {
            //Valida que el id no sea 0 y que el objeto no sea nulo
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }

            //Se toma el la lista creada en la clase villastore luego con la funcion FirstOrDefault se busca el primer elemto que cumpla con la condición
            //var villa = VillaStore.VillaList.FirstOrDefault(v => v.Id == id);
            //Se crea un ModelState personalizado para validar los datos ingresados
            var villa = _db.Villas.AsNoTracking().FirstOrDefault(v => v.Id == id);

            VillaDto villaDto = new()
            {
                Id = villa.Id,
                Nombre = villa.Nombre,
                Detalle = villa.Detalle,
                Tarifa = villa.Tarifa,
                Ocupantes = villa.ocupantes,
                MetrosCuadrados = villa.MetrosCuadrados,
                ImagenUrl = villa.ImagenUrl,
                Amenidad = villa.Amenidad,
            };

            if (villa == null)
            {
                return BadRequest();
            }

            patchDto.ApplyTo(villaDto, ModelState);

            if (!ModelState.IsValid) 
            {
                return BadRequest();
            }

            Villa modelo = new()
            {
                Id = villaDto.Id,
                Nombre = villaDto.Nombre,
                Detalle = villaDto.Detalle,
                Tarifa = villaDto.Tarifa,
                ocupantes = villaDto.Ocupantes,
                MetrosCuadrados = villaDto.MetrosCuadrados,
                ImagenUrl = villaDto.ImagenUrl,
                Amenidad = villaDto.Amenidad,
            };

            _db.Villas.Update(modelo);
            _db.SaveChanges();

            return NoContent();

        }
    }
}
