namespace Mailtrap.TestingMessages.Requests;


internal static class TestingMessageRequestExtensions
{
    public static UpdateTestingMessageRequestDto ToDto(this UpdateTestingMessageRequest request)
    {
        return new UpdateTestingMessageRequestDto
        {
            Message = request
        };
    }
}
