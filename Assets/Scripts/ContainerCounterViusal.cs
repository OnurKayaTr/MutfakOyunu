using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterViusal : MonoBehaviour
{
    private const string OPEN_CLOSE = "OpenClose";
    [SerializeField] private Container container;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        container.OnPlayerGrabbedObj += Container_OnPlayerGrabbedObj;
    }

    private void Container_OnPlayerGrabbedObj(object sender, System.EventArgs e)
    {
        animator.SetTrigger(OPEN_CLOSE);
    }
}
