using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheetBuilder
{
    public abstract class Classe
    {
        public string Nome { get; protected set; }
        public int DadoDeVida { get; set; }
        public List<string> Proficiencias { get; protected set; }
        public List<string> Ferramentas { get; protected set; }
        public List<string> Salvaguardas { get; protected set; }
        public List<string> Armas { get; protected set; }
        public string HabilidadeUnica { get; protected set; }
        public virtual void HabilidadeEspecial()
        {

        }

    }
    public class Barbaro : Classe
    {
        public Barbaro()
        {

            Nome = "Bárbaro";
            DadoDeVida = 12;
            Proficiencias = new List<string> { "Armaduras Leves", "Armaduras Médias", "Escudos", "Armas Simples", "Armas Marciais" };
            Salvaguardas = new List<string> { "Força", "Constituição" };
            Armas = new List<string> { "Machado de Batalha", "Martelo de Guerra", "Lança", "Machadinha", "Martelo Leve", "Espada Larga" };
            HabilidadeUnica = "Fúria";
        }


        public override void HabilidadeEspecial()
        {

        }
    }
    public class Bardo : Classe
    {
        public Bardo()
        {
            Nome = "Bardo";
            DadoDeVida = 8;
            Proficiencias = new List<string> { "Armaduras leves", "Armas simples", "bestas de mão", "espadas longas",
            "rapieiras", "espadas curtas" };
            Ferramentas = new List<string> { " Três instrumentos musicais, à sua escolha" };
            Salvaguardas = new List<string> { "Destreza", "Carisma" };
            Armas = new List<string> { "rapieira", "espada longa", "qualquer arma simples" };
            HabilidadeUnica = "Inspiração de Bardo";
        }
        public override void HabilidadeEspecial()
        {

        }

    }
}
