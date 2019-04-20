using System;
using System.Threading.Tasks;

namespace Movie_recommendation
{
    /// <summary>
    /// Unity of work pattern class
    /// </summary>
    class UnitOfWork : IDisposable
    {
        private MoviesRecDbContext context = new MoviesRecDbContext();
        private GenericRepository<Movie> _movieRepository;
        private GenericRepository<User> _userRepository;
        private GenericRepository<FavouriteMovies> _favMoviesRepository;
        private GenericRepository<Rating> _ratingRepository;

        #region properties of repos
        public GenericRepository<Movie> movieRepository
        {
            get
            {
                if (this._movieRepository == null)
                {
                    this._movieRepository = new GenericRepository<Movie>(context);
                }
                return this._movieRepository;
            }
        }

        public GenericRepository<User> userRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new GenericRepository<User>(context);
                }
                return this._userRepository;
            }
        }

        public GenericRepository<FavouriteMovies> favMowieRepository
        {
            get
            {
                if (this._favMoviesRepository == null)
                {
                    this._favMoviesRepository = new GenericRepository<FavouriteMovies>(context);
                }
                return this._favMoviesRepository;
            }
        }

        public GenericRepository<Rating> ratingRepository
        {
            get
            {
                if (this._ratingRepository == null)
                {
                    this._ratingRepository = new GenericRepository<Rating>(context);
                }
                return this._ratingRepository;
            }
        }

        #endregion
        
        /// <summary>
        /// Saves changes async 
        /// </summary>
        /// <returns></returns>
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
