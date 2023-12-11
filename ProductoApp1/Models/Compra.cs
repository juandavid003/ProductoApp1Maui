using System.ComponentModel.DataAnnotations;

namespace Ejemplo1.Models
{
    public class Compra
    {
        public int IdCompra { get; set; }

        public int Codigo { get; set; }
        public int IdProducto { get; set; }
        public string Nombre { get; set; }

        public int Cantidad { get; set; }

        //public float PrecioTotal { get; set; }

        public DateTime FechaCompra { get; set; }

     //  public List<SelectListItem> SelectList { get; set; }

    }
}
