using System;
using Dodger.Controls;
using Dodger.Core.ValueObjects;

namespace Dodger.Core.Entities.Enemy.Controls
{
    public class EnemyPictureBox : PictureBox
    {
        public EnemyPictureBox(Guid id, string name, Size size, Point location, string imagePath) : base(name, size, location, imagePath)
        {
            Tag = id;
        }
    }
}