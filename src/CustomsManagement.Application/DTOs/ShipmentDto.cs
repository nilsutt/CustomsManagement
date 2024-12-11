namespace CustomsManagement.Application.DTOs;

public class ShipmentDto
{
    public int Id { get; set; }
    public string ImporterExporterName { get; set; }
    public string ProductType { get; set; }
    public decimal DeclaredValue { get; set; }
    public decimal Tax { get; set; }
    public string Status { get; set; }
    public DateTime CreatedDate { get; set; }
}