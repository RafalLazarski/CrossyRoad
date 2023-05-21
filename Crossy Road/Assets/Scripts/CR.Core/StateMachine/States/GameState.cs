using UnityEngine;
using UnityEngine.InputSystem.XR;

namespace CR.Core
{
    public class GameState : BaseState
    {

        public override void Init(GameController gameController)
        {
            base.Init(gameController);
            gameController.CarSpawner.InitSpawner();
            gameController.LevelSpawner.Init(2);
            gameController.CrossyInput.isMovePressed += gameController.PlayerMovement.UpdateMovement;

            gameController.CrossyInput.isPausePressed += test;
        }

        public override void DestroyState()
        {
            gameController.CrossyInput.ClearAllInputs();
        }

        public override void Tick()
        {
            gameController.CameraController.
                UpdateCameraPosition();
        }

        public void test(bool isPressed)
        {
            if (isPressed)
            {
                Debug.Log("Dzia³a");
            }
        }
    }
}
