using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CR.UI
{
	public class LoseView : BaseView
	{
        [SerializeField]
        private Button restartButton;

        [SerializeField]
        private TextMeshProUGUI score;

        public override void ShowView()
        {
            base.ShowView();
            restartButton.onClick.AddListener(() => SceneManager.LoadScene(0));
        }

        public void UpdateScore(int lastScore, int bestScore)
        {
            this.score.text = $"Current score: {lastScore.ToString()}\nBest Score: {bestScore.ToString()}";
        }

    }
}
