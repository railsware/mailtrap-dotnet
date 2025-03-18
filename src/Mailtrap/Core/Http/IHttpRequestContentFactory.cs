namespace Mailtrap.Core.Http;


/// <summary>
/// Factory to spawn <see cref="HttpContent"/> instances.
/// </summary>
internal interface IHttpRequestContentFactory
{
    /// <summary>
    /// Creates a new <see cref="StringContent"/> instance, using provided string.
    /// </summary>
    /// 
    /// <returns>
    /// New <see cref="StringContent"/> instance or <see langword="null"/>
    /// when provided <paramref name="content"/> is <see langword="null"/>.
    /// </returns>
    public StringContent? CreateStringContent<T>(T? content);
}
