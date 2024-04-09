namespace CharacterSheetBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Saudação
           
            Console.WriteLine("Bem vindo ao criador de fichas de D&D 5E!");

            //coletor de informações

            Console.WriteLine("Digite o nome do personagem: ");
            string nomeJogador = Console.ReadLine();

            Console.WriteLine("Escolha sua Classe: ");
            Console.WriteLine("1.Bárbaro");
            Console.WriteLine("2.Bardo");
            Console.WriteLine("3.Bruxo");
            Console.WriteLine("4.Clérigo");
            Console.WriteLine("5.Druida");
            Console.WriteLine("6.Feiticeiro");
            Console.WriteLine("7.Guardião/Patrulheiro");
            Console.WriteLine("8.Guerreiro");
            Console.WriteLine("9.Ladino");
            Console.WriteLine("10.Mago");
            Console.WriteLine("11.Monge");
            Console.WriteLine("12.Paladino");
            Console.WriteLine("Para escolher uma classe basta digitar o número correspondente.")

            //switch de classes
            Classe classeJogador;
            switch (escolhaClasse) {

                case "1":

                    classeJogador = new Classe { Nome = "Bárbaro" };
                    break;

                case "2":

                    classeJogador = new Classe { Nome = "Bardo" };
                    break;
                case "3":

                    classeJogador = new Classe { Nome = "Bruxo" };
                    break;

                case "4":

                    classeJogador = new Classe { Nome = "Clérigo" };
                    break;

                case "5":

                    classeJogador = new Classe { Nome = "Druida" };
                    break;

                case "6":

                    classeJogador = new Classe { Nome = "Feiticeiro" };
                    break;

                case "7":

                    classeJogador = new Classe { Nome = "Patrulheiro" };
                    break;

                case "8":

                    classeJogador = new Classe { Nome = "Guerreiro" };
                    break;

                case "9":

                    classeJogador = new Classe { Nome = "Ladino" };
                    break;

                case "10":

                    classeJogador = new Classe { Nome = "Mago" };
                    break;

                case "11":

                    classeJogador = new Classe { Nome = "Monge" };
                    break;

                case "12":

                    classeJogador = new Classe { Nome = "Paladino" };
                    break;
                default:
                Console.WriteLine("Escolha inválida. Classe padrão definida como Guerreiro.");}
            
        }
}
