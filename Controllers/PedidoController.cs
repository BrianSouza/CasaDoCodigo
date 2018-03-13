using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IDataService _DataService;
        public PedidoController(IDataService dataService)
        {
            _DataService = dataService;
        }
        public IActionResult Carrossel()
        {
            List<Produto> produtos = _DataService.GetProdutos();
            return View(produtos);
        }

        public IActionResult Carrinho(int? produtoId)
        {
            if (produtoId.HasValue)
            {
                _DataService.AddItemPedido(produtoId.Value);
            }
            CarrinhoViewModel cVM = GetCarrinhoViewModel();
            return View(cVM);
        }
        public IActionResult Cadastro()
        {
            var pedido = _DataService.GetPedido();
            if (pedido == null)
                return RedirectToAction("Carrossel");
            else
                return View(pedido);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Resumo(Pedido cadastro)
        {
            if (ModelState.IsValid)
            {
                var pedido = _DataService.UpdateCadastro(cadastro);
                return View(pedido);
            }
            else
                return RedirectToAction("Cadastro");
        }
        private CarrinhoViewModel GetCarrinhoViewModel()
        {
            List<Produto> produtos = _DataService.GetProdutos();
            List<ItemPedido> itensCarrinho = this._DataService.GetItensPedido();
            CarrinhoViewModel cVM = new CarrinhoViewModel(itensCarrinho);
            return cVM;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public UpdateItemPedidoResponse PostQuantidade([FromBody]ItemPedido input)
        {
            return _DataService.UpdateItemPedido(input);
        }

    }
}