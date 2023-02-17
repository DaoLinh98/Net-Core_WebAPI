using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore_API.Data;
using NetCore_API.Model;
using NetCore_API.Repository;
using NetCore_API.Service;

namespace NetCore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {

        private readonly IAssetService _assetService;
        private readonly IAssetRepository _assetRpository;

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
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            return Ok(_assetRpository.getById(id));  
        }

    }
}
