using AutoMapper;
using HashidsNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.Services.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        private readonly IHashids _hashids;

        public AutoMapperConfiguration(IHashids hashids)
        {
            _hashids = hashids;

            CreateMap<Shared.Communication.Requests.RegisterUserRequest, Domain.Entities.UserEntity>()
                .ForMember(d => d.NormalizedEmail, s => s.MapFrom(s => s.Email))
                .ForMember(d => d.UserName, s => s.MapFrom(s => s.UserName))
                .ForMember(d => d.NormalizedUserName, s => s.MapFrom(s => s.UserName));


            //Example how to use hashids to send ID encoded in response
            //CreateMap<Domain.Entities.UserEntity, Shared.Communication.Responses.RegisterUserResponse>()
            //    .ForMember(destino => destino.Id, config => config.MapFrom(origem => _hashids.EncodeLong(int.Parse(origem.Id))));


            //RequisicaoParaEntidade();
            //EntidadeParaResposta();
        }

        /* private void RequisicaoParaEntidade()
        {
            CreateMap<Comunicacao.Requisicoes.RequisicaoRegistrarUsuarioJson, Domain.Entidades.Usuario>()
                .ForMember(destino => destino.Senha, config => config.Ignore());

            CreateMap<Comunicacao.Requisicoes.RequisicaoReceitaJson, Domain.Entidades.Receita>();
            CreateMap<Comunicacao.Requisicoes.RequisicaoIngredienteJson, Domain.Entidades.Ingrediente>();
        } */

        /* private void EntidadeParaResposta()
        {
            CreateMap<Domain.Entidades.Receita, Comunicacao.Respostas.RespostaReceitaJson>()
                .ForMember(destino => destino.Id, config => config.MapFrom(origem => _hashids.EncodeLong(origem.Id)));

            CreateMap<Domain.Entidades.Ingrediente, Comunicacao.Respostas.RespostaIngredienteJson>()
                .ForMember(destino => destino.Id, config => config.MapFrom(origem => _hashids.EncodeLong(origem.Id)));

            CreateMap<Domain.Entidades.Receita, Comunicacao.Respostas.RespostaReceitaDashboardJson>()
                .ForMember(destino => destino.Id, config => config.MapFrom(origem => _hashids.EncodeLong(origem.Id)))
                .ForMember(destino => destino.QuantidadeIngredientes, config => config.MapFrom(origem => origem.Ingredientes.Count));

            CreateMap<Domain.Entidades.Usuario, Comunicacao.Respostas.RespostaPerfilUsuarioJson>();

            CreateMap<Domain.Entidades.Usuario, Comunicacao.Respostas.RespostaUsuarioConectadoJson>()
                .ForMember(destino => destino.Id, config => config.MapFrom(origem => _hashids.EncodeLong(origem.Id)));
        } */
    }
}
