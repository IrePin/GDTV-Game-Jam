
using UnityEngine;

namespace _DrRush.Scripts.ShooterCrutch.Enemy
{
    public class AngleToPlayer : MonoBehaviour
    {
        [SerializeField] private Transform player;
        private Vector3 _targetPos;
        private Vector3 _targetDir;
    
        [SerializeField]private SpriteRenderer spriteRenderer;

        private float _angle;
        public int lastIndex;
        
        void Update()
        {
            // Get Target Position and Direction
            _targetPos = new Vector3(player.position.x, transform.position.y, player.position.z);
            _targetDir = _targetPos - transform.position;

            // Get Angle
            _angle = Vector3.SignedAngle(_targetDir, transform.forward, Vector3.up);
        
            //Flip Sprite if needed
            Vector3 tempScale = Vector3.one;
            if (_angle > 0) { tempScale.x *= -1f; }
            spriteRenderer.transform.localScale = tempScale;

            lastIndex = GetIndex(_angle);
        }
        
        private int GetIndex(float _angle)
        {
            //front
            if (_angle > -22.5f && _angle < 22.6f)
                return 0;
            if (_angle >= 22.5f && _angle < 67.5f)
                return 7;
            if (_angle >= 67.5f && _angle < 112.5f)
                return 6;
            if (_angle >= 112.5f && _angle < 157.5f)
                return 5;
        
        
            //back
            if (_angle <= -157.5 || _angle >= 157.5f)
                return 4;
            if (_angle >= -157.4f && _angle < -112.5f)
                return 3;
            if (_angle >= -112.5f && _angle < -67.5f)
                return 2;
            if (_angle >= -67.5f && _angle <= -22.5f)
                return 1;
        
            return lastIndex;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward);
        }
    }
}
