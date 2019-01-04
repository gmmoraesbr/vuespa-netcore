using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public interface IFigureService
    {
        IEnumerable<Figure> GetAll();
        bool Add(Figure model);
        bool Delete(int id);
        bool Update(Figure model);
        Figure Get(int id);
    }

    public class FigureService : IFigureService
    {
        private readonly FigureDbContext _figureDbContext;
        private readonly UserDbContext _userDbContext;

        public FigureService(
            FigureDbContext figureDbContext,
            UserDbContext userDbContext
        )
        {
            _figureDbContext = figureDbContext;
            _userDbContext = userDbContext;
        }

        public IEnumerable<Figure> GetAll()
        {   
            try
            {
                var result = _figureDbContext.Figure
                    .Join(_userDbContext.User
                    , f => f.UserId
                    , u => u.UserId
                    , (f, u) => new Figure
                    {
                        FigureId = f.FigureId,
                        Number = f.Number,
                        Amount = f.Amount,
                        UserId = f.UserId,
                        User = new User { Name = u.Name }
                    }).ToList();

                return result;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public Figure Get(int id)
        {
            var result = new Figure();

            try
            {
                result = _figureDbContext.Figure.Single(x => x.FigureId == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Add(Figure model)
        {
            try
            {
                _figureDbContext.Add(model);
                _figureDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool Update(Figure model)
        {
            try
            {
                var originalModel = _figureDbContext.Figure.Single(x =>
                    x.FigureId == model.FigureId
                );

                originalModel.Number = model.Number;
                originalModel.Amount = model.Amount;
                originalModel.User = model.User;

                _figureDbContext.Update(originalModel);
                _figureDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                _figureDbContext.Entry(new Figure { FigureId = id }).State = EntityState.Deleted; ;
                _figureDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }
    }
}
