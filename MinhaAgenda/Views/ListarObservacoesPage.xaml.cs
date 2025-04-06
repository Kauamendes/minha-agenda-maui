using System.Collections.ObjectModel;
using CasosDeUso.Interface;
using CoreBusiness.Entidades;

namespace MinhaAgenda.Views;

public partial class ListarObservacoesPage : ContentPage
{

    private readonly IVisualizarObservacoesUseCase _visualizarObservacoesUseCase;

    public ListarObservacoesPage(IVisualizarObservacoesUseCase visualizarContatosUseCase)
    {
        InitializeComponent();
        this._visualizarObservacoesUseCase = visualizarContatosUseCase;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        CarregarObservacoes();
    }

    private async void CarregarObservacoes()
    {
        var observacoes = new ObservableCollection<Observacao>(await _visualizarObservacoesUseCase.ExecutaList());
        listaObservacoes.ItemsSource = observacoes;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(AdicionarObservacaoPage)}");
    }
}