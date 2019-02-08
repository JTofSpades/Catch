Catch! v1.0.0
by Juron Townsend

To run the game, run Catch.cs.

This is a small game in a 1600 x 900 pixel window. The objective is to move your character around the window to obtain little pieces of "fruit" that are lying on the screen. There are 8 different characters you can choose
from and each have their own perks and quirks. Note: the game technically never ends as there isn't a score count. End it when necessary.



Choosing Characters:
There isn't a character select screen, so to choose your character, you're going to have to go into Form1.cs. There is a section blocked out by comments which say "CHOOSE HERE". These are the lines you'll be editing. The
very first parameter available is the player preset number. Here are the seperate abilities of each:

Preset 1 and Preset 2:
These two characters are polar opposites, however these two have the most average statistics in the game.
		* Preset 1 jumps slightly higher than Preset 2
		* Preset 2 moves slightly faster than Preset 1
Preset 3 and Preset 4:
These two characters are polar opposites, however these two touch the game statistic's best and worst extremities.
		* Preset 3 is the character than jumps the highest
		* Preset 3 is the character that moves the slowest
		* Preset 4 is the character that jumps the shortest
		* Preset 4 is the character that moves the fastest
Preset 5 and Preset 6:
These two characters are polar opposites, however these two really flips the game's mechanics upside down. It's because of their gravity flipping properties!
		* Preset 5 has the 2nd slowest move speed
		* Preset 5 has the 2nd shortest jump
		* Preset 6 has the 2nd fastest move speed
		* Preset 6 has the 2nd highest jump

		* Preset 5 can switch gravity 3 times
		* Preset 6 can switch gravity 0 times
	What's going on? Why does Preset 5's statistics say it can't switch gravity? That's surely unfair. It must have to do with their abilities (visit Abilities).
Preset 7 and Preset 8:
These two characters are polar opposites. Both of them are broken. One is coded to be played unfairly and the other is coded to be played unfairly. Only play these characters for fun.
		* Preset 7 actually has the fastest speed and the highest jump.
		* Preset 7's default statistics and abilities are high.
		* Preset 8 actually has the slowest speed and lowest jump.
		* Preset 8's default statistcs and abilities are low.
Preset 7 is broken in terms of "This preset is too good. Please nerf." Preset 8 is broken in terms of "This preset is horrible. Please buff." Don't worry, a character with Preset 8 can still catch fruit.


Abilities:
Each character has 3 abilities. To understand how they work more, visit the Important Mechanics section. The 3 abilities are as follows:
		* Super Jump: gives the character's jump much higher than their original jump height
		* Super Boost: gives the character's speed a huge boost to the side before returning to the character's maximum run speed
		* Gravity Flip: instantly stops the character's momentum and flips its gravity
Every time an ability is used, the player would have to reinput a direction if they want to continue moving. Super Jump and Super Boost have input locks on them until the character has moved the furthest it can before the
lock goes away. By default, the character after using Super Jump will fall to the ground and remain idle, and the character after using Super Boost will slow down, continuing in the same direction it had been.
Each ability has a default number of times it can be used before the character touches the ground. Super Jump and Gravity Flip can only be used once. Super Boost can be used twice.


Character Presets:
Each preset has default statics and some of them may be altered a little bit to balance the game further. A statistic resets when the player touches the ground. A quick list of statistics and defaults:
		* 1 Jump
		* Super Jump: 1
		* Super Boost: 2
		* Gravity Flip: 1
Of course, not all presets have all default values.
		* Preset 1: no changes
		* Preset 2: no changes
		* Preset 3:
			* 3 Jumps
		* Preset 4:
			* Super Boost: 3
		* Preset 5:
			* Gravity Flip: 3
		* Preset 6:
			* 2 Jumps
			* Super Jump: 2
			* Gravity Flip: 0
		* Preset 7:
			* 5 Jumps
			* Super Jump: 7
			* Super Boost: 7
			* Gravity Flip: 7
		* Preset 8:
			* Super Jump: 0
			* Super Boost: 0


Changing Name and Color:
The second parameter is how the character's name is set. It will appear at the bottom of the screen and will tell the player how many points it has scored. Type whatever is necessary in between the two quotation marks. Don't
make it very long, however. The text can cover up another player's name. Changing the color is easiest explained Catch! is being ran on an editing software like Visual Studio where it helps guide the user with code prompts.
The color parameter is the very last one and you can write which ever color necessary as long as the first letter is capitalized.



