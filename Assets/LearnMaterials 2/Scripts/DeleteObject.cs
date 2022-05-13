using System.Collections;
using UnityEngine;

public class DeleteObject : SampleScript
{
    [SerializeField]
    [Min(0.1f)]
    private float shrinkSpeed;
    [SerializeField]
    private GameObject target;

    [ContextMenu("Use")]
    public override void Use()
    {
        StartCoroutine(ShrinkAndDelete());
    }

    private IEnumerator ShrinkAndDelete()
    {
        while (transform.childCount > 0)
        {
            Transform c = transform.GetChild(0);
            Debug.Log(c.name);

            while (c.localScale.x > 0)
            {
                c.localScale -= new Vector3(shrinkSpeed, shrinkSpeed, shrinkSpeed) * Time.deltaTime;
                yield return null;
            }

            Destroy(c.gameObject);
            yield return null;
        }
    }
}