using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LevelSwipeOutTransitionBehavior : MonoBehaviour
{
    #region Fields
    public float swipeDuration = 1.0f;
    public float delay = 1.0f;
    [Range(0.0f, 1.0f)] public float randomizedColorBaseAlpha = 1.0f;
    [Range(0.0f, 1.0f)] public float randomizedColorBaseValue = 0.75f;
    #endregion

    #region Members
    private Image m_MyImage;
    #endregion

    private void Awake()
    {
        m_MyImage = GetComponent<Image>();

        // For fun!
        //RandomizeMyColor();

        // We're picking up from the last scene, so be sure to
        // set the level text to the current level number.
        GetComponentInChildren<Text>().text = (SceneManager.GetActiveScene().buildIndex + 1).ToString();

        SwipeOut();
    }

    private void SwipeOut()
    {
        LeanTween.moveLocal(gameObject, new Vector2(-2000, 0), swipeDuration).setDelay(delay).setEaseInCubic().setDestroyOnComplete(true);
    }

    // When attached to something with an Image component, simply randomizes the
    // color property within certain constraints.
    private void RandomizeMyColor()
    {
        Color randomizedColor = Random.ColorHSV(0.0f, 1.0f, 0.0f, 1.0f, randomizedColorBaseValue, randomizedColorBaseValue);
        randomizedColor.a = randomizedColorBaseAlpha;
        m_MyImage.color = randomizedColor;
    }
}
