using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetCore_API.Data;
using NetCore_API.Entity;
using NetCore_API.Model;

namespace NetCore_API.Repository
{
    public interface IAssetRepository
    {
        void add(AssetRequest assetModel);
        AssetRespone getById(int? id);
        List<AssetResponseAll> getAll();
        public int? getByUserName(string userName);

    }
    public class AssetRepository : IAssetRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly DapperContext _dapper;
        public AssetRepository(DataContext context, DapperContext dapper, IMapper mapper)
        {
            _context = context;
            _dapper = dapper;
            _mapper = mapper;
        }
        public void add(AssetRequest assetModel)
        {


            var asset = new Asset
            {
                Asset_Name = assetModel.Asset_Name
            };

            _context.Assets.Add(asset);
            _context.SaveChanges();

        }

        public List<AssetResponseAll> getAll()
        {
            var listAssets = _context.Assets.ToList();
            List<AssetResponseAll> assetResponseAlls = new List<AssetResponseAll>();
            foreach (var assetModel in listAssets)
            {
                AssetResponseAll assetResponseAll = new AssetResponseAll();
                assetResponseAll.Asset_Id = assetModel.Asset_Id;
                assetResponseAll.Asset_Name = assetModel.Asset_Name;
                assetResponseAlls.Add(assetResponseAll);
            }
            return assetResponseAlls;
        }

  


        public AssetRespone getById(int? id)
        {

           var a = _context.Assignments.Include("User").Include("Asset").Where(x => x.Asset_Id == id);

            AssetRespone assetViewModel = new AssetRespone();
            assetViewModel.Asset_Id = a.First().Asset_Id;
            assetViewModel.Asset_Name = a.First().Asset.Asset_Name;
            List<UserRespone> listUserVM = new List<UserRespone>();
            foreach (var item in a)
            {
                UserRespone userVM = new UserRespone();
                userVM.User_Id = item.User.User_Id;
                userVM.User_Name = item.User.User_Name;
                userVM.Number_Phone = item.User.Number_Phone;
                userVM.Depart_Id = item.User.Depart_Id;
                userVM.DateOfbirth = item.User.DateOfbirth;
                listUserVM.Add(userVM);
                assetViewModel.userVMs.Add(userVM);
            }
            return assetViewModel;

        }

        public int? getByUserName(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
