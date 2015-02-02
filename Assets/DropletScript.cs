using UnityEngine;
using System.Collections;

public class DropletScript : MonoBehaviour {
	public float dropDelay = 2;
	private float counter;
	public GameObject raindrop;
	public float rainDropOffset;
	public float dropletDownDistance = .1f;
	// Use this for initialization
	void Start () {
		counter = dropDelay;
	}
	
	// Update is called once per frame
	void Update () {
		if (counter <= 0) {
						dropRainDrop ();
				}
		else {
			transform.Translate(0,-(dropletDownDistance * Time.deltaTime)/dropDelay,0);
			counter -= Time.deltaTime;
				}
	}
	void dropRainDrop(){

		Instantiate (raindrop, gameObject.transform.position + new Vector3(0,rainDropOffset,0), raindrop.transform.rotation);
		Destroy (gameObject);
	}
}
