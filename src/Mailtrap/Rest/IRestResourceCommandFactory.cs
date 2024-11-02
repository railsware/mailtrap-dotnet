// -----------------------------------------------------------------------
// <copyright file="IRestResourceCommandFactory.cs" company="Railsware Products Studio, LLC">
// Copyright (c) Railsware Products Studio, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Mailtrap.Rest;


internal interface IRestResourceCommandFactory
{
    public GetRestResourceCommand<TResponse> CreateGet<TResponse>(Uri resourceUri, params string[] additionalAcceptContentTypes);
    public GetWithPlainTextResultRestResourceCommand CreatePlainText(Uri resourceUri, params string[] additionalAcceptContentTypes);
    public PatchRestResourceCommand<TResponse> CreatePatch<TResponse>(Uri resourceUri);
    public DeleteRestResourceCommand<TResponse> CreateDelete<TResponse>(Uri resourceUri);

    public PostWithStatusCodeResultRestResourceCommand<TRequest> CreatePostWithStatusCodeResult<TRequest>(Uri resourceUri, TRequest request) where TRequest : class;

    public PostRestResourceCommand<TRequest, TResponse> CreatePost<TRequest, TResponse>(Uri resourceUri, TRequest request) where TRequest : class;
    public PutRestResourceCommand<TRequest, TResponse> CreatePut<TRequest, TResponse>(Uri resourceUri, TRequest request) where TRequest : class;
    public PatchWithContentRestResourceCommand<TRequest, TResponse> CreatePatchWithContent<TRequest, TResponse>(Uri resourceUri, TRequest request) where TRequest : class;
}
