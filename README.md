# in-class-activities
## Devlogs
### W1
The cat cannot follow the movement of the camera

### W2
1.In Unity, RGB color values typically range from 0.0 to 1.0 and can include decimals. We use floats for r, g, and b because they can store these fractional values.

An int stores only whole numbers, so it cannot represent values such as 0.3 or 0.7.

A bool stores only true or false, so it cannot represent different levels of color intensity.

A string stores text rather than numerical values used in calculations.


2. bounce counts how many times the ball collides. Bounces are whole numbers (1, 2, 3…).

• int stores whole counting numbers perfectly.

• float allows decimals, but you cannot have half a bounce.

• bool only has true/false and cannot count multiple bounces.

• string stores words and cannot do addition to increment the count.


3.The error indicated that we cannot directly modify individual channels of `spriteRenderer.color` because this property returns a copy of the color data. Modifying that copy does not update the sprite’s actual color. To change it, we store the r, g, and b values in local float variables, adjust them, and then assign a new color back using `new Color(r, g, b)`.

## Open-Source Assets
### W1
- Animals: https://assetstore.unity.com/packages/3d/characters/animals/animals-free-animated-low-poly-3d-models-260727 
- Low-poly environment: https://assetstore.unity.com/packages/3d/environments/landscapes/low-poly-simple-nature-pack-162153 

# W3 Devlog

## Activity 1: Methods Discussion

### 1. GetResponse
Parameters: `int friendshipLevel` and `bool knowsSecret`.
Return type: `string`.

The friendship level and whether the player knows the character's secret determine the character's text response.

Example: `string GetResponse(int friendshipLevel, bool knowsSecret)`

### 2. SetLightDimness
Parameter: `float sanityLevel`, ranging from 0 to 100.
Return type: `void`.

The method changes the room's lighting based on the player's sanity level. No return value is needed because it changes the light directly.

Example: `void SetLightDimness(float sanityLevel)`

### 3. DidPlayerHitBeat
Parameter: `float keyPressTime`.
Return type: `bool`.

The method compares the key press time with the expected beat time and returns whether the player hit the beat accurately. The expected beat time and allowed timing window can be stored as member variables.

Example: `bool DidPlayerHitBeat(float keyPressTime)`

## Activity 2: Components and Classes Metaphor

A class is like a blueprint for a car engine. A Component is an actual engine created from that blueprint and installed in a car, which represents a GameObject.

Member variables describe the engine's properties and state, such as its temperature and horsepower. Methods describe actions it can perform, such as starting, accelerating, and stopping.

Multiple Components can be created from the same class, with each storing its own member variable values.

## Activity 3: Methods Coding Activity

I made BallW3 inherit from MonoBehaviour and added SerializeField attributes so its private fields could be configured in the Inspector. I created four balls with different colors, added Rigidbody2D and CircleCollider2D components, assigned PhysMat_Ball, and connected the script references.

In BallW3, I implemented velocity scaling on collision and GetColorMultiplier. This method calculates the average of the absolute X and Y speeds and returns 1.5 when the average exceeds the speed threshold, or 1.0 otherwise.

In CatW3, I implemented health reduction, health and speech text updates, copying the ball's color, and destroying the cat when its health reaches zero if Destroy Cat When Dead is enabled.

One challenge was assigning component references in the Inspector. I solved this by dragging the Ball GameObject from the Hierarchy into the appropriate fields. I also resized and repositioned the balls.

During testing, the cat changed color and lost health when touching a ball. The speech displayed "ouch" at higher health and "OH NO!" below half health. Initially, the cat remained alive with negative health because Destroy Cat When Dead was unchecked. After enabling it, the cat disappeared when its health reached zero.

W4
## Devlog — Collision Activity

**Table #:10

1. I added a Capsule Collider to the cat, set its direction to the Z-axis, and adjusted it to fit the cat’s body. I added a Sphere Collider to the soccer ball and a Box Collider to the goal area.

I added Rigidbodies to both the cat and the soccer ball so they could move and respond to physics. I left Is Trigger disabled on their colliders so they could physically collide. I enabled Is Trigger on the goal’s Box Collider so the ball could pass through the goal area while triggering goal detection. The stationary goal did not need a Rigidbody.

I also added the BounceOffWall component to the cat and the ball and connected each component to its own Rigidbody.


2.I implemented OnTriggerEnter to check whether the object the ball entered had the “Goal” tag. When it did, the script called MadeGoal to log a message, play the celebration effect, increase the score, and reset the timer. I used Update and Time.deltaTime to track and display the time since the last goal.


3.During testing, the ball bounced away from the goal instead of scoring. I corrected the goal’s collider settings so the goal area functioned as a trigger. After the fix, entering the goal increased the score, and the timer reset and continued counting.
