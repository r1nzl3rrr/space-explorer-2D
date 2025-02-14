# Space Explorer 2D

**Space Explorer 2D** is an exciting space adventure game where the player controls a ship, dodges asteroids, collects stars, and shoots enemies for points. The game is designed with progressively difficult waves of asteroids, looping levels, and thrilling particle effects.

## Controls
- **Move:** `WASD` or arrow keys
- **Shoot:** Automatic firing

## Gameplay
- **Player Ship:**
  - Health: 100
  - Projectile Damage: 10
  - Health decreases on collision with asteroids.

- **Asteroids:**
  - **Asteroid 1:**
    - Damage: 10
    - Health: 30
    - Destroying it grants 50 points.
    ![Asteroid 1](Assets/3rd%20Party%20Assets/SpaceAssets/Asteroids/Asteroid_1.png)
  - **Asteroid 2:**
    - Damage: 30
    - Health: 50
    - Destroying it grants 70 points.
    ![Asteroid 2](Assets/3rd%20Party%20Assets/SpaceAssets/Asteroids/Asteroid_2.png)
  - **Asteroid 3:**
    - Damage: 50
    - Health: 70
    - Destroying it grants 100 points.
    ![Asteroid 3](Assets/3rd%20Party%20Assets/SpaceAssets/Asteroids/Asteroid_3.png)
    
- **Stars:**
  - **Yellow Star:** Collecting gives 150 points.
  - **Red Star:** Collecting gives 300 points.

- **Progression:**
  - As the player accumulates points (thresholds like 1000 or 2000), the scene will flash and transition to the next level with more challenging asteroids.
  - The game loops through levels continuously as the player progresses.

## Asteroid Spawning
- **Trajectory:** Defined by path prefabs.
- **Waves:** Defined by scriptable objects, randomly spawning asteroids at specified intervals.
- **Spawning System:** A spawner prefab triggers waves with randomized time between waves.

## Game Over
- The player loses when their health reaches 0.

## Audio & Visual Effects
- **Particle Effects:**
  - Thrusters
  - Projectile hits
  - Explosions for asteroids and the player ship
- **Music:** Three looping tracks throughout gameplay.
- **Sound Effects:** 
  - Projectile hitting an asteroid
  - Asteroid hitting the player
  - Collecting a star

## User Interface
- **Main Menu:**
  - Start Game
  - Instructions
  - Quit
- **Game Over Screen:**
  - Displays final score
  - Options to restart, return to the main menu, or quit
- **Gameplay Screen:**
  - Health bar
  - Score counter

## Assets
- All game assets (sprites, textures) were generated using an AI-based pixelated workflow.

## Installation
1. Clone the repository:  
   ```bash
   git clone https://github.com/r1nzl3rrr/space-explorer-2D.git
   ```
2. Open the project in your preferred game engine (e.g., Unity).
3. Build and run the game!

Enjoy the game! 🚀
