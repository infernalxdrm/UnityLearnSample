using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : SampleScript
{
    private bool startProgramm;
    [SerializeField] private Transform beginPosition;
    public Vector3 endPosition = new Vector3(0, 0, 0);
    [SerializeField] [Min(0)] public float speed = 0;

    private void Awake()
    {
        beginPosition = this.transform;
    }

    [ContextMenu("Запуск программы Move")]
    override public void Use()
    {
        beginPosition = this.transform;
        startProgramm = true;
    }

    void Update()
    {
        if (startProgramm)
        {
            Vector3 directionMove = endPosition - beginPosition.position;
            if (directionMove.magnitude > 0.1f)
            {
                beginPosition.forward = directionMove;
                beginPosition.position += directionMove * Time.deltaTime * speed ;
            }
        }
    }
}