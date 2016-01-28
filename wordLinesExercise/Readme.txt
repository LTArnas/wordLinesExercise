Programming exercise
---------------------

Exercise description:

Given an arbitrary list of words and a line length, 
join the words together to form lines of the specified length. 
The last line and any lines containing only a single word may end with one or more spaces 
(however many are needed to meet the required line length). 
All others lines must begin and end with a word. 
Spacing of roughly equal length should be placed between the words, 
with the larger spaces occurring at the beginning of the line. 
In the last line, words should be separated by a single space, 
with the remaining space (if any) to the right of the last word of that line.

----------------------

Started at 2015/12/6 - 04:38
Ended at 2015/12/6 - 07:26

----------------------
How to use:
----------------------
(After looking at it again to put it up on Github,
I realised I didn't remember how to use the program; so, this.)

You run the .exe via command line, passing it the words.
Basically, it just uses the args string array 
that's defined in the entry point function, Main.
Therefore you type this:

	wordLinesExercise.exe word anotherWord someOtherWord bla bla blah etc

(That would be interpreted as you passing the program a list of 7 words.)
Basically, it uses space as the separator (at least, on my Windows 10).
I believe you can use quotes for phrases, but don't really know, try it out.
At the end, when all is said and done, it waits for a key press before it will exit.
Um, that's it, I guess.