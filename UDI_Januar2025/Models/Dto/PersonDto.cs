namespace UDI_Januar2025.Models.Dto;

public class PersonDto
{
    public string Personnummer { get; set; } = string.Empty;
    public string Reisedokumentnummer { get; set; } = string.Empty;
    public string Fornavn { get; set; } = string.Empty;
    public string Etternavn { get; set; } = string.Empty;
    public string Mellomnavn { get; set; } = string.Empty;
    public string Fødselsdato { get; set; } = string.Empty;
    public string Mobilnummer { get; set; } = string.Empty;
    public string Epost { get; set; } = string.Empty;
    public string Adresse { get; set; } = string.Empty;
    public string Poststed { get; set; } = string.Empty;
    public string Postnummer { get; set; } = string.Empty;
    public string Land { get; set; } = string.Empty;

    public string FulltNavn => $"{Etternavn}, {Fornavn} {Mellomnavn}";
    public string Postadresse => $"{Postnummer} {Poststed}";
}
