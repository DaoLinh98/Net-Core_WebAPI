using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NetCore_API.Data;
using NetCore_API.Model;
using NetCore_API.Repository;

namespace NetCore_API.Service
{
    public interface IAssetService
    {
        String add(AssetRequest assetModel);
        public AssetRespone getById(int? id);
        public List<AssetResponseAll> getAll();

    }

    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRpository;

        private readonly DataContext _context;

        public AssetService(IAssetRepository assetRpository, DataContext context)
        {
            _context= context;
            _assetRpository = assetRpository;
        }
        public AssetService(IAssetRepository assetRpository)
        {
            
            _assetRpository = assetRpository;
        }

        public string add(AssetRequest assetModel)
        {
            if ( assetModel == null)
            {
                throw new ArgumentException("Asset Name incorrect!");
            }
            var dkm = _assetRpository.getByUserName(assetModel.Asset_Name);
            if (dkm != null)
            {
                throw new ArgumentException("Asset Name allredy!");
            }
            else
            {

                 _assetRpository.add(assetModel);
                return "Done";
            }


            //var assetexit = _context.Assets.Where(u => u.Asset_Name == assetModel.Asset_Name).FirstOrDefault();
            //if (assetModel == null || assetexit != null)
            //{
            //    throw new ArgumentException("Asset Name incorrect!");
            //}
            //_assetRpository.add(assetModel);
        }

        public List<AssetResponseAll> getAll()
        {
            var listAssets = _assetRpository.getAll();
            if (listAssets == null)
            {
                return null;
            }

            return listAssets;
        }

        public AssetRespone getById(int? id)
        {
            if(id == null)
            {
                throw new ArgumentException("id invalid!");

            }
            if (_assetRpository.getById(id) == null)
            {
                throw new ArgumentException("Asset does not exist!");
            }
            return _assetRpository.getById(id);
        }
    }
}
