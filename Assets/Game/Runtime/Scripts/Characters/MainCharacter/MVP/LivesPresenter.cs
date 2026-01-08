using System;
using Zenject;

namespace Game.Runtime.Scripts.MVP
{
    public class LivesPresenter : IInitializable, IDisposable
    {
        private readonly PlayerModel _model;
        
        public event Action<int> OnLivesChanged;

        [Inject]
        public LivesPresenter(PlayerModel model)
        {
            _model = model;
        }
        
        public void Initialize()
        {
            _model.Lives.OnChanged += OnChangedHandler;
        }

        public void Dispose()
        {
            _model.Lives.OnChanged -= OnChangedHandler;
        }
        
        private void OnChangedHandler()
        {
            OnLivesChanged?.Invoke(_model.Lives.Value);
        }
    }
}