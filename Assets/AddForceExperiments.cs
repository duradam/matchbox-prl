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
    public float m_Thrust = 6000f;
    bool flaga = true;
    int t1 = DateTime.Now.Second;
    int t2 = DateTime.Now.Second;
        
    void Start()
    {
        _loggerText = Logger.GetComponent<Text>();
        InputSystem.EnableDevice(Accelerometer.current);
    }

    private void KickOffCube(float acceleration)
    {
        LogDebug("KickOffCube");
        cube.AddForce(Vector3.up * m_Thrust * acceleration);
        flaga = false;
    }

    void Update()
    {
        Vector3 acceleration = Accelerometer.current.acceleration.ReadValue();
        LogDebug($"acc.x={acceleration.x} acc.y={acceleration.y} acc.z={acceleration.z}");
        t2 = DateTime.Now.Second;
        if (cube.position.y<1 && Math.Abs(acceleration.y)  > .2f)
        {
            KickOffCube(acceleration.y);
            t1 = DateTime.Now.Second;
        }
    }

    private void LogDebug(string msg)
    {
        //_loggerText.text = DateTime.Now.ToString() + ": " + msg + _loggerText.text;
    }

}
