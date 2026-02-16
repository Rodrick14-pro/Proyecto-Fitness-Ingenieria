namespace ProfessionalPayments.Models
{
    public class PumpCover
    {
        public string Name { get; set; } = "";
        public string Size { get; set; } = ""; // M, L, XL, XXL
        public string DesignName { get; set; } = "";
        
        // Dinero 💸
        public double ProductionCost { get; set; } // Lo que te cobra el proveedor
        public double ShippingCost { get; set; }   // Costo de envío
        public double SalePrice { get; set; }      // A cuánto lo vendes al cliente

        // Método para calcular la ganancia neta
        public double CalculateProfit()
        {
            return SalePrice - (ProductionCost + ShippingCost);
        }
    }
}