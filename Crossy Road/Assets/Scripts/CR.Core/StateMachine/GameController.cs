using CR.Data;
using CR.UI;
using UnityEngine;

namespace CR.Core
{
	public class GameController : MonoBehaviour
	{
        private BaseState currentState;

        [SerializeField]
        private MenuView menuView;
        public MenuView MenuView => menuView;

        private SaveSystem saveSystem;
        public SaveSystem SaveSystem => saveSystem;

        private void Start()
        {
            saveSystem = new SaveSystem();
            saveSystem.LoadData();

            ChangeState(new MenuState());
        }

        private void Update()
        {
            currentState?.Tick();
        }

        private void OnDestroy()
        {
            saveSystem.SaveData();
        }

        public void ChangeState(BaseState newState)
        {
            currentState?.DestroyState();
            currentState = newState;
            currentState?.Init(this);
        }
    }
}
