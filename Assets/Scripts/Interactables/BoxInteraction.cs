using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BoxInteraction : Interactable
{
    [SerializeField] private bool _isHolding;
    private Rigidbody2D _rb;
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }
    public override void OnEnabled()
    {
        if (!_isHolding)
            Hold();
        else
            LetGo();

        _isHolding = !_isHolding;
    }
    private void Hold()
    {
        _rb.constraints = RigidbodyConstraints2D.FreezeAll;
        GameManager.Instance.Player.GetComponent<PlayerController>().HoldObject(this);
    }
    private void LetGo()
    {
        _rb.constraints = RigidbodyConstraints2D.None;
        GameManager.Instance.Player.GetComponent<PlayerController>().HoldObject(null);
    }
    public override void OnTrigger(out Interactable interactable)
    {
        interactable = this;
    }


}