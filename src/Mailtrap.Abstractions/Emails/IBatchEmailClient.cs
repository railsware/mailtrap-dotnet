namespace Mailtrap.Emails;


/// <summary>
/// Mailtrap API client for sending emails in a batch.
/// </summary>
public interface IBatchEmailClient : IEmailClient<BatchEmailRequest, BatchEmailResponse> { }
