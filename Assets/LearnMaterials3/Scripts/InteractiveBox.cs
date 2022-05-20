using UnityEngine;

public class InteractiveBox : MonoBehaviour
{
    private InteractiveBox next;
    // Start is called before the first frame update
    void Start()
    {
        next = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (next == null) return;
        Debug.DrawRay(transform.position, next.transform.position - transform.position, Color.red);
    }

    public void AddNext(InteractiveBox next)
    {
        this.next = next;
    }
}
