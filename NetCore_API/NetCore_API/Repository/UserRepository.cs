using AutoMapper;
using Dapper;
using Microsoft.EntityFrameworkCore;
using NetCore_API.Data;
using NetCore_API.Entity;
using NetCore_API.Model;

namespace NetCore_API.Repository
{
    public interface IUserRepository
    {
        List<UserRespone>getAll();
        List<UserVM>getAllTest();
        UserRespone getById(int id);
        void add(UserRepuest userModel);
        void updateById(int id, UserRespone userVM);
        void deleteById(int id);
        List<UserRespone> pagingAndSorting(int pageIndex, int pageSize, string sortBy);
    }
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly DapperContext _dapper;
        public UserRepository(DataContext context, IMapper mapper, DapperContext dapper)
        {
            _context = context;
            _mapper = mapper;
            _dapper = dapper;
        }

        public void add(UserRepuest userModel)
        {
            var user = new User
            {
                User_Name = userModel.User_Name,
                Number_Phone = userModel.Number_Phone,
                DateOfbirth= userModel.DateOfbirth,
                Depart_Id = userModel.Depart_Id,
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void deleteById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.User_Id == id);
            if (user != null)
            {
                _context.Remove(user);
                _context.SaveChanges();
            }
        }

        public List<UserRespone> getAll()
        {
            //var users = _context.Users.Select(u => new UserRespone
            //{
            //    User_Id = u.User_Id,
            //    User_Name = u.User_Name,
            //    Number_Phone = u.Number_Phone,
            //    DateOfbirth= u.DateOfbirth,
            //    Depart_Id = u.Department.Depart_Id,
            //});

            var users = _dapper.CreateConnection().Query<User>("SELECT * FROM Users");
            return _mapper.Map<List<UserRespone>>(users);
        }

        public List<UserVM> getAllTest()
        {
            var users = _context.Users.ToList();

            var userViewModel = _mapper.Map<List<UserVM>>(users);
            return userViewModel;
        }

        public UserRespone getById(int id)
        {
            var user = _context.Users.Include(d => d.Department).FirstOrDefault(u => u.User_Id == id);
            if (user != null)
            {
                return new UserRespone
                {
                    User_Id = user.User_Id,
                    User_Name = user.User_Name,
                    Number_Phone = user.Number_Phone,
                    Depart_Id = user.Department.Depart_Id,
                };

            }
            return null;
        }

        public List<UserRespone> pagingAndSorting(int pageIndex, int pageSize, string sortBy)
        {
            var users = _context.Users.Select(u => new UserRespone
            {
                User_Id = u.User_Id,
                User_Name = u.User_Name,
                Number_Phone = u.Number_Phone,
                Depart_Id = u.Department.Depart_Id,
            });

            if (sortBy == "User_Id")
            {
                users = users.OrderBy(u => u.User_Id);
            }
            else if (sortBy == "User_Name")
            {
                users = users.OrderBy(u => u.User_Name);
            }
            var results = users.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return results;
        }

        public void updateById(int id, UserRespone userVM)
        {
            var user = _context.Users.Include(d => d.Department).FirstOrDefault(u => u.User_Id == id);
            if (user != null)
            {
                user.User_Id = userVM.User_Id;
                user.User_Name = userVM.User_Name;
                user.Number_Phone = userVM.Number_Phone;
                user.Depart_Id = userVM.Depart_Id;
                _context.SaveChanges();
            }

        }
    }
}
