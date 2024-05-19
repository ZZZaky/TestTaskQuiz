using UnityEngine;

public class HomeScreenHandler : MonoBehaviour
{
    private GameObject EventSystem;

    void Start()
    {
        EventSystem = GameObject.FindWithTag("EventSystem");
    }
}
