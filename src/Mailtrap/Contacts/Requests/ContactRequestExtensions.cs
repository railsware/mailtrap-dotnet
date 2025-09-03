namespace Mailtrap.Contacts.Requests;


internal static class ContactRequestExtensions
{
    public static CreateContactRequestDto ToDto(this CreateContactRequest request) => new(request);

    public static UpdateContactRequestDto ToDto(this UpdateContactRequest request) => new(request);
}
