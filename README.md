# Module003HW5

## Problem

### MessageBox class
- Contain an 'async void Open()' method

- The method writes a message on the screen with the text that a window is open 
- then waits 3 seconds
- After that, a message is written that the window was closed by the user
- We call the event that the window is closed and pass the random value 'State' as a parameter
- Hold the event that the window was closed

### enum: 'State' = OK | Cancel

### in main, select the Open method and write to the console if State
- Ok - the operation was confirmed
- Cancel - the operation was rejected
