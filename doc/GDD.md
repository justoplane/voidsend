# Voidsend Design Document

Voidsend is a 2-D roguelike dungeon crawler that takes inspiration from titles such as Risk of Rain, Hades, and Dead Cells. The game will be a top-down hack'n'slash bullet hell.

## Core Gameplay Loop

### Difficulty Scaling
- Risk of Rain 2 time-difficulty scaling + Majora's Mask style time reset mechanic
- As time increases, so does difficulty
  - Difficulty `coefficient = minutesElapsed * areasCleared * ?numResets?`
- After clearing each area, the player will have the opportunity to reset the dungeon
  - This will reset the time and areasCleared values used in difficulty scaling
  - Each time the dungeon is reset, a stacking difficulty modifier will be added to the game
    - i.e. RoR2 Eclipse difficulty (less regeneration, less health, higher weapon cooldown, take extra damage, challenge run EtG, etc.)
    - Maybe a permanent, general difficulty increase based on the number of total resets
  - A reset means that the following things will happen:
    - The player is physically moved to the start of the dungeon
    - The player will lose all non-permanent upgrades/items
    - The dungeon is re-generated with a new layout
      - The dungeon generation will keep some elements the same
      - Maybe chest locations/rarities are the same?
    - The in-game minutesElapsed value is reset
    - The player has a chance to recieve permanent debuffs (void sickness/instability)

## Core Mechanics

### Movement
- Tight, responsive movement
- Instantaneous direction changes
- Smoothed acceleration from standstill

### Integral Dash/dodge
- Invulnerable dash
- Dash chaining with successful attacks
  - Dash cooldown is refreshed on kill

### Slow Motion
- Hit freeze on successful attacks
- Slightly longer slow-mo window on dash chain melee attacks
- Long range dash/shooting bullet time effect?
  - Maybe when both dashing and shooting at the same time?
  - Maybe when dodging explicitly through bullets?
  - **Maybe anytime when shooting to give players a better opportunity to aim**
- Big boi hit freeze on parries

### Combat
- Hits are powerful and meaningful
  - Most enemies have one hp and die immediately
  - This allows for better **powerful** feeling when using melee chaining
- Focused on CQC, emphasizes melee weapons
- Ranged weapons are for a different purpose, other than killing
  - Apply debuffs to enemies
  - Mark enemies for death?
  - **Powerful effects, but costs health temporarily until subsequent melee kill of target?**
- Player is rewarded for fast-paced combat tactics
  - Timed combos?
  - Chained kill bonuses?
  - Temporary stat buffs after melee kills

### Special abilities
- Bullet reflect/parry system
  - No parrying of basic, slow 'bullet hell' bullets
  - Reflection/blocking of instantaneous ranged/melee attacks
    - Cut through/destroy parried attacks instead of relfecting them?
    - Give players speed boost
    - Increase bonuses/combo
    - Definitely some epic **hit freeze/slow motion**
    - Debuff (stun) enemies briefly
- Blank
  - Bullet clearing effect in radius around player
  - Instantaneous activation
  - "Get out of jail free"

## Controls

### Overview
| Button | Action        | Category |
| ------ | ------------- | -------- |
| LT     | Dash          | Movement |
| RT     | Melee         | Combat   |
| LB     | Map           | UI       |
| RB     | Ranged        | Combat   |
| A      | Interact      | UI       |
| B      | Blank         | Combat   |
| X      |               |          |
| Y      | Switch Weapon | Combat   |

### Movement
- **Left Jostick**
  - Player Movement
- **Left Trigger**
  - Dash

### Combat
- **Right Joystick**
  - Aim
- **Right Trigger**
  - Melee Attack
  - Parry 
    - Activates instead of melee attack if applicable
- **Right Bumper**
  - Ranged Attack
    - Press/hold to engage slow motion 
    - Release to shoot
    - Slow motion lasts for a fixed amount of time, or until the button is released, whichever is shorter
- **Y Button**
  - Switch active ranged weapon 
    - Stops time and pulls up menu controlled by left stick, ala EtG
- **B Button**
  - Activate Blank?

### UI
- **A Button**
  - Interact
  - Confirm in menus
- **B Button**
  - Back in menus
- **Left Stick**
  - Navigate menus
- **Left Bumper**
  - Show map
    - Transparent overlay while button is held

## Progression Systems
- Meta Progression
  - Unlockable features
  - Persistent upgrades
  - Currency systems
- Run Progression
  - Temporary power-ups
  - Item system
  - Level-up system

## Level Design
- Structure
  - Room types
  - Generation method
  - Biomes/zones
- Rewards
  - Item placement
  - Secret areas
  - Optional challenges

## Art Style
- Visual Direction
  - Hyper Light Drifter-esk void theme
  - EtG-style pixel art
  - Lots of dark purples, blues, and blacks
  - Bright red bullets
- Animation
  - Animation style
  - Key character animations
  - Effect animations

## References
- **Katana Zero**
  - Hit freeze
  - Powerful melee combat
- **Hyper Light Drifter**
  - Limited ranged ammo
- **ROR2**
  - Time-difficulty scaling
- **Hades**
  - Hack'n'slash mechanics?
- **EtG**
  - Bullet hell
  - Invulnerable dash/dodge
  - Top down