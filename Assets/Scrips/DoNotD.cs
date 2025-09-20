using UnityEngine;

public class DoNotD : MonoBehaviour
{
    public static DoNotD I { get; private set; }

    void Awake()
    {
        if (I != null) { Destroy(gameObject); return; }
        I = this;
        DontDestroyOnLoad(gameObject);
    }
}
