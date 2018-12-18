using UnityEngine;
using Weapons;

namespace Player
{
	public class Interact : MonoBehaviour
	{

		private PlayerMovement _player;

		private void Start()
		{
			_player = GetComponentInParent<PlayerMovement>();
		}

		private void OnTriggerStay2D(Collider2D other)
		{
			Debug.Log("girdi");
			
			if (other.CompareTag("Weapon"))
			{
				Debug.Log("You can pick up a weapon.");
				
				//if(_player.weapon != null)
					//_player.weapon.Throw(_player.direction);

				Weapon newWeapon = other.gameObject.GetComponent<Weapon>(); 
				
				
				if(Input.GetKeyDown(KeyCode.Mouse1))
					_player.PickUpWeapon(newWeapon);
			}
		}
	}
}

