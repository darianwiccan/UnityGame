﻿using UnityEngine;
using System.Collections;

namespace UnityGame.ItemSystem
{
    public interface IISObject
    {
        string Name { get; set; }
        int Value { get; set; }
        Sprite Icon { get; set; }
        int Burden { get; set; }
        ISQuality Quality { get; set; }

        // These go to other item interfaces

        // questItem flag

    }
}