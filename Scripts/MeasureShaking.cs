using UnityEngine;
using System.Collections;

public class MeasureShaking : MonoBehaviour
{
    public float avrgTime = 0.5f;
    public float peakLevel = 0.6f;
    public float endCountTime = 0.6f;
    public int shakeDir;
    public int shakeCount;

    Vector3 avrgAcc = Vector3.zero;
    int countPos;
    int countNeg;
    int lastPeak;
    int firstPeak;
    bool counting;
    float timer;

    bool ShakeDetector()
    {

        Vector3 curAcc = Input.acceleration;

        avrgAcc = Vector3.Lerp(avrgAcc, curAcc, avrgTime * Time.deltaTime);

        curAcc -= avrgAcc;

        int peak = 0;

        if (curAcc.y > peakLevel)
        {
            peak = 1;
        }
        if (curAcc.y < -peakLevel)
        {
            peak = -1;
        }

        if (peak == lastPeak)
        {
            return false;
        }

        lastPeak = peak;

        if (peak != 0)
        {
            timer = 0;

            if (peak > 0)
            {
                countPos++;
            }
            else
            {
                countNeg++;
            }

            if (!counting)
            {
                counting = true;
                firstPeak = peak;
            }
        }
        else if (counting)
        {
            timer += Time.deltaTime;
            if (timer > endCountTime)
            {
                counting = false;
                shakeDir = firstPeak;
                if (countPos > countNeg)
                {
                    shakeCount = countPos;
                }
                else
                {
                    shakeCount = countNeg;
                }

                countPos = 0;
                countNeg = 0;
                return true;
            }
        }
        return false;
    }

    void Update()
    {
        //Debug.Log(counting);
        if (ShakeDetector())
        { // call ShakeDetector every Update!
          // the device was shaken up and the count is in shakeCount
          // the direction of the first shake is in shakeDir (1 or -1)
        }
        // the variable counting tells when the device is being shaken:
        if (counting)
        {
            GameObject go = GameObject.Find("Hazard_Type_1");
            Destroy(go);

            //Debug.Log("Shaking up device");
            counting = false;
        }
    }
}