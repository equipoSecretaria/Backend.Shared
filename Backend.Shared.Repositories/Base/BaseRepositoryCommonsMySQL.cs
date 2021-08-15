namespace Backend.Shared.Repositories.Base
{
    /// <summary>
    /// BaseRepositoryCommonsMySQL
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Backend.Shared.Repositories.Base.BaseRepository&lt;T&gt;" />
    /// <seealso cref="Backend.Shared.Entities.Interface.Repository.IBaseRepositoryCommonsMySQL&lt;T&gt;" />
    public class BaseRepositoryCommonsMySQL<T> : BaseRepository<T>, Entities.Interface.Repository.IBaseRepositoryCommonsMySQL<T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepositoryCommonsMySQL{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public BaseRepositoryCommonsMySQL(Context.CommonsMySQLContext context)
        {
            AppContext = context;
        }
    }
}