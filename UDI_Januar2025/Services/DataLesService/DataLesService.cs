namespace UDI_Januar2025.Services.DataLesService;

public class DataLesService(AppDbContext context) : IDataLesService
{
    private readonly AppDbContext _context = context;


    public async Task<List<SakDto>> HentAlleSaker() 
        => await _context.Saker
            .Include(s => s.Soeker)
            .Include(v => v.Vedtak)
            .Select(sak => sak.ToDtoModel())
            .ToListAsync();


    public async Task<List<SakDto>> HentSakerMedSoekersPersonnummer(string personnummer)
        => await _context.Saker
            .Include(s => s.Soeker)
            .Include(v => v.Vedtak)
            .Where(s => s.Soeker != null && s.Soeker.Personnummer == personnummer)
            .Select(sak => sak.ToDtoModel())
            .ToListAsync();


    public async Task<SakDto?> HentSakMedSakId(string sakId)
        => await _context.Saker
            .Include(s => s.Soeker)
            .Include(f => f.Fullmektig)
            .Include(k => k.Kontakt)
            .Include(v => v.Vedtak)
            .Where(i => i.SakId == sakId)
            .Select(sak => sak.ToDtoModel())
            .FirstOrDefaultAsync();


    public async Task<List<PersonDto>> HentAllePersoner()
        => await _context.Personer
            .Select(person => person.ToDtoModel())
            .ToListAsync();


    public async Task<PersonDto?> HentPersonMedPersonnummer(string personnummer)
    {
        var person = await _context.Personer
                .Where(p => p.Personnummer == personnummer)
                .Select(person => person.ToDtoModel())
                .FirstOrDefaultAsync();

        if (person != null)
        {
            var saker = await _context.Saker
                    .Include(v => v.Vedtak)
                    .Where(p => p.Soeker != null && p.Soeker.Personnummer == personnummer)
                    .Select(sak => sak.ToDtoModel())
                    .ToListAsync();

            person.Saker = saker;
        }

        return person;
    }

    public async Task<int> TellAlleSaker()
        => await _context.Saker
            .CountAsync();


    public async Task<int> TellAllePersoner()
        => await _context.Personer
            .CountAsync();


    public async Task<int> TellVedtakInnvilget()
        => await _context.Vedtak
            .Where(v => v.Status.StartsWith("Ja"))
            .CountAsync();


    public async Task<int> TellVedtakAvslag()
        => await _context.Vedtak
            .Where(v => v.Status.StartsWith("Nei"))
            .CountAsync();


    public async Task<int> TellVedtakAvvist()
        => await _context.Vedtak
            .Where(v => v.Status.StartsWith("Avvist"))
            .CountAsync();
}
