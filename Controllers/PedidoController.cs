﻿using System;
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

        public IActionResult Carrinho()
        {
            CarrinhoViewModel cVM = GetCarrinhoViewModel();
            return View(cVM);
        }


        public IActionResult Resumo()
        {
            
            return View(GetCarrinhoViewModel());
        }
        private CarrinhoViewModel GetCarrinhoViewModel()
        {
            List<Produto> produtos = _DataService.GetProdutos();
            List<ItemPedido> itensCarrinho = this._DataService.GetItensPedido();
            CarrinhoViewModel cVM = new CarrinhoViewModel(itensCarrinho);
            return cVM;
        }

    }
}