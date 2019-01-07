using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public interface IFigureUserService
    {
        IEnumerable<FigureUser> GetAll();
        bool Add(FigureUser model);
        bool Update(FigureUser model);
        FigureUser Get(int id);
    }

    public class FigureUserService : IFigureUserService
    {
        private readonly FigureUserDbContext _figureUserDbContext;
        private readonly FigureDbContext _figureDbContext;
        private readonly UserDbContext _userDbContext;

        public FigureUserService(
            FigureUserDbContext figureUserDbContext,
            FigureDbContext figureDbContext,
            UserDbContext userDbContext
        )
        {
            _figureUserDbContext = figureUserDbContext;
            _figureDbContext = figureDbContext;
            _userDbContext = userDbContext;
        }

        public IEnumerable<FigureUser> GetAll()
        {
            try
            {
                var result = (from fi in _figureUserDbContext.FigureUser
                             join uo in _userDbContext.User on fi.UserOwnerId equals uo.UserId
                             join ur in _userDbContext.User on fi.UserRequestId equals ur.UserId
                             select new FigureUser()
                             {
                                 FigureUserId = fi.FigureUserId,
                                 FigureOwnerId = fi.FigureOwnerId,
                                 FigureRequestId = fi.FigureRequestId,
                                 NumberOwner = fi.NumberOwner,
                                 NumberRequest = fi.NumberRequest,
                                 Status = fi.Status,
                                 UserOwnerId = fi.UserOwnerId,
                                 UserRequestId = fi.UserRequestId,
                                 UserOwner = new User { Name = uo.Name},
                                 UserRequest = new User { Name = ur.Name }
                             }
                             ).ToList();

                return result;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public FigureUser Get(int id)
        {
            var result = new FigureUser();

            try
            {
                result = _figureUserDbContext.FigureUser.Single(x => x.FigureUserId == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Add(FigureUser model)
        {
            try
            {
                _figureUserDbContext.Add(model);
                _figureUserDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool Update(FigureUser model)
        {
            try
            {
                var originalModel = _figureUserDbContext.FigureUser.Single(x =>
                    x.FigureUserId == model.FigureUserId
                );

                originalModel.Status = model.Status;

                _figureUserDbContext.Update(originalModel);
                _figureUserDbContext.SaveChanges();

                if (originalModel.Status.Equals("Aceito"))
                {
                    var originalModelUserOwner = _userDbContext.User.Single(x =>
                        x.UserId == model.UserOwnerId
                    );

                    var totalOwner = Convert.ToInt32(originalModelUserOwner.FigureExchangeTotal);
                    totalOwner += 1;

                    originalModelUserOwner.FigureExchangeTotal = totalOwner.ToString();

                    var originalModelUserRequest = _userDbContext.User.Single(x =>
                        x.UserId == model.UserRequestId
                    );

                    var totalRequest = Convert.ToInt32(originalModelUserRequest.FigureExchangeTotal);
                    totalRequest += 1;

                    originalModelUserRequest.FigureExchangeTotal = totalRequest.ToString();

                    var originalModelFigureOwner = _figureDbContext.Figure.Single(x =>
                      x.FigureId.Equals(model.FigureOwnerId));

                    originalModelFigureOwner.Amount -= 1;

                    var originalModelFigureRequest = _figureDbContext.Figure.Single(x =>
                      x.FigureId.Equals(model.FigureRequestId));

                    originalModelFigureRequest.Amount -= 1;
                    
                    object figureOwner = new Figure{ Number = model.NumberOwner, Amount = 1, UserId = model.UserOwnerId };
                    object figureRequest = new Figure { Number = model.NumberRequest, Amount = 1, UserId = model.UserRequestId };

                    _userDbContext.Update(originalModelUserOwner);
                    _userDbContext.SaveChanges();

                    _userDbContext.Update(originalModelUserRequest);
                    _userDbContext.SaveChanges();

                    _figureDbContext.Update(originalModelFigureOwner);
                    _figureDbContext.SaveChanges();

                    _figureDbContext.Update(originalModelFigureRequest);
                    _figureDbContext.SaveChanges();

                    _figureDbContext.Add(figureOwner);
                    _figureDbContext.SaveChanges();

                    _figureDbContext.Add(figureRequest);
                    _figureDbContext.SaveChanges();


                }
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }
    }
}
