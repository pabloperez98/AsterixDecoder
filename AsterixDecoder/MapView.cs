using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using FlightDataItems;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Xml;
using System.IO;
using Microsoft.Win32;
using System.Reflection;

namespace AsterixDecoder
{
    public partial class MapView : Form
    {
        public AsterixData data;
        public List<double> InitialTimeSimulationList = new List<double>();
        //Simulation control parameter tables
        DataTable CATtable = new DataTable();
        DataTable DSItable = new DataTable();
        DataTable UTCtable = new DataTable();
        DataTable FlightTable = new DataTable();
        DataTable InfoTable = new DataTable();
        //Times
        double initialTime;
        double actualTime;
        double finalTime;
        //Bitmaps
        Bitmap blackPoint; // CAT01
        Bitmap pistachioPoint; // CAT 10 SMR
        Bitmap purplePoint; // CAT 10 MLAT
        Bitmap redPoint; // CAT21
        Bitmap greenPoint; // CAT48
        Bitmap orangePoint; // CAT62
        Bitmap bluePoint; // Trail
        Bitmap blueTriangle;
        Bitmap greenCross;
        // Map layers
        GMarkerGoogle point;
        GMapOverlay pointsOverlayVariableTrail = new GMapOverlay("Points Variable Trail");
        GMapOverlay pointsOverlayFullTrail = new GMapOverlay("Points Full Trial");
        GMapOverlay aerodromesOverlay = new GMapOverlay("Aerodromes");
        GMapOverlay ATZ_CTR_CTA_Overlay = new GMapOverlay("ATZ_CTR_CTA");
        GMapOverlay TMA_BCN_Overlay = new GMapOverlay("TMA BCN");
        GMapOverlay TMA_VAL_Overlay = new GMapOverlay("TMA VAL");
        GMapOverlay SactaSectorsOverlay = new GMapOverlay("Sacta Sectors");
        GMapOverlay airwaysOverlay = new GMapOverlay("Airways");
        GMapOverlay SIDproceduresOverlay = new GMapOverlay("SID Procedures");
        GMapOverlay STARproceduresOverlay = new GMapOverlay("STAR Procedures");
        GMapOverlay SactaContourOverlay = new GMapOverlay("Sacta Contour");
        GMapOverlay fixedPointsAirwaysOverlay = new GMapOverlay("Fixed Points Airways");
        GMapOverlay SactaSectorsTagOverlay = new GMapOverlay("Sacta Sectors Tag");
        GMapOverlay TMA_BCN_Tag_Overlay = new GMapOverlay("TMA BCN Tag");
        GMapOverlay TMA_VAL_Tag_Overlay = new GMapOverlay("TMA VAL Tag");
        GMapOverlay clickedRoutesOverlay = new GMapOverlay("Clicked Routes");
        // Filtered aircraft to simulate
        List<Flight> selectedFlights;
        Flight clickedFlight;
        // Variables to know which row has been selected from the simulation info gridView
        int selectedRow; object[] IDclickedFlight;
        // Control of the variable all selected flights
        Boolean allFlightsSelected = false;
        int clicksAllFlightsButton;
        // Invert aircraft / trail colors
        Boolean invertColors = false;

        public MapView()
        { InitializeComponent(); }

        //Función que obtiene el tiempo inicial y final de la simulación
        public void obtainInitialAndFinalTimeAllFlights()
        {
            initialTime = data.listaCATs[0].timeOfDay.seconds;
            actualTime = initialTime;
            finalTime = data.listaCATs[data.listaCATs.Count - 1].timeOfDay.seconds;
        }

        // Rescale the points function (Bitmap)
        public Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            g.DrawImage(bmp, 0, 0, width, height);
            return result;
        }

