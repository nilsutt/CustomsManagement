namespace CustomsManagement.Application.Constants;

public static class ExceptionMessages
{
    public const string ShipmentNotFound = "Sevkiyat bulunamadı.";
    public const string InvalidShipmentId = "Geçersiz sevkiyat ID'si.";
    public const string NoShipmentsAvailable = "Hiçbir sevkiyat bulunamadı.";
    public const string InvalidShipmentStatus = "Geçersiz sevkiyat durumu.";
    public const string ImporterExporterNameRequired = "İthalatçı/İhracatçı adı zorunludur.";
    public const string ProductTypeRequired = "Ürün tipi zorunludur.";
    public const string InvalidDeclaredValue = "Beyan edilen değer sıfırdan büyük olmalıdır.";
    public const string InvalidRequest = "Geçersiz istek.";
    public const string InvalidDelayedDayCount = "Gecikme gün sayısı sıfırdan büyük olmalıdır.";
}