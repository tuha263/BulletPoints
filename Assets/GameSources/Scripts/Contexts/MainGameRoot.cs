using strange.extensions.context.impl;
using UnityEngine;

public partial class MainGameRoot : ContextView
{
    [SerializeField] private GameObject instanceGameObject;

    void Awake()
    {
        MainGameContext mainGameContext = new MainGameContext(this, true);
        context = mainGameContext;
        context.Start();
    }

    void Start()
    {
        instanceGameObject.gameObject.SetActive(true);
    }
}