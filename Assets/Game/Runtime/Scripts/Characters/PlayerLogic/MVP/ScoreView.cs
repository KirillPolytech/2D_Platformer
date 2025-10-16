using System;
using Game.Runtime.Scripts.Config;
using TMPro;
using Zenject;

namespace Game.Runtime.Scripts.MVP
{
    public class ScoreView : IInitializable, IDisposable
    {
        private TMP_Text _scoreText;
        private ScorePresenter _presenter;
        private GameConfig _gameConfig;

        [Inject]
        public void Construct(
            ScorePresenter presenter, 
            GameConfig gameConfig, 
            TMP_Text scoreText)
        {
            _presenter = presenter;
            _gameConfig = gameConfig;
            _scoreText = scoreText;

            UpdateView(0);
        }

        private void UpdateView(int score)
        {
            _scoreText.text = $"{_gameConfig.ScoreText} {score}";
        }

        public void Initialize()
        {
            _presenter.OnScoreChanged += UpdateView;
        }

        public void Dispose()
        {
            _presenter.OnScoreChanged -= UpdateView;
        }
    }
}