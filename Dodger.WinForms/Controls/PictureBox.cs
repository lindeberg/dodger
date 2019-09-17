using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Point = Dodger.Core.ValueObjects.Point;
using Size = Dodger.Core.ValueObjects.Size;

namespace Dodger.WinForms.Controls
{
    public class PictureBox : System.Windows.Forms.PictureBox
    {
        public PictureBox(string name, Size size, Point location, string imagePath)
        {
            if (string.IsNullOrWhiteSpace(value: name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            if (string.IsNullOrWhiteSpace(value: imagePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(imagePath));

            Name = name;
            Size = new System.Drawing.Size(size.Width, size.Height);
            Location = new System.Drawing.Point(location.X, location.Y);
            Image = GetImage(imagePath);
            SizeMode = PictureBoxSizeMode.StretchImage;
        }
        
        protected Image GetImage(string path)
        {
            var imagesDirectoryPath =
                Path.Combine(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    @"Assets\Images"
                );

            var imagePath = Path.Combine(imagesDirectoryPath, path);

            return Image.FromFile(imagePath);
        }
    }
}