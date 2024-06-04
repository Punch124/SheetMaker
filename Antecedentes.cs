using System;
namespace CharacterSheetBuilder
{
	public abstract class Antecedentes
	{
			public string Nome {  get; protected set; }
			public List<string> ProficienciasPericias { get; protected set; }
            public List<string> ProficienciasFerramentas {  get; protected set; }
            public List<string> Idiomas { get; protected set; }
			public List<string> Equipamentos { get; protected set; }
			public string HabilidadeAntecedente {  get; protected set; }
		}
		public class ArtesaoGuilda: Antecedentes
        {
			public ArtesaoGuilda() {
			Nome = "Artesão da Guilda";
			ProficienciasPericias = new List<string> {"Intuição", "Persuasão"};
			ProficienciasFerramentas = new List<string> { "Um tipo de ferramenta de artesão" };
			Idiomas = new List<string> { "um à sua escolha!" };
			Equipamentos = new List<string> { "Um conjunto de ferramentas de artesão(à sua escolha)," +
				" uma carta de apresentação da sua guilda, um conjunto de roupas de viajante e uma algibeira com 15 po" };
			HabilidadeAntecedente = "ASSOCIADOS DA GUILDA(Ler no Livro do Jogador da quinta edição)";

            }
		}
	}

