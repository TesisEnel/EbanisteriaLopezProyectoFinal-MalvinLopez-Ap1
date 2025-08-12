using EbanisteriaLopezProyectoFinal.Components.Models;

namespace EbanisteriaLopezProyectoFinal.Components.Services
{
    public class CarritoService
    {
        private readonly List<CarritoItem> _items = new();

        public IReadOnlyList<CarritoItem> ObtenerItems() => _items;

        public void AgregarProducto(Producto producto, int cantidad)
        {
            var itemExistente = _items.FirstOrDefault(p => p.Producto.ProductoId == producto.ProductoId);
            if (itemExistente != null)
            {
                itemExistente.Cantidad += cantidad;
            }
            else
            {
                _items.Add(new CarritoItem
                {
                    Producto = producto,
                    Cantidad = cantidad
                });
            }
        }

        public void EliminarDelCarrito(int productoId)
        {
            var item = _items.FirstOrDefault(p => p.Producto.ProductoId == productoId);
            if (item != null)
            {
                _items.Remove(item);
            }
        }

        public void CambiarCantidad(int productoId, int nuevaCantidad)
        {
            var item = _items.FirstOrDefault(p => p.Producto.ProductoId == productoId);
            if (item != null && nuevaCantidad > 0)
            {
                item.Cantidad = nuevaCantidad;
            }
        }

        public void VaciarCarrito()
        {
            _items.Clear();
        }
    }


}
