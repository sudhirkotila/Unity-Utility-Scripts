using UnityEngine;
using System.Collections;

public class mailProduction : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void SendEmail ()
	{

		string email = "whatthefuck@gmail.com";
		string subject = MyEscapeURL("Inquery For Production");
		string body = MyEscapeURL("Tripada Biotech Pvt Ltd");

		Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
	}

	string MyEscapeURL (string url)
	{
		return WWW.EscapeURL(url).Replace("+","%20");
	}
}