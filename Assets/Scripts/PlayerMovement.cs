using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player{
	public class PlayerMovement : MonoBehaviour {

		private Rigidbody2D rigidbody;


		[Range(1f, 10f)]
		public float movementSpeed = 6f;

		[Range(2f, 5f)]
		public float movementSpeedMultiplier = 3f;

		public float rotationSpeed = 20f;

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
			float move_x = Input.GetAxis("Horizontal");
			float move_y = Input.GetAxis("Vertical");
			
			if(Input.GetKey(KeyCode.LeftShift))
				rigidbody.velocity = CalculateVelocity(move_x, move_y, movementSpeed * movementSpeedMultiplier);
			else
				rigidbody.velocity = CalculateVelocity(move_x, move_y, movementSpeed);
		} 

		private Vector3 CalculateVelocity(float _move_x, float _move_y, float movementSpeed){
			return new Vector3(_move_x * movementSpeed * Time.deltaTime,
							   _move_y * movementSpeed * Time.deltaTime,
							   0);
		}

		

		private void RotateWithMouse(){
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.z = 1;
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			
			Vector2 direction = new Vector2(mousePosition.x - transform.localPosition.x,
											mousePosition.y - transform.localPosition.y);

			Debug.DrawLine(transform.position, mousePosition, Color.red, 10f);

			float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
			Quaternion rotation = Quaternion.AngleAxis(angle - 74f, Vector3.forward);
			Debug.Log(rotation);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed *  Time.deltaTime);
		}
	}
}
