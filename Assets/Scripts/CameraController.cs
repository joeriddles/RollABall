using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject player;

	private Vector3 offset; // camera offset

    void Start()
    {
		offset = transform.position - player.transform.position;
    }

    void LateUpdate() // runs every frame like Update(). Is guaranteed to run after all other objects.
    {
		transform.position = player.transform.position + offset;
    }
}
