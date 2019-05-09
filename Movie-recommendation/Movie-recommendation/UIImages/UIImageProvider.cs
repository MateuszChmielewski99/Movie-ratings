using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Movie_recommendation.UIImages
{
    class UIImageProvider
    {
        /// <summary>
        /// Method to append dynamicly images to a panel 
        /// </summary>
        /// <param name="panel"> panel to add images </param>
        /// <param name="movies">list of movies to add</param>
        /// <returns> Collection of images </returns>
        public ICollection<Image> AddToPanel(Panel panel, ICollection<Movie> movies)
        {
            Image img;
            Border brd;
            ICollection<Image> images = new LinkedList<Image>();
            foreach (var m in movies)
            {
                // create 
                brd = new Border();
                img = new Image
                {
                    Source = new BitmapImage(new Uri(m.ImageURI, UriKind.Absolute))
                };

                //setup
                brd.BorderThickness = new System.Windows.Thickness(2);
                brd.Child = img;
                img.Width = 150;
                img.Height = 200;

                //add to panel
                panel.Children.Add(brd);

                images.Add(img);
            }
            return images;
        }

    }
}
