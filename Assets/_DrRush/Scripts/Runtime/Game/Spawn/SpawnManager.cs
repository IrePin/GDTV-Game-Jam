using UnityEngine;

namespace _DrRush.Scripts.Runtime
{
    public class SpawnManager : MonoBehaviour
    {
        public SpawnPoint[] sides;

        public static SpawnManager Instance;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        
        [System.Serializable]
        public class SpawnPoint
        {
            public Transform spawnPoint;
        }
    }
}