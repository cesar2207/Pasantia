using System;
using System.Collections.Generic;


namespace ServicioMonteCacao
{
    public class Pedido{
        public List<Producto> productos = new List<Producto>();
        public Cliente cliente;
        public int precio_total;
    }
}