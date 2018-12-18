using UnityEngine;


namespace Weapons
{
    public class Bullet : MonoBehaviour {

        void Update () {
            Destroy(this, 3f);
        }
    }
}

