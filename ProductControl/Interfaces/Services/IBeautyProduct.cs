using Microsoft.AspNetCore.Components.Web;
using ProductControl.Models;

namespace ProductControl.Interfaces.Services
{
    public interface IBeautyProduct : IProduct
    {
        string Ishypoallegenic(bool hypoallegenic);

    }
}
