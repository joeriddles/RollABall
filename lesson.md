### [Part 1: Setting up the Game](https://www.youtube.com/watch?v=W_fAidYRGzs)
New 3D project: `Rollable`\
Save empty scene (or use sample scene)\
New GameObject -> 3D Object -> Plane `Ground`\
Reset `Ground` using gear menu in top right\
Gizmos -> Deselect show grid\
Set `Ground` scale x = 2, z = 2\
New sphere, reset origin, name `Player`\
Lift `Player` above `Ground`\
All new Unity scenes come with default skybox and sun light\
New folder “Materials”, new Material “Background” -> set `Albedo` (color)\
Change `Directional Light` rotation `Y = 60` for better player lighting\

### [Part 2: Moving the Player](https://www.youtube.com/watch?v=7C7WWxUxPZE)
Add `Rigidbody` to `Player` (test game now to watch ball fall)\
New folder `Scripts` -> create new C# script (and make sure attached to `Player`)\
Open script in VS\
Delete default code, add `FixedUpdate()`, which is called just before physics calculations\
Show [Unity doc](https://docs.unity3d.com/ScriptReference/) [`Input`](https://docs.unity3d.com/ScriptReference/Input.html)/[`Input.GetAxis()`](https://docs.unity3d.com/ScriptReference/Input.GetAxis.html)\
Lookup [RigidBody doc](https://docs.unity3d.com/ScriptReference/Rigidbody.html), see [`AddForce`](https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html)\
We want to get `Rigidbody` component from Player in script\
Add `private Rigidbody rigidbody;` class variable\
Add:
```
void Start()
  { rigidbody = GetComponent<Rigidbody>();
```
Add:
```
  Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
  rigidbody.AddForce(movement);
```
Return to Unity and test game using keyboard. (ball moves slow)\
Return to VS and add `public float speed;` and change `AddForce(movement)` to `AddForce(movement * speed)`\
**Why do we make `speed` public?** (So we can change it in Unity)\
Return to Unity and change `speed` to 100. Then 10. Play with ball speeds.

### [Part 3: Moving the Camera](https://www.youtube.com/watch?v=Xcm5H2J95iI)
Lift `Main Camera`: Y = 10 and tilt: rotation-x = 45\
Drag `Main Camera` onto `Player` to make it a child of the `Player` object (typical 3rd person setup).\
Test the game and new camera set up\
Detach `Main Camera` from `Player`\
`Main Camera` -> Add Component -> new script\
Add:
```
  public GameObject player;
  private Vector3 offset; // camera offset
```
**Why is `offset` private? Why is `player` public?**\
