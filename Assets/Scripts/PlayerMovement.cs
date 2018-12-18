using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player{
	public class PlayerMovement : MonoBehaviour {

		
		[Range(1f, 10f)]
		private float movementSpeed = 6f;

		[Range(2f, 5f)]
		private float movementSpeedMultiplier = 3f;
		
		private float rotationSpeed = 10f;

		public Rigidbody2D rigidbody;


        // Use this for initialization
        private void Start () {
			rigidbody = GetComponent<Rigidbody2D>();
		}
		
		// Update is called once per frame
		private void Update () {
			RotateWithMouse();
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
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

			var direction = mousePosition - transform.position;
			direction = direction.normalized;
			
			var angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
			var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Euler(0,0, angle);
		}
	}
}
