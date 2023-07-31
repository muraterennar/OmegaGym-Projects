using AutoMapper;
using OmegaGymServer.Application.Features.Commands.SubscriptionCategoryCommad.UpdateSubscriptionCategoryCommand;
using OmegaGymServer.Application.Features.Commands.SubscriptionCommand.UpdateSubscriptionCommand;
using OmegaGymServer.Application.Features.Commands.UserCommand.InsertUserCommand;
using OmegaGymServer.Application.Features.Commands.AuthCommand.LoginCommand;
using OmegaGymServer.Application.Features.Commands.AuthCommand.RegisterCommand;
using OmegaGymServer.Application.Features.Queries.OperationClaimQuery.GetAllOperationClaim;
using OmegaGymServer.Application.Features.Queries.OperationClaimQuery.GetByIdOperationClaim;
using OmegaGymServer.Application.Features.Queries.OperationClaimQuery.GetByNameOperationClaim;
using OmegaGymServer.Application.Features.Queries.SubscriptionCategoryQuery.GetAllSubscriptionCategory;
using OmegaGymServer.Application.Features.Queries.SubscriptionCategoryQuery.GetByIdForSubscriptionCategory;
using OmegaGymServer.Application.Features.Queries.SubscriptionCategoryQuery.GetByNameSubscriptionCategory;
using OmegaGymServer.Application.Features.Queries.SubscriptionQuery.GetByCategoryIdSubscription;
using OmegaGymServer.Application.Features.Queries.SubscriptionQuery.GetByIdSubscription;
using OmegaGymServer.Application.Features.Queries.SubscriptionQuery.GetByNameSubscription;
using OmegaGymServer.Application.Features.Queries.UserQuery.GetAllUserQuery;
using OmegaGymServer.Application.Features.Queries.UserQuery.GetByFirstnameUserQuery;
using OmegaGymServer.Application.Features.Queries.UserQuery.GetByIdUserQuery;
using OmegaGymServer.Application.Features.Queries.UserQuery.GetByOperationClaimIdQuery;
using OmegaGymServer.Application.Features.Queries.UserQuery.GetByUsernameUserQuery;
using OmegaGymServer.Application.Features.Queries.UserSubscriptionQuery.GetAllUserSubscription;
using OmegaGymServer.Application.Features.Queries.UserSubscriptionQuery.GetByIdUserSubscription;
using OmegaGymServer.Application.Features.Queries.UserSubscriptionQuery.GetBySubscriptionIdUserSubscription;
using OmegaGymServer.Application.Features.Queries.UserSubscriptionQuery.GetByUserIdUserSubscription;
using OmegaGymServer.Domain.Entities;
using OmegaGymServer.Application.Features.Commands.UserCommand.UpdateUserCommand;
using OmegaGymServer.Application.Features.Commands.OperationCliamCommand.InsertOperationClaimCommand;
using OmegaGymServer.Application.DTOs.SubscriptionDTOs;
using OmegaGymServer.Application.Features.Queries.SubscriptionQuery.GetDetailsSubcription;

namespace OmegaGymServer.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, LoginCommandResponse>().ReverseMap();
        CreateMap<User, RegisterCommandResponse>().ReverseMap();
        CreateMap<User, GetAllUserQueryResponse>().ReverseMap();
        CreateMap<User, GetByIdUserQueryResponse>().ReverseMap();
        CreateMap<User, GetByOperationClaimIdUserQueryResponse>().ReverseMap();
        CreateMap<User, GetByFirstnameUserQueryResponse>().ReverseMap();
        CreateMap<User, GetByUsernameUserQueryResponse>().ReverseMap();
        CreateMap<User, InsertUserCommandResponse>().ReverseMap();
        CreateMap<User, UpdateUserCommandResponse>().ReverseMap();

        CreateMap<UserSubscription, GetAllUserSubscriptionQueryResponse>().ReverseMap();
        CreateMap<UserSubscription, GetByIdUserSubscriptionQueryResponse>().ReverseMap();
        CreateMap<UserSubscription, GetByUserIdUserSubscriptionQueryResponse>().ReverseMap();
        CreateMap<UserSubscription, GetBySubscriptionIdUserSubscriptionQueryResponse>().ReverseMap();

        CreateMap<SubscriptionCategory, GetByNameSubscriptionCategoryQueryResponse>().ReverseMap();
        CreateMap<SubscriptionCategory, GetByIdSubscriptionCategoryQueryResponse>().ReverseMap();
        CreateMap<SubscriptionCategory, GetAllSubscriptionCategoryQueryResponse>().ReverseMap();
        CreateMap<SubscriptionCategory, UpdateSubscriptionCategoryCommandResponse>().ReverseMap();

        CreateMap<Subscription, GetByNameSubscriptionQueryResponse>().ReverseMap();
        CreateMap<Subscription, GetByCategoryIdSubscriptionQueryReponse>().ReverseMap();
        CreateMap<Subscription, GetByIdSubscriptionQueryResponse>().ReverseMap();
        CreateMap<Subscription, UpdateSubscriptionCommandResponse>().ReverseMap();
        CreateMap<SubscriptionDetailDTO, GetDetailsSubscriptionQueryResponse>().ReverseMap();

        CreateMap<OperationClaim, GetAllOperationClaimQueryResponse>().ReverseMap();
        CreateMap<OperationClaim, GetByIdOperationClaimQueryResponse>().ReverseMap();
        CreateMap<OperationClaim, GetByNameOprationCliamQueryResponse>().ReverseMap();
        CreateMap<OperationClaim, InsertOperationCliamCommandResponse>().ReverseMap();
    }
}

