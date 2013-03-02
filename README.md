AzureCodeCamp
=============

A repository for working on a demo application for the Calgary .net user's group's azure code camp.  The purpose is to provide a demonstration platform to show off some of the features of the Azure cloud environment. 

The plan is to start off with a very simple MVC application based in the cloud. To it we would then add SQL Azure persistence.  Then for data which doesn't need to be relational to break out the table storage. The application has some long running processes which we really shouldn't run on the web servers so those are put into a separate process: a worker process. However we need some way to talk to that process so communication is done using azure service bus. 

Thematically the application is based on the flapjack finder application provided by the Calgary stampede. For the uninitiated every summer in Calgary there is a week long festival. During this festival many companies provide free breakfasts of pancakes or flapjacks. In order to maximize the number of free breakfasts some people created a website a few years ago to list and track the breakfasts. An ambitious eater could make as many as a dozen breakfasts each day. 

This application attempts to duplicate that.


Applications
------------

The demo is made up of two real applications and a bunch of associated unit tests projects. 

**PancakeProwler.Web** - an ASP.net MVC web application which serves as the center of our project
**PancakeProwler.RecipeAssembler** - a worker process which builds a recipe book in PDF form and e-mails it to the user. In theory this process takes a long time so it is done asynchronously out of process

Potential projects
**PancakeProwler.Notifier** - a worker process which runs using a schedule to send out notifications to users
**PancakeProwler.TwitterWatcher** - a worker process which listens to twitter and replies with information on close by breakfasts


Team
----

The team consists of the devilishly handsome David Paquette, the dark knight of MVC Richard Reukema and some bloke named Simon.
