namespace HospitalApp.Services.Interfaces
{
    public interface ICRUDService<T> where T : class
    {
        T Get(int id);
        int Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
