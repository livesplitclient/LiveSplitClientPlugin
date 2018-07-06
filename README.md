# LiveSplit Client Plugin

This LiveSplit plugin is intended for speedrunners with a 2 PC streaming setup that want their splits to display IGT or RTA no-load times.
This is to be used with the LiveSplit server plugin which can be found here https://github.com/LiveSplit/LiveSplit.Server/releases

SETUP

GAMING PC:

1. Download LiveSplit and the LiveSplit server plugin.
2. Add the plugin to your layout (Right-click > Edit Layout > + > Control > LiveSplit Server)
3. Add IGT or RTA no-load plugin for whatever game you are playing and set the timing method to "Game Time" (Right-click > Compare Against > Game Time)
4. Start the server (Right-click > Controls > Start Server) and start the timer (Right-click > Controls > Start)

STREAMING PC:

1. Download LiveSplit and the Client plugin
2. Add the plugin to your layout (Right-click > Edit Layout > + > Timer > Live Split Client)
3. Set the IP address of the server you set up (Right-click > Edit Layout > Layout Settings > LiveSplit Client tab > IP address)
4. Press the "Attempt Connection" button. It should say "Connected" under server status. If not make sure your IP address and port are correct and that the server is running.
5. Set the timing method to "Game Time" (Right-click > Compare Against > Game Time) and start the timer (Right-click > Controls > Start)

Your timers are now synced. Any changes on the Gaming PC timer should be reflected on the Streaming PC timer.
All actual splits should be saved on the Streaming PC. The gaming side is just for the game timer.


NOTES

To install plugins just add the .dll files to the "Components" folder in the LiveSplit folder.
Make sure to save the layouts after you set everything up so you don't have to do it every time you launch.
When launching the Gaming PC timer make sure to start the server. This will not happen automatically, unfortunately.

TROUBLESHOOTING

After making sure all steps in the setup were followed, make sure there is not something else controlling the timer on the Streaming PC. Make sure there are no game time or autosplitter plugins installed.
If it says "Connected" in the settings menu but the times don't match, make sure the Streaming PC "Compare Against" is set to "Game Time" and that the timer is started.