Controls:
	Player 1:
		Jump: W
		Move Left: A
		Stop Horizontal Momentum: S
		Move Right: D

		Super Jump: 1
		Super Boost: 2
		Gravity Flip: 3
		* these numbers are pressed on the top row

	Player 2:
		Jump: Up
		Move Left: Left
		Stop Horizontal Momentum: Down
		Move Right: Right

		Super Jump: H
		Super Boost: J
		Gravity Flip: K
		* the input for using abilities is indifferent to capitilization



Important Mechanics:
	Moving:
		* Pressing the run button to the left or right will have the character moving in that direction until something stops it.
		* After using Super Boost and inputting a direction the character is already going in will have character restart its dash.
		* Using jumps and Super Jumps multiple times will decrease the jump height until the character touches the ground.
	Edges:
		* Running into the left or right edge won't pop the character on the opposing side. It will flip the character's direction completely.
		* Your jumps and abilities are reset when the character hits the ground in respect to its gravity. If the gravity is facing downward, the character has to touch the bottom edge and vice versa.
	Abilities:
		* Super Jump locks all inputs from the player until the character finishes its jump. Then the character can move freely. Unless the player makes an input, the character will fall to the ground.
		* Super Boost locks all inputs from the player until the character finishes its dash. The faster the character, the sooner the lock is released. The character will continue in the direction it was just going.
		* Gravity Flip doesn't have a lock, but it does not retain either horizontal or vertical speeds, instantly freezing the character.
	Misc:
		* Players cannot clash.
		* There is port priority; if Player 1 gets the fruit at the same time as Player 2, Player 1 gets the fruit.


There will be a small guide printed in the console with controls and basic mechanics if help is needed.




Specific Statistcs:
I will not explain everything in here in great detail like I did in the instructions. All units will include pixels or milliseconds (Maybe centiseconds. I can't figure out C#'s Time class).


Jump Height:
The jump height is calculated with the jump speed. The speed works against the gravity, where the gravity for all presets is set at .8.

Preset:			1			2			3			4			5			6			7			8
v-initial:		-12			-11			-13			-8.22		-9.25		-12.55		-18.5		-5.8
dist of
v-i to 0:		-90.0		-75.6		-105.6		-42.2		-53.5		-98.4		-213.9		-21.0

Jump Height Decrements:
The formula is: (jumpMax - jumpUse) * .01 * v-i where jumpMax is the maximum number of jumps and jumpUse is the number of times jump was used already. The formula is only applied after the first jump is used.

Preset:			3			6			7
total dist:		-317.4		-197.0		-1071.8 (technically -900)


Move Speed:
Each character has an initial run speed, maximum run speed, and run acceleration. Here's a chart of the speeds of all presets.

Preset:			1			2			3			4			5			6			7			8
v-i:			2.5			3			2			3.95		2.1			3.25		5			1.25
v-maximum:		5.85		7			4			9			4.5			7.5			13			2
acc:			.1			.15			.09			.25			.095		.2			.35			.02
time from
v-i to v-m:		33.5		26.7		22.2		20.2		25.3		21.3		22.9		37.5

Here's a chart where the time elapsed reperesents the time it took the character with the preset to travel across the 1600pixel wide screen.

Preset:			1			2			3			4			5			6			7			8
t:				283.1		236.2		405.6		183.4		362.3		219.4		130.1		807.0


Super Jump:
This has the same effect as a normal jump. It takes the jump's v-i to get how high the character would jump. For Super Jumps, the v-i is multiplied by the constant 5.2 / 3. To find the distance, multiply the distance in the
Jump Height section by 4.

Preset:			1			2			3			4			5			6			7
v-i:			-20.8		-19.1		-22.5		-14.2		-16.0		-21.75		-32.1
t lock of
v-i to 0:		26.0		23.9		28.1		17.7		20.0		27.2		40.1

Super Jump Height Decrements:
The formula for decrementing the jump velocity is the same.

Preset:			6			7
total dist:		-592.6		-4518.3


Super Boost:
Every time a player uses Super Boost, the character travels the same distance of 400 pixels. The speed travelled is at 4.25 * v-i, then the character runs at v-m when the ability is over.

Preset:			1			2			3			4			5			6			7

v-i:			10.6		12.8		8.5			16.8		8.9			13.8		21.25
t lock:			37.6		31.4		47.1		23.8		44.8		29.0		18.8



How I Balance Catch!:

The game naturally benefits presets with fast v-is and v-ms because the screen's width is larger than the screen's height. It's takes longer for slower characters to reach a fruit across the screen than faster characters
and the players can't do much about that. This is why I implemented the ability locks. The character's horizontal movement stops after inputting Super Jump and Gravity Flip which hurts faster characters more than slower
characters because their speed isn't affected as heavily.

