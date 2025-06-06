﻿using MinhaAgenda.Views;

namespace MinhaAgenda
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ContatosPage), typeof(ContatosPage));
            Routing.RegisterRoute(nameof(EditarContatoPage), typeof(EditarContatoPage));
            Routing.RegisterRoute(nameof(AdicionarContatoPage), typeof(AdicionarContatoPage));
            Routing.RegisterRoute(nameof(ListarObservacoesPage), typeof(ListarObservacoesPage));
            Routing.RegisterRoute(nameof(AdicionarObservacaoPage), typeof(AdicionarObservacaoPage));
        }
    }
}
