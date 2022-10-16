using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class MPU9250 : MonoBehaviour
{
    SerialPort sp = new SerialPort("COM5", 19200);
    float gyroX, gyroY, gyroZ;

    // Use this for initialization
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1000;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        string data = sp.ReadLine();
        string[] temps = data.Split('|');

        gyroX = float.Parse(temps[0]);
        gyroY = 0f;
        gyroZ = float.Parse(temps[2]);

        transform.localEulerAngles = new Vector3(gyroX, gyroY, gyroZ);
        RotationOffset();
        Debug.Log(gyroX + " " + gyroY + " " + gyroZ);
    }

    private void OnApplicationQuit()
    {
        sp.Close();
    }

    private void RotationOffset()
    {


        if (transform.localEulerAngles.x > 15f)
        {
            transform.localEulerAngles = new Vector3(15f, gyroY, gyroZ);
        } 
        else if (transform.localEulerAngles.x < 15f)
        {
            transform.localEulerAngles = new Vector3(-15f, gyroY, gyroZ);
        }

        if (transform.localEulerAngles.z > 15f)
        {
            transform.localEulerAngles = new Vector3(gyroX, gyroY, 15f);
        }
        else if (transform.localEulerAngles.x < 15f)
        {
            transform.localEulerAngles = new Vector3(gyroX, gyroY, -15f);
        }
    }


}
