using System.Collections.ObjectModel;
using CasosDeUso.Interface;
using CoreBusiness.Entidades;
using MinhaAgenda.Views;

namespace MinhaAgenda.Views;

public partial class ListarObservacoesPage : ContentPage
{
    private readonly IVisualizarObservacoesUseCase _visualizarObservacoesUseCase;
    private readonly IApagarObservacaoUseCase _apagarObservacaoUseCase;


    public ListarObservacoesPage(IVisualizarObservacoesUseCase visualizarObservacoesUseCase,
        IApagarObservacaoUseCase apagarObservacoesUseCase)
    {
        InitializeComponent();
        _visualizarObservacoesUseCase = visualizarObservacoesUseCase;
        _apagarObservacaoUseCase = apagarObservacoesUseCase;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = CarregarObservacoesAsync();
    }

    private async Task CarregarObservacoesAsync()
    {
        try
        {
            var resultado = await _visualizarObservacoesUseCase.ExecutaList();
            listaObservacoes.ItemsSource = new ObservableCollection<Observacao>(resultado);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Erro ao carregar observações: {ex.Message}", "OK");
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(AdicionarObservacaoPage)}");
    }

    private async void ExcluirObservacao_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is Observacao obs)
        {
            bool confirmacao = await DisplayAlert("Confirmar", "Deseja excluir essa observação?", "Sim", "Não");
            if (confirmacao)
            {
                await _apagarObservacaoUseCase.ExecutaAsync(obs);
                if (listaObservacoes.ItemsSource is ObservableCollection<Observacao> lista)
                {
                    lista.Remove(obs);
                }
            }
        }
    }
}
