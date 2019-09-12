using System.Windows.Forms;
using Dodger.Core.Entities;
using Dodger.Factories;
using Dodger.Handlers;
using Dodger.Persistance.Repositories;

namespace Dodger
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var player = PlayerFactory.CreatePlayer(playerPictureBox);
            var enemyRepository = new EnemyRepository();
            
            var enemySpawner = new EnemySpawner(enemySpawnTimer, this, movementTimer, enemyRepository);
            var scoreHandler = new ScoreHandler(scoreTimer, player, aScore);
            var playerHandler = new PlayerMover(player, playerPictureBox, this, movementTimer);
            var enemyDisposer = new EnemyDisposer(movementTimer, enemyRepository, this);
                
            new Game(enemySpawner, scoreHandler, playerHandler)
                .Start();
        }
    }
}