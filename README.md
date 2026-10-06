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
