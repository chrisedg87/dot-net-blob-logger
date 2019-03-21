using System.Threading.Tasks;

namespace Logger
{
    public interface IAzureTableStorage<T>
    {
        Task Insert(T item);
    }
}