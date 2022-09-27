//Author: Juan Zaragoza
//Specialty: Graphical UIs
//Mail: zaragoza_9@csu.fullerton.edu

//Program name: Assignment #1
//Programming language: C#
//Date project began: 8-24-2022
//Date of last update: 8-25-2022

//Purpose: Demonstrate a user interface that displays an exit message with using shapes(ellipses)
//This is the main driver file that runs the form class from ExitUI.cs

//Files in this program: ExitMain.cs, ExitUI.cs, r.sh

//Status: Completed

//This file name: ExitMain.cs
//Compile this C# file:
//mcs -r:System.Windows.Forms.dll -r:System.Drawing.dll -r:UI.dll -out:Exit.exe ExitMain.cs

//System requirements: Linux system with Bash shell and package mono-complete installed.

using System;
using System.Windows.Forms;

public class ExitMain {
  public static void Main() {
    System.Console.WriteLine("This is the main driver for Assignment #1.");
    ExitUI UI_form = new ExitUI();
    Application.Run(UI_form);
    System.Console.WriteLine("The Assignment #1 program has ended.");
  } //End of Main method
} //End of ExitMain class
