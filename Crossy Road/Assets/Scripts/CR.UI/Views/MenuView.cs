using UnityEngine;

namespace CR.UI
{
	public class MenuView : MonoBehaviour
	{
		public void ShowView()
		{
			gameObject.SetActive(true);
		}

		public void HideView()
		{
			gameObject.SetActive(false);
		}
	}
}
