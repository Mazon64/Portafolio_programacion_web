using System.ComponentModel.DataAnnotations;

namespace ProjectBlazor.Models
{
    public class Product
    {
        [Required(ErrorMessage = "El número de inventario es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El número de inventario debe ser un número entero positivo")]
        public int InventoryNumber {get; set;}
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Name {get; set;}
        [Required(ErrorMessage = "El departamento es obligatorio")]
        public string Department {get; set;}
    }

    public class ProductManager
    {
        private List<Product> products = new List<Product>();
        public IReadOnlyList<Product> Products => products.AsReadOnly();
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }
        public bool IsInventoryNumberDuplicate(int inventoryNumber)
        {
            return products.Any(p => p.InventoryNumber == inventoryNumber);
        }
    }
}