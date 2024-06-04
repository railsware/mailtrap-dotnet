// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT License.
// Copyright (c) .NET Foundation and Contributors

namespace Mailtrap.ForCleanup.Disposable;


/// <summary>
/// Provides a set of static methods for creating <see cref="IDisposable"/> objects.
/// </summary>
public static partial class Disposable
{
    /// <summary>
    /// Represents a disposable that does nothing on disposal.
    /// </summary>
    private sealed class EmptyDisposable : IDisposable
    {
        /// <summary>
        /// Singleton default disposable.
        /// </summary>
        public static readonly EmptyDisposable Instance = new();

        private EmptyDisposable()
        {
        }

        /// <summary>
        /// Does nothing.
        /// </summary>
        public void Dispose()
        {
            // no op
        }
    }

    /// <summary>
    /// Gets the disposable that does nothing when disposed.
    /// </summary>
    public static IDisposable Empty => EmptyDisposable.Instance;

    /// <summary>
    /// Creates a disposable object that invokes the specified action when disposed.
    /// </summary>
    /// <param name="dispose">Action to run during the first call to <see cref="IDisposable.Dispose"/>. The action is guaranteed to be run at most once.</param>
    /// <returns>The disposable object that runs the given action upon disposal.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="dispose"/> is <c>null</c>.</exception>
    public static IDisposable Create(Action dispose)
    {
        ExceptionHelpers.ThrowIfNull(dispose, nameof(dispose));

        return new AnonymousDisposable(dispose);
    }

    /// <summary>
    /// Creates a disposable object that invokes the specified action when disposed.
    /// </summary>
    /// <param name="state">The state to be passed to the action.</param>
    /// <param name="dispose">Action to run during the first call to <see cref="IDisposable.Dispose"/>. The action is guaranteed to be run at most once.</param>
    /// <returns>The disposable object that runs the given action upon disposal.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="dispose"/> is <c>null</c>.</exception>
    public static IDisposable Create<TState>(TState state, Action<TState> dispose)
    {
        ExceptionHelpers.ThrowIfNull(dispose, nameof(dispose));

        return new AnonymousDisposable<TState>(state, dispose);
    }
}
