using UnityEngine;
using UnityEngine.InputSystem;

public class RotacionPlayer : MonoBehaviour
{
    Vector2 mouseFinal;
    Vector2 smoothMouse;

    public Vector2 clampDegrees = new Vector2(360, 180);
    public bool lookCursor;

    public Vector2 sens = new Vector2(0.1f, 0.1f);
    public Vector2 smoothing = new Vector2(3, 3);
    Vector2 targetDirection;
    Vector2 targetCharacterDirection;
}
