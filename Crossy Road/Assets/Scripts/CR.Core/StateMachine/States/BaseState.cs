using UnityEngine;

namespace CR.Core
{
	public abstract class BaseState
	{
        protected GameController gameController;

        public virtual void Init(GameController gameController)
        {
            this.gameController = gameController;
        }
        public abstract void Tick();
        public abstract void DestroyState();
    }
}
