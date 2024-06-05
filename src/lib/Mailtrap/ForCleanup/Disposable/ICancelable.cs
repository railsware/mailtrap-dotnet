// -----------------------------------------------------------------------
// <copyright file="ICancelable.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Mailtrap.ForCleanup.Disposable;


/// <summary>
/// Disposable resource with disposal state tracking.
/// </summary>
public interface ICancelable : IDisposable
{
    /// <summary>
    /// Gets a value that indicates whether the object is disposed.
    /// </summary>
    bool IsDisposed { get; }
}
