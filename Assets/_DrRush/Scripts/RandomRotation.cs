using UnityEngine;

namespace _DrRush.Scripts
{
    public class RandomRotation : MonoBehaviour
    {
        public float rotationSpeed = 1f; 

        private void Start()
        {
            transform.rotation = Random.rotation;
        }

        private void Update()
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}