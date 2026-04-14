using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface NMIBlockState
{
    void Enter(NMMovingBlock block);
    void Update(NMMovingBlock block);
}
