using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image;

namespace Level{
	public class LevelGenerator : MonoBehaviour {

		//private SpriteLibrary spriteLibrary;

		public Texture2D levelMap;
		public ColorToPrefab[] prefabs;

		// Use this for initialization
		void Start () {
			//spriteLibrary = GameObject.FindWithTag("SpriteLibrary").GetComponent<SpriteLibrary>();
			GenerateLevel();
		}
		private void GenerateLevel(){
			List <float> positions = new List<float>{
				0,0
			};
			for(int i=0; i < levelMap.width; i++){
				for(int j=0; j < levelMap.height; j++){
					GenerateObject(i, j, positions);
				}
			}
		}

		private void GenerateObject(int x, int y, List<float> positions){
			
			Color c = levelMap.GetPixel(x,y);
			float location_multiplier_x = 0;
			float location_multiplier_y = 0;
			for(int i = 0; i < prefabs.Length; i++){
				if(prefabs[i].color == c){
					location_multiplier_x = prefabs[i].prefab.GetComponent<SpriteRenderer>().sprite.rect.width/100;
					location_multiplier_y = prefabs[i].prefab.GetComponent<SpriteRenderer>().sprite.rect.height/100;
					Instantiate(prefabs[i].prefab, 
					new Vector3(x * location_multiplier_x ,y * location_multiplier_y , 0), 
					prefabs[i].prefab.transform.rotation);
				}
			}
			positions[0] += x * location_multiplier_x / 2;
			positions[1] += y * location_multiplier_y / 2;
		}
	}
}
