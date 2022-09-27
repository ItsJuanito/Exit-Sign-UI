//Author: Juan Zaragoza
//Specialty: Graphical UIs
//Mail: zaragoza_9@csu.fullerton.edu

//Program name: Assignment #1
//Programming language: C#
//Date project began: 8-24-2022
//Date of last update: 8-28-2022

//Purpose: Demonstrate a user interface that displays an exit message with using shapes(ellipses)
//Also the program uses three panels which completely cover the form behind the panels.

//Files in this program: ExitMain.cs, ExitUI.cs, r.sh

//Status: In development

//This file name: ExitUI.cs
//Compile this C# file:
//mcs -target:library -r:System.Windows.Forms.dll -r:System.Drawing.dll -out:UI.dll ExitUI.cs

//System requirements: Linux system with Bash shell and package mono-complete installed.

using System;
using System.Drawing;
using System.Windows.Forms;

public class ExitUI : Form
{  //Declare attributes of the whole form.
   private const int formwidth = 1000;  //Horizontal width of the user interface.
   private const int formheight = 800;  //Vertical height of the user interface.
   private Size ui_size = new Size(formwidth,formheight);

   //Declare attributes of Header label.
   private String header_message_text = "Welcome to Assignment #1";
   private Label header_message = new Label();
   private Point header_message_location = new Point(100,5);
   private Font  header_message_font = new Font("Arial",15,FontStyle.Bold);
   private Size  header_message_size = new Size(200,40);

   //Declare attributes of Exit label
   private String exit_message_text = "EXIT";
   private Label exit_message = new Label();
   private Point exit_message_location = new Point(0,0);
   private Font  exit_message_font = new Font("Arial",58,FontStyle.Bold);
   private Size  exit_message_size = new Size(200,10);

   //Declare attributes of Header panel
   private const int header_panel_height = 60;
   private Panel header_panel = new Panel();
   private Point header_panel_location = new Point(0,0);
   private Size  header_panel_size = new Size(formwidth,header_panel_height);
   private Color header_panel_color = Color.Orange;

   //Declare attributes of Graphic panel
   private const int graphic_panel_height = 600;
   private Graphic_panel drawingpane = new Graphic_panel();
   private Point graphic_panel_location = new Point(0,header_panel_height);
   private Size  graphic_panel_size = new Size(formwidth,graphic_panel_height);
   private Color graphic_panel_color = Color.Navy;

   //Declare attributes of the Control panel.
   private const int control_panel_height = formheight-header_panel_height-graphic_panel_height;
   private Panel control_panel = new Panel();
   private Point control_panel_location = new Point(0,header_panel_height+graphic_panel_height);
   private Size  control_panel_size = new Size(formwidth,control_panel_height);
   private Color control_panel_color = Color.Orange;   //Color.LightYellow;

   //Declare attributes common to all the buttons that will appear on the Control panel.
   private const int button_height = 40;
   private const int button_width  = 120;
   private Size  button_size = new Size(button_width,button_height);

   //Declare attributes of the fill ellipse button that will appear on the Control panel.
   private Color fillellipse_button_color = Color.Navy;
   private Point fillellipse_button_location = new Point(300,20); //x, y
   private Button fillellipse_button = new Button();

   //Declare attributes of the exit button that will appear on the Control panel.
   private Color exit_button_color = Color.Navy;
   private Point exit_button_location = new Point(600,20); //x, y
   private Button exit_button = new Button();

   //Declare some mechanisms for managing the visibility of displayed geometric shapes.
   private static bool filled_ellipse_visible = false;

   public ExitUI()   //The constructor of this class
   {//Set the attributes of this form.
    Text = "Exit Sign";
    Size = ui_size;
    MaximumSize = ui_size;
    MinimumSize = ui_size;

    //Construct the top panel
    header_message.Text = "Exit Sign by Juan Zaragoza";  //header_message_text;
    header_message.Font = header_message_font;
    header_message.TextAlign = ContentAlignment.MiddleCenter;
    header_message.Size = new Size(800,50);
    header_message.Location = header_message_location;
    header_message.ForeColor = Color.White;
    header_panel.BackColor = header_panel_color;
    header_panel.Size = header_panel_size;
    header_panel.Location = header_panel_location;
    header_panel.Controls.Add(header_message);

    //Construct the middle panel EXIT sign
    exit_message.Text = "Exit";
    exit_message.Font = exit_message_font;
    exit_message.ForeColor = Color.White;
    exit_message.TextAlign = ContentAlignment.MiddleCenter;
    exit_message.Size = new Size(1000, 200);
    exit_message.Location = exit_message_location;
    exit_message.BackColor = Color.Navy;

    //Construct the middle panel also called the "graphic panel".
    drawingpane.BackColor = graphic_panel_color;
    drawingpane.Size = graphic_panel_size;
    drawingpane.Location = graphic_panel_location;

    //Construct the bottom panel also called the "control panel".
    control_panel.BackColor = control_panel_color;
    control_panel.Size = control_panel_size;
    control_panel.Location = control_panel_location;

    //Construct the fill ellipse button
    fillellipse_button.BackColor = fillellipse_button_color;
    fillellipse_button.Size = button_size;
    fillellipse_button.Location = fillellipse_button_location;
    fillellipse_button.Text = "Show";
    fillellipse_button.ForeColor = Color.White;
    fillellipse_button.TextAlign = ContentAlignment.MiddleCenter; //MiddleCenter
    fillellipse_button.Click += new EventHandler(fill_ellipse);
    fillellipse_button.TabIndex = 3;
    fillellipse_button.TabStop = true;

    //Construct the exit button
    exit_button.BackColor = exit_button_color;
    exit_button.Size = button_size;
    exit_button.Location = exit_button_location;
    exit_button.Text = "Quit";
    exit_button.ForeColor = Color.White;
    exit_button.TextAlign = ContentAlignment.MiddleCenter;
    exit_button.Click += new EventHandler(terminate_execution);
    exit_button.TabIndex = 4;
    exit_button.TabStop = true;

    //Add Exit message to the middle panel
    drawingpane.Controls.Add(exit_message);

    //Add buttons to the control panel
    control_panel.Controls.Add(fillellipse_button);
    control_panel.Controls.Add(exit_button);

    //Add panels to the UI form
    Controls.Add(header_panel);
    Controls.Add(drawingpane);
    Controls.Add(control_panel);

   }//End of constructor

