namespace DesafioFundamentos.Models
{
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
            string placa = Console.ReadLine();
            if (!veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                if (placa.Length >= 7 && placa.Length <= 8)
                {
                    veiculos.Add(placa);
                    Console.WriteLine($"Veiculo com a placa {placa} foi adicionado ao sistema.");
                }
                else
                {
                    Console.WriteLine("Esta placa nao existe.");
                }
                
            } 
            else
            {
                Console.WriteLine($"Ja existe um veiculo com a placa {placa}. Verifique se o veiculo ja foi adicionado ao sistema.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pede para o usuário digitar a placa e armazenar na variável placa
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                bool sucesso = int.TryParse(Console.ReadLine(), out int qtdHoras);
                if (sucesso)
                {
                    // Pede para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                    // Realiza o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                    decimal valorTotal = precoInicial + precoPorHora * qtdHoras; 

                    // Remove a placa digitada da lista de veículos
                    veiculos.Remove(placa);
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                } else 
                {
                    Console.WriteLine("Operacao mal sucedida. Certifique-se de que a hora esteja escrita apenas em numeros e tente novamente.");
                }
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
                // Realiza um laço de repetição, exibindo os veículos estacionados
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"{veiculo}");
                    Console.WriteLine("------------------");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
