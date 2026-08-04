namespace Mailtrap.Inbound;


internal sealed class InboundMessageResource : RestResource, IInboundMessageResource
{
    public InboundMessageResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public Task<InboundMessage> GetDetails(CancellationToken cancellationToken = default)
        => Get<InboundMessage>(cancellationToken);

    public Task Delete(CancellationToken cancellationToken = default)
        => DeleteWithStatusCodeResult(cancellationToken);

    public Task<SendMessageResult> Reply(ReplyInboundMessageRequest request, CancellationToken cancellationToken = default)
        => Send(UrlSegments.ReplySegment, request, cancellationToken);

    public Task<SendMessageResult> ReplyAll(ReplyInboundMessageRequest request, CancellationToken cancellationToken = default)
        => Send(UrlSegments.ReplyAllSegment, request, cancellationToken);

    public Task<SendMessageResult> Forward(ForwardInboundMessageRequest request, CancellationToken cancellationToken = default)
        => Send(UrlSegments.ForwardSegment, request, cancellationToken);


    private Task<SendMessageResult> Send<TRequest>(string segment, TRequest request, CancellationToken cancellationToken)
        where TRequest : class
    {
        Ensure.NotNull(request, nameof(request));

        return RestResourceCommandFactory
            .CreatePost<TRequest, SendMessageResult>(ResourceUri.Append(segment), request)
            .Execute(cancellationToken);
    }
}
