using UnityEngine;
using UnityEngine.InputSystem.XR;

namespace CR.Core
{
    public class GameState : BaseState
    {

        public override void Init(GameController gc)
        {
            base.Init(gc);
            gc.CrossyInput.isMovePressed +=
                (input) => gc.PlayerMovement.UpdateMovement(input, gc.PointsSystem);
            gc.PlayerMovement.OnLose += () => gc.ChangeState(new LoseState());
        }

        public override void DestroyState()
        {
            gc.CrossyInput.ClearAllInputs();
        }

        public override void Tick()
        {
            gc.CameraController.
                UpdateCameraPosition();
        }
    }
}
