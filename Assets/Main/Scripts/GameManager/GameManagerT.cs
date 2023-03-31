using UnityEngine;

public abstract class GameManagerT : MonoBehaviour
{
    public static GameManager GameManagerInstance { get; protected set; } = null;

    public static PlayerSlime Player { get; protected set; } = null;

    public static DamageUIMessager DamageUIMessager { get; protected set; } = null;
}
