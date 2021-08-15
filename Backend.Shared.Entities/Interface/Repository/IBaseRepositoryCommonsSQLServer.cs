namespace Backend.Shared.Entities.Interface.Repository
{
    /// <summary>
    /// IBaseRepositoryCommonsSQLServer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Backend.Shared.Entities.Interface.Repository.IBaseRepository&lt;T&gt;" />
    public interface IBaseRepositoryCommonsSQLServer<T> : IBaseRepository<T> where T : class
    {
    }
}