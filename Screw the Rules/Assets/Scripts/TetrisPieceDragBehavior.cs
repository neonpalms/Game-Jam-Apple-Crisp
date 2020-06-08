using UnityEngine;
using UnityEngine.Events;

public class TetrisPieceDragBehavior : MonoBehaviour
{
    #region Fields
    public float incrementSnap = 1.0f;

    public UnityEvent onDrop;
    #endregion

    #region Methods
    private void Awake()
    {
        if (onDrop == null)
            onDrop = new UnityEvent();
    }

    private void OnMouseDrag()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = 0;
        transform.position = newPos;
    }

    private void OnMouseUp()
    {
        float xPos = transform.position.x, yPos = transform.position.y;
        Vector2 snappedPosition = new Vector2(RoundToNearestMultiple(xPos, incrementSnap), RoundToNearestMultiple(yPos, incrementSnap));
        transform.position = snappedPosition;
        onDrop.Invoke();
    }

    private float RoundToNearestMultiple(float numberToRound, float multipleOf)
    {
        int multiple = Mathf.RoundToInt(numberToRound / multipleOf);
        return multiple * multipleOf;
    }
    #endregion
}
