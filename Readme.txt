Arcfrag Deathmatch
==================

Deathmatch/FFA plugin for Arcfrag (SwiftlyS2). Fork of ianlucas/cs2-ss2-deathmatch (MIT).
Stats, Elo, challenges, map rotation and the HUD come from ArcfragCore; this plugin owns
the gameplay: weapon rounds, loadouts, kill rewards and the deathmatch cvars.

Arcfrag changes
  - Plugin id/folder ArcfragDeathmatch, chat prefix in the Arcfrag style.
  - No K/D alert and no round hint text (the Arcfrag UI owns the HUD); a round change is
    one chat line instead. dm_pro_ratio is gone.
  - default.json: one round with every weapon (normal DM). pistol.json: pistols only.
  - mp_timelimit 10 (the core's map vote runs at the end of the map).

Commands
  !guns        weapons of the current round and their commands
  !<weapon>    take that weapon (!ak, !m4, !m4a1s, !awp, !deagle, ...)
  !noprimary   pistol only
  !help        help

ConVars
  dm_chat_prefix " {gold}arcfrag.net{default} •"
  dm_modes_file "addons/swiftlys2/plugins/ArcfragDeathmatch/resources/configs/default.json"
  dm_replenish_health 10 / dm_replenish_health_headshot 25
  dm_replenish_armor 5 / dm_replenish_armor_headshot 20
