/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Ian Lucas. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using SwiftlyS2.Shared.Events;
using SwiftlyS2.Shared.Misc;
using SwiftlyS2.Shared.ProtobufDefinitions;

namespace Deathmatch;

public partial class Deathmatch
{
    public void OnConVarValueChanged(IOnConVarValueChanged @event)
    {
        switch (@event.ConVarName)
        {
            case "dm_modes_file":
                HandleModesFileChanged();
                return;
        }
    }

    public void OnMapLoad(IOnMapLoadEvent @event)
    {
        PendingInternalPush = true;
    }

    public void OnTick()
    {
        if (PendingInternalPush)
        {
            PendingInternalPush = false;
            OnConfigsExecuted();
        }

        Rules.Think();
        if (Core.Engine.GlobalVars.TickCount % 64 != 0)
            return;
        // Arcfrag: no K/D alert and no round hint text; the Arcfrag UI owns the HUD. Only the countdown beep stays.
        if (Rules.HasMultipleModes() && Rules.GetRemainingTime() <= 3)
        {
            CountdownBeepSound.Recipients.AddAllPlayers();
            CountdownBeepSound.Emit();
            CountdownBeepSound.Recipients.RemoveAllPlayers();
        }
    }

    public void OnConfigsExecuted()
    {
        Config.ExecDeathmatch();
        ConVars.InfinityAmmo.Value = 2;
    }

    public HookResult OnClientCommand(int playerid, string commandLine)
    {
        var player = Core.PlayerManager.GetPlayer(playerid);
        if (player != null && commandLine.StartsWith("buyrandom"))
            return HookResult.Stop;
        return HookResult.Continue;
    }
}
