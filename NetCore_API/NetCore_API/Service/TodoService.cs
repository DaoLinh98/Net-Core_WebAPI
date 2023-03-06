using NetCore_API.Repository;

namespace NetCore_API.Service
{
    public interface ITodoService
    {
        List<int> Lay();
        int LayTheoId(int a);
        int Them(string key);
    }
    public class TodoService : ITodoService
    {
        ITodoRepository todoRepository;
        public TodoService      (ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }
        public List<int> Lay()
        {
            throw new NotImplementedException();
        }

        public int LayTheoId(int a)
        {
            throw new NotImplementedException();
        }

        public int Them(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return -1;
            }
            var dkm = todoRepository.GetById(int.Parse(key));
            if (dkm != null)
            {
                return -2;
            } else
            {
                return todoRepository.Add(key);
            }
        }
    }
}
