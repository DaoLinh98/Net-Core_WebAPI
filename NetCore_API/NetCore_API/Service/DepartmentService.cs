using NetCore_API.Model;
using NetCore_API.Repository;

namespace NetCore_API.Service
{
    public interface IDepartmentService
    {
        List<DepartmentRespone> getAll();
        List<DepartmentRespone> getAllWithUsers();
        DepartmentRespone getById(int id);
        void add(DepartmentRequest departModel);
        void updateById(int id, DepartmentRespone departVM);
        void deleteById(int id);
    }
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void add(DepartmentRequest departModel)
        {
            _departmentRepository.add(departModel);

        }

        public void deleteById(int id)
        {
            _departmentRepository.deleteById(id);
        }

        public List<DepartmentRespone> getAll()
        {
            return _departmentRepository.getAll();
        }

        public List<DepartmentRespone> getAllWithUsers()
        {
            return _departmentRepository.getAllWithUsers();
        }

        public DepartmentRespone getById(int id)
        {
            return _departmentRepository.getById(id);
        }

        public void updateById(int id, DepartmentRespone departVM)
        {
            _departmentRepository.updateById(id, departVM);
        }
    }
}
