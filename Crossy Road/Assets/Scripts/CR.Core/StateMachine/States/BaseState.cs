using UnityEngine;

namespace CR.Core
{
	public abstract class BaseState
	{
        protected GameController gc;

        public virtual void Init(GameController gc)
        {
            this.gc = gc;
        }
        public abstract void Tick();
        public abstract void DestroyState();
    }
}
