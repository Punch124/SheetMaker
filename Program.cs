namespace CharacterSheetBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Saudação

            Console.WriteLine("Bem vindo ao criador de fichas de D&D 5E!");

            //coletor de informações
            Console.WriteLine("Digite o nome do seu personagem:");
            string nomePersonagem = Console.ReadLine();
            Personagem personagem = new Personagem(nomePersonagem);
            Console.WriteLine("Distribua seus pontos entre os atributos. Total de pontos disponíveis: 27");
            personagem.MostrarTabelaDeCustos();
            Console.WriteLine("Digite o valor para Força (8-15):");
            int forca = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor para Destreza (8-15):");
            int destreza = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor para Constituição (8-15):");
            int constituicao = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor para Inteligência (8-15):");
            int inteligencia = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor para Sabedoria (8-15):");
            int sabedoria = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor para Carisma (8-15):");
            int carisma = int.Parse(Console.ReadLine());

            personagem.DistribuirPontos(forca, destreza, constituicao, inteligencia, sabedoria, carisma);

            Console.WriteLine("Distribua os pontos entre os atributos (Total deve ser 27):");
            

            Dictionary<string, Type> classes = new Dictionary<string, Type>
            {
                { "Bárbaro", typeof(Barbaro) }
            };
            Console.WriteLine("escolha uma classe: ");
            int i = 1;
            foreach (var nomeClasse in classes.Keys)
            {
                Console.WriteLine($"{i}. {nomeClasse}");
                i++;
            }
            int escolhaClasse = int.Parse(Console.ReadLine());
            string classeEscolhida = new List<string>(classes.Keys)[escolhaClasse - 1];

            personagem.Classe = (Classe)Activator.CreateInstance(classes[classeEscolhida]);

            Dictionary<string, List<string>> racas = new Dictionary<string, List<string>>
            {
                { "Humano", null },
                { "Anão", new List<string> { "Anão da Colina", "Anão da Montanha" } }
                // Adicione mais raças e sub-raças conforme necessário
            };

            // Obter a escolha da raça
            string racaEscolhida = ObterEscolhaDoUsuario("Escolha uma raça:", racas.Keys);

            // Obter a escolha da sub-raça, se aplicável
            List<string> subracasDisponiveis = racas[racaEscolhida];
            string subracaEscolhida = null;
            if (subracasDisponiveis != null)
            {
                subracaEscolhida = ObterEscolhaDoUsuario("Escolha uma sub-raça:", subracasDisponiveis);
            }

            // Instanciar o personagem com base na raça e sub-raça escolhidas
            Raca raca = CriarRaca(racaEscolhida, subracaEscolhida);

            Console.WriteLine($"Você escolheu a raça: {raca.GetType().Name}");
        }

        private static string ObterEscolhaDoUsuario(string mensagem, IEnumerable<string> opcoes)
        {
            Console.WriteLine(mensagem);
            int i = 1;
            foreach (var opcao in opcoes)
            {
                Console.WriteLine($"{i}. {opcao}");
                i++;
            }

            int escolha = int.Parse(Console.ReadLine());
            return new List<string>(opcoes)[escolha - 1];
        }

        private static Raca CriarRaca(string racaEscolhida, string subracaEscolhida)
        {
            switch (racaEscolhida)
            {
                case "Anão":
                    switch (subracaEscolhida)
                    {
                        case "Anão da Colina":
                            return new AnaoColina();
                        case "Anão da Montanha":
                            return new AnaoMontanha();
                    }
                    break;
                    // Adicione outros casos conforme necessário
            }
            throw new ArgumentException("Raça ou sub-raça inválida.");
        }
    }
    }
