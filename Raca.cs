using System;
namespace CharacterSheetBuilder
{
    public abstract class Raca
    {
        public string Nome { get; protected set; }
        public int Deslocamento { get; protected set; }
        public List<string> Proficiencias { get; protected set; }
        public List<string> Idiomas { get; protected set; }
        public Atributos AtributosRaca { get; protected set; }
        public int IncrementoVida { get; protected set; }
        public string HabilidadeRaca { get; protected set; }

        public Raca()
        {
            AtributosRaca = new Atributos();
        }

        public virtual void AplicarIncrementos(Personagem personagem) { }
    }

    public abstract class Anao : Raca
    {
        public Anao()
        {
            Nome = "Anão";
            Deslocamento = 25;
            Proficiencias = new List<string> { "Visão no escuro", "Vantagem em testes contra venenos", "machados de batalha",
             "machadinhas","martelos leves", "martelos de guerra", "Proficiência com Ferramentas"};
            Idiomas = new List<string> { "idioma Anão", "idioma comum" };
            AtributosRaca.Constituicao += 2;
        }

        public override void AplicarIncrementos(Personagem personagem)
        {
            personagem.Atributos.Constituicao += AtributosRaca.Constituicao;
        }
    }

    public class AnaoColina : Anao
    {
        public AnaoColina()
        {
            AtributosRaca.Sabedoria += 1;
            IncrementoVida += 1;
        }

        public override void AplicarIncrementos(Personagem personagem)
        {
            base.AplicarIncrementos(personagem);
            personagem.Atributos.Sabedoria += AtributosRaca.Sabedoria;
            personagem.Classe.DadoDeVida += IncrementoVida;
        }
    }

    public class AnaoMontanha : Anao
    {
        public AnaoMontanha()
        {
            AtributosRaca.Forca += 2;
            Proficiencias.Add("Armaduras Leves");
            Proficiencias.Add("Armaduras médias");
        }

        public override void AplicarIncrementos(Personagem personagem)
        {
            base.AplicarIncrementos(personagem);
            personagem.Atributos.Forca += AtributosRaca.Forca;
        }
    }
}
