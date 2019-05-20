New 3D project: “Rollable”
Save empty scene (or use sample scene)
3.	New GameObject -> 3D Object -> Plane “Ground”
4.	Reset Ground using gear menu in top right
5.	Gizmos -> Deselect show grid
6.	Set Ground scale x = 2, z = 2
7.	New sphere, reset origin, name “Player”
8.	Lift sphere above ground
9.	All new Unity scenes come with default skybox and sun light
10.	New folder “Materials”, new Material “Background” -> set Albedo (color)
11.	Change Directional Light rotation Y = 60 for better player lighting

12.	Add Rigidbody to Player (test game now to watch ball fall)
13.	New folder “Scripts” -> create new C# script (and make sure attached to player)
14.	Open script in VS
15.	Delete default code, add “FixedUpdate()”, called just before physics calculations
16.	Show unity doc “input”/”Input.GetAxis()”
17.	Add 
