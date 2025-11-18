namespace _1_EcommerceMVC_EFCore.Models.ViewModels
{
    public class CarrinhoViewModel
    {
        public CarrinhoViewModel(IList<ItemPedido> itens)
        {
            this.Itens = itens;
        }

        // Uma ViewModel é utilizada para conter as regras de negócio que devem estar na view, mas que não é interessante mostrar como a lógica funciona, mantendo o princípio da responsabilidade única. Exemplo de regra de negócio que deve ser encapsulada é a de calcular o somatório do preço dos produtos.
        public IList<ItemPedido> Itens {  get; }
        public decimal Total => Itens.Sum(i => i.Quantidade * i.PrecoUnitario);
    }
}
