﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Security.Claims;
using AutoMapper;
using IdentityServer4.Models;

namespace IdentityServer4.EntityFramework.Mappers
{
    /// <summary>
    /// Defines entity/model mapping for clients.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ClientMapperProfile : Profile
    {
        /// <summary>
        /// <see>
        ///     <cref>{ClientMapperProfile}</cref>
        /// </see>
        /// </summary>
        public ClientMapperProfile()
        {
            CreateMap<Entities.ClientProperty, KeyValuePair<string, string>>()
                .ReverseMap();

            CreateMap<Entities.Client, Client>()
                .ForMember(dest => dest.ProtocolType, opt => opt.Condition(srs => srs != null))
                .ForMember(x => x.AllowedIdentityTokenSigningAlgorithms, opts => opts.ConvertUsing(AllowedSigningAlgorithmsConverter.Converter, x => x.AllowedIdentityTokenSigningAlgorithms))
                .ReverseMap()
                .ForMember(x => x.AllowedIdentityTokenSigningAlgorithms, opts => opts.ConvertUsing(AllowedSigningAlgorithmsConverter.Converter, x => x.AllowedIdentityTokenSigningAlgorithms));

            CreateMap<Entities.ClientCorsOrigin, string>()
                .ConstructUsing(src => src.Origin)
                .ReverseMap()
                .ForMember(dest => dest.Origin, opt => opt.MapFrom(src => src));

            CreateMap<Entities.ClientIdPRestriction, string>()
                .ConstructUsing(src => src.Provider)
                .ReverseMap()
                .ForMember(dest => dest.Provider, opt => opt.MapFrom(src => src));

            CreateMap<Entities.ClientClaim, ClientClaim>(MemberList.None)
                .ConstructUsing(src => new ClientClaim(src.Type, src.Value, ClaimValueTypes.String))
                .ReverseMap();

            CreateMap<Entities.ClientScope, string>()
                .ConstructUsing(src => src.Scope)
                .ReverseMap()
                .ForMember(dest => dest.Scope, opt => opt.MapFrom(src => src));

            CreateMap<Entities.ClientPostLogoutRedirectUri, string>()
                .ConstructUsing(src => src.PostLogoutRedirectUri)
                .ReverseMap()
                .ForMember(dest => dest.PostLogoutRedirectUri, opt => opt.MapFrom(src => src));

            CreateMap<Entities.ClientRedirectUri, string>()
                .ConstructUsing(src => src.RedirectUri)
                .ReverseMap()
                .ForMember(dest => dest.RedirectUri, opt => opt.MapFrom(src => src));

            CreateMap<Entities.ClientGrantType, string>()
                .ConstructUsing(src => src.GrantType)
                .ReverseMap()
                .ForMember(dest => dest.GrantType, opt => opt.MapFrom(src => src));

            CreateMap<Entities.ClientSecret, Secret>(MemberList.Destination)
                .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null))
                .ReverseMap();
        }
    }
}