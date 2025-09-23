namespace Mailtrap.Contacts.Requests;


/// <summary>
/// Request object for creating contact.
/// </summary>
internal sealed record CreateContactRequestDto : ContactRequestDto<CreateContactRequest>
{
    public CreateContactRequestDto(CreateContactRequest request) : base(request) { }
}
