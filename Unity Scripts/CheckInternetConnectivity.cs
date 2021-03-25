using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Net;
using System.IO;

public class CheckInternetConnectivity : MonoBehaviour
{
	//Instance
	public static CheckInternetConnectivity instance;

	//Message Text
	public Text msgText;

	// Use this for initialization
	void Start ()
	{
		instance=this;
	
		if (CheckInternetAvailability ()) {
			print ("Internet is Available...");
		} else {
			print ("Internet Not Available...Please Turn on...");
			msgText.text = "Opps...Internet Not Available" + System.Environment.NewLine + System.Environment.NewLine + "Please Turn On Internet Connectivity.";
		}
	}
	
	/// <summary>
	/// Checks the internet availability.
	/// </summary>
	public bool CheckInternetAvailability ()
	{
		string HtmlText = GetHtmlFromUri ("http://google.com");
		if (HtmlText == "") {
			//No connection
			GLOBALS.isInternetAvailable = false;
			return false;
			
		} else {
			//success
			GLOBALS.isInternetAvailable = true;
			return true;
		}
	}
	
	/// <summary>
	/// Gets the html from URI.
	/// </summary>
	/// <returns>The html from URI.</returns>
	/// <param name="resource">Resource.</param>
	private string GetHtmlFromUri (string resource)
	{
		string html = string.Empty;
		HttpWebRequest req = (HttpWebRequest)WebRequest.Create (resource);
		try {
			using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse()) {
				bool isSuccess = (int)resp.StatusCode < 299 && (int)resp.StatusCode >= 200;
				if (isSuccess) {
					using (StreamReader reader = new StreamReader(resp.GetResponseStream())) {
						//We are limiting the array to 80 so we don't have
						//to parse the entire html document feel free to 
						//adjust (probably stay under 300)
						char[] cs = new char[80];
						reader.Read (cs, 0, cs.Length);
						foreach (char ch in cs) {
							html += ch;
						}
					}
				}
			}
		} catch {
			return "";
		}
		return html;
	}
}
