using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LootLocker.Requests;
using System;
using TMPro;

public class menuscr : MonoBehaviour
{

    public GameObject props;
    
    public Camera cam;
    public Vector3 campos;
    public Vector3 camrot;
    public int ID;
    public TextMeshProUGUI sheet;
    

    // Start is called before the first frame update
    void Start()
    {
        campos = new Vector3(-34.05f, 61.1f, -41.26f);
        camrot = new Vector3(59.877f, 357.6f, 1f);
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

    // Update is called once per frame
    void FixedUpdate()
    {
        props.transform.eulerAngles += new Vector3(0, 0.2f, 0);
        cam.transform.position = new Vector3(Mathf.Lerp(cam.transform.position.x, campos.x, 0.06f), Mathf.Lerp(cam.transform.position.y, campos.y, 0.06f), Mathf.Lerp(cam.transform.position.z, campos.z, 0.06f));
        cam.transform.eulerAngles = new Vector3(Mathf.Lerp(cam.transform.eulerAngles.x, camrot.x, 0.06f), Mathf.Lerp(cam.transform.eulerAngles.y, camrot.y, 0.06f), Mathf.Lerp(cam.transform.eulerAngles.z, camrot.z, 0.06f));



    }

    public void begin()
    {

        SceneManager.LoadScene(1);
    }
    public void tut()
    {
        campos = new Vector3(-22.5f, 22f, -11.1f);
        camrot = new Vector3(85.106f, 2.426f, 275.626f);
    }
    public void high()
    {
        campos = new Vector3(-22.5f, 22f, -11.1f);
        camrot = new Vector3(85.106f, 2.426f, 275.626f);

        string leadstring = "";

        LootLockerSDKManager.GetScoreList(ID, 10,0, (response) =>
        {
            if (response.success)
            {


                int counter = 1;
                LootLockerLeaderboardMember[] members = response.items;
                for (int i = 0; i < members.Length; i++)
                {
                    if(members[i].member_id != "")
                    {

                        int score = members[i].score;
                        TimeSpan t = TimeSpan.FromMilliseconds(score * 10);
                        string answer = string.Format("{0:D2}:{1:D2}:{2:D3}",
                                                t.Minutes,
                                                t.Seconds,
                                                t.Milliseconds);



                        leadstring += counter + ". " + members[i].member_id + " " + answer + "\n";
                    }
                    counter++;


                }
                sheet.text = leadstring;


            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }
    
    public void back()
    {
        campos = new Vector3(-34.05f, 61.1f, -41.26f);
        camrot = new Vector3(59.877f, 357.6f, 1f);
    }

    public void quitgame()
    {
        Application.Quit();
    }
}
