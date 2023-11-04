using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 5f;

	private Rigidbody rb;


	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{

		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

		movement.Normalize();

		Ray ray = new Ray(transform.position,transform.forward * 10);
		//Debug.DrawRay(transform.position, transform.forward * 10, Color.green);

		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			if (hit.collider.gameObject.name == "Sun")
			{
				Debug.Log("Victory");
            }
		}

		movement *= moveSpeed;
	
		rb.velocity = movement;
	}
}
