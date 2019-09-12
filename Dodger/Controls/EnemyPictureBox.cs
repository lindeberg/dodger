using System;
using Dodger.Core.ValueObjects;

namespace Dodger.Controls
{
    public class EnemyPictureBox : PictureBox
    {
        public EnemyPictureBox(Guid id, string name, Size size, Point location, string imagePath) : base(name, size, location, imagePath)
        {
            Tag = id;
        }
    }
}