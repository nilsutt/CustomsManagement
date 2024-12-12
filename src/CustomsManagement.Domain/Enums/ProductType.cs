using System.ComponentModel.DataAnnotations;

namespace CustomsManagement.Domain.Constants;

public enum ProductType
{
    [Display(Name = "Elektronik")]
    Electronic = 1,
    
    [Display(Name = "Gıda")]
    Food = 2,
    
    [Display(Name = "Tekstil")]
    Textile = 3
}