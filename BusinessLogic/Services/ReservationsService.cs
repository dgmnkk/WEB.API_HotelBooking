using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    internal class ReservationsService : IReservationService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Reservation> reservationR;
        private readonly IRepository<Room> roomR;
        private readonly IEmailSender emailSender;
        //private readonly IViewRender viewRender;

        public ReservationsService(IMapper mapper,
                            IRepository<Reservation> reservationR,
                            IRepository<Room> roomR,
                            IEmailSender emailSender)
        {
            this.mapper = mapper;
            this.reservationR = reservationR;
            this.roomR = roomR;
            this.emailSender = emailSender;
            //this.viewRender = viewRender;
        }

        public async Task Create(string userId, int id, DateOnly date1, DateOnly date2)
        {
            var reservation = new Reservation()
            {
                CheckInDate = date1,
                CheckOutDate = date2,
                UserId = userId,
                RoomId = id
            };

            reservationR.Insert(reservation);
            reservationR.Save();
        }

        IEnumerable<ReservationDto> IReservationService.GetAllByUser(string userId)
        {
            var items = reservationR.Get(x => x.UserId == userId, includeProperties: "Room");
            return mapper.Map<IEnumerable<ReservationDto>>(items);
        }
    }
}
