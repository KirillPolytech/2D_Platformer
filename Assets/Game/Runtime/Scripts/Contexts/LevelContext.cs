using Game.Runtime.Scripts.Camera;
using Game.Runtime.Scripts.Enemies;
using Game.Runtime.Scripts.EventBusThings;
using Game.Runtime.Scripts.FSM;
using Game.Runtime.Scripts.MVP;
using Game.Runtime.Scripts.Providers;
using Game.Runtime.Scripts.Windows;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Runtime.Scripts.Contexts
{
    public class LevelContext : MonoInstaller
    {
        [SerializeField]
        private CameraRayCaster rayCaster;

        [SerializeField]
        private PlayerLogic.Player player;

        [SerializeField]
        private Transform playerStartPosition;

        [SerializeField]
        private TMP_Text scoreText;

        [SerializeField]
        private TMP_Text livesText;

        [SerializeField]
        private WindowsController windowsController;

        [SerializeField]
        private Enemy[] enemies;
        
        [SerializeField]
        private PathData[] PathsData;
        
        [SerializeField]
        private ParticleSystem explosionParticle;

        public override void InstallBindings()
        {
            Container.Bind<InputSystem_Actions>().AsSingle();

            BindSignalBus();

            Container.Bind<Enemy[]>().FromInstance(enemies).AsSingle();
            Container.Bind<EnemiesProvider>().AsSingle();
            
            Container.Bind<PathData[]>().FromInstance(PathsData).AsSingle();
            
            Container.BindInstance(rayCaster).AsSingle();

            Container.BindInstance(windowsController).AsSingle();

            Container.BindInterfacesAndSelfTo<DragSystem.DragSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<Invincibility>().AsSingle();

            Container.BindInstance(player).AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerModel>().AsSingle();
            BindScore();
            BindLives();

            Container.BindInterfacesAndSelfTo<LevelStateMachine>().AsSingle().WithArguments(playerStartPosition);
            Container.BindInterfacesAndSelfTo<GameController>().AsSingle();
        }

        private void BindScore()
        {
            Container.BindInterfacesAndSelfTo<ScorePresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<ScoreView>().AsSingle().WithArguments(scoreText);
        }

        private void BindLives()
        {
            Container.BindInterfacesAndSelfTo<LivesPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<LivesView>().AsSingle().WithArguments(livesText);
        }

        private void BindSignalBus()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<RaycastColliderHitSignal>();
            Container.DeclareSignal<PlayerOnColliderEnterHitSignal>();
            Container.DeclareSignal<PlayerOnTriggerEnterHitSignal>();
            Container.DeclareSignal<VictorySignal>();
        }
    }
}