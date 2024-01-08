using Business.Models;
using Business.Results;
using Business.Results.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public interface IMovieService
    {
     
        IQueryable<MovieModel> Query();

        Result Add(MovieModel model);
        Result Update(MovieModel model);

        [Obsolete("Do not use this method anymore, use DeleteUser method instead!")]
        //Result Delete(int id);

        Result DeleteUser(int id);
    }

    public class MovieService : IMovieService 
    {
        #region Db Constructor Injection
        private readonly Db _db;

        public MovieService(Db db)
        {
            _db = db;
        }
        #endregion

        public IQueryable<MovieModel> Query()
        {
            return _db.Movie.Include(e => e.Director)

                .Select(e => new MovieModel()
                {
                    Id = e.id,
                    Name = e.Name,
                    Revenue = e.Revenue,
                    Year = e.Year,

                    DirectorId = e.DirectorId,
                    

                    directorOutput = e.Director.Name
                });
        }

        public Result Add(MovieModel model)
        {
            
            List<Movie> existingUsers = _db.Movie.ToList();
            if (existingUsers.Any(u => u.Name.Equals(model.Name.Trim(), StringComparison.OrdinalIgnoreCase)))
                return new ErrorResult("Movie with the same name already exists!");

            Movie userEntity = new Movie()
            {
                Name = model.Name,
                Year = model.Year,
                Revenue = model.Revenue,
                DirectorId = model.DirectorId,
            };

            
            _db.Movie.Add(userEntity);

            
            _db.SaveChanges();

            return new SuccessResult("User added successfully.");
        }

        public Result Update(MovieModel model)
        {
            
            var existingUsers = _db.Movie.Where(u => u.id != model.Id).ToList();
            if (existingUsers.Any(u => u.Name.Equals(model.Name.Trim(), StringComparison.OrdinalIgnoreCase)))
                return new ErrorResult("Movie with the same  name already exists!");

            
            var Movieentity = _db.Movie.SingleOrDefault(u => u.id == model.Id);

            
            if (Movieentity is null)
                return new ErrorResult("Movie not found!");

            
            Movieentity.Name = model.Name.Trim();
            Movieentity.Year = model.Year;
            Movieentity.Revenue = model.Revenue;

            Movieentity.DirectorId = model.DirectorId ?? 0;


            _db.Movie.Update(Movieentity);

            _db.SaveChanges();

            return new SuccessResult("User updated successfully.");
        }

        
        
        public Result DeleteUser(int id)
        {
            var userEntity = _db.Movie.Include(u => u.MovieGenres).SingleOrDefault(u => u.id == id);
            if (userEntity is null)
                return new ErrorResult("User not found!");

            _db.MovieGenre.RemoveRange(userEntity.MovieGenres);

            _db.Movie.Remove(userEntity);

            _db.SaveChanges(); 

            return new SuccessResult("User deleted successfully.");
        }
    }
}
