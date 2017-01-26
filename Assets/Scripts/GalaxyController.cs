using UnityEngine;
using System.Collections;

public class GalaxyController : MonoBehaviour {

	public int maxSystems;
	public Vector3 bounds;
	public GameObject starPrefab;

	// Use this for initialization
	void Start () {
		generateDisc();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void generateRect() {
		// Generates a rectangular distribution of Star Systems.
		for (int i = 0; i < maxSystems; i++) {
			Vector3 rand = new Vector3(Random.value, Random.value, Random.value);

			Vector3 pos = new Vector3();

			pos.x = Mathf.Lerp(-bounds.x, bounds.x, rand.x);
			pos.y = Mathf.Lerp(-bounds.y, bounds.y, rand.y);
			pos.z = Mathf.Lerp(-bounds.z, bounds.z, rand.z);

			Debug.Log("x: " + pos.x + "\ny: " + pos.y + "\nz: " + pos.z);

			GameObject star = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			star.name = "Star";
			star.transform.position = pos;
			star.transform.localScale = new Vector3(10.0f, 10.0f, 10.0f);
		}
	}

	public void generateDisc() {
		// Generates a polar distribution of Star Systems.
		// TODO: need to add a "dead zone" for the center of the galaxy.
		for (int i = 0; i < maxSystems; i++) {
			Vector3 pos;
			Vector3 pBounds = new Vector3((bounds.x * Mathf.PI) / 180, (bounds.y * Mathf.PI) / 180, (bounds.z * Mathf.PI) / 180);

			// polarPos:
			// x = radius
			// y = polar
			// z = elevation

			Vector3 polarPos = new Vector3();
			polarPos.x = Mathf.Lerp(bounds.x * 0.2f, bounds.x, Random.value);
			polarPos.y = Mathf.Lerp(0, pBounds.y, Random.value);
			polarPos.z = Mathf.Lerp(-pBounds.z, pBounds.z, Random.value);

			Debug.Log(pBounds.y);

			float a = polarPos.x * Mathf.Cos(polarPos.z);
            pos = new Vector3(a * Mathf.Cos(polarPos.y), polarPos.x * Mathf.Sin(polarPos.z), a * Mathf.Sin(polarPos.y));

			generateStar("Star_" + i, pos);
		}
	}

	private void generateStar(string name, Vector3 pos) {
		// Generates a single star system.
		GameObject star = (GameObject)Instantiate(starPrefab, pos, Quaternion.identity, this.transform);
		star.name = name;
	}
}
