using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallerManager : MonoBehaviour
{
	public GameObject CALLER_PANEL;

	// Start is called before the first frame update
	void Start()
	{
		Debug.Log("Ciallo world! (Caller Manager)");    // main control flow starts here
	}

	// Update is called once per frame
	void Update()
	{
		if (CALLER_PANEL.activeInHierarchy && Input.anyKeyDown)
		{
			CALLER_PANEL.SetActive(false);
			ChessingManager.Instance.InvokeStart();
		}
	}
}
