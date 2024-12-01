// -----------------------------------------------------------------------
// <copyright file="MailtrapException.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Core.Exceptions;


/// <summary>
/// Generic exception for the Mailtrap library.
/// </summary>
public abstract class MailtrapException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MailtrapException"/> class.
    /// </summary>
    protected MailtrapException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="MailtrapException"/> class with a specified error message.
    /// </summary>
    /// 
    /// <param name="message">
    /// <inheritdoc cref="Exception(string)" path="/param[@name='message']"/>
    /// </param>
    protected MailtrapException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="MailtrapException"/> class
    /// with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    ///
    /// <param name="message">
    /// <inheritdoc cref="Exception(string, Exception)" path="/param[@name='message']"/>
    /// </param>
    ///
    /// <param name="innerException">
    /// <inheritdoc cref="Exception(string, Exception)" path="/param[@name='innerException']"/>
    /// </param>
    protected MailtrapException(string message, Exception innerException) : base(message, innerException) { }
}
