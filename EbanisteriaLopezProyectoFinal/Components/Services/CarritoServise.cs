using EbanisteriaLopezProyectoFinal.Components.Models;

namespace EbanisteriaLopezProyectoFinal.Components.Services;




public class CarritoService
{
    private List<CarritoItem> items = new();
    public event Action? OnChange;

    public IEnumerable<CarritoItem> GetItems() => items;

    public void AgregarProducto(Producto producto, int cantidad = 1)
    {
        var itemExistente = items.FirstOrDefault(i => i.Producto.ProductoId == producto.ProductoId);

        if (itemExistente != null)
        {
            itemExistente.Cantidad += cantidad;
        }
        else
        {
            items.Add(new CarritoItem
            {
                Producto = producto,
                Cantidad = cantidad
            });
        }

        NotificarCambio();
    }

    public void QuitarProducto(int productoId)
    {
        var item = items.FirstOrDefault(i => i.Producto.ProductoId == productoId);
        if (item != null)
        {
            items.Remove(item);
            NotificarCambio();
        }
    }

    public void LimpiarCarrito()
    {
        items.Clear();
        NotificarCambio();
    }

    private void NotificarCambio() => OnChange?.Invoke();
}
