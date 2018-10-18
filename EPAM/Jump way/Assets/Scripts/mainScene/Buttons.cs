using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public Sprite music_on, music_off;

    void Start()
    {
        if (gameObject.name == "Settings")
        {
            if (PlayerPrefs.GetString("Music") == "off")
            {
                transform.GetChild(0).gameObject.GetComponent<Image>().sprite = music_off;
                Camera.main.GetComponent<AudioListener>().enabled = false;
            }
        }
    }

	void OnMouseDown ()
    {
        transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);
    }

    void OnMouseUp()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    void OnMouseUpAsButton()
    {
        GetComponent<AudioSource>().Play();
        switch (gameObject.name)
        {
            case "Restart":
                SceneManager.LoadScene("main");
                break;
            case "Facebook":
                Application.OpenURL("https://facebook.com");
                break;
            case "Twitter":
                Application.OpenURL("https://twitter.com");
                break;
            case "Google+":
                Application.OpenURL("https://google.com");
                break;
            case "Settings":
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(!transform.GetChild(i).gameObject.activeSelf);
                }
                break;
            case "Music":
                if (PlayerPrefs.GetString("Music") == "off")
                {
                    GetComponent<Image>().sprite = music_on;
                    PlayerPrefs.SetString("Music", "on");
                    Camera.main.GetComponent<AudioListener>().enabled = true;
                }
                else
                {
                    GetComponent<Image>().sprite = music_off;
                    PlayerPrefs.SetString("Music", "off");
                    Camera.main.GetComponent<AudioListener>().enabled = false;
                }
                break;
        }
    }
}
