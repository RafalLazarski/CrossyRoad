using TMPro;
using UnityEngine;

namespace CR.UI
{
	public class MenuView : BaseView
	{
		[SerializeField]
		private TextMeshProUGUI score;

		public void UpdateScores(int bestScore)
		{
			score.text = $"Best score: {bestScore}";

        }
	}
}
