using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore_API.Data;
using NetCore_API.Model;
using NetCore_API.Repository;
using NetCore_API.Service;
using NLog;

namespace NetCore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {

        private readonly IAssetService _assetService;
        private readonly IAssetRepository _assetRpository;
        private static readonly NLog.ILogger Logger = LogManager.GetCurrentClassLogger();
        public AssetsController(IAssetService assetService, IAssetRepository assetRpository)
        {
            _assetService = assetService;
            _assetRpository = assetRpository;

        }

        [HttpPost]
        public IActionResult add(AssetRequest assetModel)
        {
            try
            {
                _assetService.add(assetModel);
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.Error($"########### {ex.Message.ToString()} ############");
                return BadRequest(ex.Message);
            }
        }


        [HttpGet()]
        public IActionResult getAll(int id)
        {
            try
            {
                return Ok(_assetService.getAll());
            }
            catch (Exception ex)
            {
                Logger.Error($"########### {ex.Message.ToString()} ############");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult getById(int? id)
        {
            try
            {
                return Ok(_assetRpository.getById(id));
            }
            catch (Exception ex)
            {
                Logger.Error($"########### {ex.Message.ToString()} ############");
                return BadRequest(ex.Message);
            }
        }

    }
}
