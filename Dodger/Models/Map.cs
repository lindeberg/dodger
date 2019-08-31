using System;
using System.Drawing;
using System.Windows.Forms;
using Dodger.Entities;

namespace Dodger.Models
{
    public class Map
    {
        private readonly PictureBox _map;
        private static readonly Brush PlayerColor = Brushes.Black;

        public Map(PictureBox map)
        {
            _map = map ?? throw new ArgumentNullException(nameof(map));

            InitMaxPosition();
        }

        private void InitMaxPosition()
        {
            MaxPosition = new Point(_map.Size.Width, _map.Size.Height);
        }

        public Point MaxPosition { get; private set; }

        public void InitPlayer(Player player)
        {
            var graphics = _map.CreateGraphics();

            var point = new System.Drawing.Point(player.Location.X, player.Location.Y);
            var size = new System.Drawing.Size(MaxPosition.X, MaxPosition.Y);
            var rectangle = new Rectangle(point, size);
            
            graphics.FillEllipse(PlayerColor, rectangle);
        }
    }
}