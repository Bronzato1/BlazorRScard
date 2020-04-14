using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorRScard.Models;

public interface IApiService
{
    public Task<List<Experience>> GetExperiencesAsync(int pageIndex, int pageSize);
}