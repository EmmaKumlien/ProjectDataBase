using Infrastructure.Entities;

namespace Infrastructure.Dtos;

public class CustomerDTO
{
    public int Id { get; set; }    
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public BillingAdressEntity BillingAdress { get; set; } = new BillingAdressEntity();
    public ContactInformationEntity ContactInformation { get; set; } = new ContactInformationEntity();
}
