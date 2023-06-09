using System;
using UnityEngine;
using UnityEngine.InputSystem.XR;

namespace CR.Core
{
    public class MenuState : BaseState
    {
        public override void Init(GameController gc)
        {
            base.Init(gc);
            gc.MenuView.ShowView();
            gc.CrossyInput.isStartPressed += StartGame;
            gc.MenuView.UpdateScores(0);
            try
            {
                gc.MenuView.UpdateScores(gc.SaveSystem.PlayerData.BestScore);
            }
            catch(Exception e)
            {
                Debug.LogException(e);
            }

            gc.PointsSystem.Init(gc.SaveSystem.PlayerData.BestScore);
            gc.CarSpawner.InitSpawner();
            gc.LevelSpawner.Init(2);
        }

        public override void DestroyState()
        {
            gc.MenuView.HideView();
            gc.CrossyInput.ClearAllInputs();
        }

        public override void Tick()
        {

        }

        private void StartGame(bool isPressed)
        {
            if(isPressed)
            {
                gc.ChangeState(new GameState());
            }
        }
    }
}
