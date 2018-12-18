using UnityEngine;

namespace Weapons
{
	public abstract class Weapon : MonoBehaviour
	{
		
		public abstract void Attack(Vector3 attackDirection);
		public abstract void Reload();
		public abstract void Throw(Vector3 throwDirection);
	}
}

