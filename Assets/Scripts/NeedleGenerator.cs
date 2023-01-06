using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleGenerator : MonoBehaviour
{
    public bool shouldSpawn = false;
    public Camera cam;
    public Vector3 startPosition;// = new Vector3(0, 0, 0);
    public Quaternion startRotation = new Quaternion(-90.0f, 0.0f, 0.0f, 1);
    private Vector3 positionOffset = new Vector3(0.0f, -0.8238f, -0.068f);
    public GameObject[] trackerHolder;
    public string data;
    //public GameObject testNeedle;
    GameObject need;
    //  public float angle = Quaternion.Angle(transform.rotation, target.rotation);
    // Start is called before the first frame update
    void Start()
    {
        //GenNeedle(testNeedle);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GenNeedle(GameObject needle)
    {
        //destroyNeedle();
        trackerHolder = GameObject.FindGameObjectsWithTag("QRSquare");
        data = (((GameObject.FindGameObjectsWithTag("Text"))[0]).GetComponent<TextMesh>()).text;

        startPosition = trackerHolder[0].transform.position;
        startRotation = trackerHolder[0].transform.rotation;
        need = Instantiate(needle, startPosition, startRotation);// Quaternion.identity);
        need.transform.parent = trackerHolder[0].transform;
        //need.transform.localPosition += new Vector3(0.0f, -0.238f, -0.068f); 
        // need.transform.position += need.transform.right*0.0f + need.transform.up* -0.238f + need.transform.forward * -0.068f;
        if(data.Equals("ABC")){
            //Middle QR Code offset
            need.transform.localPosition = positionOffset;
            need.transform.localPosition += new Vector3(-0.045f, 0, 9.75f);
        }
        else if (data.Equals("DEF"))
        {
            //Right side
            need.transform.localPosition = positionOffset;
            need.transform.localPosition += new Vector3(1.7f, 0, 3.5714f);
        }
        else if (data.Equals("GHI"))
        {
            //left side
            need.transform.localPosition = positionOffset;
            need.transform.localPosition += new Vector3(-1.7f, 0, 3.5714f);
        }
        else
        {
            need.transform.localPosition = positionOffset;
        }


        //need.transform.rotation = startRotation * trackerHolder[0].gameObject.transform.rotation * new Quaternion(180.0f, 0.0f, 0.0f, 1);

        Debug.Log(trackerHolder[0].gameObject.transform.rotation);
        //  need.transform.localRotation = need.transform.rotation * trackerHolder[0].gameObject.transform.rotation;
        need.transform.parent = null;
    }
    public void destroyNeedle()
    {
        // Create an array of all needle objects in the application
        // Every object with the tag "needle" will be added to the array, this will come in handy if you end up having multiple needles
        // You can also alternatively give different length needles different tags, and have the voice command activate based on those
        GameObject[] needle = GameObject.FindGameObjectsWithTag("Needle");

        // Loop through the array and destroy each needle in the array
        // This is a foreach loop, the commands in the parenthesis read as "For each GameObject in the needle array, set a temporary variable named "n"... 
        foreach (GameObject n in needle)
        {
            // Take that temporary variable "n" and destroy it
            Destroy(n, 0.0f);
        }
        // After the loop completes, all objects with the tag needle are destroyed
    }

    public void destroyLastNeedle()
    {
        GameObject[] needle = GameObject.FindGameObjectsWithTag("Needle");

        if(needle.Length > 0) {
            Destroy(needle[needle.Length - 1], 0.0f);
        }

    }
}
