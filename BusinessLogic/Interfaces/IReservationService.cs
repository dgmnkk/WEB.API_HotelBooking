using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    internal interface IReservationService
    {
        IEnumerable<ReservationDto> GetAllByUser(string userId);
        Task Create(string userId);
    }
}
