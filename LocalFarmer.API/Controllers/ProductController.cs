using Microsoft.AspNetCore.Mvc;

namespace LocalFarmer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        [HttpGet, Route("ListProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetAllAsync
            (
                whereExpression: p => true,
                includeProperties: p => p.Farmhouse
            );

            return Ok(products);
        }

        [HttpGet, Route("Product/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            Product product = await _productRepository.GetFirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet, Route("ListProductsFarmhouse/{idFarmhouse}")]
        public async Task<IActionResult> GetProductsFarmhouse(int idFarmhouse)
        {
            var products = await _productRepository.GetAllAsync(x => x.IdFarmhouse == idFarmhouse);

            return Ok(products);
        }

        [HttpPost, Route("Product")]
        public async Task<IActionResult> AddProduct(ProductDto dto, int idFarmhouse)
        {
            Product product = _mapper.Map<Product>(dto);

            product.IdFarmhouse = idFarmhouse;

            _productRepository.Add(product);
            await _productRepository.SaveChangesAsync();

            return Ok(product);
        }
    }
}
