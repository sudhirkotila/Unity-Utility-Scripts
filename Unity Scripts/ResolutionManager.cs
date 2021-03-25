using UnityEngine;
using System.Collections;

public class ResolutionManager : MonoBehaviour
{

		public static ResolutionManager instance;
		public GameObject UIRootPanel, GamePanel,PausePanel;
		public GameObject BG, PauseBtn;
		public tk2dTextMesh resoText;

		void OnEnable ()
		{

				instance = this;
				resoText.text = "Width:" + Screen.width + " Height:" + Screen.height;
					
				if (Screen.width == 1024 || Screen.width == 2048) { //iPAD 1024*768 OR 2048*1536
						UIRootPanel.transform.localScale = new Vector3 (1, 1, 1);
						GamePanel.transform.localScale = new Vector3 (1, 1, 1);
						BG.transform.localScale = new Vector3(1,1.3f,1);
						PauseBtn.transform.localScale = new Vector3(1,1,1);
						PausePanel.transform.localScale = new Vector3(1,1,1);
				} else if (Screen.width == 960) { //iPOD & iPHONE 960*640
						UIRootPanel.transform.localScale = new Vector3 (1, 1.05f, 1);
						GamePanel.transform.localScale = new Vector3 (1, 1.05f, 1);
						PauseBtn.transform.localScale=new Vector3(1.3f,1.3f,1.3f);
						PausePanel.transform.localScale = new Vector3(1.2f,1.2f,1.2f);
				} else if (Screen.width == 1136) { //iPOD & iPHONE 1136*940
						UIRootPanel.transform.localScale = new Vector3 (0.85f, 1f, 1);
						GamePanel.transform.localScale = new Vector3 (0.85f, 1f, 1);
						BG.transform.localScale = new Vector3(1.2f,1.3f,1);
						PauseBtn.transform.localScale=new Vector3(1.4f,1.4f,1.4f);
						PausePanel.transform.localScale = new Vector3(1.2f,1.2f,1.2f);
				}
		}
}
