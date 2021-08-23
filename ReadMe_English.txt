Welcome to the AsterixDecoder application user manual, developed by a student from EETAC (Polytechnic University of Catalonia). This short summary will list the different options that the program has and will also serve as a user manual for its correct operation.

- - - - - - - - - - - - - - - - - - - - - - - - - OVERVIEW - - - - - - - - - - - - - - - - - - - - - - - - -

The objective of this project is to develop an ASTERIX (EUROCONTROL Surveillance Information Exchange) graphical reproducer and data analyzer software using C# language that is capable of decoding any ASTERIX file of air traffic (both surface, approach and route) from Spain and south of France for the following categories: CAT001 (Monoradar Data Target Reports), CAT002 (Monoradar Service Messages), CAT008 (Monoradar Derived Weather Information), CAT010 (Monosensor Surface Movement Data (SMR, MLAT)), CAT021 (ADS - B Messages), CAT034 (Transmission of Monoradar Service Messages), CAT048 (Monoradar Target Reports) and CAT062 (System Track Data).

The program, capable of analyzing up to two files at the same time, displays the radar data in table format, with the possibility of searching through chained filters. In addition, it shows the flights visually on a map to see their evolution over a period of time, with the option of adding airspace layers (Airways, TMAs, SIDs, STARs). It is possible to plot all the flights in the file at the same time or filter them according to fields of interest (callsign, category, radar station, time). It includes several extra options to give the user a more complete experience, such as, for example, extracting the information from the data table in a CSV file or generating a KML of the simulated flights to view it in Google Earth (3D).

This software developed is an innovative tool, since previously there was no possibility of comparing monoradar tracks (captured by radars) and SACTA tracks (processed and are those that are viewed by the controllers) in parallel through a Windows program. Mainly the application is focused for its use in ENAIRE, where there is a need to visualize the monoradar and multiradar tracks simultaneously on a map and thus be able to analyse their precision and look for ATC incidents on surveillance issues.


- - - - - - - - - - - - - - - - - - - - - - - - - GENERAL DESCRIPTION - - - - - - - - - - - - - - - - - - - - - - - - -

This application has 6 buttons, which are shown on the left side of the program.
1. The "Load File" button is used to load the files that the user wants (a maximum of two files in the simulation).
2. The "Select Time" button allows you to select the period of time of interest within the range of hours of the uploaded file.
3. A "Data View" button that allows you to see a table with all the data and with different options that will be detailed later.
4. A "Map View" button that offers the user a map that shows the movements of aircraft and land vehicles. It also offers different options for its configuration.
5. A "Clear File" button that removes previously loaded files.
6. Finally, an "Exit" button that allows the user to close the program.

This application has been optimized for proper operation and performance.


- - - - - - - - - - - - - - - - - - - - - - - - - LOAD FILE - - - - - - - - - - - - - - - - - - - - - - - - - 

First, once the program has been executed, the welcome screen will be displayed, with the AsterixDecoder logo in its center. To start the program you must click the "Load File" button, where the file explorer of your computer will open and you must select the file with a double click or with the open button.

If you select any other button before this step, a message will be displayed on the screen that a file has not been selected yet.

A maximum of two files can be loaded simultaneously (doing the process twice, not at the same time) and must be from the same time.

There are different filters when loading the file to detect if the second file complies with the range of hours of the first or if you are trying to load the same file by mistake. If the file you are trying to upload is not from ASTERIX data or from a category other than those analyzed, a message pops up saying that it cannot be decoded.


- - - - - - - - - - - - - - - - - - - - - - - - - SELECT TIME - - - - - - - - - - - - - - - - - - - - - - - - - 

Once the file has been successfully uploaded, the program displays a text message with the name of the uploaded file and the start and end time. Below are some text boxes in which you have to write the start and end time of interest. These fields have filters correcting the input format by the user and also if there are inconsistencies in the established times (for example, that they are outside the interval, the initial one is greater than the final one, etc.).

Because the files have a huge amount of data, and it is not possible to decode the entire file, a limitation of a 30min window has been set. Except for one type of file, those with surface radar data (CAT010 and CAT021), which does allow the entire time range of the file to be selected, since the data volume is less (they are 2-hour files unlike those of route that are 4 hours).

Once the hours have been selected, click on the lens icon and begin to decode the messages in the file. Depending on the interval entered, it will take more or less time to decode all the data. Once completed, a message is displayed indicating that it was successful and shows the number of decoded packets.

There is also the possibility of changing the period of time to be analyzed at any time, in case the user is interested in studying another moment within the time period of the file.


- - - - - - - - - - - - - - - - - - - - - - - - - DATA VIEW - - - - - - - - - - - - - - - - - - - - - - - - - 

Once the file to be analyzed has been loaded, its information can be displayed in table format. To do this, click on the "Data View" button from the menu that is displayed on the left. You will see in table format, in which the header indicates the field of that column, all the information that has been decoded, showing an N / A in cases where this information is not available for that file and a "Click to see info "or in some cells behind the data you will find an asterisk (*) indicating that if you click on that cell, all the information that, due to its large size, is not shown on the initial screen will be displayed in an additional window.
 
