// -----------------------------------------------------------------------
// <copyright file="EmailSendApiRequestExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Validation;


/// <summary>
/// A set of extensions for <see cref="EmailSendApiRequest"/> validation
/// </summary>
public static class EmailSendApiRequestValidationExtensions
{
    /// <summary>
    /// Allows to check safely if <see cref="EmailSendApiRequest"/> instance is valid
    /// and won't throw validation exceptions during send.
    /// </summary>
    /// <param name="request"></param>
    /// <returns>Flag indicating data validity</returns>
    /// <exception cref="ArgumentNullException" />
    public static bool IsValid(this EmailSendApiRequest request)
    {
        Ensure.NotNull(request, nameof(request));

        return EmailSendApiRequestValidator.Instance.Validate(request).IsValid;
    }

    /// <summary>
    /// This helper validates provided <paramref name="request"/> and throws <see cref="ValidationException"/>
    /// in case any validation issues arise.
    /// </summary>
    /// <param name="request"></param>
    /// <exception cref="ArgumentNullException" />
    /// <exception cref="ValidationException" />
    public static void Validate(this EmailSendApiRequest request)
    {
        Ensure.NotNull(request, nameof(request));

        EmailSendApiRequestValidator.Instance.ValidateAndThrow(request);
    }
}
