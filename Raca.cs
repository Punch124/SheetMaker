using System;
namespace CharacterSheetBuilder
{
    public abstract class Raca
    {
        public string Nome { get; protected set; }
        public int Deslocamento { get; protected set; }
        public List<string> Proficiencias { get; protected set; }
        public List<string> Idiomas { get; protected set; }
        public Atributos AtributosRaca {  get; protected set; }
        public Classe IncrementoVida {  get; protected set; }
        public string HabilidadeRaca { get; protected set; }
        
    }


    public abstract class Anao: Raca
    {
        public Anao()
        {
            Nome = "Anão";
            Deslocamento = 25;
            Proficiencias = new List<string> {"Visão no escuro", "Vantagem em testes contra venenos", "machados de batalha",
             "machadinhas","martelos leves", "martelos de guerra", "Proficiência com Ferramentas"};
            Idiomas = new List<string> { "idioma Anão", "idioma comum" };
            AtributosRaca.Constituicao += 2;
            

        }
    }
    public class AnaoColina: Anao
    {
        /// <summary>
        /// AnaoColina adiciona +1 no de bônus de rolagem em sabedoria e +1 na vida máxima
        /// </summary>
        public AnaoColina()
        {
            AtributosRaca.Sabedoria += 1;

            IncrementoVida.DadoDeVida += 1;

        }
    }
    public class AnaoMontanha: Anao
    {
        public AnaoMontanha()
        {
            AtributosRaca.Forca += 2;
            Proficiencias.Add("Armaduras Leves");
            Proficiencias.Add("Armaduras médias"); 
        }
    }
}
