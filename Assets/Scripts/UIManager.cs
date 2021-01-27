using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : MonoBehaviour
{
	GameObject[] pauseObjects;
	GameObject[] aboutObjects;
	GameObject[] controlsObjects;

	void Start()
	{
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		controlsObjects = GameObject.FindGameObjectsWithTag("ShowOnControls");
		aboutObjects = GameObject.FindGameObjectsWithTag("ShowOnAbout");
		hidePaused();
		hideControls();
	}

	void Update()
	{

		if (Input.GetKeyDown(KeyCode.P))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			}
			else if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
				hidePaused();
			}
		}
	}


	public void Reload()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	public void pauseControl()
	{
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showPaused();
		}
		else if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
			hidePaused();
		}
	}

	public void showPaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(true);
		}
	}

	public void hidePaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(false);
		}
	}

	public void showControls()
    {
		foreach (GameObject g in controlsObjects)
			g.SetActive(true);
    }

	public void hideControls()
	{
		foreach (GameObject g in controlsObjects)
			g.SetActive(false);
	}

	public void showAbout()
	{
		foreach (GameObject g in aboutObjects)
			g.SetActive(true);
	}

	public void hideAbout()
	{
		foreach (GameObject g in aboutObjects)
			g.SetActive(false);
	}


	public void LoadLevel(string level)
	{
		Application.LoadLevel(level);
	}

	public void QuitGame()
    {
		Application.Quit();
    }

	public void LoadMenu()
    {
		Application.LoadLevel(0);
    }

	public void LoadAbout()
    {
		Application.LoadLevel(2);
    }

	public void StartGame()
    {
		Application.LoadLevel(1);
    }

	public void ClickControls()
    {
		hideAbout();
		showControls();
    }

	public void ClickAbout()
    {
		hideControls();
		showAbout();
    }
}
