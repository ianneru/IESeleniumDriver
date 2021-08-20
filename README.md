# Framework do driver Selenium para Internet Explorer
Framework feito em .Net Core 3.1 para implementação da biblioteca de automatização - Selenium (https://www.selenium.dev/documentation/) para Internet Explorer com funcionalidades como botão,tabelas e demais elementos de site.

Testado com Internet Explorer 11 e rodando na versão versão 3.150.1 (https://github.com/SeleniumHQ/selenium/releases/download/selenium-3.150.0/IEDriverServer_Win32_3.150.2.zip)

Projeto em elaboração e futuramente assumir demais versões do Internet Explorer.

## Utilização :

Basicamente utiliza a classe **InternetExplorerDriver** para criar instâncias do driver.

```c#
    Driver = new InternetExplorerDriver(PathDriver);
```

Após isso, navegar no site:

```c#
   configuration.Driver.Navegar(configuration.UrlSite);
```
Após isso, navegar no site:

```c#
   configuration.Driver.Navegar(configuration.UrlSite);
```
Logo, pode-se alterar os comportamentos/acessar funcionalidades dos elementos da página:

```c#
    private void SelecionarUnidade()
    {
        configuration.Driver
                    .GetSelect("cmbUnidade", BuscaPor.Name)
                    .SelecionarPorTexto("CIVEL");

        configuration.Driver.GetBotao("btOk", BuscaPor.Name)
                    .Clicar();
    }
```

