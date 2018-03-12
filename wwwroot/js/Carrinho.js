class Carrinho {
    clickIncrement(btn) {

        var data = this.getData(btn);
        data.Quantidade++;
        this.PostQuantidade(data);
    }

    clickDecremente(btn) {
        var data = this.getData(btn);
        data.Quantidade--;
        this.PostQuantidade(data);
    }

    updateQuantidade(input) {
        var data = this.getData(input);
        this.PostQuantidade(data);
    }

    getData(elemento) {
        var itemLinha = $(elemento).parents('[item-id]');
        var itemId = itemLinha.attr('item-id');
        var inputField = itemLinha.find('input');
        var itemQtd = inputField.val();

        return {
            Id: itemId,
            Quantidade: itemQtd
        };
    }

    PostQuantidade(data) {
        $.ajax({
            url: '/pedido/PostQuantidade',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data)
        }).done(function (response) {
            this.setQuantidade(response.itemPedido);
            this.setSubTotal(response.itemPedido);
            this.setTotal(response.carrinhoViewModel);
            this.setNumeroItem(response.carrinhoViewModel);
            if (response.itemPedido.quantidade == 0) {
                this.removeItem(response.itemPedido);
            }
        }.bind(this));
    }

    setQuantidade(itemPedido) {
       this.getLinhaDoItem(itemPedido)
            .find('input').val(itemPedido.quantidade);
    }

    setSubTotal(itemPedido) {
        this.getLinhaDoItem(itemPedido)
            .find('[subtotal]').html(itemPedido.setsubtotal.duasCasas());
    }

    setTotal(carrinhoViewModel) {
        $('[total]').html(carrinhoViewModel.total.duasCasas());
    }
    removeItem(itemPedido) {
        this.getLinhaDoItem(itemPedido).remove();
    }
    setNumeroItem(carrinhoViewModel) {
        var texto = 'Total: ' + carrinhoViewModel.itens.lenght + ' ' + (carrinhoViewModel.itens.lenght > 1 ? 'Itens' : 'Item');
        $('[numero-itens]').html(texto);
    }
    getLinhaDoItem(itemPedido) {
        return $('[item-id=' + itemPedido.Id + ']');

    }
    
}
var carrinho = new Carrinho();

Number.prototype.duasCasas = function () {
    return this.toFixed(2).replace('.', ',');
}


