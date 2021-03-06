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
**Why is `offset` private? (because we only set it in the script)\
Add:
```
void Start()
{
	offset = transform.position - player.transform.position;
}

void LateUpdate() // runs every frame like Update(). Is guaranteed to run after all other objects.
{
  transform.position = player.transform.position + offset;
}
```
Return to Unity. Drag `Player` to `Main Camera`'s `Camera Controleler -> Player` spot and test game.

### [Part 4: Setting up the Play Area](https://www.youtube.com/watch?v=dahT0wRVO1Q)
We're gonna add walls and pick-ups\
Game Object -> new empty object named `Walls` and reset position\
Game Object -> new cube `WestWall` and reset position. Make child of `Walls`\
Focus on `WestWall` (select `WestWall` -> Edit -> Frame Selected)\
`WestWall` scale x = 0.5, y = 2, z = 20.5, position x = -10\
Duplicate `WestWall` and rename `EastWall`. set position x = 10\
Duplicate `EastWall` and rename `NorthWall`. set position x = 10, z = 10\
Rescale `NorthWall` or rotate to face the appropriate direction (rotate y = 90)\
Duplicate `NorthWall` and rename `SouthWall`. set position z = -10\
Test game. Highlight `Player` and set play mode to local (top-left). See ball axis change.

### [Part 5: Creating Collectibles](https://www.youtube.com/watch?v=HlDGSStxuHI)
Game Object -> new cube `Pickup`. Reset origin. Focus on `Pickup`\
Select `Player` and deselect "active" checkbox by name to hide.\
`Pickup` y = 0.5\
Let's make it look better: all scales = .5, all rotates = 45\
Let's add a script to rotate `Pickup` named `Rotator`.\
Open `Rotator` in VS. Remore `Start()` as it is uneeded.\
Lookup [`Transform`](https://docs.unity3d.com/ScriptReference/Transform.html). See [`Rotate`](https://docs.unity3d.com/ScriptReference/Transform.Rotate.html)\
Add `transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);` to `Update()`\
Test changes in Unity\
Create new folder `Prefabs` and drag `Pickup` game object into folder to create a new prefab.\
Create new empty game object to hold `Pickup`s, named `Pickups`. Move `Pickup` into `Pickups`.
Click on y-axis in gizmo to get a top-down view and zoom out to see entire game area.\
Move object around. See how it dips in and out? Change editor-mode to `Global` to move in relation to `Ground`.\
Move `Pickup` somewhere on `Ground`. Use Ctrl+D to duplicate and fill game with pickups.\
Duplicate material object and create new color. Apply color to `Pickup` prefab.\

### [Part 6: Counting Points](https://www.youtube.com/watch?v=XtR29MmzuT0)
Make `Player` active again and open `Player` script in VS.\
Add:
```
void OnTriggerEnter(Collider other)
{
  if (other.gameObject.CompareTag("Pickup")) // is the object we collided with a Pickup prefab?
  {
    other.gameObject.SetActive(false);
  }
}
```
Select `Pickup` prefab and add tag "Pickup".\
Test game. We're still bouncing off the Pickups. **Why?** (Rigidbody - no collision is registered.)\
Disable mesh renderer on `Player` and a `Pickup` and inspect.\
Check "Is Trigger" on `Pickup` prefab.\
Unity is constantly recalculating collider for `Pickups`. Add Rigidbody to prefab.\
They now fall through! Select "Is Kinematic". Now `Pickups` will not react to physics forces.\

### [Part 7: Displaying Score and Text](https://www.youtube.com/watch?v=bFSLI2cmYYo)
Open `PlayerController` script.\
Add `private int count;`, `Start() ... count = 0;`, `OnTriggerEnter() if(...) ... count = count + 1;`\
Go back to Unity and add Text element using Hieracrchy -> Create\
Rename `Text` to `Count Text`.\
Make `Count Text` white. Add placeholder "Count Text".\
Click on anchor button. Hold Shift + Alt and put it on the top-left.\
Change Pos X = 10, Pos Y = -10\
Open `PlayerController` script in VS.\
Add `using UnityEngine.UI;` to top of file.\
Add `public Text countText;`, `OnStart()... countText.text = "Count: " + count.ToString();`, `OnTriggerEnter() ... if(...) ... countText.text = "Count: " + count.ToString();`\
Now we have the same line of code twice!! Time for a new method: `SetCountText()`\
Return to Unity and drag and drop `Count Text` to `Player`'s "Count Text" slot under "Player Controller"\
Test game.\
Create new text "Win Text". Change color to white, size to 24pt, center-align, and add placeholder text\
Change Pos Y = 75\
Return to `PlayerController` in VS and add `public Text winText;`, `Start()... winText.text = "";`,
```
SetCountText()... 
if (count >= 10) // use number of Pickups here
{
  winText.text = "You Win!";
}
```
Return to game and test winning!

### [Part 8: Building the Game](https://www.youtube.com/watch?v=hSg3e1M3hKY)
File -> Build Settings...\
Add Open Scenes\
Build And Run\
Create new folder "Builds" and name build\
**Test game!**
