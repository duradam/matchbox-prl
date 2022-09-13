using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

//using Gyroscope = UnityEngine.InputSystem.Gyroscope;

public class AddForceExperiments : MonoBehaviour
{
    public GameObject Logger;
    private Text _loggerText;
    public Rigidbody cube;
    public float m_Thrust = 4000f;
    bool flaga = true;
    int t1 = DateTime.Now.Second;
    int t2 = DateTime.Now.Second;
        
    void Start()
    {
        _loggerText = Logger.GetComponent<Text>();
        LogDebug("start");
        InputSystem.EnableDevice(Accelerometer.current);
    }

    private void KickOffCube()
    {
        Debug.Log("KickOffCube");
        LogDebug("KickOffCube");

        cube.AddForce(Vector3.up * m_Thrust);
        flaga = false;
    }

    void Update()
    {
        Vector3 acceleration = Accelerometer.current.acceleration.ReadValue();
        Debug.Log($"acc.x={acceleration.x} acc.y={acceleration.y} acc.z={acceleration.z}");
        t2 = DateTime.Now.Second;
        if (Math.Abs(t2 - t1) >= 3
            && (Math.Abs(acceleration.x) + Math.Abs(acceleration.y) + Math.Abs(acceleration.z)) > 2)
        {
            KickOffCube();
            t1 = DateTime.Now.Second;
        }
    }

    private void LogDebug(string msg)
    {
        _loggerText.text = Environment.NewLine + DateTime.Now.ToString() + ": " + msg + _loggerText.text;
    }

}
