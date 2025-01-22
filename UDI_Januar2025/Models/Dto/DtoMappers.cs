namespace UDI_Januar2025.Models.Dto;

public static class DtoMappers
{
    public static PersonDto ToDtoModel(this Person person)
        => new()
        {
            Personnummer = person.Personnummer,
            Reisedokumentnummer = person.Reisedokumentnummer,
            Etternavn = person.Etternavn,
            Fornavn = person.Fornavn,
            Mellomnavn = person.Mellomnavn,
            Fødselsdato = person.Fødselsdato.ToString("dd.MM.yyyy"),
            Mobilnummer = person.Mobilnummer,
            Epost = person.Epost,
            Adresse = person.Adresse,
            Postnummer = person.Postnummer,
            Poststed = person.Poststed,
            Land = person.Land
        };

    public static SakDto ToDtoModel(this Sak sak)
        => new()
        { 
            SakId = sak.SakId,
            RecNo = sak.RecNo.ToString(),
            RefNo = sak.RefNo,
            SendtSms = sak.SendtSms ? "Ja" : "Nei",
            Soeker = sak.Soeker?.ToDtoModel(),
            Fullmektig = sak.Fullmektig?.ToDtoModel(),
            Kontakt = sak.Kontakt?.ToDtoModel(),
            Vedtak = sak.Vedtak?.ToDtoModel()
        };

    public static VedtakDto ToDtoModel(this Vedtak vedtak)
        => new()
        { 
            Authority = vedtak.Authority,
            Status = vedtak.Status.StartsWith("Ja") ? VedtakEnum.Innvilget : 
                     vedtak.Status.StartsWith("Nei") ? VedtakEnum.Avslag :
                     vedtak.Status.StartsWith("Avvist") ? VedtakEnum.Avvist :
                     VedtakEnum.Annet,
            GyldigFra = vedtak.GyldigFra?.ToString("dd.MM.yyyy") ?? "",
            GyldigTil = vedtak.GyldigTil?.ToString("dd.MM.yyyy") ?? ""
        };
}
