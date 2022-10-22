using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using web_api_Empleados.Models;

namespace web_api_Empleados.Controllers{

    [Route("api/[controller]")]

    public class PuestosController : Controller {
        
            private Conexion dbConexion;
            public PuestosController(){ dbConexion = Conectar.Create();}
            // GET api/puestos
            [HttpGet]
             public ActionResult Get() {return Ok(dbConexion.Puestos.ToArray());}
            // GET api/puestos/nombre del campo
             [HttpGet("{id}")]
            public async Task<ActionResult> Get(int id) {
             var puestos = await dbConexion.Puestos.FindAsync(id);
            if (puestos != null) {
                return Ok(puestos);
            } else {
                return NotFound();
            }
        }

        // metodO POST
        public async Task<ActionResult> Post([FromBody] Puestos puestos){
            if (ModelState.IsValid){
             dbConexion.Puestos.Add(puestos);
             await dbConexion.SaveChangesAsync();
             return Ok();
             //return Ok(puestos); retorna el registro ingresado
             //return Created("api/puestos",puestos); retorna los registros
             }else{
                 return BadRequest();
             }
             
        }

        
        // Update
        public async Task<ActionResult> Put([FromBody] Puestos puestos){
        var V_puestos = dbConexion.Puestos.SingleOrDefault(a => a.idPuesto == puestos.idPuesto);
        if (V_puestos != null && ModelState.IsValid) {
            dbConexion.Entry(V_puestos).CurrentValues.SetValues(puestos);
            await dbConexion.SaveChangesAsync();
            //return Created("api/puestos",puestos);
                return Ok();
            } else {
                return BadRequest();
            }
        }
    
    
        //DELETE api/puestos/3
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) {
            var puestos = dbConexion.Puestos.SingleOrDefault(a => a.idPuesto == id);
            if(puestos!= null) {
                dbConexion.Puestos.Remove(puestos);
                await dbConexion.SaveChangesAsync();
                        return Ok();
                } 
                else {    return NotFound();
                }
        }
    
    
    }

}
