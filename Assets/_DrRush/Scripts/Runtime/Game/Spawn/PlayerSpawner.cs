using UnityEngine;

namespace _DrRush.Scripts.Runtime.Game.Spawn
{
    [DisallowMultipleComponent()]
    public class PlayerSpawner : MonoBehaviour
    {
        public Unit Unit { get; set; }

        public bool spawnOnAwake;
        public Unit unitPrefab;
        public int teamID;
        
        public string UnitName { get; set; }

        public SpawnManager SpawnManager { get; set; }

        private void Start()
        {
            if (!unitPrefab) unitPrefab = GetComponentInChildren<Unit>();
            SpawnManager = SpawnManager.Instance;
            
            if (spawnOnAwake)
            {
                foreach (Transform t in transform) t.gameObject.SetActive(false);
                Spawn();
            }
        }
        
        private void SpawnActor()
        {
            Spawn();
        }
        
        public Unit Spawn()
        {
            

            Vector3 pos = SpawnManager.sides[teamID].spawnPoint.position;
            Quaternion rot = Quaternion.identity;

            Unit newUnit = Instantiate(unitPrefab, pos, rot, transform);

            newUnit.gameObject.SetActive(true);

            return newUnit;
        }
    }
}