Another way the game naturally benefits presets with fast vs are with the vertical edges. If a slow character and a fast character were to have a race to the other side, obviously the faster character would win. Neither
character can go off the end of the screen and reappear on the other side of the screen in an attempt to cheese the other player's fruit. This gives a severe advantage to faster characters.

Alternatively, the game naturally benefits characters who make it to the ground faster. This is because, if an ability is used, all of the character's abilities would be set to its respective preset's default values. Faster
characters tend not to have high jump heights which would often mean that they have to switch gravity to catch the fruits. By doing so, those characters can't get to the opposite ground as quickly as they could if they
could instead jump [Remember: most presets have a Gravity Flip maximum of 1].

I have attempted to give slower characeters more of an edge by shortening faster character's jump heights more than I normally would have. Since it is a little easy for faster characters to miss fruits anyway, a shorter jump
can seriously hinder the player's ability to accurately depict if jumping for the fruit is worth it.


Specific Perks and Quirks of Each Preset:

Obviously, there are more perks and quirks each preset has than the descriptions I gave above. Even with the basic descriptions, they each have their unique playstyles:
		* Preset 1 and Preset 2:
			* Preset 1 and Preset 2 are the presets I would give to someone who is trying to figure out the game to see what it's like to play Standards. Play Preset 1 if you would want to learn Preset 3 and Preset 2 if you
			want to learn to play Preset 4. Since Preset 1 and Preset 2 are the most average of the presets (hence the name Standards), it warms up the player for major flaws, yet major benefits.
		* Preset 3:
			* Since Preset 3 can jump a total of 739 full pixels, this preset teaches the player to jump for the fruit, switch gravity for the fruit, and weigh the pros and cons of doing both and when to do it. Remember,
			gravity switches take a longer time to complete than jumping, however, if landing to the ground makes you lose more time than actually switching gravity, switching gravity is the better option.
			* Characters with slower presets tend to learn to balance their ability usage more. Since 3 is the slowest character in the game, you as the player need to know about how big of a distance 400 pixels is to
			sustain proficiency.
		* Preset 4:
			* This preset has a ridiculously fast run speed. It's a little easy to miss the fruit or to mess up switching gravity to catch other fruits. Precision is key when learning Preset 4.
	Preset 5 and Preset 6 tend to prove and disprove what I've said above about fast/slow and high jump/low jump characters. Their playstyles are that different.
		* Preset 5:
			* As the preset with a very slow speed and very low jump height, players using this preset needs to master Gravity Flip. The character can't get anywhere quickly enough without using Gravity Flip. Players can
			eliminate some time it takes to land by using Gravity Flip twice to catch a fruit.
			* Preset 5 players need to understand how important their other abilities are. Optimal Preset 5 gameplay utilizes these abilities in unique ways. Didn't mean to Gravity Flip? Do it again. Overshot your target
			using Super Boost? Any of the 3 abilities there would help you depending on the situation.
			* Fruit are more likely to spawn away from edges and towards the center (basic RNG magic). Preset 5 players should learn to optimize time airborne to have a bigger chance of getting fruit the player needs.
		* Preset 6:
			* Preset 6 is very unique to play where the preset can seem actually seem unbalanced. Yes, Preset 6 has a fast dash speed and a very high jump height. In fact, with combination of jump and Super Jump, Preset 6
			characters can touch the very top of the screen. Preset 6 players can easily mix up how they can catch fruit with its high Super Jump height.
			* However, those are its flaws. Firstly, you already know that Super Jump gives a character more lag if the amplitude of jump has a higher v-i. Preset 6 will have to spend a lot of time trying to get up to the
			top of the screen and it's not hard for someone else to Gravity Flip and beat the Preset 6 player to the fruit.
			* It takes Preset 6 characters a long time to fall to the ground after making it to the top. If the player just passes by a fruit, the player often times cannot jump or Super Jump up to catch it and have to fall
			to the ground to retry. Also, it is very hard to time inputs out of Super Jump and Super Boost accurately to minimize the time lost it would take to get to the ground.
	All in all, players who play Preset 5 and Preset 6 needs a good understanding of how to use their abilities in conjunction with minimizing its character's faults. Failure to do either, especially maximizing the
	effects of abilities, will lead to difficult times.
	Preset 7 and Preset 8 are obviously special presets. I'm not going to go over their perks and quirks.