   //Method to execute when the fill ellipse button receives a mouse click
   protected void fill_ellipse(Object sender, EventArgs h)
   {if(filled_ellipse_visible)
       {filled_ellipse_visible = false;
        //Change button text to "Show"
        fillellipse_button.Text = "Show";
       }
    else
       {filled_ellipse_visible = true;
        //Change button text to "Hide"
        fillellipse_button.Text = "Hide";
       }
    drawingpane.Invalidate();
   }//End of method fill_ellipse

   protected void terminate_execution(Object sender, EventArgs i)
   {System.Console.WriteLine("This program will end execution.");
    Close();
   }

   public class Graphic_panel: Panel            //Class Graphicpanel inherits from class Panel
   {public Graphic_panel()                      //Constructor for derived class Graphicpanel
    {Console.WriteLine("A graphic enabled panel was created");
    }//End of constructor

    //The next method is the OnPaint that belongs to the middle panel only.  The outputs from this
    //method are located according to the local Cartesian system of that middle panel.  The draw
    //methods called inside of this OnPaint can only output onto the middle panel alone.
    protected override void OnPaint(PaintEventArgs ee)
    {Graphics graph = ee.Graphics;

     // filled elllipse visible top arrow
     if(filled_ellipse_visible) graph.FillEllipse(Brushes.Orange, 690, 200, 25, 25); // x, y, w, h
     if(filled_ellipse_visible) graph.FillEllipse(Brushes.Orange, 750, 250, 25, 25); // x, y, w, h
     if(filled_ellipse_visible) graph.FillEllipse(Brushes.Orange, 810, 300, 25, 25); // x, y, w, h
     // filled elllipse visible middle arrow
     if(filled_ellipse_visible) graph.FillEllipse(Brushes.Orange, 120, 350, 25, 25); // x, y, w, h
     if(filled_ellipse_visible) graph.FillEllipse(Brushes.Orange, 190, 350, 25, 25); // x, y, w, h
     if(filled_ellipse_visible) graph.FillEllipse(Brushes.Orange, 270, 350, 25, 25); // x, y, w, h
     if(filled_ellipse_visible) graph.FillEllipse(Brushes.Orange, 360, 350, 25, 25); // x, y, w, h
     if(filled_ellipse_visible) graph.FillEllipse(Brushes.Orange, 440, 350, 25, 25); // x, y, w, h
     if(filled_ellipse_visible) graph.FillEllipse(Brushes.Orange, 520, 350, 25, 25); // x, y, w, h
     if(filled_ellipse_visible) graph.FillEllipse(Brushes.Orange, 600, 350, 25, 25); // x, y, w, h
     if(filled_ellipse_visible) graph.FillEllipse(Brushes.Orange, 680, 350, 25, 25); // x, y, w, h
     if(filled_ellipse_visible) graph.FillEllipse(Brushes.Orange, 760, 350, 25, 25); // x, y, w, h
     if(filled_ellipse_visible) graph.FillEllipse(Brushes.Orange, 840, 350, 25, 25); // x, y, w, h
     // filled elllipse visible bottom arrow
     if(filled_ellipse_visible) graph.FillEllipse(Brushes.Orange, 810, 400, 25, 25); // x, y, w, h
     if(filled_ellipse_visible) graph.FillEllipse(Brushes.Orange, 750, 440, 25, 25); // x, y, w, h
     if(filled_ellipse_visible) graph.FillEllipse(Brushes.Orange, 690, 490, 25, 25); // x, y, w, h

     base.OnPaint(ee);
    }//End of OnPaint belonging only to Graph Panel class.

   }//End of derived class Graphicpanel

}//End of class ExitUI
