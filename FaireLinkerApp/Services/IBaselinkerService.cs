using FaireLinkerApp.Models;
using FaireLinkerApp.Services;
using System;


namespace FaireLinkerApp.Services
{
    public interface IBaselinkerService
    {
        bool AddOrder(BaselinkerOrder order);
    }
}
