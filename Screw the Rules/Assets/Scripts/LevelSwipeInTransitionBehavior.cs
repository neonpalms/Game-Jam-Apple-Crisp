using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LevelSwipeInTransitionBehavior : MonoBehaviour
{
    #region Fields
    public float swipeDuration = 1.0f;
    public float delay = 0.0f;
    [Range(0.0f, 1.0f)] public float randomizedColorBaseAlpha = 1.0f;
    [Range(0.0f, 1.0f)] public float randomizedColorBaseValue = 0.75f;

    [HideInInspector] public bool winConditionMet = false;
    #endregion

    #region Members
    private Image m_MyImage;
    #endregion

    #region Methods
    private void Awake()
    {
        m_MyImage = GetComponent<Image>();

        // For fun!
        //RandomizeMyColor();

        // Set the text in this transition object to the next level's
        // build number.  Since the player would be transitioning to the
        // next level.
        GetComponentInChildren<Text>().text = (SceneManager.GetActiveScene().buildIndex + 2).ToString();
    }

    private void Update()
    {
        if (winConditionMet)
            SwipeIn();
    }

    // This is the method call to move toward center screen.
    private void SwipeIn()
    {
        LeanTween.moveLocal(gameObject, Vector2.zero, swipeDuration).setDelay(delay).setEaseOutCubic().setOnComplete(LoadNextScene);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // When attached to something with an Image component, simply randomizes the
    // color property within certain constraints.
    private void RandomizeMyColor()
    {
        Color randomizedColor = UnityEngine.Random.ColorHSV(0.0f, 1.0f, 0.0f, 1.0f, randomizedColorBaseValue, randomizedColorBaseValue);
        randomizedColor.a = randomizedColorBaseAlpha;
        m_MyImage.color = randomizedColor;
    }
    #endregion
}
