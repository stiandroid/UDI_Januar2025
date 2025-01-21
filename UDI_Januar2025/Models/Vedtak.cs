namespace UDI_Januar2025.Models;

public class Vedtak
{
    public Guid Id { get; set; }
    public string Authority { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime? GyldigFra { get; set; }
    public DateTime? GyldigTil { get; set; }
}
