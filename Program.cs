namespace CharacterSheetBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Saudação
            Console.WriteLine("Bem vindo ao criador de fichas de D&D 5E!");

            // Coletor de informações
            Console.WriteLine("Digite o nome do seu personagem:");
            string nomePersonagem = Console.ReadLine();
            Personagem personagem = new Personagem(nomePersonagem);

            Console.WriteLine("Distribua seus pontos entre os atributos. Total de pontos disponíveis: 27");
            personagem.MostrarTabelaDeCustos();

            // Coletar valores para os atributos
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

            // Escolha da classe
            Dictionary<string, Type> classes = new Dictionary<string, Type>
            {
                { "Bárbaro", typeof(Barbaro) },
                { "Bardo", typeof (Bardo) }
            };
            Console.WriteLine("Escolha uma classe: ");
            int i = 1;
            foreach (var nomeClasse in classes.Keys)
            {
                Console.WriteLine($"{i}. {nomeClasse}");
                i++;
            }
            int escolhaClasse = int.Parse(Console.ReadLine());
            string classeEscolhida = new List<string>(classes.Keys)[escolhaClasse - 1];
            personagem.Classe = (Classe)Activator.CreateInstance(classes[classeEscolhida]);

            // Escolha da raça e sub-raça
            Dictionary<string, List<string>> racas = new Dictionary<string, List<string>>
            {
                { "Humano", null },
                { "Anão", new List<string> { "Anão da Colina", "Anão da Montanha" } }
            };

            string racaEscolhida = ObterEscolhaDoUsuario("Escolha uma raça:", racas.Keys);
            List<string> subracasDisponiveis = racas[racaEscolhida];
            string subracaEscolhida = null;
            if (subracasDisponiveis != null)
            {
                subracaEscolhida = ObterEscolhaDoUsuario("Escolha uma sub-raça:", subracasDisponiveis);
            }

            // Instanciar a raça escolhida
            personagem.Raca = CriarRaca(racaEscolhida, subracaEscolhida);

            // Aplicar incrementos de atributos da raça
            personagem.AplicarAtributosRaca();

            //Antecedentes
            Dictionary<string, Type> antecedentes = new Dictionary<string, Type>
                 {
                { "Artesão da Guilda", typeof(ArtesaoGuilda) },
                     // Adicione mais antecedentes conforme necessário
                  };
            Console.WriteLine("Escolha um antecedente:");
            i = 1;
            foreach (var nomeAntecedente in antecedentes.Keys)
            {
                Console.WriteLine($"{i}. {nomeAntecedente}");
                i++;
            }
            int escolhaAntecedente = int.Parse(Console.ReadLine());
            string antecedenteEscolhido = new List<string>(antecedentes.Keys)[escolhaAntecedente - 1];

            personagem.Antecedentes = (Antecedentes)Activator.CreateInstance(antecedentes[antecedenteEscolhido]);

            // Exibir informações do personagem
            Console.WriteLine($"Você escolheu a raça: {personagem.Raca.Nome}");
            Console.WriteLine($"Você escolheu o antecedente: {personagem.Antecedentes.Nome}");
            Console.WriteLine("Idiomas:");
            Console.WriteLine(string.Join(", ", personagem.Raca.Idiomas));
            Console.WriteLine("Proficiências:");
            Console.WriteLine(string.Join(", ", personagem.Raca.Proficiencias));
            Console.WriteLine($"Habilidade Única:  {personagem.Classe.HabilidadeUnica}");
            Console.WriteLine($"Atributos Finais:");
            Console.WriteLine($"Força: {personagem.Atributos.Forca}");
            Console.WriteLine($"Destreza: {personagem.Atributos.Destreza}");
            Console.WriteLine($"Constituição: {personagem.Atributos.Constituicao}");
            Console.WriteLine($"Inteligência: {personagem.Atributos.Inteligencia}");
            Console.WriteLine($"Sabedoria: {personagem.Atributos.Sabedoria}");
            Console.WriteLine($"Carisma: {personagem.Atributos.Carisma}");
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