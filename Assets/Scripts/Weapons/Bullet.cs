using UnityEngine;


namespace Weapons
{
    public class Bullet : MonoBehaviour {

        void Update () {
            Destroy(this.gameObject, 3f);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(this.gameObject);
        }
    }
}

