namespace Mailtrap.Contacts.Requests;


/// <summary>
/// Request object for updating contact details.
/// </summary>
internal sealed record UpdateContactRequestDto : ContactRequestDto<UpdateContactRequest>
{
    public UpdateContactRequestDto(UpdateContactRequest request) : base(request) { }
}
