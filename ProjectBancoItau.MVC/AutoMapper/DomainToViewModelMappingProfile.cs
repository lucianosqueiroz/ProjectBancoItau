using AutoMapper;
using ProjectBancoItau.Domain.Entities;
using ProjectBancoItau.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectBancoItau.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ClienteViewModel, Cliente>();
            Mapper.CreateMap<ContaViewModel, Conta>();
            Mapper.CreateMap<ClienteContaViewModel, Conta>();
            Mapper.CreateMap<ClienteContaTransLogTransViewModel, LogTransacao>();
            Mapper.CreateMap<UsuarioViewModel, Usuario>();
            Mapper.CreateMap<TransacaoViewModel, Transacao>();
            Mapper.CreateMap<LogTransacaoViewModel, LogTransacao>();

        }
    }
}