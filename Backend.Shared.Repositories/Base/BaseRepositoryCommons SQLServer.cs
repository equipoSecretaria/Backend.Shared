namespace Backend.Shared.Repositories.Base
{
    /// <summary>
    /// BaseRepositorySharedSQLServer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Backend.Shared.Repositories.Base.BaseRepository{T}" />
    /// <seealso cref="Backend.Shared.Entities.Interface.Repository.IBaseRepositoryCommonsMySQLSQLServer{T}" />
    public class BaseRepositorySharedSQLServer<T> : BaseRepository<T>, Entities.Interface.Repository.IBaseRepositoryCommonsSQLServer<T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepositorySharedSQLServer{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public BaseRepositorySharedSQLServer(Context.SharedSQLServerContext context)
        {
            AppContext = context;
        }
    }
}