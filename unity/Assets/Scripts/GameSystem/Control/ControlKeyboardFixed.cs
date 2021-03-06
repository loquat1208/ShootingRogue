﻿using System;
using UnityEngine;
using UniRx;

public class ControlKeyboardFixed : IControl
{
    private MoveController moveController = new MoveController();

    private IObservable<Vector3> OnDir { get { return Observable.EveryUpdate().Select(_ => new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))); } }

    public ControlKeyboardFixed(Rigidbody rigid)
    {
        Init(rigid);
    }

    private void Init(Rigidbody rigid)
    {
        OnDir.Subscribe(dir => moveController.Move(rigid, dir));
    }
}
