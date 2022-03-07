using JsonDiffProgram.Entity;

namespace JsonDiffProgram.DiffStorage
{
    public interface IDiffStorage
    {
        // our storage
        Dictionary<int, DiffItem> Data { get; set; }

        // storage methods
        Task SetLeft(int id, string data);
        Task SetRight(int id, string data);
        Task<bool> Remove(int id);
        Task<DiffResult> GetDiff(int id);
    }
}
