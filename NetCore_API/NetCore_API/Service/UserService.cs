using NetCore_API.Data;
using NetCore_API.Model;
using NetCore_API.Repository;
using System.Security.Claims;

namespace NetCore_API.Service
{
    public interface IUserService
    {
        List<UserRespone>getAll();
        List<UserVM>getAllTest();
        UserRespone getById(int id);
        String add(UserRepuest userModel);
        string updateById(int id, UserRespone userVM);
        string deleteById(int id);
        List<UserRespone> pagingAndSorting(int pageIndex, int pageSize, string sortBy);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly DataContext _context;

        public UserService(IUserRepository userRepository, DataContext context)
        {
            _context = context;
            _userRepository = userRepository;
        }
        public UserService(IUserRepository userRepository)
        {
         
            _userRepository = userRepository;
        }

        public String add(UserRepuest userModel)
        {
            if (userModel == null)
            {
                throw new ArgumentException("User incorrect!");
            }
            var dkm = _userRepository.getByUserName(userModel.User_Name);
            if (dkm != null)
            {
                throw new ArgumentException("Asset Name allredy!");
            }
            else
            {
                _userRepository.add(userModel);
                return "Done";
            }
        }

        public string deleteById(int id)
        {
            if(_userRepository.getById(id) == null)
            {
                throw new ArgumentException("User does not exit!");
            }
            _userRepository.deleteById(id);
            return "Done";
        }

        public List<UserRespone> getAll()
        {
            if(_userRepository.getAll() == null)
            {
                throw new ArgumentException("List Item is null");
            }
            return _userRepository.getAll();
        }

        public List<UserVM> getAllTest()
        {
            return _userRepository.getAllTest();
        }

        public UserRespone getById(int id)
        {
            if(_userRepository.getById(id) == null)
            {
                throw new ArgumentException("User does not exist!");
            }
            return _userRepository.getById(id);
        }

        public List<UserRespone> pagingAndSorting(int pageIndex, int pageSize, string sortBy)
        {
            if(pageIndex < 0)
            {
                throw new ArgumentException("Page index incorect!");
            }
            if(pageSize < 0)
            {
                throw new ArgumentException("Page size incorrect!");
            }
            return _userRepository.pagingAndSorting(pageIndex, pageSize, sortBy);
        }

        public string updateById(int id, UserRespone userVM)
        {
            if(_userRepository.getById(id) == null)
            {
                throw new ArgumentException("User does not exist!");
            }
            if(id != userVM.User_Id)
            {
                throw new ArgumentException("Update incorrect!");
            }
            _userRepository.updateById(id, userVM);
            return "Done";
        }
    }
}
