using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LevelTransitionBehavior : MonoBehaviour
{
    #region Fields
    [Range(0.0f, 1.0f)] public float alpha = 1.0f;
    [Range(0.0f, 1.0f)] public float value = 1.0f;
    #endregion

    #region Members
    Image m_MyImage;
    #endregion

    private void Awake()
    {
        m_MyImage = GetComponent<Image>();
        
        // For fun!
        RandomizeMyColor();

        // Set the text in this transition object to the next level's
        // build number.  Since the player would be transitioning to the
        // next level.
        GetComponentInChildren<Text>().text = "" + SceneManager.GetActiveScene().buildIndex + 2;
    }

    // When attached to something with an Image component, simply randomizes the
    // color property within certain constraints.
    private void RandomizeMyColor()
    {
        Color randomizedColor = Random.ColorHSV(0.0f, 1.0f, 0.0f, 1.0f, value, value);
        randomizedColor.a = alpha;
        m_MyImage.color = randomizedColor;
    }
}
