
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;
using CI.HttpClient;
using System.Collections;
using UnityEngine.Rendering.PostProcessing;
using MegaFiers;
public class textVisulization : MonoBehaviour
{   //text control
    public textControHTTP textControl;
    /// <summary>
    /// /////
    /// </summary>
    public GameObject myPrefab;
    public GameObject effectPrefab;
    GameObject[] textObjects;
    public int resolution;
    public GameObject pathParent;
    public GameObject cameraObject;
    
    //public TextAsset jsonFile;
    //public string[] jsonArray;
    //public ListItem items;
    JSONNode items;

    //int index;
    public float architectureScale;
    public Slider ArchSliderScale;
    public float architectureScaleY;
    public Slider ArchSliderScaleY;
    public float textScale;
    public Slider textSliderScale;
    //text;
    TextMeshPro textmeshPro;
    MegaWorldPathDeform textmeshProMega;
    public MegaShape megaShape;
    public MegaShape megaShape1;
    public MegaShape megaShape2;
    public MegaShape megaShape3;
    public MegaShape megaShape4;
    public Vector3[] prefebPosition;
    public Quaternion[] prefebRotation;
    public Vector3[] prefebScale;
    //post effect
    public PostProcessVolume pVolume;
    // Start is called before the first frame update
    void Start()
    {
        //ArchSliderScale.value = 0.5f;
        //textSliderScale.value = 5f;
        pVolume.weight = 0;
        //Debug.Log(items["textDatas"]);
        //StartCoroutine(GetText());
        StartCoroutine(ReadJsonHTTP());
        StartCoroutine(initialText());
        StartCoroutine(newInstanceEffect());



        //Debug.Log(items["textDatas"]);
        //items = JsonUtility.FromJson<ListItem>(jsonFile.text);
        //print(json.items);

        /*
        textObjects = new GameObject[resolution];
        prefebPosition = new Vector3[resolution];
        prefebRotation = new Quaternion[resolution];
        prefebScale = new Vector3[resolution];
        for (int i = 0; i < resolution; i++)
        {
            GameObject textObject = textObjects[i] = Instantiate(myPrefab);
            textObjects[i].GetComponent<Transform>().SetParent(transform);
            prefebPosition[i] = new Vector3(0, 0, 0) * architectureScale;
            prefebRotation[i] = Quaternion.Euler(0, 0, 0);
            prefebScale[i] = new Vector3(0, 0, 0) * textScale;
            //prefebPosition = new Vector3[i](0, Random.Range(0f,1f), 0) * architectureScale;

            //prefebPosition[i]= new Vector3(0, Random.Range(0f, 1f), 0) * architectureScale;
            //prefebPosition[i] = new Vector3(0, Random.Range(0f, 1f), 0) * architectureScale;
            //Instantiate(myPrefab);
        }
        */

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
        //ReadJsonHTTP();
        architectureScale = ArchSliderScale.value;
        architectureScaleY = ArchSliderScaleY.value;
        textScale = textSliderScale.value;
        //architectureScale = textControl.ArchScale;
        //architectureScaleY = textControl.ArchScaleY;
        //textScale = textControl.textScale;
        if(pVolume.weight > 0)
        {
            pVolume.weight = pVolume.weight - 0.004f;
        }
        print(pVolume.weight);

    }

    IEnumerator ReadJsonHTTP()
    {
        while (true)
        {
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
            //Destroy(textObjects[resolution-1]);
            //resolution = items["textDatas"].Count;
            //print(items["textDatas"]);
            for (int i = 0; i < resolution; i++)
            {
                textmeshPro = textObjects[i].GetComponent<TextMeshPro>();
                
                if (items["textDatas"][i] != null)
                {
                    //print(items["textDatas"][0]["Input"]);
                    //textmeshPro.SetText(items["textDatas"][i]["Input"]);
                    textmeshPro.SetText(items["textDatas"][i]["randonText"]);
                    //textmeshPro.SetText(items["textDatas"][i]["originalText"]);
                    
                    prefebPosition[i] = new Vector3(items["textDatas"][i]["X"] * architectureScale, items["textDatas"][i]["Y"]* architectureScaleY, items["textDatas"][i]["Z"] * architectureScale);
                    prefebRotation[i] = Quaternion.Euler(0, items["textDatas"][i]["rY"] * 360f, 0);
                    prefebScale[i] = new Vector3(0.01f, 0.01f, 0.01f) * textScale;

                    //print(items["textDatas"][resolution]["Input"]);
                    textmeshProMega = textObjects[i].GetComponent<MegaWorldPathDeform>();
                    //textmeshProMega.path = megaShape;
                    textmeshProMega.percent = items["textDatas"][i]["X"] * 100f;
                    textmeshProMega.gizmoPos = new Vector3(items["textDatas"][i]["X"]*0.2f, items["textDatas"][i]["Y"]*0.3f, items["textDatas"][i]["Z"]*0.2f);
                    pathParent.transform.localPosition = new Vector3(0, architectureScaleY, 0);
                    pathParent.transform.localScale = new Vector3(architectureScale,architectureScale,architectureScale);
                    textmeshProMega.gizmoScale = new Vector3(textScale,textScale,textScale);


                }
                else
                {
                    textmeshPro.SetText("");
                }
                
               


                //textObjects[i].GetComponent<Transform>().localPosition = prefebPosition[i];
                //textObjects[i].GetComponent<Transform>().localPosition = prefebPosition[i];
                //textObjects[i].GetComponent<Transform>().localRotation = prefebRotation[i];
                //textObjects[i].GetComponent<Transform>().localScale = prefebScale[i];
                
                if (items["textDatas"][i]["Mood"] == 4)
                {
                    
                    textmeshPro.color = new Color32(167, 222, 95, 255);
                    textmeshProMega.path = megaShape4;
                }
                else if (items["textDatas"][i]["Mood"] == 3)
                {
                    textmeshPro.color = new Color32(245, 215, 66, 255);
                    textmeshProMega.path = megaShape3;

                }
                else if (items["textDatas"][i]["Mood"] == 2)
                {
                    textmeshPro.color = new Color32(240, 153, 72, 255);
                    textmeshProMega.path = megaShape2;
                }
                else if (items["textDatas"][i]["Mood"] == 1)
                {
                    textmeshPro.color = new Color32(255, 82, 82, 255);
                    textmeshProMega.path = megaShape1;
                }
                else if (items["textDatas"][i]["Mood"] == 0)
                {
                    textmeshPro.color = new Color32(115, 47, 47, 255);
                    textmeshProMega.path = megaShape;
                }
                else
                {
                    textmeshProMega.path = megaShape;
                }
            }


        }
    }