To facilitate the search for certain packages that may be of interest to the user, due to the large number of packages in each file and which are ordered numerically, a search engine located at the top has been incorporated. The user must click on one of the options offered to be able to filter by that field, write the package to search for in the text box and press the magnifying glass icon or using the Enter key. If the package has not been found, the red text box will be displayed. And the number of packages that have been filtered will also be shown in each search, located in the upper right corner.

In addition, another more dynamic search option, without having to use the text box, is the following: When you click on an element in the table, if it is enabled to be filtered, the packets that contain that specific field will automatically be filtered , seeing how the text box field is autocompleted with that element selected and the check box of the referred field is instantly marked.

To be able to filter more precisely, there is the possibility of making chained filters if the checkbox called “Chain Filters” is selected. This allows the user to search for very specific message groups.

To see all the packages again, click the restore arrow next to the browser.

Another functionality that it allows is to generate a CSV file from the data that is currently represented in the table (with or without filters). To obtain this file, which is saved in the user's download folder, you have to click on the icon with a sheet with the acronym CSV and then the program allows you to open it directly.


- - - - - - - - - - - - - - - - - - - - - - - - -  MAP VIEW - - - - - - - - - - - - - - - - - - - - - - - - - 

This button shows the graphical part of all the data, that is, the movement of aircraft and ground vehicles in a Google Maps application. You can customize the graphical interface of the map, being able to change the view to satellite in the "Layout" button, change the zoom to the user's liking by means of the mouse scroll over the map or with the zoom bar located below.

To start the complete simulation of all the aircraft, the user must select the "All Flights" button and then click the "play" button to see the simulation on Maps. The aircraft will be shown represented in points of different colors, each one of them referring to the type of surveillance system by which it has been captured. These data are detailed in the legend at the top.

On the left side of the map you can see a table detailing which aircraft are present at each moment of the simulation and relevant data for each one (CallSign, ICAO Address / Track Number, Mode 3 / A and number of sensors). If you click on a plane, its wake will be shown, in blue, of the entire route it will take.

To pause the simulation, click on the "Pause" button and to resume, click on "Play" again. And to restore the simulation and return to the beginning, being able to run it again or change to other parameters, you have to press the square "Stop" button.

Finally, there are different options that offer the user a more complete experience:

1. Only a single vehicle can be displayed by clicking on the "CallSign" column and then clicking "play". Once the plane is shown on the screen, an informative table appears with the most relevant data for that plane and you can click anywhere in the table and the entire route that the plane will take will appear in the color corresponding to the type of runway and its position. current in blue.

2. You can make a filter by different types of fields, such as showing only the desired category or sensor, selecting them in the respective columns "Category" or "Radar Station".

3. It is allowed to select the start time of the simulation (divided into 1 minute blocks) when there is more than one plane to simulate, selecting it in the "Initial Time" column.

4. You can view and hide elements of the airspace, such as aerodromes, ATZ, CTR, CTA, TMAs, SACTA sectors, airways, SIDs and STARs, by selecting the checkboxs found in the upper part of the map. Both airways, SIDs and STARs, if the "Tag" checkbox is selected, if a line is pressed, the name of that element appears. In the case of TMAs and SACTA sectors, if the “Tag” is marked, the name will appear within that volume.

5. The "Plot all" button shows all radar tracks of all aircraft or vehicles on the map, each plot represented with its color code.

6. Options are incorporated to increase the simulation speed, offering x2, x4, x8 and x16 speeds.

7. The start of the wake (from 1 to 10) of the monoradar track can be configured in the upper part where "Flight Trial" appears. By default, the start of the wake is set to three plots.

8. At any time the aircraft are graphically displayed on the map, the cursor can be placed over the points and the most significant data for that target will be displayed (UTC time, CallSign, ICAO, Track Number, Mode 3/A, FL).

9. At any time during the simulation (once the aircraft (s) have been selected, during or upon completion), the route (s) of the aircraft (s) can be exported ( s) in a KML file by clicking on the "KML" button that will be generated in the user's download folder. A pop-up window will open asking you if you want to view the file in Google Earth and if you accept, the application will open where you will see the path of the planes in 3D. If you want to see the vertical profile of a route, you must right-click on it and select "Show elevation profile".


- - - - - - - - - - - - - - - - - - - - - - - - - CLEAR FILE - - - - - - - - - - - - - - - - - - - - - - - - - 

This button allows you to delete previously loaded files at any time. A closing confirmation pop-up will open. This makes it easier to study several ASTERIX files without the need to open and close the program each time you want to analyze a new scenario.


- - - - - - - - - - - - - - - - - - - - - - - - - EXIT - - - - - - - - - - - - - - - - - - - - - - - - - 

There are two ways to exit the software. One is via the cross-shaped button on the upper right. If this button is pressed, a pop-up window is displayed asking the user if they want to close the program or if it was an error and they want to continue exploring.

Another is through the vertical menu button called “EXIT”, which when pressed, the same question is displayed underneath as with the pop-up window for closing confirmation. If you navigate to another tab without checking the answer, the dropdown is automatically hidden.


- - - - - - - - - - - - - - - - - - - - - - - - - CONTACT - - - - - - - - - - - - - - - - - - - - - - - - - 

For any additional questions or concerns, you can contact paabloop98@gmail.com

