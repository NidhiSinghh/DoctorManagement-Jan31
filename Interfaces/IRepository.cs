namespace DoctorApplication.Interfaces
{
    /// <summary>
    /// Interface for a repository handling operations related to doctors.
    /// </summary>
    /// <typeparam name="K">The type of the key used to identify doctors.</typeparam>
    /// <typeparam name="T">The type of the doctor entity.</typeparam>
    public interface IRepository<K, T>
    {
       



        public Task<T> GetAsync(K key);
        public Task<List<T>> GetAsync();
        public Task<T> Add(T item);
        public Task<T> Update(T item);
        public Task<T> Delete(K key);
        
    }


}
