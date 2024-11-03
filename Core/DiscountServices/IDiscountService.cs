using Data.Dtos;
using Data.Models.DiscountModel;
using Data.Models.PlanModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DiscountServices
{
    public interface IDiscountService
    {
        Task AddAndSaveDiscountAsync(DiscountDto discountDto, Guid userId, List<Guid> planTypeIds);
        Task<IEnumerable<ViewDiscountsDto>> GetAllDiscountsAsync();
        Task DeleteDiscountsAsync(Guid discountId);
        Task UpdateDiscountsAsync(Guid discountId, UpdateDiscountDto updateDiscountDto, Guid userId);
        Task ToggleDiscountStatusAsync(Guid discountId, bool activate);
        Task<IEnumerable<ViewDiscountsDto>> GetAllActiveDiscountsAsync();
        Task<bool> StreetNameExistsAsync(string state, string streetName);
        Task<Discount> FetchStreetNameDiscountAsync(string state, string streetName);
    }
}