        // Function that fills in the datagridView of the different simulation control parameters
        public void fillGridView(DataGridView gridView, DataTable table, string ID)
        {
            gridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Bahnschrift Condensed", 14F, FontStyle.Regular);
            gridView.DefaultCellStyle.Font = new Font("Bahnschrift Light", 10F, FontStyle.Regular);
            gridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridView.DefaultCellStyle.ForeColor = Color.Black;
            if (ID == "CAT")
            {
                table.Columns.Add("CATEGORY");
                data.CATsList.Sort();
                for (int i = 0; i < data.CATsList.Count; i++)
                { if (data.CATsList[i] != "02" && data.CATsList[i] != "08" && data.CATsList[i] != "34")
                        table.Rows.Add(data.CATsList[i]); }
            }
            if (ID == "DSI")
            {
                table.Columns.Add("RADAR STATION");
                data.SensorList.Sort();
                for (int i = 0; i < data.SensorList.Count; i++)
                    table.Rows.Add(data.SensorList[i]);
            }
            if (ID == "UTC")
            {
                table.Columns.Add("INITIAL TIME");
                obtainInitialAndFinalTimeAllFlights();
                double endTimeList = finalTime;
                if (finalTime < initialTime)
                    endTimeList = 86400;
                for (double i = actualTime; i <= endTimeList; i += 60)
                {
                    if (i != actualTime && Math.Truncate(i) % 10 != 0)
                        i -= Math.Truncate(i) % 10;
                    InitialTimeSimulationList.Add(i);
                }
                for (int i = 0; i < InitialTimeSimulationList.Count; i++)
                {
                    if (InitialTimeSimulationList[i] == 86400)
                        table.Rows.Add(TimeOfDay.obtainTimeUTC(0));
                    else
                        table.Rows.Add(TimeOfDay.obtainTimeUTC(InitialTimeSimulationList[i]));
                }
            }
            if (ID == "FLIGHT")
            {
                if (data.CallsignList.Count != 0)
                {
                    data.CallsignList.Sort();
                    table.Columns.Add("CALLSIGN");
                    for (int i = 0; i < data.CallsignList.Count; i++)
                        table.Rows.Add(data.CallsignList[i]);
                }
                else
                {
                    table.Columns.Add("TRACK Nº");
                    for (int i = 0; i < data.TrackNumberList.Count; i++)
                        table.Rows.Add(data.TrackNumberList[i]);
                }
            }
            gridView.DataSource = table;
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            foreach (DataGridViewColumn column in gridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // Function that plots the selected aircraft list on the map
        public void plotFlightsAndTable(List<Flight> FlightList)
        {
            foreach (Flight flight in FlightList)
            {
                if (flight.index < flight.seconds.Count)
                {
                    while (flight.seconds[flight.index] == actualTime)
                    {
                        // If only an aircraft is shown, zoom in on its initial position or if there is a very large position change
                        if (FlightList.Count == 1 && flight.index == 0)
                        { gMap.Position = new PointLatLng(flight.latitude[flight.index], flight.longitude[flight.index]); gMap.Zoom = 10; }
                        // Generate a point and asign the corresponding color
                        Bitmap colorPoint;
                        if (flight.category[flight.index] == "10" && data.RadarStationList.Find(r => r.radarStation == flight.sensor[flight.index]).type == "SMR")
                            colorPoint = pistachioPoint;
                        else if (flight.category[flight.index] == "10" && data.RadarStationList.Find(r => r.radarStation == flight.sensor[flight.index]).type == "SMMS")
                            colorPoint = purplePoint;
                        else if (flight.category[flight.index] == "21")
                            colorPoint = redPoint;
                        else if (flight.category[flight.index] == "48")
                            colorPoint = greenPoint;
                        else if (flight.category[flight.index] == "62")
                            colorPoint = orangePoint;
                        else
                            colorPoint = blackPoint;
                        if (invertColors) // If  info table of a single aircraft is clicked, change the color of the trail
                        {
                            point = new GMarkerGoogle(new PointLatLng(flight.latitude[flight.index], flight.longitude[flight.index]), bluePoint);
                            bluePointIcon.Visible = true; flightTrailLabel.Text = "ACTUAL POSITION"; flightTrailLabel.Visible = true;
                        }
                        else 
                            point = new GMarkerGoogle(new PointLatLng(flight.latitude[flight.index], flight.longitude[flight.index]), colorPoint);
                        // Adding the labels to the aircrafts depending on the type of CAT
                        point.ToolTipText = string.Format("Callsign: {0}\nICAO: {1}\nTrack Number: {2}\nMode 3/A: {3}\nSensor: {4}\nUTC Time: {5}\nFL: {6}", flight.callsign, flight.ICAOadress, flight.trackNumber[flight.index], flight.mode3A, flight.sensor[flight.index], TimeOfDay.obtainTimeUTC(flight.decimalSeconds[flight.index]), flight.FL[flight.index]);
                        point.Tag = string.Format(flight.index.ToString());
                        // Adding the point to the list of points of that flight
                        flight.pointList.Add(point);
                        // Refreshment from an aircraft table
                        if (selectedFlights.Count == 1)
                        {
                            InfoTable.Rows.Clear();
                            InfoTable.Rows.Add("CALLSING", flight.callsign); InfoTable.Rows.Add("ICAO", flight.ICAOadress); InfoTable.Rows.Add("Track Number", flight.trackNumber[flight.index]);
                            InfoTable.Rows.Add("Mode 3/A", flight.mode3A); InfoTable.Rows.Add("Sensors Nº", flight.sensor.Distinct().Count()); InfoTable.Rows.Add("Packets", flight.index + 1 + "/" + flight.seconds.Count);
                        }
                        // Adding the new flight to the table of several planes (SMR -> Track Nº, others -> ICAO)
                        else if (selectedFlights.Count != 1 && flight.pointList.Count == 1 && data.RadarStationList.Find(r => r.radarStation == flight.sensor[0]).type == "SMR")
                            InfoTable.Rows.Add(flight.callsign, flight.trackNumber[flight.index], flight.mode3A, flight.sensor.Distinct().Count()); 
                        else if (selectedFlights.Count != 1 && flight.pointList.Count == 1)
                            InfoTable.Rows.Add(flight.callsign, flight.ICAOadress, flight.mode3A, flight.sensor.Distinct().Count());
                        // Adding the point to the layer
                        pointsOverlayVariableTrail.Markers.Add(point);
                        // Counting the trail points that has that flight detected by each sensor independent (to plot all sensors of the flight)
                        int actualPointsTrail = pointsOverlayVariableTrail.Markers.AsEnumerable().Count(r => r.ToolTipText.Contains(flight.callsign) && r.ToolTipText.Contains(flight.mode3A) && r.ToolTipText.Contains(flight.trackNumber[flight.index]));

                        // Delete the trail if more than n points of that aircraft are plotted on the map specified by the user
                        while (actualPointsTrail > Convert.ToInt32(trailNumberLabel.Text))
                        {
                            pointsOverlayVariableTrail.Markers.Remove(pointsOverlayVariableTrail.Markers.AsEnumerable().FirstOrDefault(r => r.ToolTipText.Contains(flight.callsign) && r.ToolTipText.Contains(flight.mode3A) && r.ToolTipText.Contains(flight.trackNumber[flight.index])));
                            actualPointsTrail = pointsOverlayVariableTrail.Markers.AsEnumerable().Count(r => r.ToolTipText.Contains(flight.callsign) && r.ToolTipText.Contains(flight.mode3A) && r.ToolTipText.Contains(flight.trackNumber[flight.index]));
                        }
                        flight.index++;
                        // If the aircraft has reached the last second of simulation exit the loop
                        if (flight.index == flight.seconds.Count)
                            break;
                    }
                    // Show the gridView refreshed
                    infoSimulationGridView.DataSource = InfoTable;
                    infoSimulationGridView.ClearSelection();
                    infoSimulationGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    foreach (DataGridViewColumn column in infoSimulationGridView.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    if (selectedFlights.Count != 1)
                    {
                        if (infoSimulationGridView.Rows.Count != 0)
                        {
                            infoSimulationGridView.FirstDisplayedScrollingRowIndex = selectedRow;
                            infoSimulationGridView.Rows[selectedRow].Selected = true;
                        }
                    }
                }
                // If it is the last point of the flight, erase it from the map and table
                else if (flight.index == flight.seconds.Count && InfoTable.AsEnumerable().FirstOrDefault(r => r[" CALLSIGN "].ToString() == flight.callsign && r["MODE 3/A"].ToString() == flight.mode3A && (flight.trackNumber.Contains(r["ICAO/TRACK Nº"].ToString()) || r["ICAO/TRACK Nº"].ToString() == flight.ICAOadress)) != null)
                {
                    for (int j = 0; j < pointsOverlayVariableTrail.Markers.Count; j++)
                    {
                        
                        if (pointsOverlayVariableTrail.Markers[j].ToolTipText.Contains(flight.callsign) && flight.callsign != "N/A")
                        { pointsOverlayVariableTrail.Markers.RemoveAt(j); j--; }
                        else if (pointsOverlayVariableTrail.Markers[j].ToolTipText.Contains(flight.mode3A) && flight.mode3A != "N/A")
                        { pointsOverlayVariableTrail.Markers.RemoveAt(j); j--; }
                        else if (pointsOverlayVariableTrail.Markers[j].ToolTipText.Contains(flight.trackNumber[flight.index - 1]) && flight.trackNumber[flight.index - 1] != "N/A")
                        { pointsOverlayVariableTrail.Markers.RemoveAt(j); j--; }
                    }
                    // Find row that is wanted to be deleted
                    DataRow toBeDeletedRow = InfoTable.AsEnumerable().FirstOrDefault(r => r[" CALLSIGN "].ToString() == flight.callsign && r["MODE 3/A"].ToString() == flight.mode3A && (flight.trackNumber.Contains(r["ICAO/TRACK Nº"].ToString()) || r["ICAO/TRACK Nº"].ToString() == flight.ICAOadress));
                    if (InfoTable.Rows.IndexOf(toBeDeletedRow) < selectedRow)
                        selectedRow--;  
                    toBeDeletedRow.Delete();
                    // Delete the trail and the selected row if the aircraft has finished the simulation
                    if (IDclickedFlight != null)
                    {
                        if (IDclickedFlight[0].ToString() == flight.callsign && IDclickedFlight[2].ToString() == flight.mode3A && (flight.trackNumber.Contains(IDclickedFlight[1].ToString()) || flight.ICAOadress == IDclickedFlight[1].ToString()))
                        { pointsOverlayFullTrail.Markers.Clear(); selectedRow = 0; }
                    }
                }
            }
        }

        // Function that establishes the starting indexes of each plane with respect to the time chosen for the simulation
        public void setIndexFlights()
        {
            pointsOverlayVariableTrail.Markers.Clear();
            foreach (Flight flight in selectedFlights)
            {
                flight.index = 0; flight.pointList.Clear();
                for (int i = 0; i < flight.seconds.Count; i++)
                {
                    if (flight.seconds[flight.index] < actualTime)
                        flight.index++;
                    if (flight.index > 0 && flight.index < flight.seconds.Count )
                    { if (flight.seconds[flight.index] - flight.seconds[flight.index - 1] > 86000)
                        break; }
                }
            }
        }

        // Function that selects by default the start time of the simulation and activates and displays all its labels
        public void showActualTime()
        {
            timeUTCLabel.Text = TimeOfDay.obtainTimeUTC(actualTime);
            startSimulationLabel.Text = "START SIMULATION: " + TimeOfDay.obtainTimeUTC(actualTime);
            startSimulationLabel.Visible = true;
            endSimulationLabel.Text = "END SIMULATION: " + TimeOfDay.obtainTimeUTC(finalTime);
            endSimulationLabel.Visible = true;
        }

        public void readKMLs()
        {
            fillAirTrafficLayers(Assembly.GetExecutingAssembly().GetManifestResourceStream("AsterixDecoder.Resources.Aerovias.kml"), "Aerovias.kml", "Puntos Fijos", "Folder");
            fillAirTrafficLayers(Assembly.GetExecutingAssembly().GetManifestResourceStream("AsterixDecoder.Resources.Aerovias.kml"), "Aerovias.kml", "Aerovías", "Folder");
            fillAirTrafficLayers(Assembly.GetExecutingAssembly().GetManifestResourceStream("AsterixDecoder.Resources.ATZ_CTR_CTA.kml"), "ATZ_CTR_CTA.kml", "Airspace_Dissolve2", "Folder");
            fillAirTrafficLayers(Assembly.GetExecutingAssembly().GetManifestResourceStream("AsterixDecoder.Resources.Procedimientos.kml"), "Procedimientos.kml", "Aeródromo", "Folder");
            fillAirTrafficLayers(Assembly.GetExecutingAssembly().GetManifestResourceStream("AsterixDecoder.Resources.Procedimientos.kml"), "Procedimientos.kml", "Procedimientos SID", "Folder");
            fillAirTrafficLayers(Assembly.GetExecutingAssembly().GetManifestResourceStream("AsterixDecoder.Resources.Procedimientos.kml"), "Procedimientos.kml", "Procedimientos STAR", "Folder");
            fillAirTrafficLayers(Assembly.GetExecutingAssembly().GetManifestResourceStream("AsterixDecoder.Resources.Sectores y Contornos Base FIR.kml"), "Sectores y Contornos Base FIR.kml", "Sectores Sacta", "Folder");
            fillAirTrafficLayers(Assembly.GetExecutingAssembly().GetManifestResourceStream("AsterixDecoder.Resources.Aerovias.kml"), "Aerovias.kml", "Contorno Sacta", "Folder");
            fillAirTrafficLayers(Assembly.GetExecutingAssembly().GetManifestResourceStream("AsterixDecoder.Resources.TMABCN.kml"), "TMABCN.kml", "1.57d00aaaa7d00aaaa", "Document");
            fillAirTrafficLayers(Assembly.GetExecutingAssembly().GetManifestResourceStream("AsterixDecoder.Resources.TMABCN_tag.kml"), "TMABCN_tag.kml", "7d00aaaa0.8", "Document");
            fillAirTrafficLayers(Assembly.GetExecutingAssembly().GetManifestResourceStream("AsterixDecoder.Resources.TMAVAL.kml"), "TMAVAL.kml", "1.57d00aaaa7d00aaaa", "Document");
            fillAirTrafficLayers(Assembly.GetExecutingAssembly().GetManifestResourceStream("AsterixDecoder.Resources.TMAVAL_tag.kml"), "TMAVAL_tag.kml", "7d00aaaa0.8", "Document");
        }

        public void createRoute(XmlNode childNode, Color color, GMapOverlay overlay)
        {
            GMapRoute route = new GMapRoute(childNode["name"].InnerText);
            route.Stroke = new Pen(color, 3 / 2); //width and color of line
            string latitude; string longitude;
            string[] coordinates = childNode["LineString"]["coordinates"].InnerText.Split(' ');
            for (int i = 0; i < coordinates.Length - 1; i++)
            {
                latitude = coordinates[i].Split(',')[1].Replace('.', ',');
                longitude = coordinates[i].Split(',')[0].Replace('.', ',');
                route.Points.Add(new PointLatLng(Convert.ToDouble(latitude), Convert.ToDouble(longitude)));
                route.IsHitTestVisible = true;
                overlay.Routes.Add(route);
            }
        }

        public void fillAirTrafficLayers(Stream kmlFile, string nameKML, string element, string tagName)
        {
            XmlDocument KML = new XmlDocument();
            KML.Load(kmlFile);
            XmlNodeList folderNodes = KML.GetElementsByTagName(tagName);
            foreach (XmlNode node in folderNodes)
            {
                if (node.FirstChild.InnerText == element)
                {
                    foreach (XmlNode childNode in node)
                    {
                        if (childNode.Name == "Placemark" && element == "Puntos Fijos")
                        {
                            string longitude = childNode["Point"].InnerText.Split(',')[0].Replace('.', ',');
                            string latitude = childNode["Point"].InnerText.Split(',')[1].Replace('.', ',');
                            point = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(latitude), Convert.ToDouble(longitude)), blackPoint);
                            point.ToolTipText = childNode["name"].InnerText;
                            point.ToolTipMode = MarkerTooltipMode.Always;
                            point.ToolTip.Font = new Font("Bahnschrift Light", 7.8F, FontStyle.Regular);
                            point.ToolTip.Foreground = new SolidBrush(Color.Black);
                            point.ToolTip.Fill = new SolidBrush(Color.Transparent);
                            point.ToolTip.Stroke = new Pen(new SolidBrush(Color.Transparent));
                            point.ToolTip.Offset = new Point(0, 0);
                            fixedPointsAirwaysOverlay.Markers.Add(point);
                        }
                        else if (childNode.Name == "Placemark" && element == "Aerovías")
                            createRoute(childNode, Color.Black, airwaysOverlay);
                        else if (childNode.Name == "Placemark" && element == "Airspace_Dissolve2")
                        {
                            string[] coordinates = childNode["MultiGeometry"].InnerText.Split(' ');
                            string latitude; string longitude;
                            List<PointLatLng> points = new List<PointLatLng>();
                            for (int i = 0; i < coordinates.Length - 1; i++)
                            {
                                latitude = coordinates[i].Split(',')[1].Replace('.', ',');
                                longitude = coordinates[i].Split(',')[0].Replace('.', ',');
                                points.Add(new PointLatLng(Convert.ToDouble(latitude), Convert.ToDouble(longitude)));
                            }
                            GMapPolygon ATZ_CTR_CTA = new GMapPolygon(points, childNode["name"].InnerText);
                            ATZ_CTR_CTA.Stroke = new Pen(new SolidBrush(Color.DarkBlue), 3);
                            ATZ_CTR_CTA_Overlay.Polygons.Add(ATZ_CTR_CTA);
                        }
                        else if (childNode.Name == "Placemark" && element == "Aeródromo")
                        {
                            string longitude = childNode["Point"].InnerText.Split(',')[0].Replace('.', ',');
                            string latitude = childNode["Point"].InnerText.Split(',')[1].Replace('.', ',');
                            point = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(latitude), Convert.ToDouble(longitude)), blueTriangle);
                            point.ToolTipText = childNode["name"].InnerText;
                            point.ToolTipMode = MarkerTooltipMode.Always;
                            point.ToolTip.Font = new Font("Bahnschrift Light", 7.8F, FontStyle.Regular);
                            point.ToolTip.Foreground = new SolidBrush(Color.Blue);
                            point.ToolTip.Fill = new SolidBrush(Color.Transparent);
                            point.ToolTip.Stroke = new Pen(new SolidBrush(Color.Transparent));
                            point.ToolTip.Offset = new Point(0, 0);
                            aerodromesOverlay.Markers.Add(point);
                        }
                        else if (childNode.Name == "Placemark" && element == "Procedimientos SID")
                            createRoute(childNode, Color.DarkOrange, SIDproceduresOverlay);
                        else if (childNode.Name == "Placemark" && element == "Procedimientos STAR")
                            createRoute(childNode, Color.Purple, STARproceduresOverlay);
                        else if (childNode.Name == "Folder" && element == "Sectores Sacta")
                        {
                            foreach (XmlNode sector in childNode)
                            {
                                if (sector.Name == "Placemark")
                                {
                                    string[] coordinates = sector["MultiGeometry"].InnerText.Split(' ');
                                    string latitude; string longitude;
                                    List<PointLatLng> points = new List<PointLatLng>();
                                    for (int i = 0; i < coordinates.Length - 2; i++)
                                    {
                                        latitude = coordinates[i].Split(',')[1].Replace('.', ',');
                                        longitude = coordinates[i].Split(',')[0].Replace('.', ',');
                                        points.Add(new PointLatLng(Convert.ToDouble(latitude), Convert.ToDouble(longitude)));
                                    }
                                    GMapPolygon sactaSector = new GMapPolygon(points, sector["name"].InnerText);
                                    sactaSector.Stroke = new Pen(new SolidBrush(Color.DarkOliveGreen), 3);
                                    sactaSector.Fill = new SolidBrush(Color.Transparent);
                                    latitude = coordinates[coordinates.Length - 2].Split(',')[1].Replace('.', ',');
                                    longitude = coordinates[coordinates.Length - 2].Split(',')[0].Replace('.', ',');
                                    point = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(latitude), Convert.ToDouble(longitude)), greenCross);
                                    point.ToolTipText = sector["name"].InnerText;
                                    point.ToolTipMode = MarkerTooltipMode.Always;
                                    point.ToolTip.Font = new Font("Bahnschrift Light", 7.8F, FontStyle.Regular);
                                    point.ToolTip.Foreground = new SolidBrush(Color.DarkOliveGreen);
                                    point.ToolTip.Fill = new SolidBrush(Color.Transparent);
                                    point.ToolTip.Stroke = new Pen(new SolidBrush(Color.Transparent));
                                    point.ToolTip.Offset = new Point(0, 0);
                                    int counter = 1;
                                    foreach (GMapMarker sactaSectorName in SactaSectorsTagOverlay.Markers)
                                    {
                                        if (sactaSectorName.Position == point.Position)
                                        { point.ToolTip.Offset = new Point(0, counter * 10); counter++; }
                                    }
                                    SactaSectorsTagOverlay.Markers.Add(point);
                                    SactaSectorsOverlay.Polygons.Add(sactaSector);
                                }
                            }
                        }
                        else if (childNode.Name == "Placemark" && element == "Contorno Sacta")
                        {
                            string[] coordinates = childNode["MultiGeometry"].InnerText.Split(' ');
                            string latitude; string longitude;
                            List<PointLatLng> points = new List<PointLatLng>();
                            for (int i = 0; i < coordinates.Length - 2; i++)
                            {
                                latitude = coordinates[i].Split(',')[1].Replace('.', ',');
                                longitude = coordinates[i].Split(',')[0].Replace('.', ',');
                                points.Add(new PointLatLng(Convert.ToDouble(latitude), Convert.ToDouble(longitude)));
                            }
                            GMapPolygon sactaContour = new GMapPolygon(points, childNode["name"].InnerText);
                            sactaContour.Fill = new SolidBrush(Color.Transparent);
                            sactaContour.Stroke = new Pen(new SolidBrush(Color.Gray), 2);
                            SactaContourOverlay.Polygons.Add(sactaContour);
                        }
                        else if (childNode.Name == "Folder" && element == "1.57d00aaaa7d00aaaa" && nameKML == "TMABCN.kml") // TMA_BCN
                        {
                            foreach (XmlNode TMA in childNode)
                            {
                                if (TMA.Name == "Folder")
                                {
                                    string[] coordinates = TMA["Placemark"]["Polygon"]["outerBoundaryIs"].InnerText.Split('\r');
                                    string latitude; string longitude;
                                    List<PointLatLng> points = new List<PointLatLng>();
                                    for (int i = 1; i < coordinates.Length - 1; i++)
                                    {
                                        latitude = coordinates[i].Split(',')[1].Replace('.', ',');
                                        longitude = coordinates[i].Split(',')[0].Replace('.', ',');
                                        points.Add(new PointLatLng(Convert.ToDouble(latitude), Convert.ToDouble(longitude)));
                                    }
                                    GMapPolygon TMA_BCN = new GMapPolygon(points, TMA["name"].InnerText);
                                    TMA_BCN.Fill = new SolidBrush(Color.Transparent);
                                    TMA_BCN.Stroke = new Pen(new SolidBrush(Color.Brown), 2);
                                    TMA_BCN_Overlay.Polygons.Add(TMA_BCN);
                                }
                            }
                        }
                        else if (childNode.Name == "Folder" && element == "7d00aaaa0.8" && nameKML == "TMABCN_tag.kml") // TMA_BCN_Tag
                        {
                            foreach (XmlNode TMA in childNode)
                            {
                                if (TMA.Name == "Folder")
                                {
                                    string latitude = TMA["Placemark"]["Point"]["coordinates"].InnerText.Split(',')[1].Replace('.', ',');
                                    string longitude = TMA["Placemark"]["Point"]["coordinates"].InnerText.Split(',')[0].Replace('.', ',');
                                    point = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(latitude), Convert.ToDouble(longitude)), blackPoint);
                                    point.ToolTipText = TMA["Placemark"]["name"].InnerText;
                                    point.ToolTipMode = MarkerTooltipMode.Always;
                                    point.ToolTip.Font = new Font("Bahnschrift Light", 7.8F, FontStyle.Regular);
                                    point.ToolTip.Foreground = new SolidBrush(Color.Black);
                                    point.ToolTip.Fill = new SolidBrush(Color.Transparent);
                                    point.ToolTip.Stroke = new Pen(new SolidBrush(Color.Transparent));
                                    point.ToolTip.Offset = new Point(0, 0);
                                    int counter = 1;
                                    foreach (GMapMarker TMA_Tag in TMA_BCN_Tag_Overlay.Markers)
                                    {
                                        if (TMA_Tag.Position == point.Position)
                                        { point.ToolTip.Offset = new Point(0, counter * 10); counter++; }
                                    }
                                    TMA_BCN_Tag_Overlay.Markers.Add(point);
                                }
                            }
                        }
                        else if (childNode.Name == "Folder" && element == "1.57d00aaaa7d00aaaa" && nameKML == "TMAVAL.kml") // TMA_VAL
                        {
                            foreach (XmlNode TMA in childNode)
                            {
                                if (TMA.Name == "Folder")
                                {
                                    string[] coordinates = TMA["Placemark"]["Polygon"]["outerBoundaryIs"].InnerText.Split('\r');
                                    string latitude; string longitude;
                                    List<PointLatLng> points = new List<PointLatLng>();
                                    for (int i = 1; i < coordinates.Length - 1; i++)
                                    {
                                        latitude = coordinates[i].Split(',')[1].Replace('.', ',');
                                        longitude = coordinates[i].Split(',')[0].Replace('.', ',');
                                        points.Add(new PointLatLng(Convert.ToDouble(latitude), Convert.ToDouble(longitude)));
                                    }
                                    GMapPolygon TMA_BCN = new GMapPolygon(points, TMA["name"].InnerText);
                                    TMA_BCN.Fill = new SolidBrush(Color.Transparent);
                                    TMA_BCN.Stroke = new Pen(new SolidBrush(Color.Brown), 2);
                                    TMA_VAL_Overlay.Polygons.Add(TMA_BCN);
                                }
                            }
                        }
                        else if (childNode.Name == "Folder" && element == "7d00aaaa0.8" && nameKML == "TMAVAL_tag.kml") // TMA_VAL_Tag
                        {
                            foreach (XmlNode TMA in childNode)
                            {
                                if (TMA.Name == "Folder")
                                {
                                    string latitude = TMA["Placemark"]["Point"]["coordinates"].InnerText.Split(',')[1].Replace('.', ',');
                                    string longitude = TMA["Placemark"]["Point"]["coordinates"].InnerText.Split(',')[0].Replace('.', ',');
                                    point = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(latitude), Convert.ToDouble(longitude)), blackPoint);
                                    point.ToolTipText = TMA["Placemark"]["name"].InnerText;
                                    point.ToolTipMode = MarkerTooltipMode.Always;
                                    point.ToolTip.Font = new Font("Bahnschrift Light", 7.8F, FontStyle.Regular);
                                    point.ToolTip.Foreground = new SolidBrush(Color.Black);
                                    point.ToolTip.Fill = new SolidBrush(Color.Transparent);
                                    point.ToolTip.Stroke = new Pen(new SolidBrush(Color.Transparent));
                                    point.ToolTip.Offset = new Point(0, 0);
                                    int counter = 1;
                                    foreach (GMapMarker TMA_Tag in TMA_VAL_Tag_Overlay.Markers)
                                    {
                                        if (TMA_Tag.Position == point.Position)
                                        { point.ToolTip.Offset = new Point(0, counter * 10); counter++; }
                                    }
                                    TMA_VAL_Tag_Overlay.Markers.Add(point);
                                }
                            }
                        }
                    }
                }
            }
        }

        // Event that is executed when loading the MapView
        private void MapView_Load(object sender, EventArgs e)
        {
            try
            {
                // Google map settings
                gMap.DragButton = MouseButtons.Left;
                gMap.MapProvider = GMapProviders.GoogleMap;
                gMap.MinZoom = 6; gMap.MaxZoom = 18;
                gMap.Zoom = 6; gMap.Position = new PointLatLng(41.296582, 2.083148); // Spain and middle France View
                gMap.ShowCenter = false;
                
                // Definition of point formats
                redPoint = ResizeBitmap(new Bitmap(Properties.Resources.RedPoint), 6, 6);
                bluePoint = ResizeBitmap(new Bitmap(Properties.Resources.BluePoint), 6, 6);
                blackPoint = ResizeBitmap(new Bitmap(Properties.Resources.BlackPoint), 7, 7);
                greenPoint = ResizeBitmap(new Bitmap(Properties.Resources.GreenPoint), 6, 6);
                orangePoint = ResizeBitmap(new Bitmap(Properties.Resources.OrangePoint), 7, 7);
                purplePoint = ResizeBitmap(new Bitmap(Properties.Resources.PurplePoint), 7, 7);
                pistachioPoint = ResizeBitmap(new Bitmap(Properties.Resources.PistachioPoint), 7, 7);
                blueTriangle = new Bitmap(Properties.Resources.BlueTriangle);
                greenCross = new Bitmap(Properties.Resources.GreenCross);
                // Load airspace layers
                readKMLs();
                // Agreggate the layers to the map
                gMap.Overlays.Add(pointsOverlayFullTrail);
                gMap.Overlays.Add(pointsOverlayVariableTrail);
                gMap.Overlays.Add(clickedRoutesOverlay);
                // Fill and show several gridViews
                fillGridView(CATgridView, CATtable, "CAT");
                fillGridView(DSIgridView, DSItable, "DSI");
                DSIgridView.Sort(DSIgridView.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                fillGridView(UTCgridView, UTCtable, "UTC");
                fillGridView(FlightGridView, FlightTable, "FLIGHT");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message);}
        }

        // Uncheck the first cell of all the gridView which by default is selected
        private void MapView_Shown(object sender, EventArgs e)
        { DSIgridView.ClearSelection(); CATgridView.ClearSelection(); UTCgridView.ClearSelection(); FlightGridView.ClearSelection(); }

        // Button of simulation layout
        private void LayoutButton_Click(object sender, EventArgs e)
        {
            if (gMap.MapProvider == GMapProviders.GoogleSatelliteMap)
                gMap.MapProvider = GMapProviders.GoogleMap;
            else
                gMap.MapProvider = GMapProviders.GoogleSatelliteMap;
        }

        // Event that occurs when changing the zoom with the mouse scroll
        private void timerZoom_Tick(object sender, EventArgs e)
        {trackZoomBar.Value = Convert.ToInt32(gMap.Zoom); }

        // Event that occurs when changing the zoom of the zoom bar
        private void trackZoomBar_ValueChanged(object sender, EventArgs e)
        { gMap.Zoom = trackZoomBar.Value; }

        // Event that runs while the timer is activated and repeats every defined interval
        private void timerMap_Tick(object sender, EventArgs e)
        {
            try 
            {
                if (actualTime == 86400)
                    actualTime = 0;
                timeUTCLabel.Text = TimeOfDay.obtainTimeUTC(actualTime);
                if (actualTime != finalTime)
                    plotFlightsAndTable(selectedFlights);
                else if (actualTime == finalTime)
                {
                    plotFlightsAndTable(selectedFlights);
                    timerMap.Stop();
                    endSimulationInfoLabel.Visible = true;
                    PauseButton.Visible = false;
                    PlayButton.Visible = false;
                }
                actualTime++;
            }

            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        // Control simulation Buttons (Play, Pause y Stop)
        private void PlayButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (initialTime == actualTime)
                    setIndexFlights();
                timerMap.Start();
                PlayButton.Visible = false; PauseButton.Visible = true; StopButton.Visible = true;
                if (clickedFlight == null && clearSelectionButton.Tag == null)
                    clearSelectionButton.Visible = false;
                ClickOnTableLabel.Visible = true;
                CATgridView.Visible = false; DSIgridView.Visible = false;
                UTCgridView.Visible = false; FlightGridView.Visible = false;
                AllFlightsButton.Visible = false; plotAllFileButton.Visible = false; infoSimulationGridView.Visible = true;
                if (PlayButton.Tag == null)
                {
                    InfoTable = new DataTable();
                    // GridView definition of info for simulation
                    infoSimulationGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
                    infoSimulationGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    infoSimulationGridView.DefaultCellStyle.ForeColor = Color.Black;
                    if (selectedFlights.Count == 1)
                    {
                        InfoTable.Columns.Add("Field"); InfoTable.Columns.Add("Value");
                        infoSimulationGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Bahnschrift Condensed", 14F, FontStyle.Regular);
                        infoSimulationGridView.DefaultCellStyle.Font = new Font("Bahnschrift Light", 10F, FontStyle.Regular);
                    }
                    else
                    {
                        InfoTable.Columns.Add(" CALLSIGN "); InfoTable.Columns.Add("ICAO/TRACK Nº"); InfoTable.Columns.Add("MODE 3/A"); InfoTable.Columns.Add("SENSORS Nº");
                        infoSimulationGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Bahnschrift Condensed", 13F, FontStyle.Regular);
                        infoSimulationGridView.DefaultCellStyle.Font = new Font("Bahnschrift Light", 10F, FontStyle.Regular);
                    }
                }
                PlayButton.Tag = "Clicked";
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void PauseButton_Click(object sender, EventArgs e)
        { timerMap.Stop(); PauseButton.Visible = false; PlayButton.Visible = true; }

        private void StopButton_Click(object sender, EventArgs e)
        {
            try 
            {
                timerMap.Stop();
                PauseButton.Visible = false; PlayButton.Visible = true; StopButton.Visible = false; PlayButton.Tag = null; plotAllFileButton.Visible = true;
                endSimulationInfoLabel.Visible = false; infoSimulationGridView.Visible = false; IDclickedFlight = null; flightTrailLabel.Text = "FLIGHT TRAIL";
                clearSelectionButton.Tag = null; clickedFlight = null; selectedRow = 0; ClickOnTableLabel.Visible = false; invertColors = false;
                // Reinitialize the indices and delete the points of each flight and point layer
                foreach (Flight flight in data.FlightList)
                { flight.index = 0; flight.pointList.Clear(); }
                pointsOverlayFullTrail.Markers.Clear();
                pointsOverlayVariableTrail.Markers.Clear();
                // Showing again the empty map with zoom of all Spain
                gMap.Zoom = 6; gMap.Position = new PointLatLng(41.296582, 2.083148); // Spain and middle France View
                CATgridView.Visible = true; DSIgridView.Visible = true;
                // Showing again all the filter tables without modifying their state prior to the simulation
                UTCgridView.Visible = true; FlightGridView.Visible = true;
                clearSelectionButton.Visible = true;
                AllFlightsButton.Visible = true;
                // Showing the start time of the selected simulation again
                timeUTCLabel.Text = TimeOfDay.obtainTimeUTC(initialTime);
                actualTime = initialTime;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        // Accelerate and slow simulation buttons
        private void AccelerateButton_Click(object sender, EventArgs e)
        {
            if (timerMap.Interval > 1000 / 16)
            {
                SlowDownButton.Visible = true;
                timerMap.Interval = timerMap.Interval / 2;
                VelocityLabel.Text = string.Concat("x", Convert.ToString(1000 / timerMap.Interval));
                if (timerMap.Interval == 62)
                    AccelerateButton.Visible = false;
            }
        }

        private void SlowDownButton_Click(object sender, EventArgs e)
        {
            if (timerMap.Interval * 2 <= 1000)
            {
                AccelerateButton.Visible = true;
                timerMap.Interval = timerMap.Interval * 2;
                VelocityLabel.Text = string.Concat("x", Convert.ToString(1000 / timerMap.Interval));
            }
            if (timerMap.Interval == 1000 || timerMap.Interval == 992)
                SlowDownButton.Visible = false;
        }

        // CellClick events of the 4 filters (CAT, DSI, UTC, Flight)
        private void CATgridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Obtaining the list of selected aircraft
                selectedFlights = new List<Flight>();
                foreach (Flight flight in data.FlightList)
                {
                    if (flight.category.Contains(CATgridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    {
                        Flight filteredFlight = new Flight();
                        filteredFlight.ICAOadress = flight.ICAOadress; filteredFlight.callsign = flight.callsign; filteredFlight.mode3A = flight.mode3A;
                        for (int i = 0; i < flight.seconds.Count; i++)
                        {
                            if (CATgridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == flight.category[i])
                                filteredFlight.addValueFlight(flight.category[i], flight.sensor[i], flight.trackNumber[i], flight.seconds[i], flight.decimalSeconds[i], flight.longitude[i], flight.latitude[i], flight.altitude[i], flight.FL[i], flight.groundSpeed[i], flight.trackVelocity[i]);
                        }
                        selectedFlights.Add(filteredFlight);
                    }
                }
                // Visible design:
                clearSelectionButton.Visible = true;
                PlayButton.Visible = true; KMLbutton.Visible = true;
                showActualTime();
                UTCgridView.ClearSelection(); UTCgridView.Rows[0].Selected = true;
                UTCgridView.FirstDisplayedScrollingRowIndex = UTCgridView.Rows[0].Index;
                // Unvisible design:
                FlightGridView.ClearSelection(); DSIgridView.ClearSelection();
                FlightGridView.Visible = false; AllFlightsButton.Visible = false; selectFlightLabel.Visible = false;
                allFlightsSelected = false; clicksAllFlightsButton = 0; AllFlightsButton.BackColor = Color.Gainsboro; AllFlightsButton.ForeColor = Color.Black; AllFlightsButton.IconColor = Color.Black;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void DSIgridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Obtaining the list of selected aircraft
                selectedFlights = new List<Flight>();
                foreach (Flight flight in data.FlightList)
                {
                    if (flight.sensor.Contains(DSIgridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    {
                        Flight filteredFlight = new Flight();
                        filteredFlight.ICAOadress = flight.ICAOadress; filteredFlight.callsign = flight.callsign; filteredFlight.mode3A = flight.mode3A;
                        for (int i = 0; i < flight.seconds.Count; i++)
                        {
                            if (DSIgridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == flight.sensor[i])
                                filteredFlight.addValueFlight(flight.category[i], flight.sensor[i], flight.trackNumber[i], flight.seconds[i], flight.decimalSeconds[i], flight.longitude[i], flight.latitude[i], flight.altitude[i], flight.FL[i], flight.groundSpeed[i], flight.trackVelocity[i]);
                        }
                        selectedFlights.Add(filteredFlight);
                    }
                }
                // Visible design:
                clearSelectionButton.Visible = true;
                PlayButton.Visible = true; KMLbutton.Visible = true;
                showActualTime();
                UTCgridView.ClearSelection(); UTCgridView.Rows[0].Selected = true;
                UTCgridView.FirstDisplayedScrollingRowIndex = UTCgridView.Rows[0].Index;
                // Unvisible design:
                FlightGridView.ClearSelection(); CATgridView.ClearSelection();
                FlightGridView.Visible = false; AllFlightsButton.Visible = false; selectFlightLabel.Visible = false;
                allFlightsSelected = false; clicksAllFlightsButton = 0; AllFlightsButton.BackColor = Color.Gainsboro; AllFlightsButton.ForeColor = Color.Black; AllFlightsButton.IconColor = Color.Black;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void UTCgridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                actualTime = InitialTimeSimulationList[e.RowIndex];
                if (selectedFlights != null)
                {
                    if (selectedFlights.Count == 1)
                    { selectedFlights.Clear(); FlightGridView.ClearSelection(); PlayButton.Visible = false; }
                    else
                    { setIndexFlights(); }
                }
                if (actualTime == 86400)
                    actualTime = 0;
                showActualTime();
                // Visible design:
                clearSelectionButton.Visible = true;
                if (allFlightsSelected)
                { PlayButton.Visible = true; selectFlightLabel.Visible = false; }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void FlightGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedFlights = new List<Flight>();
                Flight foundedFlight;
                if (FlightGridView.Columns[0].Name == "CALLSIGN")
                    foundedFlight = data.FlightList.Find(r => r.callsign == FlightGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                else
                    foundedFlight = data.FlightList.Find(r => r.trackNumber.Contains(FlightGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
                timeUTCLabel.Text = TimeOfDay.obtainTimeUTC(foundedFlight.seconds[0]);
                initialTime = foundedFlight.seconds[0];
                actualTime = initialTime;
                finalTime = foundedFlight.seconds[foundedFlight.seconds.Count - 1];
                selectedFlights.Add(foundedFlight);
                // Visible design:
                clearSelectionButton.Visible = true;
                PlayButton.Visible = true;
                showActualTime();
                // Unvisible design:
                selectFlightLabel.Visible = false;
                UTCgridView.ClearSelection(); DSIgridView.ClearSelection(); CATgridView.ClearSelection();
                UTCgridView.Visible = false; DSIgridView.Visible = false; CATgridView.Visible = false;
                // Button control all selected aircraft
                clicksAllFlightsButton = 0; allFlightsSelected = false; AllFlightsButton.BackColor = Color.Gainsboro; AllFlightsButton.ForeColor = Color.Black; AllFlightsButton.IconColor = Color.Black;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        // Buttons to clear the selection of filter tables
        private void clearSelectionButton_Click(object sender, EventArgs e)
        {
            try 
            {
                if (PlayButton.Tag == null) // Play button without pressing
                {
                    if (selectedFlights != null)
                        selectedFlights.Clear();
                    pointsOverlayFullTrail.Markers.Clear(); endSimulationInfoLabel.Visible = false;
                    DSIgridView.ClearSelection(); CATgridView.ClearSelection(); UTCgridView.ClearSelection(); FlightGridView.ClearSelection();
                    DSIgridView.Visible = true; CATgridView.Visible = true; UTCgridView.Visible = true; FlightGridView.Visible = true;
                    AllFlightsButton.Visible = true; AllFlightsButton.BackColor = Color.Gainsboro; AllFlightsButton.ForeColor = Color.Black; AllFlightsButton.IconColor = Color.Black;
                    selectFlightLabel.Visible = true; clearSelectionButton.Visible = false; clicksAllFlightsButton = 0;
                    PlayButton.Visible = false; allFlightsSelected = false; timeUTCLabel.Text = "HH:MM:SS"; timeUTCLabel.Visible = true; startSimulationLabel.Visible = false; endSimulationLabel.Visible = false;
                    bluePointIcon.Visible = true; flightTrailLabel.Visible = true; plotAllFileButton.Visible = true;
                    incrementTrail.Visible = true; reduceTrail.Visible = true; trailNumberLabel.Visible = true;
                    TimeScaleLabel.Visible = true; AccelerateButton.Visible = true; SlowDownButton.Visible = true; VelocityLabel.Visible = true;
                    gMap.Zoom = 8;
                    infoSimulationGridView.Visible = false;
                    // Reinitialization of the indexes and delete the points of each flight and point layer
                    foreach (Flight flight in data.FlightList)
                    { flight.index = 0; flight.pointList.Clear(); }
                }
                else // Play button pressed
                {
                    clickedFlight = null; clearSelectionButton.Tag = null; IDclickedFlight = null; invertColors = false;
                    if (selectedFlights.Count != 1)
                    { gMap.Zoom = 8; }
                    clearSelectionButton.Visible = false;
                    infoSimulationGridView.ClearSelection(); selectedRow = 0;
                    pointsOverlayFullTrail.Markers.Clear();
                    gMap.Zoom = 6; gMap.Position = new PointLatLng(41.296582, 2.083148); // Spain and middle France View
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        // Button select all aircraft to simulate
        private void AllFlightsButton_Click(object sender, EventArgs e)
        {
            try 
            {
                if (clicksAllFlightsButton % 2 == 0) // If it is pressed
                {
                    selectedFlights = new List<Flight>();
                    foreach (Flight flight in data.FlightList)
                        selectedFlights.Add(flight);
                    foreach (DataGridViewRow row in FlightGridView.Rows)
                        row.Selected = true;
                    obtainInitialAndFinalTimeAllFlights();
                    showActualTime();
                    UTCgridView.ClearSelection();
                    UTCgridView.Rows[0].Selected = true;
                    UTCgridView.FirstDisplayedScrollingRowIndex = UTCgridView.Rows[0].Index;
                    clearSelectionButton.Visible = true;
                    allFlightsSelected = true; selectFlightLabel.Visible = false;
                    AllFlightsButton.BackColor = SystemColors.Highlight; AllFlightsButton.ForeColor = Color.White; AllFlightsButton.IconColor = Color.White;
                    CATgridView.Visible = false; CATgridView.ClearSelection();
                    DSIgridView.Visible = false; DSIgridView.ClearSelection();
                    PlayButton.Visible = true; KMLbutton.Visible = true;
                }
                else // If is not pressed
                {
                    FlightGridView.ClearSelection();
                    allFlightsSelected = false; AllFlightsButton.BackColor = Color.Gainsboro; AllFlightsButton.ForeColor = Color.Black; AllFlightsButton.IconColor = Color.Black;
                    selectFlightLabel.Visible = true;
                    if (UTCgridView.SelectedCells.Count == 0)
                        clearSelectionButton.Visible = false;
                    CATgridView.Visible = true; DSIgridView.Visible = true;
                    startSimulationLabel.Visible = false; endSimulationLabel.Visible = false;
                    PlayButton.Visible = false;
                }
                clicksAllFlightsButton++;
                UTCgridView.Visible = true;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        // Event generated by clicking on the table that appears in the aircraft simulation, with the trail of the selected aircraft appearing
        private void infoSimulationGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                clearSelectionButton.Visible = true;
                if (PlayButton.Tag != null)
                {
                    selectedRow = e.RowIndex;
                    infoSimulationGridView.Cursor = Cursors.WaitCursor;
                    if (selectedFlights.Count == 1) // Click grid of an aircraft
                    {
                        invertColors = true; // To know that we have clicked on the cell and we have to change the color of the current plane
                        pointsOverlayFullTrail.Markers.Clear();
                        foreach (Flight flight in selectedFlights)
                        {
                            for (int position = 0; position < flight.seconds.Count; position++)
                            {
                                Bitmap colorPoint;
                                if (flight.category[position] == "10" && data.RadarStationList.Find(r => r.radarStation == flight.sensor[position]).type == "SMR")
                                        colorPoint = pistachioPoint;
                                else if (flight.category[position] == "10" && data.RadarStationList.Find(r => r.radarStation == flight.sensor[position]).type == "SMMS")
                                    colorPoint = purplePoint;
                                else if (flight.category[position] == "21")
                                    colorPoint = redPoint;
                                else if (flight.category[position] == "48")
                                    colorPoint = greenPoint;
                                else if (flight.category[position] == "62")
                                    colorPoint = orangePoint;
                                else
                                    colorPoint = blackPoint;
                                point = new GMarkerGoogle(new PointLatLng(flight.latitude[position], flight.longitude[position]), colorPoint);
                                pointsOverlayFullTrail.Markers.Add(point);
                                point.ToolTipText = string.Format("Callsign: {0}\nICAO: {1}\nTrack Number: {2}\nMode 3/A: {3}\nSensor: {4}\nUTC Time: {5}\nFL: {6}", flight.callsign, flight.ICAOadress, flight.trackNumber[position], flight.mode3A, flight.sensor[position], TimeOfDay.obtainTimeUTC(flight.decimalSeconds[position]), flight.FL[position]);
                            }
                        }
                    }
                    else // Click grid of several planes
                    {
                        IDclickedFlight = InfoTable.Rows[selectedRow].ItemArray;
                        flightTrailLabel.Text = "FLIGHT TRAIL";
                        if (pointsOverlayFullTrail.Markers.Count != 0)
                            pointsOverlayFullTrail.Markers.Clear();
                        // Find clicked flight in table of several flights
                        clickedFlight = selectedFlights.Find(r => r.callsign == InfoTable.Rows[e.RowIndex].ItemArray[0].ToString() && r.mode3A == InfoTable.Rows[e.RowIndex].ItemArray[2].ToString() && (r.trackNumber.Contains(InfoTable.Rows[e.RowIndex].ItemArray[1].ToString()) || r.ICAOadress == InfoTable.Rows[e.RowIndex].ItemArray[1].ToString()));
                        // Show trail of the complete route of the selected aircraft
                        for (int position = 0; position < clickedFlight.seconds.Count; position++)
                        {
                            if (position == 0)
                            { gMap.Zoom = 12; gMap.Position = new PointLatLng(clickedFlight.latitude[position], clickedFlight.longitude[position]); }
                            point = new GMarkerGoogle(new PointLatLng(clickedFlight.latitude[position], clickedFlight.longitude[position]), bluePoint);
                            pointsOverlayFullTrail.Markers.Add(point);
                            point.ToolTipText = string.Format("Callsign: {0}\nICAO: {1}\nTrack Number: {2}\nMode 3/A: {3}\nSensor: {4}\nUTC Time: {5}\nFL: {6}", clickedFlight.callsign, clickedFlight.ICAOadress, clickedFlight.trackNumber[position], clickedFlight.mode3A, clickedFlight.sensor[position], TimeOfDay.obtainTimeUTC(clickedFlight.decimalSeconds[position]), clickedFlight.FL[position]);
                        }
                    }
                    clearSelectionButton.Tag = "Clicked";
                    infoSimulationGridView.Cursor = Cursors.Default;
                }
                else
                    infoSimulationGridView.ClearSelection();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        // Button that reduces the trail of aircraft
        private void reduceTrail_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(trailNumberLabel.Text) > 1)
            {
                trailNumberLabel.Text = (Convert.ToInt32(trailNumberLabel.Text) - 1).ToString();
                incrementTrail.Visible = true;
                if (Convert.ToInt32(trailNumberLabel.Text) == 1)
                    reduceTrail.Visible = false;
            }
        }

        // Button that increments the trail of aircraft
        private void incrementTrail_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(trailNumberLabel.Text) < 10)
            {
                trailNumberLabel.Text = (Convert.ToInt32(trailNumberLabel.Text) + 1).ToString();
                reduceTrail.Visible = true;
                if (Convert.ToInt32(trailNumberLabel.Text) == 10)
                    incrementTrail.Visible = false;
            }
        }

        // Button that shows on the map all the routes of the aircraft in the loaded file
        private void plotAllFileButton_Click(object sender, EventArgs e)
        {
            try 
            {
                selectedFlights = new List<Flight>();
                foreach (Flight flight in data.FlightList)
                    selectedFlights.Add(flight);
                gMap.Zoom = 6; gMap.Position = new PointLatLng(41.296582, 2.083148); // Spain and middle France View
                KMLbutton.Visible = true; plotAllFileButton.Visible = false;
                CATgridView.Visible = false; DSIgridView.Visible = false;
                UTCgridView.Visible = false; FlightGridView.Visible = false;
                AllFlightsButton.Visible = false; selectFlightLabel.Visible = false; PlayButton.Visible = false;
                bluePointIcon.Visible = false; flightTrailLabel.Visible = false; timeUTCLabel.Visible = false;
                incrementTrail.Visible = false; reduceTrail.Visible = false; trailNumberLabel.Visible = false;
                TimeScaleLabel.Visible = false; AccelerateButton.Visible = false; SlowDownButton.Visible = false; VelocityLabel.Visible = false;
                clearSelectionButton.Visible = true;
                obtainInitialAndFinalTimeAllFlights();
                showActualTime();
                Bitmap colorPoint;
                foreach (Flight flight in data.FlightList)
                {
                    for (int i = 0; i < flight.seconds.Count; i++)
                    {
                        if (flight.category[i] == "10" && data.RadarStationList.Find(r => r.radarStation == flight.sensor[i]).type == "SMR")
                            colorPoint = pistachioPoint;
                        else if (flight.category[i] == "10" && data.RadarStationList.Find(r => r.radarStation == flight.sensor[i]).type == "SMMS")
                            colorPoint = purplePoint;
                        else if (flight.category[i] == "21")
                            colorPoint = redPoint;
                        else if (flight.category[i] == "48")
                            colorPoint = greenPoint;
                        else if (flight.category[i] == "62")
                            colorPoint = orangePoint;
                        else
                            colorPoint = blackPoint;
                        point = new GMarkerGoogle(new PointLatLng(flight.latitude[i], flight.longitude[i]), colorPoint);
                        pointsOverlayFullTrail.Markers.Add(point);
                        point.ToolTipText = string.Format("Callsign: {0}\nICAO: {1}\nTrack Number: {2}\nMode 3/A: {3}\nSensor: {4}\nUTC Time: {5}\nFL: {6}", flight.callsign, flight.ICAOadress, flight.trackNumber[flight.index], flight.mode3A, flight.sensor[flight.index], TimeOfDay.obtainTimeUTC(flight.decimalSeconds[flight.index]), flight.FL[flight.index]);
                        flight.index++;
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        // Button that generates a KML file and shows 3D trajectories in Google Earth
        private void KMLbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (PlayButton.Tag != null) // Play button pressed
                { timerMap.Stop(); PlayButton.Visible = true; PauseButton.Visible = false; }
                DateTime date = DateTime.Now; // Obtaining the current day and time to display it in the KML file
                XmlDocument XMLdoc = new XmlDocument(); // Generating a XML file
                XmlNode DocumentNode = XMLdoc.CreateElement("Document");
                XMLdoc.AppendChild(DocumentNode);
                string downloadFolderPath = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", String.Empty).ToString();
                if (downloadFolderPath.Contains("Pablo Pérez"))
                    downloadFolderPath = downloadFolderPath.Replace(" Pérez", "");
                string[] fileNameSplit = data.AsterixFiles[0].fileName.Split('.');
                string nameKML = date.Year + "-" + date.Month.ToString().PadLeft(2, '0') + "-" + date.Day.ToString().PadLeft(2, '0') + "_" + date.Hour.ToString().PadLeft(2, '0') + "-" + date.Minute.ToString().PadLeft(2, '0') + "-" + date.Second.ToString().PadLeft(2, '0') + "_" + fileNameSplit[0] + ".kml";
                string pathKML = downloadFolderPath + "\\" + nameKML;
                XMLdoc.Save(pathKML); // Saving XML file
                // Opening the file with a StreamReader (easier to write the code) and modifying it with the desired data
                StreamWriter sw = new StreamWriter(pathKML, false, Encoding.UTF8); // Writting in the saved KML file
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + " <kml xmlns=\"http://www.opengis.net/kml/2.2\"> ");
                string ID = "";
                if (selectedFlights == null)
                { selectedFlights = new List<Flight>(); foreach (Flight flight in data.FlightList) { selectedFlights.Add(flight); } }
                else if (selectedFlights.Count == 0)
                {foreach (Flight flight in data.FlightList) { selectedFlights.Add(flight); } }
                if (selectedFlights.Count == 1)
                {
                    if (selectedFlights[0].callsign != "N/A")
                        ID = selectedFlights[0].callsign;
                    else if (selectedFlights[0].ICAOadress != "N/A")
                        ID = selectedFlights[0].ICAOadress;
                    else if (data.RadarStationList.Find(r => r.radarStation == selectedFlights[0].sensor[0]).type == "SMR")
                        ID = selectedFlights[0].trackNumber[0];
                    sw.WriteLine(" <Document><name> " + fileNameSplit[0] + "_" + ID + " </name>");
                }
                    
                else
                    sw.WriteLine(" <Document><name> " + fileNameSplit[0] + " </name>");
                sw.WriteLine("<Style id=\"blackRoute\"> <LineStyle> <color> ff000000 </color> <width> 3 </width> </LineStyle> </Style>");
                sw.WriteLine("<Style id=\"blueRoute\"> <LineStyle> <color> fff48206 </color> <width> 3 </width> </LineStyle> </Style>");
                sw.WriteLine("<Style id=\"purpleRoute\"> <LineStyle> <color> fff90092 </color> <width> 3 </width> </LineStyle> </Style>");
                sw.WriteLine("<Style id=\"redRoute\"> <LineStyle> <color> ff0000ff </color> <width> 3 </width> </LineStyle> </Style>");
                sw.WriteLine("<Style id=\"greenRoute\"> <LineStyle> <color> ff0fb21c </color> <width> 3 </width> </LineStyle> </Style>");
                sw.WriteLine("<Style id=\"orangeRoute\"> <LineStyle> <color> ff249eff </color> <width> 3 </width> </LineStyle> </Style>");
                foreach (Flight flight in selectedFlights)
                {
                    for (int sensorNumber = 0; sensorNumber < flight.sensor.Distinct().Count(); sensorNumber++)
                    {
                        string sensor = flight.sensor.Distinct().ToList()[sensorNumber];
                        if (flight.callsign != "N/A" && flight.sensor.Distinct().Count() == 1)
                            ID = flight.callsign;
                        else if (flight.callsign != "N/A" && flight.sensor.Distinct().Count() > 1)
                            ID = flight.callsign + "_" + sensor;
                        else if (flight.ICAOadress != "N/A" && flight.sensor.Distinct().Count() == 1)
                            ID = flight.ICAOadress;
                        else if (flight.ICAOadress != "N/A" && flight.sensor.Distinct().Count() > 1)
                            ID = flight.ICAOadress + "_" + sensor;
                        else if (data.RadarStationList.Find(r => r.radarStation == flight.sensor[0]).type == "SMR")
                            ID = flight.trackNumber[0];
                        // Defining line color of the flight depending on category
                        string lineColor;
                        if (flight.category[flight.sensor.IndexOf(sensor)] == "01")
                            lineColor = "blackRoute";
                        else if (flight.category[flight.sensor.IndexOf(sensor)] == "10" && data.RadarStationList.Find(r => r.radarStation == sensor).type == "SMR")
                            lineColor = "blueRoute";
                        else if (flight.category[flight.sensor.IndexOf(sensor)] == "10" && data.RadarStationList.Find(r => r.radarStation == sensor).type == "SMMS")
                            lineColor = "purpleRoute";
                        else if (flight.category[flight.sensor.IndexOf(sensor)] == "21")
                            lineColor = "redRoute";
                        else if (flight.category[flight.sensor.IndexOf(sensor)] == "48")
                            lineColor = "greenRoute";
                        else // CAT62
                            lineColor = "orangeRoute";
                        sw.WriteLine(" <Placemark><name>" + ID + " </name> <styleUrl>#" + lineColor + "</styleUrl> <LineString> <altitudeMode>absolute</altitudeMode> <coordinates>");
                        for (int i = 0; i < flight.seconds.Count; i++)
                        {
                            if (flight.sensor[i] == sensor)
                                sw.WriteLine(flight.longitude[i].ToString().Replace(',', '.') + "," + flight.latitude[i].ToString().Replace(',', '.') + "," + flight.altitude[i].ToString().Replace(',', '.'));
                        }
                        sw.WriteLine(" </coordinates></LineString></Placemark>");
                    }
                }
                sw.WriteLine(" </Document></kml> ");
                sw.Close();
                string message = "KML generated at Download Folder!\nWould you like to open the file in Google Earth?";
                string caption = "Open KML";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    System.Diagnostics.Process.Start(pathKML);
                else
                {
                    if (PlayButton.Tag != null)
                    { timerMap.Start(); PlayButton.Visible = false; PauseButton.Visible = true; }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); return; }
        }

        public void manageOverlays(string airTrafficItem, GMapOverlay overlay, int selectedCheckListItem)
        {
            if (AirTrafficLayersCheckList.SelectedItem.ToString() == airTrafficItem)
            {
                if (AirTrafficLayersCheckList.GetItemChecked(selectedCheckListItem)) // Item tick
                {if (airTrafficItem != "Tags")
                        gMap.Overlays.Add(overlay); } 
                else // Item untick
                {
                    if (AirTrafficLayersCheckList.CheckedItems.Contains("Tags"))
                    {
                        if (AirTrafficLayersCheckList.SelectedItem.ToString() == "TMA BCN")
                        { gMap.Overlays.Remove(TMA_BCN_Tag_Overlay); gMap.Overlays.Remove(overlay); }
                        else if (AirTrafficLayersCheckList.SelectedItem.ToString() == "TMA VAL")
                        { gMap.Overlays.Remove(TMA_VAL_Tag_Overlay); gMap.Overlays.Remove(overlay); }
                        else if (AirTrafficLayersCheckList.SelectedItem.ToString() == "Sacta Sectors")
                        { gMap.Overlays.Remove(SactaSectorsTagOverlay); gMap.Overlays.Remove(overlay); }
                        else if (AirTrafficLayersCheckList.SelectedItem.ToString() == "Airways")
                        { gMap.Overlays.Remove(fixedPointsAirwaysOverlay); gMap.Overlays.Remove(overlay); }
                        else
                            gMap.Overlays.Remove(overlay);
                    }
                    else if (AirTrafficLayersCheckList.SelectedItem.ToString() == "Tags")
                    { gMap.Overlays.Remove(TMA_BCN_Tag_Overlay); gMap.Overlays.Remove(TMA_VAL_Tag_Overlay); gMap.Overlays.Remove(SactaSectorsTagOverlay); gMap.Overlays.Remove(fixedPointsAirwaysOverlay); }
                    else
                        gMap.Overlays.Remove(overlay);
                }
            }  
        }

        private void AirTrafficLayersCheckList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AirTrafficLayersCheckList.SetItemChecked(11, false); // Uncheck Clear All box
            if (AirTrafficLayersCheckList.SelectedItem.ToString() == "Select all" && AirTrafficLayersCheckList.GetItemChecked(10))
            {
                for (int i = 0; i < AirTrafficLayersCheckList.Items.Count - 1; i++)
                    AirTrafficLayersCheckList.SetItemChecked(i, true);
                // First erase the possible layers that have been selected and then show all
                gMap.Overlays.Remove(aerodromesOverlay); gMap.Overlays.Remove(ATZ_CTR_CTA_Overlay);
                gMap.Overlays.Remove(TMA_BCN_Overlay); gMap.Overlays.Remove(TMA_VAL_Overlay);
                gMap.Overlays.Remove(SactaSectorsOverlay); gMap.Overlays.Remove(airwaysOverlay);
                gMap.Overlays.Remove(SIDproceduresOverlay); gMap.Overlays.Remove(STARproceduresOverlay);
                gMap.Overlays.Remove(SactaContourOverlay); gMap.Overlays.Remove(TMA_BCN_Tag_Overlay);
                gMap.Overlays.Remove(TMA_VAL_Tag_Overlay); gMap.Overlays.Remove(SactaSectorsTagOverlay);
                gMap.Overlays.Remove(fixedPointsAirwaysOverlay);
                gMap.Overlays.Add(aerodromesOverlay); gMap.Overlays.Add(ATZ_CTR_CTA_Overlay); 
                gMap.Overlays.Add(TMA_BCN_Overlay); gMap.Overlays.Add(TMA_VAL_Overlay); 
                gMap.Overlays.Add(SactaSectorsOverlay); gMap.Overlays.Add(airwaysOverlay); 
                gMap.Overlays.Add(SIDproceduresOverlay); gMap.Overlays.Add(STARproceduresOverlay); 
                gMap.Overlays.Add(SactaContourOverlay); gMap.Overlays.Add(TMA_BCN_Tag_Overlay); 
                gMap.Overlays.Add(TMA_VAL_Tag_Overlay); gMap.Overlays.Add(SactaSectorsTagOverlay); 
                gMap.Overlays.Add(fixedPointsAirwaysOverlay);
                
            }
            if (AirTrafficLayersCheckList.SelectedItem.ToString() == "Clear all")
            {
                gMap.Overlays.Remove(aerodromesOverlay); gMap.Overlays.Remove(ATZ_CTR_CTA_Overlay);
                gMap.Overlays.Remove(TMA_BCN_Overlay); gMap.Overlays.Remove(TMA_VAL_Overlay);
                gMap.Overlays.Remove(SactaSectorsOverlay); gMap.Overlays.Remove(airwaysOverlay);
                gMap.Overlays.Remove(SIDproceduresOverlay); gMap.Overlays.Remove(STARproceduresOverlay);
                gMap.Overlays.Remove(SactaContourOverlay); gMap.Overlays.Remove(TMA_BCN_Tag_Overlay); 
                gMap.Overlays.Remove(TMA_VAL_Tag_Overlay); gMap.Overlays.Remove(SactaSectorsTagOverlay); 
                gMap.Overlays.Remove(fixedPointsAirwaysOverlay);
                for (int i = 0; i < AirTrafficLayersCheckList.Items.Count; i++)
                    AirTrafficLayersCheckList.SetItemChecked(i, false);
                AirTrafficLayersCheckList.SetItemChecked(AirTrafficLayersCheckList.SelectedIndex, true);
            }
            if (AirTrafficLayersCheckList.CheckedItems.Contains("Tags"))
            {
                if (AirTrafficLayersCheckList.CheckedItems.Contains("TMA BCN") && !gMap.Overlays.Contains(TMA_BCN_Tag_Overlay))
                    gMap.Overlays.Add(TMA_BCN_Tag_Overlay);
                if (AirTrafficLayersCheckList.CheckedItems.Contains("TMA VAL") && !gMap.Overlays.Contains(TMA_VAL_Tag_Overlay))
                    gMap.Overlays.Add(TMA_VAL_Tag_Overlay);
                if (AirTrafficLayersCheckList.CheckedItems.Contains("Sacta Sectors") && !gMap.Overlays.Contains(SactaSectorsTagOverlay))
                    gMap.Overlays.Add(SactaSectorsTagOverlay);
                if (AirTrafficLayersCheckList.CheckedItems.Contains("Airways") && !gMap.Overlays.Contains(fixedPointsAirwaysOverlay))
                    gMap.Overlays.Add(fixedPointsAirwaysOverlay);
            }
            manageOverlays("Aerodromes", aerodromesOverlay, 0);
            manageOverlays("ATZ, CTR, CTA", ATZ_CTR_CTA_Overlay, 1);
            manageOverlays("TMA BCN", TMA_BCN_Overlay, 2);
            manageOverlays("TMA VAL", TMA_VAL_Overlay, 3);
            manageOverlays("Sacta Sectors", SactaSectorsOverlay, 4);
            manageOverlays("Airways", airwaysOverlay, 5);
            manageOverlays("SID Procedures", SIDproceduresOverlay, 6);
            manageOverlays("STAR Procedures", STARproceduresOverlay, 7);
            manageOverlays("Sacta Contour", SactaContourOverlay, 8);
            manageOverlays("Tags", TMA_BCN_Tag_Overlay, 9);
            clickedRoutesOverlay.Markers.Clear();
            gMap.Refresh();
            gMap.Zoom += 0.1; gMap.Zoom -= 0.1;
        }

        private void gMap_OnRouteClick(GMapRoute item, MouseEventArgs e)
        {
            GMarkerGoogle clickedRoute = new GMarkerGoogle(gMap.FromLocalToLatLng(e.X, e.Y), orangePoint);
            clickedRoute.ToolTipText = item.Name;
            clickedRoute.ToolTipMode = MarkerTooltipMode.Always;
            clickedRoute.ToolTip.Font = new Font("Bahnschrift Light", 7.8F, FontStyle.Regular);
            clickedRoute.ToolTip.Foreground = new SolidBrush(Color.Black);
            clickedRoute.ToolTip.Fill = new SolidBrush(Color.Transparent);
            clickedRoute.ToolTip.Stroke = new Pen(new SolidBrush(Color.Transparent));
            clickedRoute.ToolTip.Offset = new Point(0, 0);
            clickedRoutesOverlay.Markers.Add(clickedRoute);
        }
    }
}