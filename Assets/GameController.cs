using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public float minZ,maxZ,minX,maxX,yPos;
	public GameObject dropletFormation,rainDrop;
	private Vector3 dropPosition;
	public float initialDropDelay;
	public float maxDropDelay;
	private float currentDropDelay;
	private float counter;
	private int score;
	public Text scoreText;

	void Start () {
		score = 0;
		scoreText.text = "Score: " + score.ToString ();
		counter = initialDropDelay;
		currentDropDelay = initialDropDelay;
	}
	void Update () 
	{
		if (counter <= 0)
		{
						formNewDrop ();
						counter = currentDropDelay;

				} 
		else {
			counter -= Time.deltaTime;
		}
		

	}
	void formNewDrop(){
		float z, x, y;
		z = Random.Range (minZ, maxZ);
		x = Random.Range (minX, maxX);
		y = yPos;
		dropPosition = new Vector3 (x, y, z);
		Instantiate (dropletFormation, dropPosition, dropletFormation.transform.rotation);
	}
	public void incrementScore(){
		score += 1;
		scoreText.text = "Score: " + score.ToString ();
		//Increment score here
	}
	public void speedUpDropRate(float speed){
		currentDropDelay -= speed;
	}
	public void gameOver()
	{
		scoreText.text = "GAME OVER";
	}
}
