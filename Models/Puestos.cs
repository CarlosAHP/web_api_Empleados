using System.ComponentModel.DataAnnotations;

namespace web_api_Empleados.Models{
public class Puestos{
        [Key]
        public int idPuesto { get; set; }
        public string Puesto { get; set; }

}

}