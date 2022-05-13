using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : SampleScript
{
    private bool startProgramm;
    public float speed = 0;
    private float xAngle;
    private float yAngle;
    private float zAngle;
    public float xRotate;
    public float yRotate;
    public float zRotate;
    public Transform beginRotation;

    private void Awake()
    {
        beginRotation = this.transform;
    }

    [ContextMenu("Запуск программы Rotation")]
    override public void Use()
    {
        beginRotation = this.transform;
        startProgramm = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (startProgramm)
        {
            if (xAngle < xRotate) { xAngle += Time.deltaTime * speed; }
            if (yAngle < yRotate) { yAngle += Time.deltaTime * speed; }
            if (zAngle < zRotate) { zAngle += Time.deltaTime * speed; }
            transform.rotation = Quaternion.Euler(xAngle, yAngle, zAngle);
        }
    }
}
