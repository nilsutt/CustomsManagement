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
        public bool Deleted { get; private set; }
        public DateTime? DeletedDate { get; private set; }

        public Shipment()
        {
        }

        public Shipment(string importerExporterName, ProductType productType, decimal declaredValue)
        {
            ImporterExporterName = importerExporterName;
            ProductType = productType;
            DeclaredValue = declaredValue;
            Tax = CalculateTax();
            Status = ShipmentStatus.Pending;
            CreatedDate = DateTime.UtcNow;
            Deleted = false;
            DeletedDate = null;
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
        
        public void MarkAsDeleted()
        {
            Deleted = true;
            DeletedDate = DateTime.UtcNow;
        }

        public void UpdateDetails(string importerExporterName, ProductType productType, decimal declaredValue, string status)
        {
            if (string.IsNullOrWhiteSpace(importerExporterName))
            {
                throw new ArgumentException("Importer/Exporter Name cannot be null or empty.");
            }

            if (declaredValue <= 0)
            {
                throw new ArgumentException("Declared Value must be greater than zero.");
            }
            
            ImporterExporterName = importerExporterName;
            ProductType = productType;
            DeclaredValue = declaredValue;
            Status = status;
        }
    }
}