using UnityEngine;

public class Turner : MonoBehaviour
{
    private Quaternion _turnLeft = Quaternion.Euler(0f, 0f, 0f);
    private Quaternion _turnRight = Quaternion.Euler(0f, 180f, 0f);

    public void TurnTowards(float direction)
    {
        int noDirection = 0;

        if(direction < noDirection)
            transform.rotation = _turnRight;
        else
            transform.rotation = _turnLeft;
    }
}
