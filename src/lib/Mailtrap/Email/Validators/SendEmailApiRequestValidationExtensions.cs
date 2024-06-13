// -----------------------------------------------------------------------
// <copyright file="EmailSendApiRequestExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.Email.Validators;


/// <summary>
/// A set of extensions for <see cref="SendEmailApiRequest"/> validation
/// </summary>
public static class SendEmailApiRequestValidationExtensions
{
    /// <summary>
    /// Allows to check safely if <see cref="SendEmailApiRequest"/> instance is valid
    /// and won't throw validation exceptions during send.
    /// </summary>
    /// <param name="request"></param>
    /// <returns>Flag indicating data validity</returns>
    /// <exception cref="ArgumentNullException" />
    public static bool IsValid(this SendEmailApiRequest request)
    {
        Ensure.NotNull(request, nameof(request));

        return SendEmailApiRequestValidator.Instance.Validate(request).IsValid;
    }

    /// <summary>
    /// This helper validates provided <paramref name="request"/> and throws <see cref="ValidationException"/>
    /// in case any validation issues arise.
    /// </summary>
    /// <param name="request"></param>
    /// <exception cref="ArgumentNullException" />
    /// <exception cref="ValidationException" />
    public static void Validate(this SendEmailApiRequest request)
    {
        Ensure.NotNull(request, nameof(request));

        SendEmailApiRequestValidator.Instance.ValidateAndThrow(request);
    }
}
