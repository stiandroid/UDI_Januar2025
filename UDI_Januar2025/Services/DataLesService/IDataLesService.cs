namespace UDI_Januar2025.Services.DataLesService;

public interface IDataLesService
{
    // Datavisning
    
    Task<List<SakDto>> HentAlleSaker();

    Task<SakDto?> HentSakMedSakId(string sakId);

    Task<List<PersonDto>> HentAllePersoner();

    Task<PersonDto?> HentPersonMedPersonnummer(string personnummer);


    // Nøkkeltall

    Task<int> TellAlleSaker();

    Task<int> TellAllePersoner();
    
    Task<int> TellVedtakInnvilget();
    
    Task<int> TellVedtakAvslag();
    
    Task<int> TellVedtakAvvist();
}
