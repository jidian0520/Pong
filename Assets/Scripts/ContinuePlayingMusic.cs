using UnityEngine;

public class ContinuePlayingMusic : MonoBehaviour
{
    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }
}
