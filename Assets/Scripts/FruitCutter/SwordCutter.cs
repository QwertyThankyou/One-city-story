using System;
using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class SwordCutter : MonoBehaviour {

	public Material capMaterial;
	private AudioManager _audioManager;
	private bool _isFirst = true;
	
	public void Start()
	{
		_audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
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

		if (_isFirst)
		{
			_audioManager.Play("WatermellonCut1");
			_isFirst = false;
		}
		else
		{
			_audioManager.Play("WatermellonCut2");
			_isFirst = true;
		}
		
		Destroy(pieces[1], 1);
	}


}
