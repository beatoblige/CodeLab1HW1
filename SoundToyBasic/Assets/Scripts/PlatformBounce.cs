using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBounce : MonoBehaviour {


	public AudioClip[] tones;
	public float maxSpeed = 1.0f;

	private AudioSource _audioSource;

	void Start() {
		_audioSource = GetComponent<AudioSource>();
	}

	int GetCollisionStrength(Collision2D collision)
	{
		Vector3 normal = collision.contacts[0].normal;
		Vector3 bounceAmount = Vector3.Project(collision.relativeVelocity, normal);
		float speed = bounceAmount.magnitude;
		float clampedSpeed = Mathf.Clamp(speed / maxSpeed, 0.0f, 0.99f);
		Debug.Log(clampedSpeed);
		Debug.Log(Mathf.FloorToInt(clampedSpeed * tones.Length));
		return Mathf.FloorToInt(clampedSpeed * tones.Length);
		
	}

	

	void OnCollisionEnter2D(Collision2D collision)
	{
		int noteIndex = GetCollisionStrength(collision);
		
		_audioSource.PlayOneShot(tones[noteIndex]);
		

	}
}
