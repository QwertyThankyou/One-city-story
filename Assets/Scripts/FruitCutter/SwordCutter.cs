using System;
using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class SwordCutter : MonoBehaviour {

	public Material capMaterial;

	public void Start()
	{
		
	}

	void OnCollisionEnter(Collision collision)
	{
		GameObject victim = collision.rigidbody.gameObject;

		GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

		if (!pieces[1].GetComponent<Rigidbody>())
		{
			pieces[1].AddComponent<Rigidbody>();
			MeshCollider temp = pieces[1].AddComponent<MeshCollider>();
			temp.convex = true;
		}
		Destroy(pieces[1], 1);
	}


}
