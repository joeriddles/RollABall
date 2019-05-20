### Part 1: https://www.youtube.com/watch?v=W_fAidYRGzs
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
### Part 2: https://www.youtube.com/watch?v=7C7WWxUxPZE
Add `Rigidbody` to `Player` (test game now to watch ball fall)\
New folder `Scripts` -> create new C# script (and make sure attached to `Player`)\
Open script in VS\
Delete default code, add `FixedUpdate()`, which is called just before physics calculations\
Show Unity doc `Input`/`Input.GetAxis()`\
Add 
