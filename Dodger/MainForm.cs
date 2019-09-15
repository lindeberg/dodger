using System.Windows.Forms;
using Dodger.Core.Entities.Game;
using Dodger.Core.Entities.Player;
using Dodger.Core.Entities.World;
using Dodger.Core.Handlers;
using Dodger.Core.Repositories.EnemyRepository;
using Dodger.Core.ValueObjects;
using Dodger.Factories;
using Dodger.Persistance.Repositories;

namespace Dodger
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var world = new World(new Size(Width, Height));
            var player = PlayerFactory.CreatePlayer(playerPictureBox, this);
            var enemyRepository = new EnemyRepository();

            var gameComponents = InitializeGameComponents(world, player, enemyRepository);
            var gameGraphicsComponents = InitializeGameGraphicsComponents(gameComponents, enemyRepository, player);
            var game = new Game(timer, gameComponents, gameGraphicsComponents);
            
            game.Start();
        }

        private GameGraphicsComponents InitializeGameGraphicsComponents(GameComponents gameComponents, IEnemyRepository enemyRepository,
            Player player)
        {
            var enemySpawner = new Graphics.Handlers.EnemySpawner(gameComponents.EnemySpawner, this);
            var enemyDisposer = new Graphics.Handlers.EnemyDisposer(enemyRepository, this);
            var scoreHandler = new Graphics.Handlers.ScoreHandler(player, scoreLabel);
            return new GameGraphicsComponents(enemySpawner, enemyDisposer, scoreHandler);
        }

        private GameComponents InitializeGameComponents(IWorld world, IPlayer player, IEnemyRepository enemyRepository)
        {
            var enemySpawner = new EnemySpawner(enemyRepository, world);
            var enemyDisposer = new EnemyDisposer(enemyRepository, world);
            var scoreHandler = new ScoreHandler(player);

            return new GameComponents(enemySpawner, enemyDisposer, scoreHandler, world, player, enemyRepository);
        }
    }
}