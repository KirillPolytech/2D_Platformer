using System;
using Game.Runtime.Scripts.Config;
using TMPro;
using Zenject;

namespace Game.Runtime.Scripts.MVP
{
    public class LivesView : IInitializable, IDisposable
    {
        private TMP_Text _livesText;
        private LivesPresenter _presenter;
        private GameConfig _gameConfig;

        [Inject]
        public void Construct(
            LivesPresenter presenter, 
            GameConfig gameConfig, 
            TMP_Text livesText)
        {
            _presenter = presenter;
            _gameConfig = gameConfig;
            _livesText = livesText;

            UpdateView(_gameConfig.Lives);
        }
        
        private void UpdateView(int lives)
        {
            _livesText.text = $"{_gameConfig.LivesText} {lives}";
        }
        
        public void Initialize()
        {
            _presenter.OnLivesChanged += UpdateView;
        }

        public void Dispose()
        {
            _presenter.OnLivesChanged -= UpdateView;
        }
    }
}