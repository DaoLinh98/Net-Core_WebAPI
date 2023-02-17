using NetCore_API.Model;
using NetCore_API.Repository;

namespace NetCore_API.Service
{
    public interface IAssetService
    {
        void add(AssetRequest assetModel);
        public AssetRespone getById(int id);

    }

    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRpository;

        public AssetService(IAssetRepository assetRpository)
        {
            _assetRpository = assetRpository;
        }
        public void add(AssetRequest assetModel)
        {
            _assetRpository.add(assetModel);
        }

        public AssetRespone getById(int id)
        {
            return _assetRpository.getById(id);
        }
    }
}
