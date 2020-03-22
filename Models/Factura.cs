using System;    
using System.Collections.Generic;    
using System.ComponentModel.DataAnnotations;    // read about what this library can be used for
using System.Linq;    
using System.Threading.Tasks;  

namespace mvc_test.Models    // A namespace is designed for providing a way to keep one set of names separate from another.
{    
    public class Facturas    // employee class created in the models folder
    {    
        // here we set the get set methods for every variable that will be used as parameter in our database procedures
        public int ID { get; set; }    
        [Required]    
        public string nro_factura { get; set; }    
        [Required]    
        public float total_iva5 { get; set; }    
        [Required]    
        public float total_iva10 { get; set; }
        [Required]    
        public float total_factura { get; set; }     
        [Required]    
        public int id_cliente { get; set; }     
        [Required]    
        public DateTime fecha { get; set; }         
    }    
}  