using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    private Vector2 _followSpot;
    [SerializeField] private float perspectiveScale;
    [SerializeField] private float scaleRatio;
    
    private Vector2 _stuckDistanceCheck;
    private NavMeshAgent _agent;
    private Animator _animator;
    
    public static float maxAFKTime = 20f;
    public static float currentAFKTime = 0f;
    
    public static Action OnAFKTime;
    
    void Start()
    {
        _followSpot = transform.position;
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;

    }

    void Update()
    {
        if (DialogueManager.isActive)
        {
            HandleDialogueInteraction();
            return;
        }
        HandlePlayerMovement();
        AdjustPerspective();
        UpdateAnimation();
    }

    public void HandlePlayerMovement()
    {
        if (DialogueManager.isActive == false)
        {
            _animator.SetBool("interaction", false);
        }

        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0) && !IsMouseOverUI())
        {
            _followSpot = new Vector2(mousePosition.x, mousePosition.y);
            currentAFKTime = 0f;
        }

        else
        {
            OnAFKTime?.Invoke();
        }
        _agent.SetDestination(new Vector3(_followSpot.x, _followSpot.y, transform.position.z));
    }
    
    private void HandleDialogueInteraction()
    {
        _animator.SetBool("interaction", true);
        Vector3 direction = transform.position - new Vector3(_followSpot.x, _followSpot.y, transform.position.z);
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        _animator.SetFloat("angle", angle);
    }

    private void UpdateAnimation()
    {
        float distance = Vector2.Distance(transform.position, _followSpot);
        _animator.SetFloat("distance", distance);
        if (Vector2.Distance(_stuckDistanceCheck, transform.position) == 0)
        {
            _animator.SetFloat("distance",0f);
            return;
        }
        if (distance > 0.01)
        {
            Vector3 direction = transform.position - new Vector3(_followSpot.x, _followSpot.y, transform.position.z);
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            _animator.SetFloat("angle", angle);
            _stuckDistanceCheck = transform.position;
        }
    }
    
    private void AdjustPerspective()
    {
        Vector3 scale = transform.localScale;
        scale.x = perspectiveScale * (scaleRatio - transform.position.y);
        scale.y = perspectiveScale * (scaleRatio - transform.position.y);
        transform.localScale = scale;
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
