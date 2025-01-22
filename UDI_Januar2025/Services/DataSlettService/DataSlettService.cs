namespace UDI_Januar2025.Services.DataSlettService;

public class DataSlettService(AppDbContext context) : IDataSlettService
{
    private readonly AppDbContext _context = context;

    public async Task<ServiceResult> SlettAlleData()
    {
        var result = new ServiceResult();

        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            try
            {
                _context.Saker.RemoveRange(_context.Saker);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Errors.Add($"Feil under sletting av Saker: {ex.Message}");
                if (ex.InnerException != null)
                {
                    result.Errors.Add($"- Indre feil: {ex.InnerException.Message}");
                }
                throw;
            }

            try
            {
                _context.Vedtak.RemoveRange(_context.Vedtak);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Errors.Add($"Feil under sletting av Vedtak: {ex.Message}");
                if (ex.InnerException != null)
                {
                    result.Errors.Add($"- Indre feil: {ex.InnerException.Message}");
                }
                throw;
            }

            try
            {
                _context.Personer.RemoveRange(_context.Personer);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Errors.Add($"Feil under sletting av Personer: {ex.Message}");
                if (ex.InnerException != null)
                {
                    result.Errors.Add($"- Indre feil: {ex.InnerException.Message}");
                }
                throw;
            }

            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();

            if (!result.Errors.Any())
            {
                result.Errors.Add($"Generell feil under sletting av data: {ex.Message}");
                if (ex.InnerException != null)
                {
                    result.Errors.Add($"- Indre feil: {ex.InnerException.Message}");
                }
            }
            return result;
        }

        result.Success = true;
        return result;
    }

}
