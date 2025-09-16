using NUnit.Framework;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputBroadcaster : MonoBehaviour
{
    private PlayerControls inputActions; //�ڵ� ������ Input Actions�� C# ��ũ��Ʈ
    private List<IPlayerInputObserver> observers = new(); //���������� ������ ����Ʈ

    private void Awake()
    {
        inputActions = new PlayerControls();
        Debug.Log("PlayerInputBroadCaster : PlayerControls�� ��ϵǾ����ϴ�." + inputActions);
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Gameplay.Move.performed += OnMove;
        inputActions.Gameplay.Jump.performed += OnJump;
        inputActions.Gameplay.Attack.performed += OnAttack;
    }
    private void OnDisable()
    {
        inputActions.Gameplay.Move.performed -= OnMove;
        inputActions.Gameplay.Jump.performed -= OnJump;
        inputActions.Gameplay.Attack.performed -= OnAttack;
        inputActions.Disable();
    }

    public void Subscribe(IPlayerInputObserver observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }
    public void Unsubscribe(IPlayerInputObserver observer)
    {
        observers.Remove(observer);
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        foreach (IPlayerInputObserver observer in observers)
        {
            observer.OnMove(input);
        }
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        foreach (IPlayerInputObserver observer in observers)
        {
            observer.OnJump();
        }
    }
    private void OnAttack(InputAction.CallbackContext context)
    {
        foreach (IPlayerInputObserver observer in observers)
        {
            observer.OnAttack();
        }
    }
}
