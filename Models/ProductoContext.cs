using Microsoft.EntityFrameworkCore;
namespace APPBUSCO.Models
{
    public class ProductoContext:DbContext
    {
        public  DbSet<Producto> Productos {get; set;}
        public  DbSet<Categoria> Categorias {get; set;}
        public ProductoContext(DbContextOptions dco) : base(dco) {
            
        }

    }
}