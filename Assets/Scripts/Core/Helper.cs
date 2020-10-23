using UnityEngine;
public static class Helper
{

    public static Vector3[] axisVectors = { Vector3.zero,
                                             Vector3.right,
                                            -Vector3.right,
                                             Vector3.up,
                                            -Vector3.up,
                                             Vector3.forward,
                                            -Vector3.forward};


    public static bool MoveToUntil(this Rigidbody rb, Vector3 target, float lerpSpeed)
    {
        rb.MovePosition(Vector3.Lerp(rb.transform.position, target, Time.deltaTime * lerpSpeed));
        var boolcheck = (rb.transform.position - target).magnitude < 0.5f;
        return boolcheck;
    }

    public static bool HasReached(this Vector3 t, Vector3 target, float epsilon)
    {
        var boolcheck = (t - target).magnitude < epsilon;
        return boolcheck;
    }
    
    
    #region StateChecks

    public static bool IsPlaying()
    {
        return GameManager.main.game.state.GetType() == typeof(PlayingState);
    }

    public static bool IsMainMenu()
    {
        return GameManager.main.game.state.GetType() == typeof(MainMenu);
    }

    public static bool IsBrushState()
    {
        return GameManager.main.game.state.GetType() == typeof(BrushState);
    }

    public static bool WinOrLoseState()
    {
        return (GameManager.main.game.state.GetType() == typeof(WinState)) || (GameManager.main.game.state.GetType() == typeof(FailState));
    }
    
    #endregion
}
