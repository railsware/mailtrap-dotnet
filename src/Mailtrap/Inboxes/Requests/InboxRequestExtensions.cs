namespace Mailtrap.Inboxes.Requests;


internal static class InboxRequestExtensions
{
    public static CreateInboxRequestDto ToDto(this CreateInboxRequest request)
    {
        return new CreateInboxRequestDto
        {
            Inbox = request
        };
    }

    public static UpdateInboxRequestDto ToDto(this UpdateInboxRequest request)
    {
        return new UpdateInboxRequestDto
        {
            Inbox = request
        };
    }
}
