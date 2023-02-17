using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetCore_API.Data;
using NetCore_API.Entity;
using NetCore_API.Model;

namespace NetCore_API.Repository
{
    public interface IDepartmentRepository
    {
        List<DepartmentRespone> getAll();
        List<DepartmentRespone> getAllWithUsers();
        DepartmentRespone getById(int id);
        void add(DepartmentRequest departModel);
        void updateById(int id, DepartmentRespone departVM);
        void deleteById(int id);
    }
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly DapperContext _dapper;

        public DepartmentRepository(DataContext context, IMapper mapper, DapperContext dapper)
        {
            _context = context;
            _mapper = mapper;
            _dapper = dapper;
        }

        public void add(DepartmentRequest departModel)
        {
            var depart = new Department
            {
                Depart_Name = departModel.Depart_Name,
            };
            _context.Add(depart);
            _context.SaveChanges();
        }

        public void deleteById(int id)
        {
            var depart = _context.Departments.FirstOrDefault(de => de.Depart_Id == id);
            if (depart != null)
            {
                _context.Remove(depart);
                _context.SaveChanges();
            }
        }
        public void updateById(int id, DepartmentRespone departVM)
        {
            var depart = _context.Departments.FirstOrDefault(de => de.Depart_Id == id);
            if (depart != null)     
            {
                depart.Depart_Id = departVM.Depart_Id;
                depart.Depart_Name = departVM.Depart_Name;
                _context.SaveChanges();
            }
        }

        List<DepartmentRespone> IDepartmentRepository.getAll()
        {
            var departs = _context.Departments.Select(de => new DepartmentRespone
            {
                Depart_Id = de.Depart_Id,
                Depart_Name = de.Depart_Name,
            });

            return departs.ToList();
        }
        List<DepartmentRespone> IDepartmentRepository.getAllWithUsers()
        {
            var departments = (from department in _context.Departments
                               select new DepartmentRespone
                               {
                                   Depart_Id = department.Depart_Id,
                                   Depart_Name = department.Depart_Name,
                               }).ToList();
            return departments.ToList();

            foreach (var department in departments)
            {
                var users = from user in _context.Users
                            where user.Depart_Id == department.Depart_Id
                            select new UserRespone
                            {
                                User_Id = user.User_Id,
                                User_Name = user.User_Name,
                                Depart_Id = department.Depart_Id,
                                DateOfbirth = user.DateOfbirth,
                                Number_Phone = user.Number_Phone,
                            };
                department.Users = users.ToList();
            }

            return departments.ToList();
        }

        DepartmentRespone IDepartmentRepository.getById(int id)
        {
            var depart = _context.Departments.FirstOrDefault(de => de.Depart_Id == id);
            if (depart != null)
            {
                return new DepartmentRespone
                {
                    Depart_Id = depart.Depart_Id,
                    Depart_Name = depart.Depart_Name,
                };

            }
            return null;
        }
    }
}
