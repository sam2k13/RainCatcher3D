using UnityEngine;
using System.Collections;

public class RainDropScript : MonoBehaviour {
	//public GameObject gameController;
	//private GameController gameScript;
	// Use this for initialization
	void Start () {
		//gameScript = gameController.GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col)
	{Debug.Log("This Called");
		if (col.gameObject.tag == "Player") 
		{	
			Debug.Log("Hit Bucket");
			GameObject.Find("Game Controller").GetComponent<GameController>().incrementScore();
			Destroy(this.gameObject);
		}
		else if (col.gameObject.tag == "Ground")
		{
			Debug.Log("Hit Floor");

			//GameObject.Find("Game Controller").GetComponent<GameController>().gameOver();
			Destroy(this.gameObject);
		}

	}
}
