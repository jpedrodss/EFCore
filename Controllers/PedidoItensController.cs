using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Domains;
using EFCore.Interfaces;
using EFCore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoItensController : ControllerBase
    {
        private readonly IPedidoItemRepository _pedidoItemRepository;

        public PedidoItensController()
        {
            _pedidoItemRepository = new PedidoItemRepository();
        }

        [HttpGet]
        public List<PedidoItem> Get()
        {
            return _pedidoItemRepository.Listar();
        }

        [HttpGet("{id}")]
        public PedidoItem Get(Guid id)
        {
            return _pedidoItemRepository.BuscarPorID(id);
        }

        [HttpPost]
        public void Post(PedidoItem item)
        {
            _pedidoItemRepository.Adicionar(item);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, PedidoItem item)
        {
            item.Id = id;
            _pedidoItemRepository.Editar(item);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _pedidoItemRepository.Remover(id);
        }
    }
}
