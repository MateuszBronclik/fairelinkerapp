using FaireLinkerApp.Models;
using System.Collections.Generic;
using FaireLinkerApp.Services;


namespace FaireLinkerApp.Services
{
    public interface IFaireService
    {
        List<FaireOrder.Root> GetFaireOrders();
    }
}
