using CharacterSheetBuilder;
using System;

public class Personagem
{
	public string Nome { get; set; }
	public Classe Classe { get; set; }
	public Raca Raca { get; set; }
	public Antecedentes Antecedentes { get; set; }
	public Atributos Atributos { get; set; }

    
    public Personagem (string nome)
	{
		Nome = nome; 
		Atributos = new Atributos();

	}
    private Dictionary<int, int> CalcularCusto()
    {
        return new Dictionary<int, int>
        {
            { 8, 0 },
            { 9, 1 },
            { 10, 2 },
            { 11, 3 },
            { 12, 4 },
            { 13, 5 },
            { 14, 7 },
            { 15, 9 }
        };
    }

    public void DistribuirPontos(int forca, int destreza, int constituicao, int inteligencia, int sabedoria, int carisma)
    {
        var custos = CalcularCusto();

        var atributos = new Dictionary<string, int>
        {
            { "Força", forca },
            { "Destreza", destreza },
            { "Constituição", constituicao },
            { "Inteligência", inteligencia },
            { "Sabedoria", sabedoria },
            { "Carisma", carisma }
        };

        int totalPontos = 0;
        foreach (var par in atributos)
        {
            totalPontos += custos[par.Value];
        }

        if (totalPontos > 27)
        {
            Console.WriteLine("Erro! Total de pontos inicial deve ser 27 ou menos.");
            return;
        }

        if (atributos["Força"] < 8 || atributos["Destreza"] < 8 || atributos["Constituição"] < 8 || atributos["Inteligência"] < 8 ||
            atributos["Sabedoria"] < 8 || atributos["Carisma"] < 8 ||
            atributos["Força"] > 15 || atributos["Destreza"] > 15 || atributos["Constituição"] > 15 || atributos["Inteligência"] > 15 ||
            atributos["Sabedoria"] > 15 || atributos["Carisma"] > 15)
        {
            Console.WriteLine("Erro: Os atributos devem estar entre 8 e 15.");
            return;
        }

        Atributos.Forca = atributos["Força"];
        Atributos.Destreza = atributos["Destreza"];
        Atributos.Constituicao = atributos["Constituição"];
        Atributos.Inteligencia = atributos["Inteligência"];
        Atributos.Sabedoria = atributos["Sabedoria"];
        Atributos.Carisma = atributos["Carisma"];

        Console.WriteLine("Atributos distribuídos com sucesso!");
        foreach (var par in atributos)
        {
            Console.WriteLine($"{par.Key}: {par.Value}");
        }
    }

    public void MostrarTabelaDeCustos()
    {
        var custos = CalcularCusto();
        Console.WriteLine("Tabela de Custo de Pontos para Atributos:");
        foreach (var par in custos)
        {
            Console.WriteLine($"{par.Key} = {par.Value} pontos");
        }
    }

    public Dictionary<int, int> CalcularCustoPontos()
    {
        return CalcularCusto();
    }
    public void AplicarAtributosRaca()
    {
        Raca.AplicarIncrementos(this);
    }
}
