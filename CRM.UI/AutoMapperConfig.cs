using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoMapper.Configuration;
using CRM.Model;
using CRM.UI.Models;
using CRM.UI.ViewModel;

namespace CRM.UI
{
    public class AutoMapperConfig
    {
        public void Initialize()
        {
            var cfg = new MapperConfigurationExpression();
            cfg.CreateMap<Order, OrderViewModel>().ReverseMap();
            cfg.CreateMap<OrderItem, OrderItemViewModel>().ReverseMap();
            cfg.CreateMap<OfferItem, OfferItemViewModel>().ReverseMap();
            Mapper.Initialize(cfg);
        }
    }
}