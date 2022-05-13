using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : SampleScript
{
    public List<SampleScript> container = new List<SampleScript>();

    [ContextMenu("Запуск менеджера скриптов")]
    public override void Use()
    {
        for (int i = 0; i < container.Count; i++)
        {
            container[i].Use();
        }
    }
}
