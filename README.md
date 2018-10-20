# Just-Jump

## Hack UMass 2018
This project was developed as part of "HackUmass VI" Hackathon.

### Purpose:
Simple. We just wanted to improve quality of living, primarily by increasing fitness awareness. We know how well you used your gym yearly membership a few days following New Year’s day, and we have just what you need to incinerate those calories while jumping about with child-like joy! Just Jump is a running platformer game with a twist. You don’t leap across chasms by swiping on your phone – Instead, you take the leap yourselves! Worry not though, just jump whenever and wherever you feel like it.

### Tools and Technologies used:
We leveraged the powerful, well-trained Pose-Net model in tensorflow.js to acquire keypoints of body in real time. We then used computer vision techniques on this information to detect jumps. These signals were then communicated in real time to the 2D running platformer we made using Unity. This was achieved using Node.js for interprocess communication between the ts.js Pose-net model and our game. We used the Javascript scripting language for this purpose. In Unity, we developed the game using C# programming language.

### Demo
![Alt Text](https://github.com/Shishir-rmv/just-jump/blob/master/Final2.gif)

