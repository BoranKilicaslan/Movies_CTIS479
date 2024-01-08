using Business.Models;
using Business.Results;
using Business.Results.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public interface IGenreService
    {
        IQueryable<GenreModel> Query();
        Result Add(GenreModel model);
        Result Update(GenreModel model);
        Result Delete(int id);

        List<GenreModel> GetList();
        GenreModel GetItem(int id);
    }

    public class GenreService : IGenreService
    {
        private readonly Db _db;

        public GenreService(Db db)
        {
            _db = db;
        }

        public IQueryable<GenreModel> Query()
        {
            return _db.Genre.Include(r => r.MovieGenres).Select(r => new GenreModel()
            {
                Id = r.id,
                Name = r.Name,
                MovieCountOutput = r.MovieGenres.Count,
                MovieNamesOutput = string.Join("<br />", r.MovieGenres.Select(ur => ur.Movie.Name)), 
                MovieIdsInput = r.MovieGenres.Select(ur => ur.MovieId).ToList()             });
        }

        public Result Add(GenreModel model)
        {
          
            if (
                _db.Genre.Any(r =>
                r.Name.ToUpper() == model.Name.ToUpper().Trim()))
                return new ErrorResult("Genre with same name cant exist!");

            var entity = new Genre()
            {
               
                Name = model.Name,
                MovieGenres = model.MovieIdsInput?.Select(MovieId => new MovieGenre()
                {
                    MovieId = MovieId
                }).ToList()
            };

            _db.Genre.Add(entity);
            _db.SaveChanges();

            return new SuccessResult("Resource added successfully.");
        }

        public Result Update(GenreModel model)
        {
            if (
                 _db.Genre.Any(r =>
                 r.Name.ToUpper() == model.Name.ToUpper().Trim() && r.id != model.Id))
                return new ErrorResult("Genre with same name cant exist!");

            var existingEntity = _db.Genre.Include(r => r.MovieGenres).SingleOrDefault(r => r.id == model.Id);
            if (existingEntity is not null && existingEntity.MovieGenres is not null)
                _db.MovieGenre.RemoveRange(existingEntity.MovieGenres);
            
            existingEntity.Name = model.Name;

            existingEntity.MovieGenres = model.MovieIdsInput?.Select(MovieId => new MovieGenre()
            {
                MovieId = MovieId
            }).ToList();

            _db.Genre.Update(existingEntity);
            _db.SaveChanges(); 

            return new SuccessResult("Resource updated successfully.");
        }

        public Result Delete(int id)
        {
            var entity = _db.Genre.Include(r => r.MovieGenres).SingleOrDefault(r => r.id == id);
            if (entity is null)
                return new ErrorResult("Resource not found!");

            _db.MovieGenre.RemoveRange(entity.MovieGenres);

            _db.Genre.Remove(entity);

            _db.SaveChanges();

            return new SuccessResult("Resource deleted successfully.");
        }

        public List<GenreModel> GetList()
        {
            return Query().ToList();
        }

        public GenreModel GetItem(int id) => Query().SingleOrDefault(r => r.Id == id);
    }
}

