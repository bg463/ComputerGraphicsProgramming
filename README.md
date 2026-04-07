# ComputerGraphicsProgramming

This repository contains my completed solutions for the Computer Graphics Programming practical exercises.

## Repository Structure

Each week is stored in its own folder:

- `wk1` - Simple WinForms drawing exercise with an added circle inside a square.
- `wk2` - Recursive triangle drawing using midpoints until the shape becomes smaller than 1 pixel.
- `wk3` - XOR-style moving square animation based on `FillReversibleRectangle()`.
- `wk4` - Double buffering exercise with a bouncing square and reduced flicker.
- `wk5` - Shape representation exercise using a `Points` table and a `Line` table with one `DrawLine()` call inside one loop.
- `wk6` - Console-based 2x2 matrix multiplication using `Matrix2D` and `MatrixMultiplier`.
- `wk7` - Custom 2D rotation using a `Tmatrix` class instead of the built-in GDI `Matrix` class.

## Running The Exercises

Each week folder includes the relevant source files and a built executable.

Typical examples:

- `wk1\SimpleDrawing.exe`
- `wk2\Triangles.exe`
- `wk3\XORDrawing.exe`
- `wk4\Flicker.exe`
- `wk5\ShapeRepresentation.exe`
- `wk6\MatrixMultiplier.exe`
- `wk7\CustomTransforms.exe`

For week 6, the program is a console application, so it prints the matrix multiplication result in a terminal window instead of opening a graphics window.

## Notes

- The portfolio work was based on the assessed task from each weekly practical sheet.
- WinForms exercises were implemented as standalone applications for each week.
- Week 6 was implemented as a console app because the exercise sheet specifically called for that approach.
