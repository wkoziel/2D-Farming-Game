using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool isStart;
    public bool isAbout;
    public bool isQuit;
	public bool isBack;

	void OnMouseUp()
	{
		if (isStart)
		{			
			Application.LoadLevel(1);
		}
		if (isAbout)
        {
			Application.LoadLevel(2);
        }
		if (isQuit)
		{
			Application.Quit();
		}
		if (isBack)
        {
			Application.LoadLevel(0);
        }
	}
}
