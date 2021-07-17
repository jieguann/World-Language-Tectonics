
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;
using CI.HttpClient;
using System.Collections;

public class textVisulization : MonoBehaviour
{
    public GameObject myPrefab;
    GameObject[] textObjects;
    public int resolution;
    
    //public TextAsset jsonFile;
    //public string[] jsonArray;
    //public ListItem items;
    JSONNode items;
    //int index;
    public float architectureScale;
    public Slider ArchSliderScale;
    public float textScale;
    public Slider textSliderScale;
    //text;
    TextMeshPro textmeshPro;
    public Vector3[] prefebPosition;
    public Quaternion[] prefebRotation;
    public Vector3[] prefebScale;
    // Start is called before the first frame update
    void Start()
    {
        ArchSliderScale.value = 0.5f;
        textSliderScale.value = 5f;
        //Debug.Log(items["textDatas"]);
        //StartCoroutine(GetText());
        StartCoroutine(ReadJsonHTTP());



        //Debug.Log(items["textDatas"]);
        //items = JsonUtility.FromJson<ListItem>(jsonFile.text);
        //print(json.items);
        textObjects = new GameObject[resolution];
        prefebPosition = new Vector3[resolution];
        prefebRotation = new Quaternion[resolution];
        prefebScale = new Vector3[resolution];
        for (int i = 0; i < resolution; i++)
        {
            GameObject textObject = textObjects[i] = Instantiate(myPrefab);
            textObjects[i].GetComponent<Transform>().SetParent(transform);
            prefebPosition[i] = new Vector3(0, 0, 0) * architectureScale;
            prefebRotation[i] = Quaternion.Euler(0,0,0);
            prefebScale[i] = new Vector3(0, 0, 0) * textScale;
            //prefebPosition = new Vector3[i](0, Random.Range(0f,1f), 0) * architectureScale;

            //prefebPosition[i]= new Vector3(0, Random.Range(0f, 1f), 0) * architectureScale;
            //prefebPosition[i] = new Vector3(0, Random.Range(0f, 1f), 0) * architectureScale;
            //Instantiate(myPrefab);
        }


            /*
            textObjects = new GameObject[items.textDatas.Length];
            for (int i = 0; i < items.textDatas.Length; i++)
            {
                //Debug.Log(items.textDatas[i].Input);
                //Vector3 prefebPosition = new Vector3(items.textDatas[i].X, items.textDatas[i].Y, items.textDatas[i].Z) * architectureScale;
                //Quaternion prefebRotation = Quaternion.Euler(items.textDatas[i].rX, items.textDatas[i].rY, items.textDatas[i].rZ);
                //Vector3 prefebScale = new Vector3(items.textDatas[i].sX, items.textDatas[i].sY, items.textDatas[i].sZ);


                GameObject textObject = textObjects[i] = Instantiate(myPrefab);
                textObjects[i].GetComponent<Transform>().SetParent(transform);
                //textObjects[i].GetComponent<Transform>().localPosition = prefebPosition;
                //textObjects[i].GetComponent<Transform>().localRotation = prefebRotation;
                //textObjects[i].GetComponent<Transform>().localScale = prefebScale;
                //Instantiate(myPrefab, prefebPosition, prefebRotation);

                
                textmeshPro.SetText(items.textDatas[i].Input);

                if (items.textDatas[i].Color == 4)
                {
                    textmeshPro.color = new Color32(245, 215, 66, 255);
                }
                else if (items.textDatas[i].Color == 3)
                {
                    textmeshPro.color = new Color32(240, 153, 72, 255);
                }
                else if (items.textDatas[i].Color == 2)
                {
                    textmeshPro.color = new Color32(167, 222, 95, 255);
                }
                else if (items.textDatas[i].Color == 1)
                {
                    textmeshPro.color = new Color32(255, 82, 82, 255);
                }
                else if (items.textDatas[i].Color == 0)
                {
                    textmeshPro.color = new Color32(115, 47, 47, 255);
                }




        }
             */

        }

    // Update is called once per frame
    void Update()
    {
        
        textVisualizer();
        ReadJsonHTTP();
        architectureScale = ArchSliderScale.value;
        textScale = textSliderScale.value;

    }

    IEnumerator ReadJsonHTTP()
    {
        while (true) {
            var client = new HttpClient();

            // Send the GET request to the specified uri
            client.Get(new System.Uri("http://68.183.206.206:8000/text.json"), HttpCompletionOption.AllResponseContent, r =>
            {
                // This callback is raised when the request completes
                if (r.IsSuccessStatusCode)
                {
                    // Read the response content as a string if the server returned a success status code
                    items = JSON.Parse(r.ReadAsString());
                    //print(items["textDatas"]);

                }

            });
            yield return new WaitForSeconds(0.5f);
        }

       
    }

    void textVisualizer()
    {
        if (items != null)
        {

            //print(items["textDatas"]);
            for (int i = 0; i < resolution; i++)
            {
                textmeshPro = textObjects[i].GetComponent<TextMeshPro>();
                if (items["textDatas"][i] != null)
                {
                    //print(items["textDatas"][0]["Input"]);
                    //textmeshPro.SetText(items["textDatas"][i]["Input"]);
                    textmeshPro.SetText(items["textDatas"][i]["Input"]);
                    prefebPosition[i] = new Vector3(items["textDatas"][i]["X"], items["textDatas"][i]["Y"], items["textDatas"][i]["Z"]) * architectureScale;
                    prefebRotation[i] = Quaternion.Euler(0, items["textDatas"][i]["rY"] * 360f, 0);
                    prefebScale[i] = new Vector3(0.01f, 0.01f, 0.01f) * textScale;
                    //print(items["textDatas"][resolution]["Input"]);


                }
                else
                {
                    textmeshPro.SetText("");
                }

                //textObjects[i].GetComponent<Transform>().localPosition = prefebPosition[i];
                textObjects[i].GetComponent<Transform>().localPosition = prefebPosition[i];
                textObjects[i].GetComponent<Transform>().localRotation = prefebRotation[i];
                textObjects[i].GetComponent<Transform>().localScale = prefebScale[i];

                if (items["textDatas"][i]["Mood"] == 4)
                {
                    textmeshPro.color = new Color32(245, 215, 66, 255);
                }
                else if (items["textDatas"][i]["Mood"] == 3)
                {
                    textmeshPro.color = new Color32(240, 153, 72, 255);
                }
                else if (items["textDatas"][i]["Mood"] == 2)
                {
                    textmeshPro.color = new Color32(167, 222, 95, 255);
                }
                else if (items["textDatas"][i]["Mood"] == 1)
                {
                    textmeshPro.color = new Color32(255, 82, 82, 255);
                }
                else if (items["textDatas"][i]["Mood"] == 0)
                {
                    textmeshPro.color = new Color32(115, 47, 47, 255);
                }
            }


        }
    }

 
    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://68.183.206.206:8000/text.json");
        yield return www.Send();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            //string itemsData = JsonUtility.ToJson(www.downloadHandler.text);
            // Show results as text
            items = JSON.Parse(www.downloadHandler.text);
            //Debug.Log(www.downloadHandler.text);
            Debug.Log(items["textDatas"][10]["Input"]);
            Debug.Log(items["textDatas"]);

            // Or retrieve results as binary data
            //byte[] results = www.downloadHandler.data;
        }
    }

}


