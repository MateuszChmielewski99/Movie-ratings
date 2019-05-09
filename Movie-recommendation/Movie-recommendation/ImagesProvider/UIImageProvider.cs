using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
                brd.BorderThickness = new Thickness(2);
                brd.Child = img;
                img.Width = 150;
                img.Height = 200;

                //add to panel
                panel.Children.Add(brd);

                images.Add(img);
            }
            return images;
        }

        /// <summary>
        /// Add action to collection of UIElements, opptionaly events on mouse enter and mouse leave
        /// </summary>
        /// <param name="elements"> elements to add action </param>
        /// <param name="action"> action performed on left button clicked </param>
        /// <param name="mouseEnter"> optional mouse enter event </param>
        /// <param name="mouseLeave"> optional mouse leave event </param>
        public void AddFunctionality(ICollection<UIElement> elements, MouseButtonEventHandler action, 
            MouseEventHandler mouseEnter = null, MouseEventHandler mouseLeave = null)
        {
            foreach (var img in elements)
            {
                img.MouseLeftButtonDown += action;

                if (mouseEnter != null)
                    img.MouseEnter += mouseEnter;
                if (mouseLeave != null)
                    img.MouseLeave += mouseLeave;

            }
        }


    }
}
