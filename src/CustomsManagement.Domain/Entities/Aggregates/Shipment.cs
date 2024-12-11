using CustomsManagement.Domain.Constants;

namespace CustomsManagement.Domain.Entities.Aggregates
{
    public class Shipment : BaseEntity
    {
        public string ImporterExporterName { get; private set; }
        public ProductType ProductType { get; private set; }
        public decimal DeclaredValue { get; private set; }
        public decimal Tax { get; private set; }
        public string Status { get; private set; }
        
        private Shipment() { } 

        public Shipment(string importerExporterName, ProductType productType, decimal declaredValue)
        {
            ImporterExporterName = importerExporterName;
            ProductType = productType;
            DeclaredValue = declaredValue;
            Tax = CalculateTax();
            Status = ShipmentStatus.Pending;
            CreatedDate = DateTime.UtcNow;
        }

        private decimal CalculateTax()
        {
            return ProductType switch
            {
                ProductType.Electronic => DeclaredValue * 0.15m,
                ProductType.Food => DeclaredValue * 0.05m,
                ProductType.Textile => DeclaredValue * 0.10m,
                _ => 0
            };
        }

        public void UpdateStatus(string newStatus)
        {
            if (string.IsNullOrEmpty(newStatus))
                throw new ArgumentException("Status cannot be empty.");

            Status = newStatus;
        }

        public bool IsDelayed()
        {
            return Status == ShipmentStatus.Pending && (DateTime.UtcNow - CreatedDate).TotalDays > 3;
        }
    }
}
