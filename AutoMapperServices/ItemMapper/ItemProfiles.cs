using AutoMapper;
using DataAccess.Models;
using DTOs.ItemDTOs;
using System.Collections.Generic;

namespace AutoMapperServices.ItemMapper
{
    public class ItemProfiles : Profile
    {
        public ItemProfiles()
        {
            CreateMap<Item, ViewItem>();

            CreateMap<AccountItem, ViewItem>()
                .ForMember(viewItem => viewItem.ItemId, 
                            opt => opt.MapFrom(src => src.ItemId))
                .ForMember(viewItem => viewItem.Name,
                            opt => opt.MapFrom(src => src.Item.Name))
                .ForMember(viewItem => viewItem.Coin,
                            opt => opt.MapFrom(src => src.Item.Coin))
                .ForMember(viewItem => viewItem.Amount,
                            opt => opt.MapFrom(src => src.Amount))
                .ForMember(viewItem => viewItem.Description,
                            opt => opt.MapFrom(src => src.Item.Description))
                .ForMember(viewItem => viewItem.LinkImage,
                            opt => opt.MapFrom(src => src.Item.LinkImage));

        }
    }
}
