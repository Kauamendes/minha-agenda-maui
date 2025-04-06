using CasosDeUso.Interface;
using CoreBusiness.Entidades;

namespace MinhaAgenda.Views;

public partial class AdicionarObservacaoPage : ContentPage
{
    private readonly IAdicionarObservacoesUseCase _adicionarObservacaoUseCase;

    public AdicionarObservacaoPage(IAdicionarObservacoesUseCase adicionarObservacoesUseCase)
    {
        InitializeComponent();
        _adicionarObservacaoUseCase = adicionarObservacoesUseCase;
    }

    private async void Salvar_Clicked(object sender, EventArgs e)
    {
        var texto = textoObservacao.Text?.Trim();

        if (string.IsNullOrWhiteSpace(texto))
        {
            await DisplayAlert("Aviso", "Por favor, digite uma observação antes de salvar.", "OK");
            return;
        }

        try
        {
            var observacao = new Observacao(texto);
            await _adicionarObservacaoUseCase.ExecutaAsync(observacao);
            textoObservacao.Text = string.Empty;
            await Shell.Current.GoToAsync(".."); // Volta para a tela anterior
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Erro ao salvar observação: {ex.Message}", "OK");
        }
    }
}
