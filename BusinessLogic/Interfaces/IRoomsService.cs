using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IRoomsService
    {
        IEnumerable<RoomDto> GetAll();
        IEnumerable<RoomDto> Get(IEnumerable<int> ids);
        RoomDto? Get(int id);
        IEnumerable<CategoryDto> GetAllCategories();
        void Create(CreateRoomModel room);
        void Edit(RoomDto room);
        void Delete(int id);
    }
}
