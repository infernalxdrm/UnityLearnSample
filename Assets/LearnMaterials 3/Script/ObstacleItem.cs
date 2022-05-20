using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    [Header("Модуль урон")]
    [SerializeField] [Range(0,1)] private float currentValue;

    private Material mat;
    [SerializeField] private UnityEvent onDestroyObstacle;

    [ContextMenu("Нанести урон")]
    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        onDestroyObstacle.AddListener(() => Destroy(gameObject));
    }
    private void Update()
    {
        GeatDamage(Time.deltaTime);
    }

    void GeatDamage (float value)
    {
        currentValue -= value;
        if (currentValue < 0)
        {
            onDestroyObstacle.Invoke();
        }
        mat.color = Color.Lerp(Color.red, Color.white, currentValue);
    }

}
