using UnityEngine;

namespace CR.Core
{
    public class GameState : BaseState
    {

        public override void Init(GameController gameController)
        {
            base.Init(gameController);
            gameController.LevelSpawner.Init(2);
            gameController.CrossyInput.isPausePressed += test;
        }

        public override void DestroyState()
        {

        }

        public override void Tick()
        {

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
