// -----------------------------------------------------------------------
// <copyright file="SendEmailRequestValidationExtensions.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Email.Extensions;


/// <summary>
/// A set of extensions for <see cref="SendEmailRequest"/> validation.
/// </summary>
public static class SendEmailRequestValidationExtensions
{
    /// <summary>
    /// Allows to check if <paramref name="request"/> is valid
    /// and won't throw validation exceptions during send.
    /// </summary>
    /// 
    /// <param name="request">
    /// <see cref="SendEmailRequest"/> instance to validate.
    /// </param>
    /// 
    /// <returns>
    /// <see langword="true"/> if <paramref name="request"/> is valid.<br />
    /// <see langword="false"/> otherwise.
    /// </returns>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When provided <paramref name="request"/> is <see langword="null"/>.
    /// </exception>
    public static bool IsValid(this SendEmailRequest request)
    {
        Ensure.NotNull(request, nameof(request));

        return SendEmailRequestValidator.Instance.Validate(request).IsValid;
    }

    /// <summary>
    /// Validates provided <paramref name="request"/> and throws
    /// <see cref="ArgumentException"/> in case of any validation errors.
    /// </summary>
    /// 
    /// <param name="request">
    /// <see cref="SendEmailRequest"/> instance to validate.
    /// </param>
    /// 
    /// <exception cref="ArgumentNullException">
    /// When provided <paramref name="request"/> is <see langword="null"/>.
    /// </exception>
    /// 
    /// <exception cref="ArgumentException">
    /// When validation fails.
    /// </exception>
    public static void Validate(this SendEmailRequest request)
    {
        Ensure.NotNull(request, nameof(request));

        SendEmailRequestValidator.Instance
            .Validate(request)
            .EnsureValidity(nameof(request));
    }
}
