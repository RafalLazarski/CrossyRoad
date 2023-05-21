using UnityEngine;

namespace CR.Gameplay
{
	public class PointsSystem : MonoBehaviour
	{
		private int currentScore;
		private int bestScore;

		public int BestScore
		{
			get
			{
				if(currentScore < bestScore)
				{
					return bestScore;
				}
				return currentScore;
			}
		}

		public int CurrentScore => currentScore;

		public void Init(int bestScore)
		{
			this.bestScore = bestScore;
		}

        public void AddPoint()
        {
            currentScore++;
        }


    }
}
