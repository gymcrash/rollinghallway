# rollinghallway
Some code to demonstrate a configuration of infinite hallways for Unity

You can find the main code on the Main gameobject in the scene. You can provide from 1 to many hallways,
and it will loop through them infinitely in the order in which they are specified. 
The hallways must be prefabs, with dimensions of 4f*4f*20f. 
Of course, you can extend the code to dynamically calculate the dimensions based on each prefab provided, but that's up to you.

'w' moves forwards, 's' back. There is no backwards looping - walking back will let you break out, but implementing
backwards looping is a simple extension of forwards looping left as an excercise for the reader.

Finally, I've used ProBuilder (free with Unity) to build the simple hallways, so you might need to have that package installed. 

![Infinite hallways](https://i.imgur.com/tLjyuTw.mp4)