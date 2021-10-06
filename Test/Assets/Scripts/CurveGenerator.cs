using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveGenerator : MonoBehaviour
{
    public float a;
    public float b;
    public float c;

    public float x;
    private float incrementer = 0.01f;

    private LineRenderer lineREnderer;

    void Start()
    {
        Debug.Log("Equation is y = ax2 + bx + c");

        lineREnderer = GetComponent<LineRenderer>();

        List<Vector3> positions = GetCurvePoints();
        lineREnderer.positionCount = positions.Count;
        lineREnderer.SetPositions(positions.ToArray());
    }

    private List<Vector3> GetCurvePoints()
    {
        List<Vector3> positions = new List<Vector3>();
        float xValue = -x;

        do
        {
            Vector3 newPos = new Vector3(xValue, GetYValue(xValue), 0);
            positions.Add(newPos);

            xValue += incrementer;

        } while (xValue <= x);

        return positions;
    }

    private float GetYValue(float xValue)
    {
        float y = (a * (xValue * xValue)) + (b * xValue) + c;
        return y;
    }
}
