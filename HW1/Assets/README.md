# Core Mechanics
## Player
* **Movement:** The player is controlled via a character controller. "w,a,s,d" keys are used to move the player and pressing shift allows user to sprint. The player movement is supported with animations for smoother gameplay.
* **Interaction:** The player can physically push the key. The key can also be grabbed by pressing "e" key which makes it hover over the player.

## The Objective (Key & Door)
* **Win Condition:** Successfully pushing the Key into the Door triggers a collision event which opens the Victory Panel.

## Traps and Guard
* **Sawblade Trap:** Moves horizontally between two points. Touching it results in an immediate Game Over.

* **Spike Trap:** Periodically emerges from the ground and retracts. The player can only safely pass when the spikes are retracted.

* **Skeleton Guard:** Patrolled by a skeleton asset moving between two waypoints. It features a Rectangular Detection Zone in front of it; entering this zone triggers Game over.
* Used coroutines to move the traps and the guard periodically.

## UI
* **Victory/Loss Panels:** Both screens ask the player for "Another Round."
* **Restart Button**: Reloads the current scene and resets Time.timeScale to 1.0.

## Music
* Pressing the 'M' key during gameplay toggles the background music ON/OFF dynamically.

