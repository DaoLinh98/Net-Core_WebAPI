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
        void add(UserRepuest userModel);
        void updateById(int id, UserRespone userVM);
        void deleteById(int id);
        List<UserRespone> pagingAndSorting(int pageIndex, int pageSize, string sortBy);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void add(UserRepuest userModel)
        {
            _userRepository.add(userModel);
        }

        public void deleteById(int id)
        {
            _userRepository.deleteById(id);
        }

        public List<UserRespone> getAll()
        {
            return _userRepository.getAll();
        }

        public List<UserVM> getAllTest()
        {
            return _userRepository.getAllTest();
        }

        public UserRespone getById(int id)
        {
            return _userRepository.getById(id);
        }

        public List<UserRespone> pagingAndSorting(int pageIndex, int pageSize, string sortBy)
        {
            return _userRepository.pagingAndSorting(pageIndex, pageSize, sortBy);
        }

        public void updateById(int id, UserRespone userVM)
        {
            _userRepository.updateById(id, userVM);
        }
    }
}
