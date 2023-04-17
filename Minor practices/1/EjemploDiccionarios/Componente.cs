using System;

public class Componente
{
    private string codigoReferencia;
    private string categoria;
    private string marca;
    private string modelo;
    private float precio;

    public string Categoria
    {
        get
        {
            return categoria;
        }
    }

    public Componente(string codigoReferencia, string categoria,
        string marca, string modelo, float precio)
    {
        this.codigoReferencia = codigoReferencia;
        this.categoria = categoria;
        this.marca = marca;
        this.modelo = modelo;
        this.precio = precio;
    }

    public override string ToString()
    {
        return "[" + codigoReferencia + "] - " + categoria + " " +
            marca + " " + modelo + " " + precio.ToString("N2") + " eur.";
    }
}
