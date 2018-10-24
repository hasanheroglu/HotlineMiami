using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image;

namespace Level{
	public class LevelGenerator : MonoBehaviour {

		private SpriteLibrary spriteLibrary;

		// Use this for initialization
		void Start () {
			spriteLibrary = GameObject.FindWithTag("SpriteLibrary").GetComponent<SpriteLibrary>();
			Debug.Log(spriteLibrary.corner.border.y);
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}

}
