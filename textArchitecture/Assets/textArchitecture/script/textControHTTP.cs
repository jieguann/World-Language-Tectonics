using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;
using CI.HttpClient;
using System.Collections;
using UnityEngine.Rendering.PostProcessing;

public class textControHTTP : MonoBehaviour
{
    JSONNode items;
    public float ArchScale;
    public float ArchScaleY;
    public float textScale;
    // Start is called before the first frame update
    void Start()
    {
        ArchScale = 1f;
        ArchScaleY = 1f;
        textScale = 5f;
        StartCoroutine(ReadJsonHTTP());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator ReadJsonHTTP()
    {
        //yield return new WaitForSeconds(10f);
        //yield return new WaitForSeconds(1f);
        while (true)
        {
            //yield return new WaitForSeconds(1f);


            var client = new HttpClient();

            // Send the GET request to the specified uri
            client.Get(new System.Uri("https://websocket.jieguann.com/ArchScale"), HttpCompletionOption.AllResponseContent, r =>
            {
                // This callback is raised when the request completes
                if (r.IsSuccessStatusCode)
                {
                    
                    // Read the response content as a string if the server returned a success status code
                    items = JSON.Parse(r.ReadAsString());
                    //print(items["ArchScale"].AsFloat);
                    //{"ArchScale":90,"ArchScaleY":90,"textScale":90}
                    ArchScale = items["ArchScale"].AsFloat;
                    ArchScaleY = items["ArchScaleY"].AsFloat;
                    textScale = items["textScale"].AsFloat;
                    //print(90f);
                }

            });
            yield return new WaitForSeconds(1f);
        }


    }
}
