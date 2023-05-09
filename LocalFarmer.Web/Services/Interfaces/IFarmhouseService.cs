﻿namespace LocalFarmer.Web.Services
{
    public interface IFarmhouseService
    {
        List<Farmhouse> Farmhouses { get; set;}
        public Task<List<Farmhouse>> GetFarmhouses();
        public Task<Farmhouse> GetFarmhouse(int id);
    }
}
