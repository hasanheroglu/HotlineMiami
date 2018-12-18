using UnityEngine;

namespace Weapons
{
	public class Pistol : Weapon
	{
		public int maxAmmoCount;
		public int ammoCount;
		public float reloadTime;
		public GameObject pistolBullet;
		public GameObject bulletHolder;
		public float bulletSpeed = 100.0f;
		public float throwSpeed = 100.0f;
		
		
		public override void Attack(Vector3 attackDirection)
		{
			if(ammoCount <= 0)
			{
				Reload();
				return;
			}

			GameObject newBullet = Instantiate(pistolBullet, bulletHolder.transform.position, Quaternion.identity);
			newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(attackDirection.x, attackDirection.y) * bulletSpeed);
			ammoCount--;
		}

		public override void Reload()
		{
			ammoCount = maxAmmoCount;
			
			//ADD TIMER
		}

		public override void Throw(Vector3 throwDirection)
		{
			this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(throwDirection.x, throwDirection.y) * throwSpeed);
		}
	}
}

