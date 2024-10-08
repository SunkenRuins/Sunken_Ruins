using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunkenRuins
{
    public enum ItemType
    {
        HealthPotion,
        PowerBattery,
        BubbleShield,
    }

    public enum TeamType
    {
        Player,
        Monster,
        NPC,
    }

    /// <summary>
    /// Determines the Event type that is used for the EventManager.
    /// </summary>
    public enum EventType
    {
        NormalBoost,
        PerfectBoost,
        Dead,
        MoveUp,
        MoveDown,
        MoveIdle,

        PlayerToStartPosition,
        StingRayParalyze,
        StingRayMoveTowardsPlayer,
        StingRayPrepareAttack,
        HypnoCuttleFishHypnotize,
        HypnoCuttleFishEscape,
        ThrowingCrabThrowRock,
        ShellAbsorb,
        ShellAttack,
        ShellEscape,
        ShellSwallow,
        PlayerDamaged,
    }
}