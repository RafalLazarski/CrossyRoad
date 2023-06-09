using System;
using UnityEngine;

namespace CR.Core
{
    public class LoseState : BaseState
    {
        private int lastScore;
        public LoseState(int lastScore)
        {
            this.lastScore = lastScore;
        }

        public override void Init(GameController gc)
        {
            base.Init(gc);
            gc.LoseView.ShowView();
            gc.SaveSystem.PlayerData.BestScore = gc.PointsSystem.BestScore;
            gc.SaveSystem.SaveData();
            gc.LoseView.UpdateScore(lastScore, gc.PointsSystem.BestScore);
        }

        public override void DestroyState()
        {
            gc.LoseView.HideView();
        }

        public override void Tick()
        {

        }
    } 
}
