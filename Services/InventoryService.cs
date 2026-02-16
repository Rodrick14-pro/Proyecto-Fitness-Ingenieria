using System;
using System.Linq; // Necesario para usar herramientas de búsqueda avanzada
using System.Collections.Generic;
using ProfessionalPayments.Models;

namespace ProfessionalPayments.Services
{
    public class InventoryService
    {
        
        // Esta lista guardará tus diseños de Pump Covers
        private List<PumpCover> _catalog = new List<PumpCover>();
        public InventoryService()
        {
            // Agregamos 3 productos con diferentes ganancias para probar el análisis
            _catalog.Add(new PumpCover { Name = "Classic", Size = "L", DesignName = "Logo", ProductionCost = 10, ShippingCost = 5, SalePrice = 25 }); // Profit: 10
            _catalog.Add(new PumpCover { Name = "Vintage", Size = "XL", DesignName = "Old School", ProductionCost = 12, ShippingCost = 5, SalePrice = 40 }); // Profit: 23 (El mejor)
            _catalog.Add(new PumpCover { Name = "Street", Size = "M", DesignName = "Cyber", ProductionCost = 15, ShippingCost = 5, SalePrice = 25 }); // Profit: 5
        }

        public void AddProduct(PumpCover product)
        {
            _catalog.Add(product);
        }

        public List<PumpCover> GetProducts()
        {
            return _catalog;
        }

        public void ShowCatalog()
        {
            if (_catalog.Count == 0)
            {
                Console.WriteLine("⚠️ El inventario está vacío.");
                return;
            }

            Console.WriteLine("--- CATÁLOGO DE PUMP COVERS ---");
            foreach (var item in _catalog)
            {
                double profit = item.CalculateProfit();
                Console.WriteLine($"- {item.Name} ({item.Size}) | Diseño: {item.DesignName}");
                Console.WriteLine($"  Precio: ${item.SalePrice} | Ganancia: ${profit:F2}");
                Console.WriteLine("-----------------------------------");
            }
        }
        public void ShowMostProfitableProduct()
        {
            if (_catalog.Count == 0) return;

            // Buscamos el producto que tenga el CalculateProfit() más alto
            var bestProduct = _catalog.OrderByDescending(p => p.CalculateProfit()).FirstOrDefault();

            if (bestProduct != null)
            {
                Console.WriteLine($"\nAnálisis de Negocio 📈:");
                Console.WriteLine($"Tu producto más rentable es: {bestProduct.Name}");
                Console.WriteLine($"Ganancia neta: ${bestProduct.CalculateProfit():F2}");
            }
        }
        
    }
}