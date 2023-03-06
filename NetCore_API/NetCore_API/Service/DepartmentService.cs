using Microsoft.EntityFrameworkCore;
using NetCore_API.Data;
using NetCore_API.Entity;
using NetCore_API.Model;
using NetCore_API.Repository;

namespace NetCore_API.Service
{
    public interface IDepartmentService
    {
        List<DepartmentRespone> getAll();
        List<DepartmentRespone> getAllWithUsers();
        DepartmentRespone getById(int id);
        string add(DepartmentRequest departModel);
        string updateById(int id, DepartmentRespone departVM);
        string deleteById(int id);
    }
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly DataContext _context;

        public DepartmentService(IDepartmentRepository departmentRepository, DataContext context)
        {
            _context = context;
            _departmentRepository = departmentRepository;
        }
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
          
            _departmentRepository = departmentRepository;
        }

        public string add(DepartmentRequest departModel)
        {
            if (departModel == null)
            {
                throw new ArgumentException("Department incorrect!");
            }
            var dkm = _departmentRepository.getByUserName(departModel.Depart_Name);
            if (dkm != null)
            {
                throw new ArgumentException("Department Name allredy!");
            }
            else
            {
                _departmentRepository.add(departModel);
                return "Done";
            }
            //var departExit = _context.Departments.Where(d => d.Depart_Name == departModel.Depart_Name).FirstOrDefault();
            //if (departModel == null || departExit != null)
            //{
            //    throw new ArgumentException("Department Name incorrect!");
            //}
            //_departmentRepository.add(departModel);
            //return "Done";

        }

        public string deleteById(int id)
        {
            if (_departmentRepository.getById(id) == null)
            {
                throw new ArgumentException("Department does not exit!");
            }
            _departmentRepository.deleteById(id);
            return "Done";
        }

        public List<DepartmentRespone> getAll()
        {
            if (_departmentRepository.getAll() == null)
            {
                throw new ArgumentException("List Item is null");
            }
            return _departmentRepository.getAll();
        }

        public List<DepartmentRespone> getAllWithUsers()
        {
            if (_departmentRepository.getAllWithUsers() == null)
            {
                throw new ArgumentException("List Item is null");
            }
            return _departmentRepository.getAllWithUsers();
        }

        public DepartmentRespone getById(int id)
        {
            //if (_userRepository.getById(id) == null)
            //{
            //    throw new ArgumentException("User does not exist!");
            //}
            //return _userRepository.getById(id);

            if (_departmentRepository.getById(id) == null)
            {
                throw new ArgumentException("Department does not exist!");
            }
            return _departmentRepository.getById(id);
        }

        public string updateById(int id, DepartmentRespone departVM)
        {

            if (_departmentRepository.getById(id) == null)
            {
                throw new ArgumentException("Department does not exist!");
            }
            if (id != departVM.Depart_Id)
            {
                throw new ArgumentException("Update incorrect!");
            }
            _departmentRepository.updateById(id, departVM);
            return "Done";
        }
    }
}
