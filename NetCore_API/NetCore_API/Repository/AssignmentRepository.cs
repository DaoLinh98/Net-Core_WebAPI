using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetCore_API.Data;

namespace NetCore_API.Repository
{
    public interface IAssignmentRepository{
        public void getvalue();
       
}
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly DapperContext _dapper;
        public AssignmentRepository(DataContext context, DapperContext dapper, IMapper mapper)
        {
            _context = context;
            _dapper = dapper;
            _mapper = mapper;
        }
            public void getvalue()
        {
            var result = _context.Assets.Where(a=> a.Asset_Id == 1).FirstOrDefault();

            _context.Entry(result).Collection(u => u.Assignments).Load();

            Console.WriteLine(result);
        }
    }
}
