using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

namespace Player{
	public class PlayerMovement : MonoBehaviour {

		
		[Range(1f, 10f)]
		private float movementSpeed = 6f;
		[Range(2f, 5f)]
		private float movementSpeedMultiplier = 3f;
		
		private float rotationSpeed = 10f;
		private Rigidbody2D rigidbody;
		
		public Vector3 direction;
		public Weapon weapon;
		public GameObject weaponHolder;

        // Use this for initialization
        private void Start () {
			rigidbody = GetComponent<Rigidbody2D>();
	        
	        if(weapon != null)
				weapon.transform.position = weaponHolder.transform.position;
        }
		
		// Update is called once per frame
		private void Update () {
			RotateWithMouse();

			if (Input.GetKeyDown(KeyCode.Mouse0) && weapon != null)
				weapon.Attack(direction);

			if (Input.GetKeyDown(KeyCode.Space) && weapon != null)
				ThrowWeapon();

		}

		private void FixedUpdate(){
			Move();
		}

		private void Move(){
			var moveX = Input.GetAxis("Horizontal");
			var moveY = Input.GetAxis("Vertical");
			
			rigidbody.velocity = Input.GetKey(KeyCode.LeftShift) ? 
								 CalculateVelocity(moveX, moveY, movementSpeed * movementSpeedMultiplier) : 
								 CalculateVelocity(moveX, moveY, movementSpeed);
		} 

		private Vector3 CalculateVelocity(float moveX, float moveY, float movSpeed){
			return new Vector3(moveX * movSpeed * Time.deltaTime,
							   moveY * movSpeed * Time.deltaTime,
							   0);
		}

		private void RotateWithMouse(){
			var mousePosition = Input.mousePosition;
			mousePosition.z = 1;
			
			if(Camera.main != null)
				mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			else
				Debug.Log("Camera not found!");

			direction = mousePosition - transform.position;
			direction = direction.normalized;
			
			var angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0,0, angle);
		}


		public void PickUpWeapon(Weapon newWeapon)
		{
			weapon = newWeapon;
			weapon.transform.position = weaponHolder.transform.position;
			weapon.transform.SetParent(this.gameObject.transform);
		}

		private void ThrowWeapon()
		{
			weapon.transform.SetParent(null);
			weapon.Throw(direction);
			weapon = null;
		}
	}
}