    IEnumerator initialText()
    {
        yield return items != null;
        //resolution = items["textDatas"].Count;
        textObjects = new GameObject[resolution];
        prefebPosition = new Vector3[resolution];
        prefebRotation = new Quaternion[resolution];
        prefebScale = new Vector3[resolution];
        for (int i = 0; i < resolution; i++)
        {
            GameObject textObject = textObjects[i] = Instantiate(myPrefab);
            textObjects[i].GetComponent<Transform>().SetParent(transform);



            prefebPosition[i] = new Vector3(0, 0, 0) * architectureScale;
            prefebRotation[i] = Quaternion.Euler(0, 0, 0);
            prefebScale[i] = new Vector3(0, 0, 0) * textScale;
            //prefebPosition = new Vector3[i](0, Random.Range(0f,1f), 0) * architectureScale;

            //prefebPosition[i]= new Vector3(0, Random.Range(0f, 1f), 0) * architectureScale;
            //prefebPosition[i] = new Vector3(0, Random.Range(0f, 1f), 0) * architectureScale;
            //Instantiate(myPrefab);
        }

    }

    public IEnumerator newInstanceEffect()
    {
        yield return new WaitForSeconds(0.1f);
        
        while (true)
        {
            int count = items["textDatas"].Count;
            //yield return count != items["textDatas"].Count;
            yield return new WaitUntil(() => count != items["textDatas"].Count);
            //prefebPosition[count] = new Vector3(items["textDatas"][count]["X"] * architectureScale, items["textDatas"][count]["Y"]* architectureScaleY, items["textDatas"][count]["Z"] * architectureScale);
            prefebPosition[count] = pathParent.transform.localPosition;
            prefebRotation[count] = Quaternion.Euler(0, items["textDatas"][count]["rY"] * 360f, 0);
            //prefebScale[count] = new Vector3(0.01f, 0.01f, 0.01f) * textScale;
            prefebScale[count] = new Vector3(1f, 1f, 1f)/3f;
            GameObject newTextObject = Instantiate(effectPrefab);newTextObject.GetComponent<Transform>().SetParent(transform);
            newTextObject.GetComponent<Transform>().SetParent(transform);
            newTextObject.transform.localPosition = prefebPosition[count];
            //newTextObject.transform.localRotation = prefebRotation[count];
            newTextObject.transform.localScale = prefebScale[count]; 
            
            newTextObject.GetComponent<TextMeshPro>().SetText(items["textDatas"][count]["randonText"]);
            newTextObject.GetComponent<TextMeshPro>().color = new Color32(255, 255, 255, 255);
            pVolume.weight = 1;
            newTextObject.layer = 6;
            print(pVolume.weight);
            //yield return new WaitForSeconds(0.1f);
            //pVolume.weight = pVolume.weight - 0.1f;
            yield return new WaitUntil(() => pVolume.weight <= 0);
            //pVolume.weight = 0;
            //pVolume.weight = 0;
            Destroy(newTextObject);
            /*
            yield return new WaitForSeconds(2f);
            pVolume.weight = 0.8f;
            yield return new WaitForSeconds(2f);
            pVolume.weight = 0.6f;
            yield return new WaitForSeconds(2f);
            pVolume.weight = 0.4f;
            yield return new WaitForSeconds(2f);
            pVolume.weight = 0.2f;
            yield return new WaitForSeconds(2f);
            pVolume.weight = 0;
            Destroy(newTextObject);
            */
            
        }
        

        /*
        GameObject newTextObject = Instantiate(effectPrefab);

        newTextObject.transform.position = prefebPosition[count];
        */
    }

 






        /*
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
        */

    }


