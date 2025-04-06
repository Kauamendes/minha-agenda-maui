using CasosDeUso.Interface;
using CoreBusiness.Entidades;

namespace MinhaAgenda.Views;

public partial class AdicionarObservacaoPage
{

    private readonly IAdicionarObservacoesUseCase _adicionarObservacaoUseCase;

    public AdicionarObservacaoPage(IAdicionarObservacoesUseCase adicionarObservacoesUseCase)
    {
        InitializeComponent();
        _adicionarObservacaoUseCase = adicionarObservacoesUseCase;
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        Observacao observacao = new Observacao(textoObservacao.Text);
        await _adicionarObservacaoUseCase.ExecutaAsync(observacao);
    }
}