namespace UDI_Januar2025.Services.DataLesService;

public class DataLesService(AppDbContext context) : IDataLesService
{
    private readonly AppDbContext context = context;


    public async Task<List<SakDto>> HentAlleSaker() 
        => await context.Saker
            .Include(s => s.Soeker)
            .Include(v => v.Vedtak)
            .Select(sak => sak.ToDtoModel())
            .ToListAsync();


    public async Task<SakDto?> HentSakMedSakId(string sakId)
        => await context.Saker
            .Include(s => s.Soeker)
            .Include(f => f.Fullmektig)
            .Include(k => k.Kontakt)
            .Include(v => v.Vedtak)
            .Where(i => i.SakId == sakId)
            .Select(sak => sak.ToDtoModel())
            .FirstOrDefaultAsync();


    public async Task<List<PersonDto>> HentAllePersoner()
        => await context.Personer
            .Select(person => person.ToDtoModel())
            .ToListAsync();


    public async Task<PersonDto?> HentPersonMedPersonnummer(string personnummer)
        => await context.Personer
            .Where(p => p.Personnummer == personnummer)
            .Select(person => person.ToDtoModel())
            .FirstOrDefaultAsync();


    public async Task<int> TellAlleSaker()
        => await context.Saker
            .CountAsync();


    public async Task<int> TellAllePersoner()
        => await context.Personer
            .CountAsync();


    public async Task<int> TellVedtakInnvilget()
        => await context.Vedtak
            .Where(v => v.Status.StartsWith("Ja"))
            .CountAsync();


    public async Task<int> TellVedtakAvslag()
        => await context.Vedtak
            .Where(v => v.Status.StartsWith("Nei"))
            .CountAsync();


    public async Task<int> TellVedtakAvvist()
        => await context.Vedtak
            .Where(v => v.Status.StartsWith("Avvist"))
            .CountAsync();
}
