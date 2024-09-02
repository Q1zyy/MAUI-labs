using MauiApp1.LR4.Entities;
using System.Collections.Generic;

namespace MauiApp1.LR4.Services
{
    public interface IRateService
    {
        Task<IEnumerable<Rate>> GetRates(DateTime date);
    }

}
