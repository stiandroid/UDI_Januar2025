namespace UDI_Januar2025.Models.Dto;

public class SakDto
{
    public string SakId { get; set; } = string.Empty;
    public string RefNo { get; set; } = string.Empty;
    public string RecNo { get; set; } = string.Empty;
    public string SendtSms { get; set; } = string.Empty;

    public PersonDto? Kontakt { get; set; }
    public PersonDto? Fullmektig { get; set; }
    public PersonDto? Soeker { get; set; }
    public VedtakDto? Vedtak { get; set; }
}
