using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCore_API.Model;
using NetCore_API.Service;
using NLog;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using ILogger = NLog.ILogger;

namespace NetCore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentsController> _logger;
        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
           
        }
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        [HttpGet]
        public IActionResult getAll()
        {
            try
            {
                var departments = new List<DepartmentRespone>();
                departments = _departmentService.getAll();
                // Initialize NLog with your configuration file
                LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration("nlog.config", true);
                // Log something to trigger NLog to create the zip file
                Logger.Info("This are lists Department!");
                return Ok(departments);

            }
            catch (Exception ex)
            {
                Logger.Error($"########### {ex.Message.ToString()} ############");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("users")]
        [Authorize]
        public IActionResult getAllWithUser()
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                string jwt = Request.Headers["Authorization"];

                if (string.IsNullOrEmpty(jwt))
                {
                    return BadRequest("Authorization header is missing.");
                }

                if (!jwt.StartsWith("Bearer "))
                {
                    return BadRequest("Authorization header is not a bearer token.");
                }

                jwt = jwt.Substring(7);
                var token = handler.ReadToken(jwt) as JwtSecurityToken;

                if (token.ValidTo.ToLocalTime() < DateTime.Now)
                {
                    return Unauthorized();
                }

                return Ok(_departmentService.getAllWithUsers());

            }
            catch (Exception ex)
            {
                Logger.Error($"########### {ex.Message.ToString()} ############");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            try
            {
                return Ok(_departmentService.getById(id));

            }
            catch (Exception ex)
            {
                Logger.Error($"########### {ex.Message.ToString()} ############");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult add(DepartmentRequest departModel)
        {
            try
            {
                _departmentService.add(departModel);
                return NoContent();

            }
            catch (Exception ex) { Logger.Error($"########### {ex.Message.ToString()} ############"); return BadRequest(ex.Message);     }
        }

        [HttpPut("{id}")]
        public IActionResult updateById(int id, DepartmentRespone departVM)
        {
            if (id != departVM.Depart_Id)
            {
                return BadRequest();
            }
            try
            {
                _departmentService.updateById(id, departVM);
                return NoContent();


            }
            catch (Exception ex) { Logger.Error($"########### {ex.Message.ToString()} ############"); return BadRequest(ex.Message); }
        }

        [HttpDelete("{id}")]
        public IActionResult deleteById(int id)
        {
            try
            {
                _departmentService.deleteById(id);
                return NoContent();

            }
            catch (Exception ex) { Logger.Error($"########### {ex.Message.ToString()} ############"); return BadRequest(ex.Message); }
        }
    }
}
