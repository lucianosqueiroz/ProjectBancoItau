using AutoMapper;
using ProjectBancoItau.Domain.Entities;
using ProjectBancoItau.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectBancoItau.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Cliente, ClienteViewModel>();
            Mapper.CreateMap<Conta, ContaViewModel>();
            Mapper.CreateMap<Conta, ClienteContaViewModel>();
            Mapper.CreateMap<LogTransacao, ClienteContaTransLogTransViewModel>();
            Mapper.CreateMap<Usuario, UsuarioViewModel>();
            Mapper.CreateMap<Transacao, TransacaoViewModel>();
            Mapper.CreateMap<LogTransacao, LogTransacaoViewModel>();
        }
    }
} 