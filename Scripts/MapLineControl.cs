using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MapLineControl : MonoBehaviour
{
    public LineRenderer mapLineRenderer;

    List<Vector2> points;

    public float pointStep;

    [SerializeField]
    LayerMask mapLayer;

    private void Update()
    {
      //  transform.position = new Vector3(0,0,0);
    }

    public void UpdateLine(Vector2 position)
    {

        if (points == null)
        {
            points = new List<Vector2>();
            SetPoint(position);
            return;
        }

        if (Vector2.Distance(points.Last(), position) > pointStep)
        {
            SetPoint(position);
        }

    }

    void SetPoint(Vector2 point)
    {
        points.Add(point);

        mapLineRenderer.positionCount = points.Count;
        mapLineRenderer.SetPosition(points.Count - 1, point);

    }
}
