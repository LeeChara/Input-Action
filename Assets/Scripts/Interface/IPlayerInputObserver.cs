using UnityEngine;

public interface IPlayerInputObserver
{
    void OnMove(Vector2 direction);
    void OnJump();
    void OnAttack();
}
