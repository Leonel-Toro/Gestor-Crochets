namespace Gestor.Modelos
{
    public class MaterialProducto
    {
        public int Id { get; set; }
        public Producto producto { get; set; }
        public CostoMaterial costoMaterial { get; set; }

    }
}
