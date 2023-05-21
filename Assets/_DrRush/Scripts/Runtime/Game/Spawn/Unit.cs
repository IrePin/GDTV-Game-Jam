using UnityEngine;
using System;

namespace _DrRush.Scripts.Runtime.Game.Spawn
{
    public class Unit : MonoBehaviour
    {
        public UnitType type;
        public string Name;
        public PlayerSpawner PlayerSpawner { get; set; }

        private void Awake()
        {
            PlayerSpawner = GetComponentInParent<PlayerSpawner>();
        }

        private void Start()
        {
            if (PlayerSpawner) PlayerSpawner.Unit = this;
        }

        public enum UnitType
        {
            Human,
            Bot
        }
    }
}
