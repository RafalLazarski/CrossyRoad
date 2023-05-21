using UnityEngine;
using UnityEngine.InputSystem.XR;

namespace CR.Core
{
    public class MenuState : BaseState
    {
        public override void Init(GameController gameController)
        {
            base.Init(gameController);
            gameController.MenuView.ShowView();
            gameController.CrossyInput.isStartPressed += StartGame;
            gameController.MenuView.UpdateScores(0, 30);
            gameController.MenuView.UpdateScores(gameController.SaveSystem.PlayerData.BestScore,
                gameController.SaveSystem.PlayerData.LastScore);
            gameController.PointsSystem.Init(gameController.SaveSystem.PlayerData.BestScore);
        }

        public override void DestroyState()
        {
            gameController.MenuView.HideView();
            gameController.CrossyInput.ClearAllInputs();
        }

        public override void Tick()
        {

        }

        private void StartGame(bool isPressed)
        {
            if(isPressed)
            {
                gameController.ChangeState(new GameState());
            }
        }
    }
}
