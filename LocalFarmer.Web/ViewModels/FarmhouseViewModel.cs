﻿namespace LocalFarmer.Web.ViewModels
{
    public class FarmhouseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool ShowDetails { get; set; } = false;

        public IList<Product> Products { get; set; }
    }
}
