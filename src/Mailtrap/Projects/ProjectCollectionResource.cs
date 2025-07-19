namespace Mailtrap.Projects;


internal sealed class ProjectCollectionResource : RestResource, IProjectCollectionResource
{
    public ProjectCollectionResource(IRestResourceCommandFactory restResourceCommandFactory, Uri resourceUri)
        : base(restResourceCommandFactory, resourceUri) { }


    public async Task<IList<Project>> GetAll(CancellationToken cancellationToken = default)
        => await GetList<Project>(cancellationToken).ConfigureAwait(false);

    public async Task<Project> Create(CreateProjectRequest request, CancellationToken cancellationToken = default)
        => await Create<CreateProjectRequestDto, Project>(request.ToDto(), cancellationToken).ConfigureAwait(false);
}
