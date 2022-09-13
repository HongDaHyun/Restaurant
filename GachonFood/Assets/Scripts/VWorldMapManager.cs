using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class VWorldMapManager : MonoBehaviour
{

    public RawImage mapRawImage;

    [Header("¸Ê Á¤º¸ ÀÔ·Â")]
    public string strBaseURL = "";
    public string latitude = "";
    public string longitude = "";
    public int level;
    public int mapWidth;
    public int mapHeight;
    public string strAPIKey = "";


    // Start is called before the first frame update
    void Start()
    {
        mapRawImage = GetComponent<RawImage>();
        StartCoroutine(VWorldMapLoader());
    }

    IEnumerator VWorldMapLoader()
    {

        string str = strBaseURL + strAPIKey + "&" + "format=png" + "&basemap=GRAPHIC" + "&center=" + longitude + "," + latitude + "&size=" + mapWidth + "," + mapHeight + "&zoom=" + level;

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(str);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
        }
        else
        {
            mapRawImage.texture = DownloadHandlerTexture.GetContent(request);
        }
    }

    private void Update()
    {
        
    }
}