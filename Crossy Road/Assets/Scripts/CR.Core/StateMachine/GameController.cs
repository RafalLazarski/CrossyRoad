using CR.Data;
using CR.Gameplay;
using CR.InputSystem;
using CR.UI;
using UnityEngine;

namespace CR.Core
{
	public class GameController : MonoBehaviour
	{
        private BaseState currentState;

        [SerializeField]
        private MenuView menuView;
        public MenuView MenuView => menuView;

        private SaveSystem saveSystem;
        public SaveSystem SaveSystem => saveSystem;

        [SerializeField]
        private CrossyInput crossyInput;
        public CrossyInput CrossyInput => crossyInput;

        [SerializeField]
        private LevelSpawner levelSpawner;
        public LevelSpawner LevelSpawner => levelSpawner;

        [SerializeField]
        private CarSpawner carSpawner;
        public CarSpawner CarSpawner => carSpawner;

        [SerializeField]
        private CameraMovementController cameraController;
        public CameraMovementController CameraController => cameraController;

        [SerializeField]
        private PlayerMovement playerMovement;
        public PlayerMovement PlayerMovement => playerMovement;


        private void Start()
        {
            saveSystem = new SaveSystem();
            saveSystem.LoadData();

            ChangeState(new MenuState());
            //ChangeState(new GameState());
        }

        private void Update()
        {
            currentState?.Tick();
        }

        private void OnDestroy()
        {
            saveSystem.SaveData();
        }

        public void ChangeState(BaseState newState)
        {
            currentState?.DestroyState();
            currentState = newState;
            currentState?.Init(this);
        }
    }
}
