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
            var result = new List<FigureUser>();


            try
            {
                result = _figureUserDbContext.FigureUser.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
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

                if (originalModel.Status == "Aceito")
                {
                    var originalModelUser = _userDbContext.User.Single(x =>
                        x.UserId == model.UserOwnerId
                    );

                    var total = int.Parse(originalModelUser.FigureExchangeTotal);
                    total += 1;

                    originalModelUser.FigureExchangeTotal = total.ToString();

                    _userDbContext.Update(originalModelUser);
                    _userDbContext.SaveChanges();

                    var originalModelFigure = _figureDbContext.Figure.Single(x =>
                        x.FigureId == model.FigureId
                    );

                    originalModelFigure.Amount -= 1;

                    _figureDbContext.Update(originalModelFigure);
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
