# Tropic Trigger - Final Documentation
"Trapped deep in the jungle as the last survivor of his squad, Wesley must blast through ruthless enemies and fight his way home—one trigger pull at a time."

## Game Concept
Tropic Trigger is a fast-paced side-scrolling action game that gives the players an intense jungle warfare and gunplay. The game follows Wesley, the only surviving soldier stranded deep in enemy territory, fighting his way through relentless enemies to get home.
Inspired by classic arcade shooters like Contra and Metal Slug, Tropic Trigger focuses on fast-paced gunplay and combat with precise player movement. Players will navigate the multi-tiered platforms, utilizing their weapon to defeat enemies while avoiding environmental hazards and ambushes. Tropic Trigger aims to deliver a nostalgic run-and-gun experience.

![image](https://github.com/user-attachments/assets/bbe87561-27c0-4aa3-a43e-c7713f909592)
 

## The Prototype
The current prototype demonstrates the core mechanics and overall feel of Tropic Trigger. Players control Wesley through keyboard inputs, navigating through a jungle environment while engaging with enemy soldiers. The prototype features a tutorial level to let the player get familiar with the controls and a complete level that showcases the fundamental gameplay elements, including player movement, combat mechanics, enemy AI, and environmental interaction.

![image](https://github.com/user-attachments/assets/0bfac507-bd28-4397-8361-c6195d811cfe)

 
### Playing the Game
Players navigate through the game using the following controls:  
•	A/D keys for horizontal movement.  
•	Space bar/W for jumping.  
•	C/Left Shift key for crouching.  
•	Left mouse button for shooting.  

The objective is straightforward: traverse the terrain, eliminate enemies, and reach the extraction point. The player must manage their health, which depletes upon taking damage from enemies. With limited lives and no checkpoints, death results in restarting from the beginning of the level, adding tension and stakes to each encounter.  

### Elements
Initially the player is dropped into the tutorial level, which the player can skip, that guides them through the controls. The player can enter the main level with the pause menu or getting to the final extraction point in the tutorial. Player can go back to the tutorial level from the main level from the same menu.
The prototype has a dynamic menu system, that will display according to the game state. The player can enter the pause menu by pressing the ESC key, where they’ll get other game options.

![image](https://github.com/user-attachments/assets/ea4819a4-f732-4419-9c0f-814cdc584434)

The UI HUD will show when the player gets into the game and changes according to the actions like getting hurt and reloading.

## Meeting Requirements

### Core Requirements  

The prototype successfully implements all mandatory requirements:  

Core Gameplay Mechanic: The run-and-gun combat serves as the primary gameplay mechanic, with responsive controls for movement and shooting that form the foundation of the experience.  

Sound: The game features audio design, including:  
•	Weapon sounds (gunshots, empty magazine clicks)  
•	Character sounds (footsteps, jumping, hurt responses, death)  
•	Environmental ambient sounds (jungle atmosphere)  
•	Music that fits to gameplay  

Interactive Environment: The jungle setting includes:  
•	Platform elements that players can navigate  
•	Enemies that also have a health system  

### Additional Requirements  
The prototype also incorporates several additional requirements:  

Physics: The game implements physics for the player using the built-in engine.  
AI: Enemy soldiers feature basic AI behaviours, detect the player and shoot when in range.  

![image](https://github.com/user-attachments/assets/be1306cc-6101-4a16-98d5-cdaf18c9208e)

## Self-Evaluation
The prototype, as is, is within the scope that we set out for the game. Other than the constraints that using premade 2D assets has, we delivered the essentials that we have put onto the scope of the game.
We focused on the core mechanics of the game, the visual concept and the game feel to deliver a retro styled gameplay.

## Inspiration and Influences  
Tropic Trigger draws significant inspiration from two iconic run-and-gun classics:  

Contra (1988, Konami)   
Contra influenced the approach to fast-paced, challenging gameplay that rewards skill, clean, responsive controls that facilitate precise platforming and overall difficulty curve that pushes players to improve.  

Metal Slug (1996, SNK)   
Metal Slug inspired the vibrant, detailed visual style with hand-drawn sprites, fluid animation transitions between character states and the satisfying feel of combat with visual and audio feedback.

## Gameplay Details

### Game Loop  
•	Run, jump, shoot, and dodge enemies in a classic side-scrolling view.  
•	Combat includes reloading and dealing with enemies.  
•	Players must navigate dynamic levels to get the upper hand on the enemies.  

![image](https://github.com/user-attachments/assets/46fae882-6f76-4eb6-9580-7f4c956c5721) ![image](https://github.com/user-attachments/assets/f635cf0a-dac3-4e0e-8ce8-6ee0bb19350e) ![image](https://github.com/user-attachments/assets/4e28882d-c7e4-433d-aa79-dc47a6e33c50) ![image](https://github.com/user-attachments/assets/06be1229-d01c-4ad6-8d2b-349568dbe453) ![image](https://github.com/user-attachments/assets/cb1042f1-99a5-479a-ab26-dade0609d0c2) ![image](https://github.com/user-attachments/assets/8134009e-b60b-47ff-9bec-f6446c19f1be) ![image](https://github.com/user-attachments/assets/ed08ec73-194a-4fa6-b2b6-ac132ee26ba2)








### Game Feel  
•	Fast-Paced: Tight controls and responsive movement to create a smooth but fast-paced gameplay.  
•	Combat: Weapons have impactful sound and visual effects, satisfying game feel.  
•	Environment: The jungle setting includes foliage, ambient sounds, and sound effects to further enhance user experience.  

### Game Mechanics  
•	Run: Default horizontal movement.  
•	Jump: Variable height based on button press duration.  
•	Crouch: Reduces hitbox size, enables sliding.  
•	Weapon: Standard rifle with unlimited ammo.  
•	Reload: Reload the weapon automatically on an empty magazine.  

### Win/Lose Conditions  
•	Players advance through levels by eliminating enemies and reaching the extraction point.  
•	Health bar depletes upon taking damage.  
•	Limited lives system with no checkpoints.  
•	Losing all health results in restarting from the beginning of the level.  
•	Contact with the enemy results in losing health points.  
•	Falling off platforms results in death.  

### Visual & Audio  
•	Hand-drawn 2D sprites with detailed animations.  
•	Vibrant color palette emphasizing jungle environments.  
•	Parallax scrolling backgrounds for depth.  
•	Fast-paced action music that intensifies during combat.  
•	Ambient jungle sounds for immersion.  
•	Audio queues for player weapons and actions.  
  
## Core Systems Implementation

### Player Controller  
The player controller implements a state machine with distinct states for idle, running, jumping, falling, crouching, and hurt. Each state has specific entry and exits conditions, allowing for smooth transitions between animations. The controller uses raycasting for ground detection and colliders for collision handling, ensuring precise platform interactions.  

### Camera System  
We implemented a smooth-follow camera that maintains focus on the player while slightly leading in the direction of movement.   

### Enemy AI  
As mentioned before, enemy soldiers feature basic AI behaviours, detect the player and shoot when in range.   

### Health System   
We have implemented a health script that in modular and has been used for the player and enemy objects.  

### Projectile System  
Same as the health system, the projectile system is also modular and used for both the player and the enemy.  

### Prefabs  
We made prefabs for the player, enemies, bullets, audio manager and the extraction point so that we can reuse them without additional implementations saving us time. We had to remove the Canvas for the menu a prefab as we had to have a different menu system between the tutorial and the main level. But we can use the menu as a prefab as we add additional level in the future.  

### UI System  
The UI system includes dynamic health bar that updates in real-time, ammunition counter with reload indicator, minimalist HUD design that maintains gameplay visibility, pause menu with options for sound adjustment and control reminding, other menus that are dynamically displayed on the game state.  

### Implementation Nuances  
During development, we encountered several challenges that influenced the final implementation:  

Hitbox Detection: Initial implementations of hitbox detection were inconsistent, particularly during fast movement. We resolved this by implementing a interaction conditions in the scripts.  

Animation Transitions: Some animation transitions appeared jarring, especially when switching rapidly between states. We addressed this by adding intermediate frames and adjusting transition timings in the animation state machine.  

## Scoping Decisions
### Initial Scope

Our initial scope included multiple weapon types with unique characteristics, collectible power-ups that modify gameplay and variety if enemy types with different behaviours.

### Final Scope

After evaluating time constraints and resource availability, we narrowed our focus to one level that demonstrates core gameplay, single weapon type with refined feel and feedback, standard enemy types with basic AI behaviours.  

**Decision Process**  

Making scope decisions required honest assessment of priorities and capabilities:  

Art Decisions: We chose to use pre-made assets for most visual elements, focusing our artistic efforts on animation refinement and visual feedback rather than creating original sprites. This allowed us to maintain a consistent visual style while concentrating development time on gameplay mechanics.  

Feature Prioritization: Core movement and combat mechanics were deemed essential, while additional weapons and levels were categorized as "could have" features that could be added post-prototype if time permitted.  

Technical Feasibility: Some features like dynamic destruction were technically challenging to implement within our timeframe and skill level. Rather than delivering a poorly implemented version, we chose to exclude these features entirely.  

## Test Strategy
Our testing approach focused on gathering feedback to refine the core experience:

### Playtesting Goals
During the main playtesting, we aimed to answer specific questions: Are the controls intuitive and responsive? Does the difficulty curve feel appropriate? Do combat encounters feel satisfying? Is the audio appropriate for an enhanced gameplay?

### Methodology
We conducted two playtesting with 2 participants by letting them play freely while they commented on anything they noticed, felt, or thought during gameplay. After the session, they were asked for additional feedback, including any features they would like to see added or improved.

### Key Findings

Game Restart Flow: Restarting should skip the main menu. Game now restarts directly into gameplay.  

Player Feedback Cues: No clear feedback when the player is hurt or dies. Added hurt animation and sound, and death audio cues.   

Damage on Enemy Contact: Contact with enemies should cause damage to the player. Implemented damage on contact to prevent exploitation (e.g., pushing enemies offscreen).  

Familiarization with Controls: Players needed guidance on controls. A tutorial level was added before the main gameplay.  

Shoot and Bullet Limit: Prevents infinite shooting; ammo is now tracked and single click for shooting.  

## Progress Reflection  

Risk Assessment Review  

Technical Risk: We initially identified enemy AI as a significant technical risk. However, by focusing on basic behaviours and polishing them while simpler than initially conceived, effectively serves the gameplay.  

Concept Overreach Risk: Even with the initial pitch being very basic, during the development, while learning the implementation techniques, the requirements seem to need more features.  

Learning Outcomes  

We gained understanding of 2D action game design principles. Developed skills in balancing challenge and accessibility. Improved ability to scope projects realistically and enhanced technical knowledge of animation systems.  

Level Design Evolution  

Our level design didn’t evolve significantly from initial concepts; it is still the same of platforms the player can navigate to gain the upper hand and traverse the level.  

## References & Credit

### Tutorial Resources  

Game Code Library   
•	FULL Platformer Tutorial Series - Unity 2D https://www.youtube.com/playlist?list=PLaaFfzxy_80EWnrTHyUkkIy6mJrhwGYN0  
•	https://www.youtube.com/watch?v=RgUA6hGnrF8&t=543s  
•	https://www.youtube.com/watch?v=Sg_w8hIbp4Y  

Pandemonium   
•	Unity 2D Platformer for Complete Beginners https://www.youtube.com/playlist?list=PLgOEwFbvGm5o8hayFB6skAfa8Z-mw4dPV  

Pixel Pete (Peter Milko) - https://www.youtube.com/watch?v=rC55Q7p90qs  

Brackeyes: https://www.youtube.com/watch?v=ryISV_nH8qw  

Unity Learn  
•	Introduction to Tilemaps - https://learn.unity.com/tutorial/introduction-to-tilemaps#  

Unity Documentation:  
•	https://docs.unity.com/  

### Audio Asset

Sound Effects  
•	Death: Vinodadora - https://pixabay.com/sound-effects/male-death-sound-128357/  
•	Hurt: freesound_community - https://pixabay.com/sound-effects/male-hurt7-48124/  
•	Empty Gun: freesound_community - https://pixabay.com/sound-effects/empty-gun-shot-6209/  
•	Gun Shot: ShashiRaj Production - SCI-FI GUNS : GAME OF WEAPONS https://assetstore.unity.com/packages/audio/sound-fx/weapons/sci-fi-guns-game-of-weapons-284029  
•	Footsteps: Dryoma - https://dryoma.itch.io/footsteps-sounds  
•	Cloth/Jump & Fall: kenney.nl - RPG Audio - https://kenney.nl/assets/rpg-audio  
•	Ambience - Goumain Antoine - Nature Sounds Pack - Free  https://assetstore.unity.com/packages/audio/sound-fx/nature-sounds-pack-free-202076    

Music  
•	CarizaCarlos - ThunderWood Tempest https://echo-mellow.itch.io/thunderwood-tempest  

### Visual Assets

Character  
•	Enemy: Craftpix - https://craftpix.net/freebies/free-soldier-sprite-sheets-pixel-art/  
•	Player: Ansimuz - Gothicvania Swamp https://assetstore.unity.com/packages/2d/characters/gothicvania-swamp-152865  
•	Bullet: Ansimuz - Warped Shooting Fx https://assetstore.unity.com/packages/2d/textures-materials/abstract/warped-shooting-fx-195246  

Environment  
•	Tiles, Background, DecorPixel: karsiori - Art Woods Tileset and Background https://assetstore.unity.com/packages/2d/environments/pixel-art-woods-tileset-and-background-280066  
•	Helicopter: geeksagon- Chinook - https://geeksagon.itch.io/chinook  

UI Element  
•	Icons: OArielG - 2D Simple UI Pack https://assetstore.unity.com/packages/2d/gui/icons/2d-simple-ui-pack-218050  
•	Input Icons: Amanz - Game Input Controller Icons Free https://assetstore.unity.com/packages/2d/gui/icons/game-input-controller-icons-free-285953  
•	Font: Navairas - Metal Slug Latino Font https://fontmeme.com/fonts/metal-slug-latino-font/  

### Inspiration  

Contra (1988, Konami): https://en.wikipedia.org/wiki/Contra_(video_game)  
Metal Slug (1996, SNK): https://en.wikipedia.org/wiki/Metal_Slug  


	

