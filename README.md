# Questão 1: Explique detalhadamente todos os serviços que devem ser registrados na classe principal do projeto principal (Classe de inicialização)

A **classe de inicialização** tem como principal objetivo **configurar a aplicação**. Nela, definimos:

- As fontes utilizadas no app;
- O nível de log (por exemplo, modo Debug durante o desenvolvimento);
- As **injeções de dependência**, fundamentais para o funcionamento da aplicação.

---

## 🔧 Configuração Inicial

A aplicação é iniciada a partir do `builder`, que pode incluir recursos como o **MauiCommunityToolkit** e definição de fontes:

```csharp
builder.UseMauiApp<App>()
       .UseMauiCommunityToolkit();

builder.ConfigureFonts(fonts =>
{
    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
});
```

Também é possível configurar logs:

```csharp
#if DEBUG
    builder.Logging.AddDebug();
#endif
```

---

## 💉 Injeção de Dependência

A injeção de dependência permite à aplicação saber **qual classe concreta deve ser fornecida** sempre que uma determinada **interface for solicitada**.

### Exemplo:

```csharp
builder.Services.AddSingleton<IRepositorioDeContatos, RepositorioContatosSqlLite>();
```

Neste caso, sempre que o sistema precisar de um `IRepositorioDeContatos`, ele irá reutilizar a **mesma instância** da classe `RepositorioContatosSqlLite` ao longo de toda a execução do app.

### Vantagens:

- **Desacoplamento** entre classes;
- **Facilidade de manutenção e testes**;
- **Flexibilidade** para alternar implementações conforme o ambiente ou necessidade.

---

## 🔄 Alternando Implementações

A injeção de dependência também permite **trocar facilmente a implementação** da interface. Exemplo:

```csharp
builder.Services.AddSingleton<IRepositorioDeContatos, Plugins.DadosEmMemoria.Dados>();
```

Aqui, estamos indicando que o sistema deve usar a implementação `Dados` da pasta `Plugins.DadosEmMemoria` como a fonte de dados.

Essa flexibilidade permite, por exemplo:

- Usar dados em memória durante testes;
- Usar SQLite em produção;
- Alternar estratégias sem alterar o restante da aplicação.

---

## ✅ Conclusão

A classe de inicialização é essencial para definir como a aplicação será configurada e quais implementações serão usadas. 
Utilizando a injeção de dependência corretamente, ganhamos organização, flexibilidade e manutenção mais simples ao longo do tempo.
