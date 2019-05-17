using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Movie_recommendation.UIImages
{
    class UIImageProvider
    {

        /// <summary>
        /// Appends images of movies to panel, optionally with popup menu with one item 
        /// </summary>
        /// <param name="panel"> Panel to add images </param>
        /// <param name="movies"> Collection of movies to add </param>
        public ICollection<Image> AddToPanel(Panel panel, ICollection<Movie> movies)
        {
            Image img;
            Border brd;
            ICollection<Image> images = new List<Image>();

            foreach (var m in movies)
            {
                // create 
                brd = new Border();
                img = new Image
                {
                    Source = new BitmapImage(new Uri(m.ImageURI, UriKind.Absolute)),
                    Name = m.Title
                };

                //setup
                brd.BorderThickness = new Thickness(2);
                brd.Child = img;
                img.Width = 150;
                img.Height = 200;
                brd.Margin = new Thickness(2);

                //add to panel
                panel.Children.Add(brd);

                images.Add(img);
            }
            return images;
        }



        /// <summary>
        /// Add action to collection of Images, opptionaly adds events on mouse enter, mouse leave and popup menu with one item
        /// </summary>
        /// <param name="elements"> elements to add action </param>
        /// <param name="action"> action performed on left button clicked </param>
        /// <param name="mouseEnter"> optional mouse enter event </param>
        /// <param name="mouseLeave"> optional mouse leave event </param>
        /// <param name="header"> header of optional popup menu item</param>
        /// <param name="func"> function for optional poup menu item </param>
        public void AddFunctionality(ICollection<Image> elements, MouseButtonEventHandler action, 
            MouseEventHandler mouseEnter = null, MouseEventHandler mouseLeave = null,
            string header = null, RoutedEventHandler func = null)
        {

            ContextMenu ctx;
            MenuItem mi;

            foreach (var img in elements)
            {

                if(action != null)
                    img.MouseLeftButtonDown += action;

                //context menu with one item 
                if (header != null)
                {
                    ctx = new ContextMenu();
                    mi = new MenuItem();
                    mi.Header = header;
                    mi.Click += func;
                    ctx.Items.Add(mi);
                    img.ContextMenu = ctx;
                }

                if (mouseEnter != null)
                    img.MouseMove += mouseEnter;

                if (mouseLeave != null)
                    img.MouseLeave += mouseLeave;

            }
        }

        /// <summary>
        /// Changes colour of content control 
        /// </summary>
        /// <param name="cc">Content control to update colour </param>
        /// <param name="hexColor">hex string representing colour </param>
        public void ContentControlColorChanger(ContentControl cc, string hexColor)
        {
            var bc = new BrushConverter();
            cc.Foreground = bc.ConvertFrom(hexColor) as Brush;
        }

        public void ChangeOne(Panel panel,Label toChange, string hexColor,string newHexColor, MouseEventHandler action, MouseEventHandler mouseEnter)
        {
            foreach (var lbl in panel.Children.OfType<Label>())
            {
                if (!lbl.Equals(toChange))
                {
                    ContentControlColorChanger(lbl, hexColor);
                    lbl.MouseLeave += action;
                    lbl.MouseMove += mouseEnter;
                }
            }

            ContentControlColorChanger(toChange, newHexColor);
            toChange.MouseLeave -= action;
            toChange.MouseMove -= mouseEnter;
            
        }

        #region mouseOver 
        public MouseEventHandler mouseOver = (object sender, MouseEventArgs e) =>
        {
            Image tmp = sender as Image;
            if (tmp != null)
            {
                Border b = tmp.Parent as Border;
                b.BorderBrush = Brushes.Aqua;
            }
        };
        #endregion

        #region mouseLeave
        public MouseEventHandler mouseDown = (object sender, MouseEventArgs e) =>
        {

            Image tmp = sender as Image;
            if (tmp != null)
            {
                Border b = tmp.Parent as Border;
                b.BorderBrush = null;
            }
        };
        #endregion
    }
}
