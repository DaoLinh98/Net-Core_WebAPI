namespace NetCore_API.Repository
{
    public interface ITodoRepository 
    {
        List<int> GetAll();
        int ? GetById(int a);
        int Add(string key);
    }
    public class TodoRepository : ITodoRepository
    {
        public int Add(string key)
        {
            return 999;
        }

        public List<int> GetAll()
        {
            throw new NotImplementedException();
        }

        public int ? GetById(int a)
        {
            throw new NotImplementedException();
        }
    }
}
