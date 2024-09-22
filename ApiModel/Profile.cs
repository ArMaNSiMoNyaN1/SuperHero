using SuperHeroAPI.ApiModel.Actor;
using SuperHeroAPI.ApiModel.Car;
using SuperHeroAPI.ApiModel.CartoonHero;
using SuperHeroAPI.ApiModel.Excavator;
using SuperHeroAPI.ApiModel.FootballPlayer;
using SuperHeroAPI.ApiModel.Phone;
using SuperHeroAPI.ApiModel.Plane;
using SuperHeroAPI.ApiModel.SuperHero;

namespace SuperHeroAPI.ApiModel;

public class Profile : AutoMapper.Profile
{
    public Profile()
    {
        #region SuperHero

        CreateMap<CreateSuperHeroModel, Entities.SuperHero>();
        CreateMap<Entities.SuperHero, GetByIdSuperHeroModel>();
        CreateMap<Entities.SuperHero, GetSuperHeroModel>();
        CreateMap<UpdateSuperHeroModel, Entities.SuperHero>();

        #endregion


        #region CartoonHero

        CreateMap<CreateCartoonHeroModel, Entities.CartoonHero>();
        CreateMap<Entities.CartoonHero, GetByIdCartoonHeroModel>();
        CreateMap<Entities.CartoonHero, GetCartoonHeroModel>();
        CreateMap<UpdateCartoonHeroModel, Entities.CartoonHero>();

        #endregion

        #region Actor

        CreateMap<CreateActorModel, Entities.Actor>();
        CreateMap<Entities.Actor, GetByIdActorModel>();
        CreateMap<Entities.Actor, GetActorModel>();
        CreateMap<UpdateActorModel, Entities.Actor>();

        #endregion

        #region FootballPlayer

        CreateMap<CreateFootballPlayerModel, Entities.FootballPlayer>();
        CreateMap<Entities.FootballPlayer, GetByIdFootballPlayerModel>();
        CreateMap<Entities.FootballPlayer, GetFootballPlayerModel>();
        CreateMap<UpdateFootballPlayerModel, Entities.FootballPlayer>();

        #endregion

        #region Plane

        CreateMap<CreatePlaneModel, Entities.Plane>();
        CreateMap<Entities.Plane, GetByIdPlaneModel>();
        CreateMap<Entities.Plane, GetPlaneModel>();
        CreateMap<UpdatePlaneModel, Entities.Plane>();

        #endregion


        #region Phone

        CreateMap<CreatePhoneModel, Entities.Phone>();
        CreateMap<Entities.Phone, GetByIdPhoneModel>();
        CreateMap<Entities.Phone, GetPhoneModel>();
        CreateMap<UpdatePhoneModel, Entities.Phone>();
        
        #endregion

        #region Car

        CreateMap<CreateCarModel, Entities.Car>();
        CreateMap<Entities.Car, GetByIdCarModel>();
        CreateMap<Entities.Car, GetCarModel>();
        CreateMap<UpdateCarModel, Entities.Car>();

        #endregion

        #region Excavator

        CreateMap<CreateExcavatorModel, Entities.Excavator>();
        CreateMap<Entities.Excavator, GetByIdExcavatorModel>();
        CreateMap<Entities.Excavator, GetExcavatorModel>();
        CreateMap<UpdateExcavatorModel, Entities.Excavator>();

        #endregion
    }
}