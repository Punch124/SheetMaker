using System;

public class Personagem
{
	public string Nome { get; set; }
	public string Raca { get; set; }
	public Atributos Atributos { get; set; }


	public Personagem (string nome)
	{
		{ Nome = nome; }
		Atributos = new Atributos();
	} 
	public DistribuirPontos (int forca, int destreza, int constituicao, int inteligencia, int sabedoria, int carisma)
	{
		int totalPontos = forca + destreza + constituicao + inteligencia + sabedoria + carisma;
		if (totalPontos != 27) {
			Console.WriteLine("Erro! total de pontos iniciais deve ser 27");
			return;
		}
		if (forca < 8 || destreza < 8 || constituicao < 8 || inteligencia < 8 || sabedoria < 8 || carisma < 8 ||
			forca > 15 || destreza > 15 || constituicao > 15 || inteligencia > 15 || sabedoria > 15 || carisma > 15)
		{
			Console.WriteLine("Erro: Os atributos devem estar entre 8 e 15.");
			return;
		}

        Atributos.Forca = forca;
		Atributos.Destreza = destreza;
		Atributos.Constituicao = constituicao;
		Atributos.Inteligencia = inteligencia;
		Atributos.Sabedoria = sabedoria;
		Atributos.Carisma = carisma;
	}
}
