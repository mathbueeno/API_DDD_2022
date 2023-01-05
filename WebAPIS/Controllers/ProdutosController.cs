using Domain.InterfacesExternas;
using Entities.EntidadesExternas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProduto _Iproduto;

        public ProdutosController(IProduto IProduto)
        {
            _Iproduto= IProduto;
        }

        [Produces("application/json")]
        [HttpPost("/api/ListProd")]
        public List<Produto> ListProd()
        {
            return _Iproduto.List();
        }

        [Produces("application/json")]
        [HttpPost("/api/GetOne")]
        public Produto GetOne(int id)
        {
            return _Iproduto.GetOne(id);
        }

        [Produces("application/json")]
        [HttpPost("/api/CreateProd")]
        public bool CreateProd(Produto collection)
        {
            try
            {
                _Iproduto.Create(collection);

                return true;
            } 
            catch
            {
                return false;
            }
        }

        [Produces("application/json")]
        [HttpPost("/api/UpdateProd")]
        public bool UpdateProd(Produto collection)
        {
            try
            {
                _Iproduto.Update(collection);

                return true;
            }
            catch
            {
                return false;
            }
        }


        [Produces("application/json")]
        [HttpPost("/api/DeleteProd")]
        public bool DeleteProd(int id)
        {
            try
            {
                _Iproduto.Delete(id);

                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
