using UnityEngine;

public static class GlobalVariables
{
    public const float Threshold = 0.05f;

    public static readonly int VelocityX = Animator.StringToHash("velocityX");
    public static readonly int VelocityY = Animator.StringToHash("velocityY");
    public static readonly int Grounded = Animator.StringToHash("grounded");
    public static readonly int Hurt = Animator.StringToHash("hurt");
    public static readonly int Dead = Animator.StringToHash("dead");
    public static readonly int Spawn = Animator.StringToHash("spawn");
}