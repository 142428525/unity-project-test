using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CallerManager : MonoBehaviour
{
	public GameObject CALLER_PANEL;

	public DialogueRunner DIALOG_RUNNER;
	public string FIRST_DIALOG_NODE = "Start";

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

			//ChessingManager.Instance.InvokeStart();
			DIALOG_RUNNER.StartDialogue(FIRST_DIALOG_NODE);
		}
	}
}
