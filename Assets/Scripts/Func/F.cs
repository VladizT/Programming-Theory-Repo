

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UnityEngine
{
    ///<summary>
    /// Тестовый класс для различных функций.
    ///</summary>
    public class F : Object
    {

        ///<summary>
        /// A short method to get component of game object.
        ///</summary>
        
        static public T GC<T>(String obj)
        {
            return GameObject.Find(obj).GetComponent<T>();
        }

    }
}

