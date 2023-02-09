using System;
using AutoMapper;
using SalesOrderApp.Core.Features.Commands;
using SalesOrderApp.Core.ViewModels;
using SalesOrderApp.Persistence.Entities;

namespace SalesOrderApp.Core.Mappers
{
	public class OrderProfile: Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderRequestViewModel>();
            CreateMap<Window, WindowsRequestViewModel>();
            CreateMap<SubElement, SubElementRequestViewModel>();

            CreateMap<OrderRequestViewModel, Order>();
            CreateMap<WindowsRequestViewModel, Window>();
            CreateMap<SubElementRequestViewModel, SubElement>();

            CreateMap<Order, OrderViewModel>().ForMember(
                    dest => dest.TotalWindows,
                    opt => opt.MapFrom(src => $"{src.Windows.Count()}")
                );
        }

    }
}

