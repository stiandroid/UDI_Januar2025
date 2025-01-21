namespace UDI_Januar2025.Services.FilService;

public interface IFilService
{
    Task<ServiceResult> ImportFileAsync(IBrowserFile file);
}