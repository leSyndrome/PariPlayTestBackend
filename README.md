<h3>Islands !</h3>

<h4>Start</h4>
When you build and run the project a console will open, where youre asked to put in the size for a randomly generated matrix.</br>
After you've put in the desired size the matrix will be displayed followed by the island descriptions. Notice that if the input does not match the requirements a valid matrix will be generated anyway.

<h4>Assumptions</h4>
I assume that wildcards can only be added at the coast of an island, meaning an island like (1 0 1 1) is not possible, but I have abstracted the consideration of wildcards in a separate function, so their behaviour can be easily altered.

<h4>Code</h4>
The entry point for the program is the main function in Program.cs.</br>
All of the logic for calculating the islands is in Islands.cs.</br>
I store and pass islands as a list of indices in the matrix.
