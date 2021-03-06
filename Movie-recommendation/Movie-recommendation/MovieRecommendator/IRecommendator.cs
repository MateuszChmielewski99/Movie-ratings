﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_recommendation.MovieRecommendator
{
    interface IRecommendator
    {
        Task<ICollection<Movie>> RecommendAsync(ICollection<Movie> movies);
    }
}
