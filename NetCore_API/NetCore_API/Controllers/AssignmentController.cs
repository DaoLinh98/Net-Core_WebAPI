using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_API.Repository;
using NetCore_API.Service;
using NLog;

namespace NetCore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        //private readonly IAssetService _assetService;
        private readonly IAssignmentRepository _assignmentRpository;
        private static readonly NLog.ILogger Logger = LogManager.GetCurrentClassLogger();
        public AssignmentController(IAssignmentRepository assignmentRepository, IAssetRepository assetRpository)
        {
            _assignmentRpository = assignmentRepository;
           // _assetRpository = assetRpository;
        }

        [HttpGet()]
        public IActionResult GetValue()
        {
            _assignmentRpository.getvalue();
            return Ok();

        }
    }
}
