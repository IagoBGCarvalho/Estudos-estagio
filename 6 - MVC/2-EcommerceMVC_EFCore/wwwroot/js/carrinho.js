class Carrinho {
    clickIncremento(btn) {
        let data = this.getData(btn);
        data.Quantidade++;
        this.postQuantidade(data);
    }

    clickDecremento(btn) {
        let data = this.getData(btn);
        data.Quantidade--;
        this.postQuantidade(data);
    }

    updateQuantidade(input) {
        let data = this.getData(input);
        this.postQuantidade(data);
    }

    getData(elemento) {
        // Sintaxe de uma função jQuery: $(selector/elemento HTML).action/ação a ser executada no elemento();
        var linhaDoItem = $(elemento).parents('[item-id]');
        var itemId = $(linhaDoItem).attr('item-id');
        var novaQtde = $(linhaDoItem).find('input').val();

        return {
            Id: itemId,
            Quantidade: novaQtde
        };
    }

    postQuantidade(data) {
        $.ajax({ // Ajax (Asynchronous Javascript Xml) é uma técnica que utiliza JS e JSON para fazer requisições assíncronas ao servidor. Precisa de 4 parâmetros: url (o endereço do método do controller, como pedido/úpdatequantidade), type (tipo de requisição HTTP), contentType (o fomato dos dados) e data (o objeto que vai levar os dados do cliente para o servidor)
            url: '/pedido/updatequantidade',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data)
        }).done(function (response) {
            let itemPedido = response.itemPedido;
            let linhaDoItem = $('[item-id=' + itemPedido.id + ']');
            linhaDoItem.find('input').val(itemPedido.quantidade);
            linhaDoItem.find('[subtotal]').html((itemPedido.subtotal).duasCasas());
            debugger; // Quando o servidor retornar a resposta OK da requisição ajax (.done(...)) o javascript irá atualizar a página
        });

    }
}

var carrinho = new Carrinho();

Number.prototype.duasCasas = function () {
    /// Função para formatar a saída do valor de somatório dos preços do carrinho
    return this.toFixed(2).replace('.', ',');
}