namespace UDI_Januar2025.Models.Dto;

public class VedtakDto
{
    public string Authority { get; set; } = string.Empty;
    public VedtakEnum Status { get; set; }
    public string GyldigFra { get; set; } = string.Empty;
    public string GyldigTil { get; set; } = string.Empty;

    public string Gyldighet => $"{GyldigFra} - {GyldigTil}";
}

public enum VedtakEnum
{
    Annet,
    Innvilget,
    Avslag,
    Avvist
}