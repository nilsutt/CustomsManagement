namespace CustomsManagement.Application.Constants;

public static class ValidationMessages
{
    public const string ImporterExporterNameRequired = "İthalatçı/İhracatçı adı zorunludur.";
    public const string ProductTypeRequired = "Ürün tipi zorunludur.";
    public const string DeclaredValueRequired = "Beyan edilen değer sıfırdan büyük olmalıdır.";
    public const string TaxRequired = "Vergi sıfırdan büyük veya eşit olmalıdır.";
    public const string StatusRequired = "Durum bilgisi zorunludur.";
    public const string DelayedDayCountPositive = "Gecikme gün sayısı sıfırdan büyük olmalıdır.";
}
