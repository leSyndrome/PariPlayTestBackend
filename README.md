<h3>Islands !</h3>

<h4>Start</h4>
When you build and run the project a console will open. The first matrix to be processed is read from the file matrix.txt. Then you can enter dimentions to generate a random matrix. Notice that if the input dimensions do not match the requirements a valid matrix will be generated anyway. When a matrix is read or generated it will be displayed followed by the island descriptions.</br>

<h4>Reading from file</h4>
The file matrix.txt assumes correct input and espects the following format:
A single integer on each of the first two lines denoting n and m respectively, followed by n lines, each containing m space-separated integers.


<h4>Code</h4>
The entry point for the program is the main function in Program.cs.</br>
Matrix.cs contains a static class with matrix utilities.</br>
All the code defining island behaviour is in the files contained in the folder Islands.</br>
