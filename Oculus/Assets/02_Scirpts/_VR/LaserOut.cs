using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserOut : MonoBehaviour
{
    public GameObject lineAxis;
    public GameObject line;


    public GameObject hitObject;
    private float maxDistance = 1000.0f;
    public Material laserMat;
    [SerializeField]
    private float dist;


    // Start is called before the first frame update
    void Start()
    {
        lineAxis = new GameObject();
        lineAxis.name = "LineAxis";
        lineAxis.transform.parent = transform;
        line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        line.transform.localPosition = transform.localPosition;
        line.transform.localScale = new Vector3(0.01f, 0.5f, 0.01f);
        line.transform.parent = lineAxis.transform;
        line.transform.rotation = Quaternion.Euler(90.0f, 0, 0);
        line.transform.localPosition = new Vector3(line.transform.localPosition.x, line.transform.localPosition.y, line.transform.localPosition.z + line.transform.localScale.y);
        line.GetComponent<Renderer>().material = laserMat;
        line.GetComponent<CapsuleCollider>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        int layerMask = 1 << 9;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layerMask))
        {
            dist = Vector3.Distance(transform.position, hit.point);
            lineAxis.transform.localScale = new Vector3(lineAxis.transform.localScale.x, lineAxis.transform.localScale.y, dist);
            hitObject = hit.transform.gameObject;

            if (hit.transform.GetComponent<RaycastButton>())
            {
                hit.transform.GetComponent<RaycastButton>().RaycastButtonOn();
            }
        }
        else
        {
            lineAxis.transform.localScale = new Vector3(lineAxis.transform.localScale.x, lineAxis.transform.localScale.y, maxDistance);
        }

        check();

    }

    void check()
    {
        if (hitObject != null)
        {
            switch (hitObject.name)
            {
                case "Game_Start":
                    if (OVRInput.GetDown(OVRInput.Button.One))
                    {
                        SceneManager.LoadScene("Test");
                    }
                    break;

            }
        }
    }
}
