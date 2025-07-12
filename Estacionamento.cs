namespace DesafioFundamentos.Models;

public class Estacionamento
{
    private decimal precoInicial = 0;
    private decimal precoPorHora = 0;
    private List<string> veiculos = new List<string>();

    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        this.precoInicial = precoInicial;
        this.precoPorHora = precoPorHora;
    }

    public void AdicionarVeiculo()
    {
        Console.WriteLine("Digite a placa do veículo para estacionar:");
        // Lê a entrada do usuário e adiciona à lista "veiculos"
        string placa = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(placa)) // Verifica se a placa não está vazia
        {
            veiculos.Add(placa.ToUpper()); // Adiciona a placa em maiúsculas para padronização
            Console.WriteLine($"Veículo com placa '{placa.ToUpper()}' adicionado com sucesso!");
        }
        else
        {
            Console.WriteLine("Placa inválida. Por favor, digite uma placa válida.");
        }
    }

    public void RemoverVeiculo()
    {
        Console.WriteLine("Digite a placa do veículo para remover:");

        // Pedir para o usuário digitar a placa e armazenar na variável placa
        string placa = Console.ReadLine();

        // Verifica se o veículo existe
        if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
        {
            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

            // Pedir para o usuário digitar a quantidade de horas e converter para int
            int horas = 0;
            if (!int.TryParse(Console.ReadLine(), out horas) || horas <= 0)
            {
                Console.WriteLine("Quantidade de horas inválida. Operação cancelada.");
                return; // Sai do método se a entrada for inválida
            }

            // Realizar o cálculo: "precoInicial + precoPorHora * horas"
            decimal valorTotal = precoInicial + (precoPorHora * horas);

            // Remover a placa digitada da lista de veículos
            veiculos.Remove(placa.ToUpper());

            Console.WriteLine($"O veículo {placa.ToUpper()} foi removido e o preço total foi de: R$ {valorTotal:F2}"); // :F2 para formatar 2 casas decimais
        }
        else
        {
            Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
        }
    }

    public void ListarVeiculos()
    {
        // Verifica se há veículos no estacionamento
        if (veiculos.Any())
        {
            Console.WriteLine("Os veículos estacionados são:");
            // Realizar um laço de repetição, exibindo os veículos estacionados
            for (int i = 0; i < veiculos.Count; i++)
            {
                Console.WriteLine($"Veículo {i + 1}: {veiculos[i]}");
            }
        }
        else
        {
            Console.WriteLine("Não há veículos estacionados.");
        }
    }
}