namespace Backend.Shared.Entities.Interface.Repository
{
    /// <summary>
    /// IBaseRepositoryCommonsMySQL
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Backend.Shared.Entities.Interface.Repository.IBaseRepository&lt;T&gt;" />
    public interface IBaseRepositoryCommonsMySQL<T> : IBaseRepository<T> where T : class
    {
    }
}