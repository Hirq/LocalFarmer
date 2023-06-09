﻿namespace LocalFarmer.Web.Services
{
    public interface IFarmhouseService
    {
        public Task<List<Farmhouse>> GetFarmhouses();
        public Task<List<Farmhouse>> GetFarmhousesWithProducts();
        public Task<List<FarmhouseViewModel>> GetFarmhousesWithProductsAndButton();
        public Task<Farmhouse> GetFarmhouse(int id);
    }
}
