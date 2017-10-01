# 202-project-asteroids
*Due Sunday 10/22 at 11:59pm*

### Purpose
Create your own version of the classic Asteroids game or a similar top-down SHMUP (shoot ‘em up) game, in Unity.  Demonstrate an understanding of time, vectors, vector-based movement and collision detection.  

### Background
* Asteroids is a classic Atari game from 1979.  Visit http://www.freeasteroids.org to play the game.  
* You may either recreate the original Asteroids look and feel of vector-based graphics, or you may add your own style to the game.  Feel free to use any visual theme you like. 
* Your game will focus on a ship, or some type of main character, shooting to survive hordes of enemies who can subdivide to make a larger menacing force!  Your enemies’ main goal is to kill you by running into you and breaking down your defenses in the process.  Shoot projectiles at the enemies to break them down into smaller enemies; shoot again to destroy them forever.  

## Details

### Ship Movement
Your ship must move using vector-based movement. 
* Position, velocity and acceleration vectors must be properly utilized.  
* Ship must wrap around the screen. 
* The ship accelerates using the up arrow key. 
* When not accelerating, the ship may either stop or continually drift at a very low speed – your choice.  
* The ship must exhibit obvious acceleration and deceleration.  

### Ship Health / Collision Response:
* Your ship must safely navigate through the world of constantly moving asteroids. If an asteroid hits your ship – no matter how large or small the asteroid - your ship loses a life.   
* The game is over when 3 asteroids hit the ship.

### Ship Security
* The ship shoots bullets when the space bar is pressed.  
* Bullets must move in the same direction as the ship is moving but at a faster speed.
* You may choose whether bullets wrap around the screen or not.  
* Bullets do not affect the ship health; accidentally running into a bullet does not harm the ship.  
* Bullets must use a timing mechanism to limit the number of bullets on screen; rapid-fire bullet spray is not permitted. (However - rapid fire bullets as an above and beyond power-up is acceptable.) 

### Asteroid Movement and Generation
* Asteroids must move in a random direction. They do not need to wrap around the screen.  
* Asteroids must be unique in their individual appearances. This could mean:
  * Using different images for an asteroid sprite, or
  * Choosing a random asteroid prefab among a set of asteroid prefabs 

### Asteroid Collision Response
* The first bullet to hit an asteroid (first-level) will break it apart into 2 or more smaller asteroids (second-level).  
* These second-level asteroids should move in roughly the same direction as the larger asteroid.  Add some variance to the direction so the asteroids don’t move in exactly the same path.
* The first bullet to hit a second-level asteroid will destroy that asteroid. 

### GUI Interface
* Ship damage, or the number of ships lives left, must be notated somewhere in the game screen. 
* A scoring system must also be implemented. Player’s score must be notated in the interface. 
  * First-level asteroids = 20 points
  * Second-level asteroids = 50 points

### Recommended User Controls
* Space = shoots bullet
* Left arrow key = rotate ship left
* Right arrow key = rotate ship right
* Up arrow key = accelerate ship
* You may use alternate controls if you wish.

### Gameplay Levels
* Only 1 gameplay level is necessary.  
* No required win condition. Endless asteroids is acceptable.



### Above & Beyond Possibilities:
* A way to win the game
* Multiple sound effects 
* Additional levels beyond 1 level
* Starting and ending game screens
* Well-designed interface, or working with Canvas in Unity
* Game Options
  * Volume control
  * User controls (for the PC only – no game controllers)
  * Difficulty levels
  * Choice of graphic or color schemes
* High score tracking with text files
* Power ups
* Physics collision response (elastic or inelastic collisions)

### Documentation
* Controls must be listed in your documentation file.
* Third-party assets must be listed in your documentation file. You are permitted to use any graphics you choose. If you borrow graphics from a friend or the internet, you must credit your sources.  A link to the source of the image will suffice. For example:
```
Asset Credit:
Asteroid sprite sheet - http://freegameassets.blogspot.com/2013/09/asteroids-and-planets-if-you-needed-to.html
```
* Above & Beyond attempts should be listed in the documentation as well.

### Submission Details
* Push your commits to your GitHub repo before 11:59pm on Sunday 10/22/17.
* It is also a good idea to clone your repo to another folder and test your project to be sure it works.

### Suggested Timeline
* Get ship movement working first with proper user controls (1 days)
* Shoot bullets from ship. Bullet timing. (1 day)
* Add in asteroid spawning and first-level asteroid movement (1 day)
* Collision detection (1 day)
* Asteroids break into second-level asteroids (1 day)
* Implement ship health / 3 ship lives and game over. (1 day)
* Above and beyond (2 days)
