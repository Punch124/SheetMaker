using System;
using System.Diagnostics.CodeAnalysis;

public class Atributos
{
    public int Forca { get; set; }
    public int Destreza { get; set; }
    public int Constituicao { get; set; }
    public int Inteligencia { get; set; }
    public int Sabedoria { get; set; }
    public int Carisma { get; set; }

    public int CalculoModificador(int valorAtributo)
    {
        return (valorAtributo - 10) / 2;
    }
}
