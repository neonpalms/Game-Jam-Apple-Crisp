using UnityEngine;

public class MusicPlayerScript : MonoBehaviour
{
    #region Methods
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    #endregion
}
