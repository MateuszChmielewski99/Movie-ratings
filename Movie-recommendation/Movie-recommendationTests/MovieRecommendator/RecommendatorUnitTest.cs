using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movie_recommendation;

namespace Movie_recommendationTests.MovieRecommendator
{
    [TestClass]
    public class RecommendatorUnitTest
    {
        [TestMethod]
        public void Check_zero_simmilarity()
        {

            Movie_recommendation.MovieRecommendator.MovieRocommendator mr =
                new Movie_recommendation.MovieRecommendator.MovieRocommendator(new UnitOfWork());

            
            Movie m = new Movie();
            m.director = "";
            m.for_kids = false;
            m.is_action = true;
            m.is_comedy = true;
            m.is_crime = false;
            m.is_fantasy = false;
            m.is_historical = false;
            m.is_horror = false;
            m.is_musical = false;
            m.is_sf = false;
            m.is_thriller = false;
            m.is_drama = false;

            Movie b = new Movie();
            b.for_kids = true;
            b.is_action = false;
            b.is_comedy = false;
            b.is_crime = true;
            b.is_fantasy = true;
            b.is_historical = true;
            b.is_horror = true;
            b.is_musical = true;
            b.is_sf = true;
            b.is_thriller = true;
            b.is_drama = true;


            double result = mr.MeasureSimmilarity(m, b);
            Assert.AreEqual(0,result);
        }

        [TestMethod]
        public void Check_full_simmilarity()
        {

            Movie_recommendation.MovieRecommendator.MovieRocommendator mr =
                new Movie_recommendation.MovieRecommendator.MovieRocommendator(new UnitOfWork());


            Movie m = new Movie();
            m.director = "";
            m.for_kids = false;
            m.is_action = true;
            m.is_comedy = true;
            m.is_crime = false;
            m.is_fantasy = false;
            m.is_historical = false;
            m.is_horror = false;
            m.is_musical = false;
            m.is_sf = false;
            m.is_thriller = false;
            m.is_drama = false;

            Movie b = new Movie();
            b.for_kids = false;
            b.is_action = true;
            b.is_comedy = true;
            b.is_crime = false;
            b.is_fantasy = false;
            b.is_historical = false;
            b.is_horror = false;
            b.is_musical = false;
            b.is_sf = false;
            b.is_thriller = false;
            b.is_drama = false;


            double result = mr.MeasureSimmilarity(m, b);
            Assert.AreEqual(1, result);

        }
    }
}
