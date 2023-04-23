using UnityEngine;

namespace CR.Core
{
    public class GameState : BaseState
    {

        public override void Init(GameController gameController)
        {
            base.Init(gameController);
            gameController.LevelSpawner.Init(2);
        }

        public override void DestroyState()
        {

        }

        public override void Tick()
        {

        }
    }
}
