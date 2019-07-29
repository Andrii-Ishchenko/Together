namespace Together.DataAccess
{
    public interface IDbContextFactory<T>
    {
        T CreateDbContext();
    }
}