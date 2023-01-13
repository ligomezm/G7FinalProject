using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SimpleCollectibleScript : MonoBehaviour 
{

	public enum CollectibleTypes {DoorKey, BlueGem, GreenGem}; 

	public CollectibleTypes CollectibleType; 

	public bool rotate; 

	public float rotationSpeed;

	public AudioClip collectSound;

	public GameObject collectEffect;

	
	void Update () {

		if (rotate)
			transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "PlayerArmature") {
			Collect ();
		}
	}

	public void Collect()
	{
		if(collectSound)
			AudioSource.PlayClipAtPoint(collectSound, transform.position);
		if(collectEffect)
			Instantiate(collectEffect, transform.position, Quaternion.identity);


		if (CollectibleType == CollectibleTypes.BlueGem) 
		{

			
		}
		if (CollectibleType == CollectibleTypes.GreenGem) 
		{

			
		}
		if (CollectibleType == CollectibleTypes.DoorKey) {

			
		}

		gameObject.SetActive(false);
		//Destroy (gameObject);
	}
}
