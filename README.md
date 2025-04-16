# ToDoListTracker
A simple todo list tracker that currently just stores todo lists and tasks in memory (aka you close down the app, your lists are gone)
Android only - easily can add ios with a new proj file changes

A few notes on this project:

Built with vs code and Rider on mac environment
No personal windows system to test on Visual Studio (since vs for mac no longer supported) - was unable to guarntee it ran smoothly on Visual Studio for windows
Notes - would typically separate out Services and View Models (for large projects especially) into separate projects - overkill for this simple application to show MVVM standards

Thoughts on singleton service to maintain active list - hit or miss for me. Played with using some navigation parameters instead. Ultimately decided to stick with simplicity.
Future additions to service - save to cloud db, local db like SQLLite, or even for this small of an app the local storage build into maui

Other future improvements:
* cleaner styles
* add theming and dynamic resources - as you will see here - hard coded colors
* do something with the due date - sort tasks and send push
* some entry focusing and unfocusing is weird in android but works out of box in iOS - if time before this is reviewed, i am fixing that
