# Asignio-Interns-Logging

Given a list of logs, display them in an user friendly format. Allow the user to query these logs in a variety of different parameters:

    •	User

    •	Date

    •	Type 

    •	Project

Then, allow user’s to flag/save certain logs as important to view later. This field would be null if no one flagged it, and string of the username of the person marking as important if marked as important. Then add a query filter that allows you to search for logs marked as important by a certain person.

8 Week Plan:

1.	Introduction

    a.	Introduction to the internship program and explanation of expectations

    b.	Meet the team and possibly do some teambuilding exercises with the other interns and other members of the team

    c.	GOAL: Understand the project given to you and what you are hoping to accomplish by the end of the summer

2.	MVC Introduction

    a.	Learn how MVC/CSHTML works
    
        i.	How to pass a model back to a view

        ii.	How to create the right model for what you need in your view

        iii.	Uses/benefits of using partial/shared views

    b.	Learn how to change pages in MVC

    c.	GOAL: Pass a model back from the controller and display its data in a view

3.	PetaPoco Introduction

    a.	Learn what PetaPoco is and how to use it
    
        i.	Look at the Get() example provided in the code given to them

        ii.	Look at the Update() example provided in the code

    b.	GOAL: Write a query that returns all logs for a given username and displays them on the screen

4.	Paging

    a.	Look at the example given on paging and use it to implement paging into the logging query

    b.	Add next and previous buttons to the results page to scroll through the pages

    c.	GOAL: Complete paging. Make sure paging works with a query as well (not just on all the data)

5.	Marking Logs as Important

    a.	Understand how PetaPoco can be used to update a database row
    
       i.	Don’t type in the update string

    b.	Add a field to each row that when pressed opens a modal dialog where you enter a username
    
       i.	Once a name is entered and the modal dialog is pressed, the Log’s ‘important’ field is updated to save the name entered

            1.	To update field, make sure an AJAX call is used

6.	More Querying

  a.	Add querying of type, Date, project, important.
  
    i.	Make sure query string is dynamically generated for each piece being queried (query string is added to for each parameter being queried one)

  b.	GOAL: Querying for other parameters is completed and being generated correctly. The ability to add a new type of query is a simple process, as the string is just being added to.

7.	Beautification

    a.	Use CSS to make pages more aesthetically pleasing
    
       i.	Make sure CSS is not done inline, but in a .css file so that it can be used across all pages

    b.	GOAL: Have a .css file with relevant styling in it. Make sure the items in the CSHTML are given the correct classes to utilize these CSS changes

8.	Presentation/Outro

    a.	Present final project to the team

    b.	Explain what you did and why you did it

    c.	Deliver code to a full developer to be reviewed and possibly added to the actual Asignio project

    d.	GOAL: Project is completed. Most, if not all goals were completed. Most, if not all, bugs have been found and fixed



