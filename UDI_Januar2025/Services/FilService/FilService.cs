using System.Text.Json;

namespace UDI_Januar2025.Services.FilService;

public class FilService(AppDbContext dbContext) : IFilService
{
    private readonly long _maxFileSize = 1024 * 1024; // 1 MB

    public async Task<ServiceResult> ImportFileAsync(IBrowserFile file)
    {
        var result = new ServiceResult();

        try
        {
            using MemoryStream memoryStream = new();
            await file.OpenReadStream(_maxFileSize)
                .CopyToAsync(memoryStream);

            memoryStream
                .Seek(0, SeekOrigin.Begin);

            await ProcessFileAsync(memoryStream, result);
        }
        catch (Exception ex)
        {
            result.Errors.Add($"Filen '{file.Name}' forårsaket feil: {ex.Message}");
        }

        result.Success = result.Errors.Count == 0;
        return result;
    }

    private async Task ProcessFileAsync(Stream fileStream, ServiceResult result)
    {
        try
        {
            var saker = await JsonSerializer.DeserializeAsync<List<Sak>>(fileStream);

            if (saker != null)
            {
                foreach (var sak in saker)
                {
                    sak.Soeker = sak.Soeker != null 
                        ? await GetOrUpdatePersonAsync(sak.Soeker)
                        : null;

                    sak.Fullmektig = sak.Fullmektig != null 
                        ? await GetOrUpdatePersonAsync(sak.Fullmektig)
                        : null;

                    sak.Kontakt = sak.Kontakt != null 
                        ? await GetOrUpdatePersonAsync(sak.Kontakt)
                        : null;

                    var existingSak = await dbContext.Saker
                        .FirstOrDefaultAsync(s => s.SakId == sak.SakId);

                    if (existingSak == null)
                    {
                        await dbContext.Saker.AddAsync(sak);
                    }
                }

                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            result.Errors.Add($"Feil ved serialisering av filen. Sannsynligvis var ikke filen riktig formatert. Feilmelding: {ex.Message}");
        }
    }

    private async Task<Person> GetOrUpdatePersonAsync(Person person)
    {
        var trackedPerson = dbContext.Personer.Local
            .FirstOrDefault(p => p.Personnummer == person.Personnummer);

        if (trackedPerson != null)
        {
            UpdatePersonProperties(trackedPerson, person);
            return trackedPerson;
        }

        var existingPerson = await dbContext.Personer
            .FirstOrDefaultAsync(p => p.Personnummer == person.Personnummer);

        if (existingPerson != null)
        {
            UpdatePersonProperties(existingPerson, person);
            return existingPerson;
        }

        await dbContext.Personer.AddAsync(person);
        return person;
    }

    private void UpdatePersonProperties(Person existingPerson, Person newPerson)
    {
        existingPerson.Reisedokumentnummer = newPerson.Reisedokumentnummer;
        existingPerson.Fornavn = newPerson.Fornavn;
        existingPerson.Etternavn = newPerson.Etternavn;
        existingPerson.Mellomnavn = newPerson.Mellomnavn;
        existingPerson.Epost = newPerson.Epost;
        existingPerson.Mobilnummer = newPerson.Mobilnummer;
        existingPerson.Fødselsdato = newPerson.Fødselsdato;
        existingPerson.Adresse = newPerson.Adresse;
        existingPerson.Poststed = newPerson.Poststed;
        existingPerson.Postnummer = newPerson.Postnummer;
        existingPerson.Land = newPerson.Land;
    }

}
