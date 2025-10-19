Unique feature - Change Color when Player jumps.
I used simple switch of colors. They can be changed in Unity Editor on PlayerCube obj. In script PlayerMovement I created bool "isGrounded"
for ground check, and when is player in air color switch to jumpColor, when in ground to normalColor. Changing colors in FixedUpdate
