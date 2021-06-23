﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
	public static bool GameIsPaused = false;
	
	private GameManager gm;
    
	[SerializeField] private GameObject settingsMenu;
	[SerializeField] private GameObject levelSelectMenu;
	[SerializeField] private GameObject pauseMenu;
	[SerializeField] private GameObject II;
	[SerializeField] private GameObject levels1;
	[SerializeField] private GameObject levels2;
	[SerializeField] private GameObject nextButton;
	[SerializeField] private GameObject previousButton;
	[SerializeField] private GameObject joyStick;
	
	private int Level4x4 = 4;
	private int Level6x6 = 6;
	private int Level8x8 = 8;
	private int Level10x10 = 10;
	
    
    private void Start()
    {
	    gm = FindObjectOfType<GameManager>();
	    
	    if (gm == null)
	    {
	    	Debug.LogError("There is no game manager in the scene");
	    }
    }
    
	public void LevelOneToThree()
	{
		gm.GenerateNewMaze(Level4x4, Level4x4);
	}
	
	public void LevelFourToSeven()
	{
		gm.GenerateNewMaze(Level6x6, Level6x6);
	}
	
	public void LevelEightToTwelve()
	{
		gm.GenerateNewMaze(Level8x8, Level8x8);
	}
	
	public void ExitButton()
	{
		gm.ExitApplication();
	}

	public void MainMenu()
	{
		Time.timeScale = 1f;
		gm.LoadMainMenu();
	}
	
	//Calling UI methods

    public void StartButton()
    {
	    EnableMe(levelSelectMenu);
    }
    
	public void SettingsButton()
	{
		EnableMe(settingsMenu);
	}
	
	public void PauseButton()
	{
		EnableMe(pauseMenu);
		Invoke("Pause", 1f);
		DisableMe(joyStick);
		DisableMe(II);
	}
	
	public void XS()
	{
		CloseMenu(settingsMenu);
	}
	
	public void XL()
	{
		CloseMenu(levelSelectMenu);
	}
	
	public void XP()
	{
		Resume();
		EnableMe(joyStick);
		CloseMenu(pauseMenu);
		EnableMe(II);
	}
	
	public void	Next()
	{
		CloseMenu(levels1);
		EnableMe(levels2);
		EnableMe(previousButton);
		DisableMe(nextButton);
	}
	
	public void Previous()
	{
		CloseMenu(levels2);
		EnableMe(levels1);
		EnableMe(nextButton);
		DisableMe(previousButton);
	}
	
	
	public void Pause()
	{
		//Time.timeScale = 0f;
		GameIsPaused = true;
	}
	
	public void Resume()
	{
		Time.timeScale = 1f;
		GameIsPaused = false;
	}
	
	//Methods to initiate UI
	
	private void EnableMe(GameObject obj)
	{
		obj.SetActive(true);
	}
	
	private void CloseMenu(GameObject obj)
	{
		LeanTween.scale(obj, Vector3.zero, 0.2f).setOnComplete(() => DisableMe(obj));
	}
	
	private void DisableMe(GameObject obj)
	{
		obj.SetActive(false);
	}
	
	
}
