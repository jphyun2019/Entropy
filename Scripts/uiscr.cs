
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using LootLocker.Requests;
using UnityEngine.SceneManagement;


public class uiscr : MonoBehaviour
{

    public RawImage currentFace;
    public RawImage currentLogo;
    public RawImage sideFace;
    public RawImage sideLogo;


    public Texture[] faces;
    public Texture[] logos;
    public string[] texas;

    public TextMeshProUGUI tex;
    public TextMeshProUGUI placetext;
    public int placeholder;

    public TextMeshProUGUI timer;
    public TextMeshProUGUI board;

    public TMP_InputField input;
    public int ID;
    public Player player;
    public GameObject inpu;
    public GameObject done;
    public TextMeshProUGUI laper;

    private void Start()
    {
        currentFace.color = new Color(0, 0, 0, 0);

        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");

            }
            else
            {
                Debug.Log("Failed");
            }
        });

    }

    public void setFace(int x)
    {
        sideFace.color = new Color(0, 0, 0, 0);
        sideLogo.color = new Color(0, 0, 0, 0);
        currentFace.color = new Color(1, 1, 1, 1);
        currentLogo.color = new Color(1, 1, 1, 1);
        currentFace.texture = faces[x];
        currentLogo.texture = logos[x];
        tex.text = texas[x];
        placetext.text = placeholder.ToString();


    }

    public void setSide(int x)
    {
        currentFace.color = new Color(0, 0, 0, 0);
        currentLogo.color = new Color(0, 0, 0, 0);
        sideFace.color = new Color(1, 1, 1, 1);
        sideLogo.color = new Color(1, 1, 1, 1);
        sideFace.texture = faces[x];
        sideLogo.texture = logos[x];
    }


    public void setText(string x)
    {
        tex.text = x;
    }
    public void setPlaceText(string x)
    {
        placetext.text = x;
    }



    public void finish()
    {
        string name = input.text;

        LootLockerSDKManager.SubmitScore(name, player.finaltime, ID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");

            }
            else
            {
                Debug.Log("Failed");
            }
        });

        SceneManager.LoadScene(0);



    }


}
