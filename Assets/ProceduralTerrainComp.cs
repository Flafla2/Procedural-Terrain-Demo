using UnityEngine;
using System.Collections;
using Noise;
using System.Threading;

public class ProceduralTerrainComp : MonoBehaviour {

	[Range(0,1)]	
	public float persistence = 0.35f;
	[Range(0.01f,2)]
	public float spread = 1;
	public int heightmapSize = 2048;
	public int terrainHeight = 600;
	public int octaves = 8;
	public int splatmapSize = 1024;
	
	public void Regenerate() {
		Perlin gen = new Perlin();
		double seed = Random.Range(0,5000);
		int size = heightmapSize;
		
		float[,] noise = new float[size,size];
		for(int x=0;x<size;x++) {
			for(int y=0;y<size;y++) {
				noise[x,y] = (float)gen.OctavePerlin(((float)x)/(1000f*spread),((float)y)/(1000f*spread),seed,octaves,persistence);
			}
		}
		
		Terrain terrain = GetComponent<Terrain>();
		TerrainData data = terrain.terrainData;
		data.size = new Vector3(data.size.x,terrainHeight,data.size.z);
		data.heightmapResolution = size;
		data.SetHeights(0,0,noise);

		float[,,] splatmap = new float[splatmapSize,splatmapSize,splatmapSize];
	}

	[System.Serializable]
	class SplatData {
		public Texture2D texture;
		[Range(0,90)]
		public float fadeInAngleLow = 0;
		[Range(0,90)]
		public float fadeInAngleHigh = 90;
		public float influence = 1;
	}

	[System.Serializable]
	class LayerData {
		public SplatData[] splats;
		[Range(0,1)]
		public float fadeInHeight = 0;
		public float 
	}
}
