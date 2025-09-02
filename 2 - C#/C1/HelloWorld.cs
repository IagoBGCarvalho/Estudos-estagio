/* Etapas da compilação manual de código C# no Windows: */

// 1 - Declarar a classe e a função Main()
// 2 - Abrir o CMD e navegar até o diretório do arquivo utilizando o cd
// 3 - Compilar o código utilizando o caminho do compilador csc.exe
// Exemplo: C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe HelloWorld.cs
// 4 - Executar o arquivo .exe gerado

// Etapas da compilação de código C# pelo visual studio no Windows:

// 1 - Iniciar um projeto de aplicativo de console
// 2 - Dar um nome para o projeto e para a solução
// 3 - Especificar a versão mais nova do .NET (no caso, a 8.0)
// 4 - Selecionar o arquivo .cs e clicar no botão de start verde que fica em cima do código

/* Etapas da compilação de código C# no Linux: */

// 1 - Instalar o .NET SDK utilizando:
// sudo apt update && sudo apt install -y wget
// wget https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
// sudo dpkg -i packages-microsoft-prod.deb
// rm packages-microsoft-prod.deb
// sudo apt update && sudo apt install -y dotnet-sdk-8.0
// 1.5 - Para instalar no Arch:
// sudo pacman -Syu dotnet-sdk
// 2 - Instalar a extensão "C# Dev Kit"
// 3 - Criar um diretório para o projeto e entrar nele
// 4 - Usar a ferramenta dotnet para criar a estrutura da aplicação utilizando:
// dotnet new console (vai criar um arquivo de projeto e um arquivo C# inicial)
// 5 - Abrir a pasta raiz do projeto no vs code utilizando "code ."

using System;

public class HelloWorld {
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World ");
        Console.WriteLine("Este é o meu primeiro programa em C#!!");
    }
}
