using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace CR.Gameplay
{
    public class BaseLane : MonoBehaviour, IPoolable
    {
        [SerializeField]
        private MeshRenderer meshRenderer;

        [SerializeField]
        private Vector2 timeFrame;

        [SerializeField]
        private Transform[] spawnPoints;

        [SerializeField]
        private Color baseColor;

        [SerializeField]
        private Color alternativeColor;

        private Action<BaseLane> onDespawn;
        private LaneDirection direction;
        protected bool enableAdditionalObjects;

        public void SetDirection(LaneDirection laneDirection)
        {
            this.direction = laneDirection;
        }

        public void SetAdditionalObjectsState(bool newState)
        {
            enableAdditionalObjects = newState;
        }

        public void AddListener(Action<BaseLane> callback)
        {
            onDespawn += callback;
        }

        public virtual void PrepareForActivate()
        {

        }

        public virtual void PrepareForDeactivate()
        {

        }

        public Vector3 GetSpawnPointPosition()
        {
            return spawnPoints[(int)direction].position;
        }

        public Quaternion GetSpawnPointRotation()
        {
            return spawnPoints[(int)direction].rotation;
        }

        public Vector2 GetTimeFrame()
        {
            return timeFrame;
        }

        private void OnTriggerEnter(Collider other)
        {
            try
            {
                if (other.CompareTag("Despawn"))
                    onDespawn.Invoke(this);
            }
            catch (NullReferenceException)
            {
                Debug.LogWarning("Object not from pool has been triggered");
            }
        }

        public void SetColor(int count)
        {
            meshRenderer.material.color = count % 2 == 0 ? baseColor : alternativeColor;
        }

    }
}
