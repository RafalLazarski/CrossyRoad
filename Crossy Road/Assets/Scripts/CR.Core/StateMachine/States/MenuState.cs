using UnityEngine;

namespace CR.Core
{
    public class MenuState : BaseState
    {
        public override void Init(GameController gameController)
        {
            base.Init(gameController);
            //gameController.MenuView.StartButton.onClick.AddListener(() => gameController.ChangeState(new GameState()));
            gameController.MenuView.ShowView();
        }

        public override void DestroyState()
        {
            gameController.MenuView.HideView();
            //gameController.MenuView.StartButton.onClick.RemoveAllListeners();
        }

        public override void Tick()
        {
            Debug.Log("Menu State is on");
        }
    }
}
