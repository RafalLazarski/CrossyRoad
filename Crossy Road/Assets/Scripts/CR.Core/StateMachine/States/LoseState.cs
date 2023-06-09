using System;
using UnityEngine;

namespace CR.Core
{
    public class LoseState : BaseState
    {
        public override void Init(GameController gc)
        {
            base.Init(gc);
            gc.LoseView.ShowView();
            gc.SaveSystem.PlayerData.BestScore = gc.PointsSystem.BestScore;
            gc.SaveSystem.SaveData();
            gc.LoseView.UpdateScore(gc.PointsSystem.CurrentScore, gc.PointsSystem.BestScore);
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
