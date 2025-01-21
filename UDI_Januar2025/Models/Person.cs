namespace UDI_Januar2025.Models;

public class Person
{
    public required string Personnummer { get; set; }
    public required string Reisedokumentnummer { get; set; }
    public required string Fornavn { get; set; }
    public required string Etternavn { get; set; }
    public string Mellomnavn { get; set; } = string.Empty;
    public required DateTime Fødselsdato { get; set; }
    public required string Mobilnummer { get; set; }
    public string Epost { get; set; } = string.Empty;
    public string Adresse { get; set; } = string.Empty;
    public string Poststed { get; set; } = string.Empty;
    public string Postnummer { get; set; } = string.Empty;
    public string Land { get; set; } = string.Empty;
}