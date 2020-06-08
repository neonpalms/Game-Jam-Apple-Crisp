using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LevelNumberBehavior : MonoBehaviour
{
    // Simply put, this script, when attached to a Canvas Text object
    // will grab the Text component and set the text to the scene's buildIndex + 1
    // OR, to put it another way, the level number!
    void Awake()
    {
        GetComponent<Text>().text = (SceneManager.GetActiveScene().buildIndex + 1).ToString();
    }
}
