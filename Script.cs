using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchObject : MonoBehaviour
{
    TouchPhase touchPhase = TouchPhase.Ended;

	public GameObject city;
	public GameObject state;
	public GameObject location;

	public GameObject birlaMandir;
	public GameObject havaMehal;
	public GameObject jalMahal;
	public GameObject jantarMantar;
	public GameObject jaigarh;

	/// <summary>
	/// Visted
	/// </summary>
	public float birlaMandir_Time;
	public float havaMehal_Time;
	public float jalMahal_Time;
	public float jantarMantar_Time;
	public float jaigarh_Time;

	public bool birlaMandir_Visited;
	public bool havaMehal_Visited;
	public bool jalMahal_Visited;
	public bool jantarMantar_Visited;
	public bool jaigarh_Visited;

	private float timeCounter = 0;

	public GameObject reviewPanel;
	public string reviewString;
	public string reviewTotalTime;
	public Text reviewDetail;

	public GameObject warningPanel;


	public AudioSource music;

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0 && Input.touchCount < 2)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    checkTouch(Input.GetTouch(0).position);
                }
            }
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                checkTouch(Input.mousePosition);
            }
        }
    }

    private void checkTouch(Vector3 pos)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000.0f))
        {
			switch (hit.transform.name) 
			{
			case  "JaipurBtn":
				state.SetActive (false);
				city.SetActive (true);
				location.SetActive (false);

				music.Play ();
				break;
				case "Birla Mandir":
				birlaMandir.SetActive (true);
				birlaMandir.GetComponent<ScaleModel> ().enabled = true;

				city.SetActive (false);
				break;
			case "Jal Mahal":
				jalMahal.SetActive (true);
				jalMahal.GetComponent<ScaleModel> ().enabled = true;

				city.SetActive (false);
				break;
			case  "Jantar Mantar":
				jantarMantar.SetActive (true);
				jantarMantar.GetComponent<ScaleModel> ().enabled = true;

				city.SetActive (false);
				break;
			case "Hava Mehal":
				havaMehal.SetActive (true);
				havaMehal.GetComponent<ScaleModel> ().enabled = true;

				city.SetActive (false);
				break;
			case "cannon":
				jaigarh.SetActive (true);
				jaigarh.GetComponent<ScaleModel> ().enabled = true;

				city.SetActive (false);
				break;
				/// <summary>
				/// Visted
				/// </summary>
				/// 
			case  "Jal Mahal Visited":
				PlanMyVisit ("jalMahal");
				break;
			case  "Hawa Mahal Visited":
				PlanMyVisit ("havaMehal");
				break;
			case  "Jaigarh Fort Visited":
				PlanMyVisit ("jaigarh");
				break;
			case  "Birla Mandir Visited":
				PlanMyVisit ("birlaMandir");
				break;
			case  "Jantar Mantar Visited":
				PlanMyVisit ("jantarMantar");
				break;
			}
        }
    }

	public void PlanMyVisit(string modelName)
	{
		switch (modelName)
		{
		case "birlaMandir":
			if (birlaMandir_Visited)
			{
				warningPanel.SetActive(true);
				return;
			}
			timeCounter += birlaMandir_Time;
			reviewString += "Birla Mandir " + birlaMandir_Time+" Hrs \n";
			birlaMandir_Visited = true;
			break;
		case "havaMehal":
			if (havaMehal_Visited) {
				warningPanel.SetActive (true);
				return;
			} else {
				timeCounter += havaMehal_Time;
				reviewString += "Hawa Mahal " + havaMehal_Time + " Hrs \n";
				havaMehal_Visited = true;
			}

			break;
		case "jalMahal":
			if (jalMahal_Visited) {
				warningPanel.SetActive (true);
				return;
			} else {
				timeCounter += jalMahal_Time;
				reviewString += "Jal Mahal " + jalMahal_Time + " Hrs \n";
				jalMahal_Visited = true;
			}

			break;
		case "jantarMantar":
			if (jantarMantar_Visited) {
				warningPanel.SetActive (true);
				return;
			} else {
				timeCounter += jantarMantar_Time;
				reviewString += "Jantar Mantar " + jantarMantar_Time + " Hrs \n";
				jantarMantar_Visited = true;
			}

			break;
		case "jaigarh":
			if (jaigarh_Visited) {
				warningPanel.SetActive (true);
				return;
			} else {
				timeCounter += jaigarh_Time;
				reviewString += "Jaigarh Fort " + jaigarh_Time + " Hrs \n";
				jaigarh_Visited = true;
			}

			break;
		}
	}

	public void ReviewMyVisites()
	{
		reviewDetail.text = "";
		reviewPanel.SetActive(true);
		reviewDetail.text = reviewString + "\n"+"<b> Total Time "+ timeCounter + " Hrs </b>" ;
	}
}
