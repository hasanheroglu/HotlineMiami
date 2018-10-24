using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image;

namespace Level{
	public class LevelGenerator : MonoBehaviour {

		private SpriteLibrary spriteLibrary;

		public Texture2D levelMap;
		public ColorToPrefab[] prefabs;

		// Use this for initialization
		void Start () {
			spriteLibrary = GameObject.FindWithTag("SpriteLibrary").GetComponent<SpriteLibrary>();
			GenerateLevel();
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		private void GenerateLevel(){
			for(int i=0; i < levelMap.width; i++){
				for(int j=0; j < levelMap.height; j++){
					GenerateObject(levelMap.GetPixel(i,j), i, j);
				}
			}
		}

		private void GenerateObject(Color c, int x, int y){
			for(int i = 0; i < prefabs.Length; i++){
				if(prefabs[i].color == c){
					Debug.Log("Girdi");
					Instantiate(prefabs[i].prefab, new Vector3(x , y , 0), Quaternion.identity);
				}
			}
		}
	}

}
