using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapDrawControl : MonoBehaviour
{
    public GameObject linePrefab;

    MapLineControl activeLine;

    public Camera mapCamera;
    public LayerMask mapLayer;

    GameObject mapParent;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) //debug
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f;
            mousePos = mapCamera.ScreenToWorldPoint(mousePos);
             
            Debug.DrawRay(mapCamera.gameObject.transform.position,
                mousePos - mapCamera.gameObject.transform.position, Color.red);
        }

        if (Input.GetMouseButtonDown(0))
        {
            
            Ray r = mapCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(r, out hit, 100, mapLayer))
            {
                Debug.Log("maphit");
                GameObject newLine = Instantiate(linePrefab);
                activeLine = newLine.GetComponent<MapLineControl>();
                mapParent = hit.collider.gameObject;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {

            if (mapParent != null)
            {
                activeLine.gameObject.transform.parent = mapParent.transform;
                activeLine.transform.Translate(0, 0, 0);
            }
            activeLine = null;

        }

        if (activeLine != null)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 100f;
            mousePos = mapCamera.ScreenToWorldPoint(mousePos);

            Ray r = mapCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(r, out hit, 100, mapLayer))
            {
                activeLine.UpdateLine(mousePos);
            }
            
        }

    }
}
