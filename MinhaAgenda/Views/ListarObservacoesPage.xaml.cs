using System.Collections.ObjectModel;
using CasosDeUso.Interface;
using CoreBusiness.Entidades;
using MinhaAgenda.Views;

namespace MinhaAgenda.Views;

public partial class ListarObservacoesPage : ContentPage
{
    private readonly IVisualizarObservacoesUseCase _visualizarObservacoesUseCase;

    public ListarObservacoesPage(IVisualizarObservacoesUseCase visualizarObservacoesUseCase)
    {
        InitializeComponent();
        _visualizarObservacoesUseCase = visualizarObservacoesUseCase;
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
}
