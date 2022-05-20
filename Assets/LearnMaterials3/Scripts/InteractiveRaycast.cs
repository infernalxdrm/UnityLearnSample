using UnityEngine;

public class InteractiveRaycast : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    private InteractiveBox clickedBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100.0f) && hit.collider.CompareTag("InteractivePlane"))
            {
                Instantiate(prefab, hit.point + Vector3.up, Quaternion.identity);
            }
            else if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit2, 100.0f) && hit2.collider.TryGetComponent<InteractiveBox>(out InteractiveBox box))
            {
                if (clickedBox == null)
                {
                    clickedBox = box;
                }
                else
                {
                    clickedBox.AddNext(box);
                    clickedBox = box;
                }
            }
        }
        else if(Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100.0f) &&
                hit.collider.TryGetComponent<InteractiveBox>(out InteractiveBox box))
            {
                Destroy(box.gameObject);
            }
        }
    }
}
