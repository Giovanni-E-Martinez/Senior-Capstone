# Gate:Crash
### Repository for my CST-451 Senior Capstone project files and information.

<hr/>

## Introduction

### The idea:

This project is a 2D orthographic action adventure game. The design philosophy for the game environment and layout took inspiration from games in similar genres such as Metroid, where the player is dropped in a large space that they will be tasked with navigating. The core gameplay loop of the game will consist of selecting a loadout and objectives from a central hub area and proceeding to the larger environment, or map, where the player will have to complete those objectives and return safely by extracting from the map to collect their rewards. 

### The purpose:

The purpose of this project was to explore and experience the process of developing a game from the ground up. I wanted to learn about what it takes to create a concept for a game and then explore the different concepts and ideas that one can utilize when developing the groundwork for the game. Primarily, I wanted to explore the concept of creating a game that utilizes object oriented fundamentals like inheritence, polymorphism, and encapsulation.

<hr/>

## Functional and Non-Functional Requirements

### Functional Requirements:

- The player will be able to move in all directions and be able to attack.
- The game will allow the player to pause and unpause and choose to exit the match, or quit the game.
- The player should be allowed to converse and navigate dialogue with NPCs.
- The player should be able to choose their objective and enter a randomly generated map.
- The game should randomly generate a dungeon each time the player enters a match.
- The enemies should be able to navigate to and attack the player.

### Non-functional requirements:

- The game should be able to run smoothly on an machine with 8GB of ram, and a minimum Intel Iris graphics card at a constant 60 frames per second.

<hr/>

## Technologies and Practices

### Technologies:

- The game was created on the Unity Engine, using the Unity Development Environment. This is because it is the single largest free to use video game development platform, which allows me to quickly find resources that would allow me to find solutions to problems or suggestions for implementations. It was also the only platform that I have had prior experience and knowldge about, which would help me get a quick foothold.
- The game was made using C#, as this is the language supported by the Unity Engine.
- The IDEs that I used were Visual Studio and Visual Studio Code, as these were the two IDEs that offered out of the box support with Unity and all of its features and componenets.
- Assets were created using Aseprite, which is a software created with the intention of creating and animating pixel art, and music and sounds were either acquired from the Unity Asset Store, or made in Studio One 5 and Audacity. These were all chosen becuase they were all software that I already have access to or have purchsed in the past.

### Practices:

The features and components of the game were created using many Objected Oriented Programming principles, such as object inheritence, encapsulation, and polymorphism. Additionally, the main structure of the systems designed for entity and player action were developed as a finite state machine, which is a structure that allows me to created specified states that allow certain actions to take place at a time and reduce the amount of overlap between scripts. This helped create a stronger seperation of concerns, as no single script was in charge of handling too many events.

<hr/>

## Learning and Research

Any new technologies or practices that I was using for the development of the project were learned through the use of related and helpful YouTube tutorials and online articles that discussed the topics in details. I also navigated through forums that were created to seek assistance with problems that I also faced during development. The reason that I chose to use this structure is that it is a popular and widely applicable form of development in many types of software related fields, not just video game development. Additionally, I learned how to properly leverage the tools and features that are provided to me by the software I used.

The primary YouTube channels that I frequently referenced were [Bardent](https://www.youtube.com/@Bardent), [Brackeys](https://www.youtube.com/@Brackeys), [Code Monkey](https://www.youtube.com/@CodeMonkeyUnity), and [Black Thorn Prod](https://www.youtube.com/@Blackthornprod).

<hr/>

## Technical Approach

As stated previously, I decided to make the most of the tools presented to me by the Unity environment. In order to accomplish this I leveraged two main features of Unity: The ability to create scriptable objects which allowed me to created reusable assets that could be designed exactly how I needed them to be and also maintained data persistence, and the state machine structure that was mentioned previously.

Below is an example UML diagram that displays the design and structure of the state machine that was created for the player game object.

![PlayerStateMachineUML drawio](https://user-images.githubusercontent.com/91548925/235070758-0da7391f-cc76-4190-814f-b2381e856ee1.png)

The following diagram is the flow chart that describes the basic flow of the game from the main menu, to an instance of the game.

![image](https://user-images.githubusercontent.com/91548925/235071217-bf3aa771-7edc-4d74-a3c2-917d0b5655c6.png)

The final image is an example of the wire frames used when story boarding the flow of the game and how the scenes should function.

![image](https://user-images.githubusercontent.com/91548925/235071352-e29076ef-74a3-47fe-809c-f56ffbdc0bfe.png)

<hr/>

## Challenges and Risks

The main challenge of this project was building an entire game from scratch without any real experience with putting together such a large scale project before. This meant that every step that I took in development was met with more questions than answers and many wild goose chases when searching for specific information or examples of an implementation for my unique use case. This also meant that I was constantly at risk of reaching a point where a particular feature or idea would become unfeasable or too large of a scope that initially intended, leading to many of the original ideas and features being cut.

## Outstanding Issues

At the moment there are three glaring issues that I was unfortunately unable to address/implement before the final code release.

- The first of these was the NPC dialogue and menu system that I had originally planned, which would have allowed the player to select their equipment and objective before the match, in order to increase the level of player control and customization.
- The second is the ability for the game to properly track the progress of a match while the player is playing, which means that the game has no idea once a mission is completed.
- The third was the fact that there is no ability for the player to be able to save and load their progress.

## Conclusion

Thank you for reading and exploring the progress and growth that I made during the development of this project! Below is the documentation of the project from CST-451 onward.

<hr/>

### Project Proposal:

<a href="Documentation/CST-451-RS-ProjectProposal.pdf">CST-451-RS-ProjectProposal</a>

### Requirements Document:

<a href="Documentation/CST-451 Project Requirements.pdf">CST-451 Project Requirements</a>

### User Stories:

<a href="Documentation/CST-452 User Stories.xls">CST-451 User Stories</a>

### Design Document:

<a href="Documentation/CST-451 Project Design.pdf">CST-451 Project Design</a>

### Test Cases:

<a href="Documentation/CST-452 Test Cases.xls">CST-452 Test Case Document</a>

### Traceability Matrix:

<a href="Documentation/CST-452 Traceability Matrix.xls">CST-452 Test Case Document</a>

<hr/>

### Release Notes & Updates:

- 2/13/2023 V.0.3.1 Release - <a href="Documentation/Milestone 1 - Release Notes 0.3.1.pdf">CST-452 Test Case Document</a>
- 3/24/2023 V.0.4.1 Update - <a href="Documentation/v0-4-1-notes.md">Update Notes</a>
- 4/26/2023 V.0.5.1 Final Submission - <a href="Documentation/Milestone 3 - Release Notes 1.0.0.pdf">CST-452 Final Release<a/>
