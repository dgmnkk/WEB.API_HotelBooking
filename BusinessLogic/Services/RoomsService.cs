using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusinessLogic.Services
{
    public class RoomsService : IRoomsService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Room> roomsR;
        private readonly IRepository<Category> categoriesR;
        //private readonly ShopDbContext context;

        public RoomsService(IMapper mapper,
                                IRepository<Room> roomsR,
                                IRepository<Category> categoriesR)
        {
            this.mapper = mapper;
            this.roomsR = roomsR;
            this.categoriesR = categoriesR;
        }

        public void Create(CreateRoomModel room)
        {
            roomsR.Insert(mapper.Map<Room>(room));
            roomsR.Save();
        }


        public void Delete(int id)
        {
            if (id < 0) throw new HttpException(Errors.IdMustPositive, HttpStatusCode.BadRequest);

            var room = roomsR.GetByID(id);

            if (room == null) throw new HttpException(Errors.ProductNotFound, HttpStatusCode.NotFound);

            roomsR.Delete(room);
            roomsR.Save();
        }

        public void Edit(RoomDto room)
        {
            roomsR.Update(mapper.Map<Room>(room));
            roomsR.Save();
        }


        public RoomDto? Get(int id)
        {
            if (id < 0) throw new HttpException(Errors.IdMustPositive, HttpStatusCode.BadRequest);

            var item = roomsR.GetByID(id);
            if (item == null) throw new HttpException(Errors.ProductNotFound, HttpStatusCode.NotFound);

            var dto = mapper.Map<RoomDto>(item);

            return dto;
        }

        public IEnumerable<RoomDto> Get(IEnumerable<int> ids)
        {
            return mapper.Map<List<RoomDto>>(roomsR.Get(x => ids.Contains(x.Id), includeProperties: "Category"));
        }

        public IEnumerable<RoomDto> GetAll()
        {
            return mapper.Map<List<RoomDto>>(roomsR.GetAll());
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            return mapper.Map<List<CategoryDto>>(categoriesR.GetAll());
        }

    }
}
