# Toguz Korgool
---
### Created by:
##### - [Vladyslav Saliuk (VladSaliuk)](https://github.com/VladSaliuk)
##### - [Artem Ruchkin (RuchkinArtem)](https://github.com/RuchkinArtem)
---
We have created a desktop game based on the national kyrgyz game of **"Toguz Korgool"**.
As a main framework for the application we used WPF with C#.

Below is a step-by-step guide on how the game works and description of features that we have implemented.

---

## Introduction
The first thing you see when launching the game is the main menu:

![Main Menu](https://user-images.githubusercontent.com/72992745/121024926-f5f57400-c7a4-11eb-9678-d1030b9f62ef.png)

Let's cut to the chase and start the game itself. First, let's name our players as Bob and John, like on the picture below

![Main Menu with Names](https://user-images.githubusercontent.com/72992745/121024974-00b00900-c7a5-11eb-8eb0-5e4454c7fb63.png)

Now, when you press **'Enter'** under the names, they will be saved and later displayed in the game. To check if the naming was successful, check the popup window that will appear after pressing the **'Enter'** button.

![Name Set Popup](https://user-images.githubusercontent.com/72992745/121025025-0c033480-c7a5-11eb-9508-acf598e5f3f3.png)

If you don't set the names, the default names for players will be Player 1 and Player 2. Now, we can start the game by pressing the **'Start'** key

---

## The Game

![In Game 1](https://user-images.githubusercontent.com/72992745/121025103-1e7d6e00-c7a5-11eb-9674-26803ec45f59.png)

Now, the game window might look intimidating at first, but after explaining the rules it actually is quite simple.

As you can see, each player has **Holes**, numbered from 1 to 9 and each of them has a number of **balls** in it, displayed below the Hole number. At the start of the game each hole has 9 balls.

On the top-left and bottom-right corners of the screen you can see individual timers. Each player has in total 25 minutes to make their turns, like in chess.

On the top-left and bottom-right corners of the screen the players' scores are located. One of the ways to win the game is to reach a score larger than 81. 

Next, let's discuss how to reach that score and how the game works. The game is turn-based, but the player to have the first turn isn't decided yet, so each of them an make their first move. For example, Bob makes a turn from his Hole #3:

![In Game 2](https://user-images.githubusercontent.com/72992745/121025155-2b9a5d00-c7a5-11eb-970f-6b2680450d9b.png)

Now, when you make a turn from a certain hole, you take all the balls but the last one from it into your hand, and start distributing them into other holes in a counter-clockwise manner. So, Bob took 8 balls out of hole #3 and placed 1 ball in 8 closest holes counter-clockwise.

The last ball in his hand he placed in John's hole #2. Now, by the rules of the game, if the last ball you place ends up on enemy territory and if the resulting number of balls in that hole is even, you take all the balls from that hole and put them to your score. So, Bob has put the 10th ball into John's hole #2 and took all of the balls to his score, so now he has a score of 10.

If the ball ends up on your territory, or the number of holes is not even, you don't take anything to your score.


This is the gist of the game, so now, the next chapter will discuss some edge cases.

---
## Edge Cases
### Turn with just 1 ball
If you make a turn from a hole that has just one ball, just move that ball to the next hole counter-clockwise:
![One Turn 1](https://user-images.githubusercontent.com/72992745/121025191-3523c500-c7a5-11eb-8918-5783160a4b53.png)

If Bob makes a turn from his hole #3, the ball will just move to his hole #4

![One Turn 2](https://user-images.githubusercontent.com/72992745/121025241-4076f080-c7a5-11eb-92d7-b609af2eb965.png)

If the ball ends up on enemy territory, it can still take score or even make an ace if other conditions are true.

### Ace
If the last ball in your hand ends up on the enemy territory and the resulting number of holes is exactly equal to 3, then that hole become your ace. Now, any balls that end up on that hole will automatically go to your score.

![Ace 1](https://user-images.githubusercontent.com/72992745/121025283-48cf2b80-c7a5-11eb-8772-0df0a363dfa3.png)

Now, if Player 1 takes a turn from his hole #5, his last ball will end up at Player 2's Hole #6, which will result in an ace. Aces are highlighted with red.

![Ace 2](https://user-images.githubusercontent.com/72992745/121025310-4f5da300-c7a5-11eb-9c6f-9761089c5e9e.png)

- Each player can only have one ace
- Cannot be placed on Holes #9
- Cannot be placed on holes which number already has an ace. 

So, Player 1 has ace on Player 2's hole #6, so now, Player 2 cannot have his ace on Player 1's hole #6.

---

## Win Conditions
- Player has a score higher than 81
- Opponent has run out of time
- Opponent has run out of balls in his holes and cannot make a turn.

---
## Other Features
### Settings
Our game as a settings window, in which you can set timer time, disable the timer altogether or toggle the visibility of hole names.

![Settings](https://user-images.githubusercontent.com/72992745/121025322-5389c080-c7a5-11eb-9493-d6cba4166882.png)

### Statistics
Each finished game will be saved to a local txt file in a csv format, after which you can open the statistics window to see the local match history.

![Statistics](https://user-images.githubusercontent.com/72992745/121025341-597fa180-c7a5-11eb-9a5d-4b24a50d93c1.png)
