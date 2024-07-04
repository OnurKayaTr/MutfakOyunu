using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasProgges 
{
    public event EventHandler<OnProgressCahangedEventArgs> OnProgressCahanged;
    public class OnProgressCahangedEventArgs : EventArgs
    {
        public float progressNomralized;
    }
}
