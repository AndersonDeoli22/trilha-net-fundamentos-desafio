namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();
        private List<string> historico = new List<string>();


        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            veiculos.Add(Console.ReadLine().ToUpper());
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = "";
            placa = Console.ReadLine().ToUpper();
            // Verifica se o veículo existe
            if (veiculos.Any(x => x == placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int.TryParse(Console.ReadLine(), out int horas);
                decimal valorTotal = precoInicial + (precoPorHora * horas);
                historico.Add($"{placa} - {DateTime.Now} - Valor: {valorTotal:C}");
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");

            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public void ListarVeiculosHistorico()
        {
            // Verifica se há veículos no estacionamento
            if (historico.Any())
            {
                Console.WriteLine("Histórico de veículos estacionados:");
                foreach (var veiculo in historico)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há histórico de veículos estacionados.");
            }
        }
        public void SaldoVeiculosHistorico()
        {
            // Verifica se há veículos no estacionamento
            if (historico.Any())
            {
                Console.WriteLine("Saldo do caixa:");
                decimal soma = 0;
                decimal valor = 0;
                foreach (var veiculo in historico)
                {
                    if (decimal.TryParse(veiculo.Split(':').LastOrDefault().Replace("R$ ", ""), out valor))
                        soma += valor;
                }
                Console.WriteLine($"{soma:C}");

            }
            else
            {
                Console.WriteLine("Não há Saldo em caixa.");
            }
        }

    }
}
