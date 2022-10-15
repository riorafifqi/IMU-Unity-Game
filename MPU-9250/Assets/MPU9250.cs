using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class MPU9250 : MonoBehaviour
{
    SerialPort sp = new SerialPort("COM5", 9600);
    float gyroX, gyroY, gyroZ;

    // Use this for initialization
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        string data = sp.ReadLine();
        string[] temps = data.Split('|');

        gyroX = float.Parse(temps[0]);
        gyroY = float.Parse(temps[1]);
        gyroZ = float.Parse(temps[2]);

        transform.eulerAngles = new Vector3(gyroX, gyroY, gyroZ);

        Debug.Log(gyroX + " " + gyroY + " " + gyroZ);

        /*try
        {
            print(sp.ReadLine());
        }
        catch (System.Exception)
        {
        }*/
    }

    
}
