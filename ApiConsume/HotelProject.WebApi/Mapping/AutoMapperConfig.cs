using AutoMapper;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.Entity.Concrete;

namespace HotelProject.WebApi.Mapping
{
    //DTOLARIMIZLA ENTİTYLERİMİZİ BAĞLAYACAĞIMIZ(EŞLEŞTİRECEĞİMİZ) SINIF
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room, RoomAddDto>();

            CreateMap<UpdateRoomDto, Room>().ReverseMap();


        }
    }
}
