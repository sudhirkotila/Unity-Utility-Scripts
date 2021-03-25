using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
		public static SoundManager instance;
		public GameObject  sound_on_button, sound_off_button;
		public AudioSource mainMenuSoundRef, levelCompletedSoundRef, levelFailedSoundRef, levelSelectionSoundRef, gamePlaySoundRef, instructionPanelSoundRef;//Common For All Game
//		public AudioSource throwCheeseSound, cheeseInBucketSound, collisionWithRatSound, gameOverFirstSound;//Changes Realeted To Game
		public AudioSource bubbleTapSoundRef;
		public static bool isSoundOn = true;//Please true this for play sound...............................................................


		//Instance Creation
		void Start ()
		{
				instance = this;
		}

		void Update ()
		{
				if (PlayerPrefs.GetInt ("SoundState") == 1) {
						isSoundOn = false;
						sound_on_button.SetActive (false);
						sound_off_button.SetActive (true);
						mainMenuSoundRef.transform.position = new Vector3 (0, 0, 5000);
				} else {
						isSoundOn = true;
						sound_on_button.SetActive (true);
						sound_off_button.SetActive (false);
						mainMenuSoundRef.transform.position = new Vector3 (0, 0, -10);
				}
		}

		//Main Menu
		public void MainMenuPlaySound ()
		{
				if (isSoundOn) {
						mainMenuSoundRef.Play ();
						InstructionPanelStopSound ();
						LevelSelectionStopSound ();
						GamePlayPanelStopSound ();
						LevelCompletedStopSound ();
						LevelFailedStopSound ();
				}
		}

		public void MainMenuStopSound ()
		{
				if (isSoundOn)
						mainMenuSoundRef.Stop ();
		}

		//Level Selection Panel
		public void LevelSelectionPlaySound ()
		{
				if (isSoundOn) {
						MainMenuStopSound ();
						LevelFailedStopSound ();
						LevelCompletedStopSound ();
						GamePlayPanelStopSound ();
						levelSelectionSoundRef.Play ();
				}
		}

		public void LevelSelectionStopSound ()
		{
				if (isSoundOn)
						levelSelectionSoundRef.Stop ();
		}

		//Level Completed Panel
		public void LevelCompletedPlaySound ()
		{
				if (isSoundOn) {
						GamePlayPanelStopSound ();	
						levelCompletedSoundRef.Play ();
				}
		}

		public void LevelCompletedStopSound ()
		{
				if (isSoundOn)
						levelCompletedSoundRef.Stop ();
		}

		//Level Failed Panel
		public void LevelFailedPlaySound ()
		{
				if (isSoundOn) {
						GamePlayPanelStopSound ();
						levelFailedSoundRef.Play ();
				}
		}

		public void LevelFailedStopSound ()
		{
				if (isSoundOn)
						levelFailedSoundRef.Stop ();
		}

		//GamePlay Panel
		public void GamePlayPanelPlaySound ()
		{
				if (isSoundOn) {
						LevelFailedStopSound ();
						LevelCompletedStopSound ();
						LevelSelectionStopSound ();
						gamePlaySoundRef.Play ();
				}
		}

		public void GamePlayPanelStopSound ()
		{
				if (isSoundOn) {
						gamePlaySoundRef.Stop ();
				}
		}

		//Instruction Panel
		public void InstructionPanelPlaySound ()
		{
				if (isSoundOn) {
						MainMenuStopSound ();
						instructionPanelSoundRef.Play ();
				}
		}
	    
		public void InstructionPanelStopSound ()
		{
				if (isSoundOn)
						instructionPanelSoundRef.Stop ();
		}

		//---------------------------------------------------------------------------------------------//

		//Write Your Methods Here

		//Bubble Tap
		public void BubbleTapPlaySound ()
		{
				if (isSoundOn) {
						bubbleTapSoundRef.Play ();
				}
		}

		//----------------------------------------------------------------------------------------------//

		//Sound On/Off Button
		public void SoundOnOff ()
		{
				if (PlayerPrefs.GetInt ("SoundState") == 0) {
						PlayerPrefs.SetInt ("SoundState", 1);
				} else {
						PlayerPrefs.SetInt ("SoundState", 0);
				}
		
		}


}