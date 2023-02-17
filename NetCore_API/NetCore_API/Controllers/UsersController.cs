using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_API.Model;
using NetCore_API.Service;
using NLog;

namespace NetCore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        private static readonly NLog.ILogger Logger = LogManager.GetCurrentClassLogger();
        [HttpGet]
        public IActionResult getAll()
        {
            try
            {
                // Initialize NLog with your configuration file
                LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration("nlog.config", true);
                // Log something to trigger NLog to create the zip file
                Logger.Info("This are lists User");
                return Ok(_userService.getAll());

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("test")]
        public IActionResult getAllTest()
        {
            try
            {
                // Initialize NLog with your configuration file
                LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration("nlog.config", true);
                // Log something to trigger NLog to create the zip file
                Logger.Info("This are lists User");
                return Ok(_userService.getAllTest());

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message.ToString());
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("pagingandsorting")]
        public IActionResult pagingAndSorting([FromQuery] int pageIndex, [FromQuery] int pageSize, [FromQuery] string sortBy)
        {
            try
            {
                return Ok(_userService.pagingAndSorting(pageIndex, pageSize, sortBy));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            try
            {
                return Ok(_userService.getById(id));

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost]
        public IActionResult add(UserRepuest userModel)
        {
            try
            {
                _userService.add(userModel);
                return Ok();


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult updateById(int id, UserRespone userVM)
        {
            if (id != userVM.User_Id)
            {
                return BadRequest();
            }
            try
            {
                _userService.updateById(id, userVM);
                return NoContent();


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult deleteById(int id)
        {
            try
            {
                _userService.deleteById(id);
                return NoContent();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
