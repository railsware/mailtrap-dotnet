// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT License.
// Copyright(c).NET Foundation and Contributors

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
