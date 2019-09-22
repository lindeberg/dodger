using System.Linq;
using System.Windows.Forms;
using Dodger.Core.Entities.World;
using Dodger.Core.Factories;
using Dodger.Core.ValueObjects;
using Dodger.WinForms.Controls.Enemy;
using Dodger.WinForms.Factories;

namespace Dodger.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var world = new World(new Size(Width, Height));
            var player = new PlayerFactory().CreatePlayer(world);
            var game = new GameFactory().CreateGame(world, player, this);
            
            timer.Tick += (sender, args) =>
            {
                game.Update();
                game.Render();
            };
        }
    }
}