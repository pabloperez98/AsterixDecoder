using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ClassLibrary
{

    // Class that reads the file asterix (.ast), decodes the messages by calling the functions of the respective classes
    // and returns the filled lists and tables of the respective CATs and versions
    public class AsterixFile
    {
        public string fileName;
        public byte[] fileBytes;
        int bytes = 0;
        int messageLength;
        AsterixData data;
        public double initialSecondsFile;
        public double finalSecondsFile;
        public double initialSecondsSelected;
        public double finalSecondsSelected;
        public Boolean timeFounded;
        
        public AsterixFile(string path, AsterixData data)
        {
            this.fileName = path.Split('\\')[path.Split('\\').Count() - 1];
            this.fileBytes = File.ReadAllBytes(path);
            this.data = data;
        }

        public double obtainSeconds(byte[] fileBytes, int bytes)
        { 
            double seconds;
            this.messageLength = Convert.ToInt32(fileBytes[bytes + 1].ToString("X").PadLeft(2, '0') + fileBytes[bytes + 2].ToString("X").PadLeft(2, '0'), 16);
            List<string> messageHex = new List<string>();
            for (int j = 0; j < this.messageLength; j++)
            { messageHex.Add(fileBytes[bytes].ToString("X").PadLeft(2, '0')); bytes++; }
            CATs packetCAT = new CATs(messageHex, data); // Add to the class CATs the message HEX
            packetCAT.category = Convert.ToInt32(messageHex[0], 16).ToString().PadLeft(2, '0');
            if (data.listaCATs.Count != 0 && packetCAT.category == "01" && data.messagesCAT48 != 0)
                packetCAT.numberOftruncatedTimes = Convert.ToInt32(data.listaCATs[data.rowPosition - 1].timeOfDay.seconds) / 512;
            if (packetCAT.category == "01" && packetCAT.numberOftruncatedTimes == 0) 
            { } // Omit CAT01 packets that it is not known the UTC time, only truncated time
            else
                packetCAT.obtainTimeUTC();
            timeFounded = packetCAT.timeFounded;
            if (packetCAT.category == "08" && !timeFounded && data.listaCATs.Count != 0 && data.messagesCAT08 != 0) // To be able to decode CAT08 polar vectors
                seconds = data.listaCATs[data.rowPosition - 1].timeOfDay.seconds;
            else
                seconds = packetCAT.timeOfDay.seconds;
            if (data.listaCATs.Count != 0 && packetCAT.category == "01")
            {
                if (seconds - data.listaCATs[data.rowPosition - 1].timeOfDay.seconds > 10)
                { packetCAT.numberOftruncatedTimes -= 1; seconds -= 512; }
            }  
            return seconds;
        }

        public int obtainMessagePosition(byte[] fileBytes, int bytes)
        {
            List<int> CATs = new List<int>() {1, 2, 8, 10, 21, 34, 48 };
            while (bytes > 0)
            {
                if (this.fileName.Substring(this.fileName.Length - 3) == "gps" && fileBytes[bytes] == 0 && CATs.Contains(fileBytes[bytes - 1]) && fileBytes[bytes - 2] == 0 && fileBytes[bytes - 6] == 0 && fileBytes[bytes - 7] == 0)
                { bytes--; break; }
                else if (!this.fileName.Contains(".") && fileBytes[bytes] == 0 && fileBytes[bytes - 1] == 62)
                {
                    bytes--;
                    this.messageLength = Convert.ToInt32(fileBytes[bytes + 1].ToString("X").PadLeft(2, '0') + fileBytes[bytes + 2].ToString("X").PadLeft(2, '0'), 16);
                    if (this.messageLength + bytes < fileBytes.Length && Convert.ToInt32(fileBytes[bytes + this.messageLength].ToString("X").PadLeft(2, '0'), 16).ToString().PadLeft(2, '0') == "62")
                        break;
                }
                else if (this.fileName.Substring(this.fileName.Length - 3) == "ast" && fileBytes[bytes] == 0 && CATs.Contains(fileBytes[bytes - 1]))
                { 
                    bytes--;
                    this.messageLength = Convert.ToInt32(fileBytes[bytes + 1].ToString("X").PadLeft(2, '0') + fileBytes[bytes + 2].ToString("X").PadLeft(2, '0'), 16);
                    if (this.messageLength + bytes == fileBytes.Length || (this.messageLength + bytes < fileBytes.Length && (CATs.Contains(Convert.ToInt32(fileBytes[bytes + this.messageLength].ToString("X").PadLeft(2, '0'), 16)))))
                        break;
                }
                bytes--;
            }
            return bytes;
        }

        public void obtainInitialFinalTime(byte[] fileBytes)
        {
            if (this.fileName.Substring(this.fileName.Length - 3) == "gps")
                bytes = 2200;
            else if (!this.fileName.Contains("."))
            { while (fileBytes[bytes] != 62) bytes++; }
            while (fileBytes[bytes] == 1) // File starting with CAT01 packet, needs to be avoided because it is not possible to obtain the time
            {
                messageLength = Convert.ToInt32(fileBytes[bytes + 1].ToString("X").PadLeft(2, '0') + fileBytes[bytes + 2].ToString("X").PadLeft(2, '0'), 16);
                bytes += messageLength;
                if (this.fileName.Substring(this.fileName.Length - 3) == "gps")
                    bytes += 10;
            }
            initialSecondsFile = obtainSeconds(fileBytes, bytes);
            int bytesInitialSeconds = bytes;
            if (this.fileName.Substring(this.fileName.Length - 3) == "gps")
            {
                for (int i = 0; i < 5; i++) // In files with CAT01, 02, 34, 48 maybe initial time is not in the 1st packet
                {
                    bytesInitialSeconds += this.messageLength + 10;
                    double seconds = obtainSeconds(fileBytes, bytesInitialSeconds);
                    if (seconds < initialSecondsFile && timeFounded)
                        initialSecondsFile = seconds;
                }
            }
            int positionLastPacket = obtainMessagePosition(fileBytes, fileBytes.Length - 1);
            finalSecondsFile = obtainSeconds(fileBytes, positionLastPacket);
            timeFounded = false;
            while (fileBytes[positionLastPacket] == 1) // File starting with CAT01 packet, needs to be avoided because it is not possible to obtain the time
            {
                positionLastPacket = obtainMessagePosition(fileBytes, positionLastPacket);
                finalSecondsFile = obtainSeconds(fileBytes, positionLastPacket);
            }
            if (finalSecondsFile < 4 * 60)
                finalSecondsFile = 86399;
            timeFounded = false;
        }

        // Function that reads the desired Asterix file, decodes it and adds each message in its list and table
        public void readAsterixFile(byte[] fileBytes)
        {
            double seconds = 0; timeFounded = false;
            if (initialSecondsSelected - initialSecondsFile == 0) // Same initial file and selected seconds
                seconds = obtainSeconds(fileBytes, bytes);
            else // Predicting the initial seconds position in the file
            {
                int estimatedByte = Convert.ToInt32(Math.Truncate((initialSecondsSelected - initialSecondsFile) / (finalSecondsFile - initialSecondsFile) * fileBytes.Length));
                bytes = obtainMessagePosition(fileBytes, estimatedByte);
                while (timeFounded != true)
                { seconds = obtainSeconds(fileBytes, bytes); bytes = obtainMessagePosition(fileBytes, bytes); }
            }
            timeFounded = false;
            Boolean initialpositionFounded = false;
            // Finding the initial seconds position in the file
            while (seconds != initialSecondsSelected && !initialpositionFounded)
            {
                if (seconds > initialSecondsSelected || (initialSecondsFile > 20*3600 && seconds < 300))
                {
                    while (timeFounded != true)
                    { 
                        bytes -= 50000;
                        if (bytes < 0 && this.fileName.Substring(this.fileName.Length - 3) == "gps")
                        { bytes = 2200; seconds = obtainSeconds(fileBytes, bytes); initialpositionFounded = true; break; }
                        else if (!this.fileName.Contains("."))
                        { bytes = 0; while (fileBytes[bytes] != 62) bytes++; seconds = obtainSeconds(fileBytes, bytes); break; }
                        else if (bytes < 0 && this.fileName.Substring(this.fileName.Length - 3) == "ast")
                        { bytes = 0; seconds = obtainSeconds(fileBytes, bytes); break; }
                        bytes = obtainMessagePosition(fileBytes, bytes);
                        seconds = obtainSeconds(fileBytes, bytes);
                    }
                    timeFounded = false;
                }
                else
                {
                    while (seconds < initialSecondsSelected)
                    {
                        seconds = obtainSeconds(fileBytes, bytes);
                        bytes += this.messageLength;
                        if (seconds == initialSecondsSelected || seconds > initialSecondsSelected)
                        { bytes -= this.messageLength; initialpositionFounded = true; break; }
                        if (this.fileName.Substring(this.fileName.Length - 3) == "gps")
                        {
                            if (bytes + 12 < fileBytes.Length)
                                messageLength = Convert.ToInt32(fileBytes[bytes + 11].ToString("X").PadLeft(2, '0') + fileBytes[bytes + 12].ToString("X").PadLeft(2, '0'), 16);
                            bytes += 10;
                        }
                        else
                        {
                            if (bytes + 2 < fileBytes.Length)
                                messageLength = Convert.ToInt32(fileBytes[bytes + 1].ToString("X").PadLeft(2, '0') + fileBytes[bytes + 2].ToString("X").PadLeft(2, '0'), 16);
                        }
                    }
                }
            }

            // Starting to decode the file at the selected initial time
            messageLength = Convert.ToInt32(fileBytes[bytes + 1].ToString("X").PadLeft(2, '0') + fileBytes[bytes + 2].ToString("X").PadLeft(2, '0'), 16);
            while (bytes < fileBytes.Length && seconds <= this.finalSecondsSelected + 2)
            {
                seconds = obtainSeconds(fileBytes, bytes);
                List<string> messageHex = new List<string>();
                for (int j = 0; j < messageLength; j++) //Message in Hexadecimal
                { messageHex.Add(fileBytes[bytes].ToString("X").PadLeft(2, '0')); bytes++; }
                if (seconds <= this.finalSecondsSelected && seconds >= this.initialSecondsSelected) // Decoding the message
                { DecodeAndFillFlight(messageHex); data.packetNumber += 1; }
                // *GPS files has 10 extra bits between each message
                if (this.fileName.Substring(this.fileName.Length - 3) == "gps")
                {
                    if (bytes + 12 < fileBytes.Length)
                        messageLength = Convert.ToInt32(fileBytes[bytes + 11].ToString("X").PadLeft(2, '0') + fileBytes[bytes + 12].ToString("X").PadLeft(2, '0'), 16);
                    bytes += 10;
                }
                else
                {
                    if (bytes + 2 < fileBytes.Length)
                        messageLength = Convert.ToInt32(fileBytes[bytes + 1].ToString("X").PadLeft(2, '0') + fileBytes[bytes + 2].ToString("X").PadLeft(2, '0'), 16);
                    while (messageLength == 0)
                    {
                        while (fileBytes[bytes] != 62 || fileBytes[bytes + 1] != 0)
                            bytes++;
                        if (bytes + 2 < fileBytes.Length)
                            messageLength = Convert.ToInt32(fileBytes[bytes + 1].ToString("X").PadLeft(2, '0') + fileBytes[bytes + 2].ToString("X").PadLeft(2, '0'), 16);
                    }
                }
            }
        }

        public void DecodeAndFillFlight(List<string> message)
        {
            int messageLength = Convert.ToInt32(message[1] + message[2], 16);
            int indexMessage = 0;
            int messagesInPacket = 0;
            while (indexMessage < messageLength)
            {
                CATs packetCAT = new CATs(message, data);
                packetCAT.category = Convert.ToInt32(message[0], 16).ToString().PadLeft(2, '0');
                
                if (!data.analyzedCATs.Contains(packetCAT.category))
                    break;
                if (data.listaCATs.Count != 0 && packetCAT.category == "01")
                    packetCAT.numberOftruncatedTimes = Convert.ToInt32(data.listaCATs[data.rowPosition - 1].timeOfDay.seconds) / 512;
                List<string> multipleMessagesInPacket = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
                if (messagesInPacket > 0)
                {
                    packetCAT.firstIndex = indexMessage;
                    data.listaCATs[data.rowPosition - 1].packetNumber = data.packetNumber.ToString() + multipleMessagesInPacket[messagesInPacket - 1];
                    packetCAT.packetNumber = data.packetNumber.ToString() + multipleMessagesInPacket[messagesInPacket];
                    data.tablaCATs.Rows[data.rowPosition - 1][0] = data.packetNumber.ToString() + multipleMessagesInPacket[messagesInPacket - 1];
                }
                packetCAT.row = data.tablaCATs.NewRow();
                if (messagesInPacket == 0)
                    packetCAT.packetNumber = data.packetNumber.ToString();
                packetCAT.DecodeCATs();
                if (packetCAT.category == "08" && packetCAT.messageType == "Polar vector")
                {
                    int i = data.listaCATs.Count - 1;
                    while (data.listaCATs[i].messageType != "SOP message")
                        i--;
                    packetCAT.timeOfDay.seconds = data.listaCATs[i].timeOfDay.seconds;
                    packetCAT.timeOfDay.decimalSeconds = data.listaCATs[i].timeOfDay.decimalSeconds;
                }
                if (data.listaCATs.Count != 0)
                {
                    if (packetCAT.timeOfDay.seconds - data.listaCATs[data.listaCATs.Count - 1].timeOfDay.seconds > 10 && packetCAT.category == "01")
                    { packetCAT.numberOftruncatedTimes -= 1; packetCAT.timeOfDay.decimalSeconds -= 512; packetCAT.timeOfDay.seconds -= 512; }
                }
                // Sorting CATs Table by UTC Time
                if (data.tablaCATs.Rows.Count != 0 && packetCAT.timeOfDay.seconds <= this.finalSecondsSelected && packetCAT.timeOfDay.seconds >= this.initialSecondsSelected)
                {
                    if (data.rowPosition == 0)
                        data.rowPosition += 1;
                    while (packetCAT.timeOfDay.decimalSeconds > data.listaCATs[data.rowPosition - 1].timeOfDay.decimalSeconds && data.rowPosition < data.tablaCATs.Rows.Count)
                        data.rowPosition += 1;
                    while (packetCAT.timeOfDay.decimalSeconds < data.listaCATs[data.rowPosition - 1].timeOfDay.decimalSeconds)
                    {
                        data.rowPosition -= 1;
                        if (data.rowPosition == 0)
                            break;
                    }
                }
                if (packetCAT.timeOfDay.seconds <= this.finalSecondsSelected && packetCAT.timeOfDay.seconds >= this.initialSecondsSelected)
                {
                    data.listaCATs.Insert(data.rowPosition, packetCAT);
                    data.tablaCATs.Rows.InsertAt(packetCAT.row, data.rowPosition);
                    data.rowPosition += 1;
                }
                //Fill CATsList, DSIList and SensorList
                if (!data.CATsList.Contains(packetCAT.category))
                    data.CATsList.Add(packetCAT.category);
                if (!data.DSIList.Contains(packetCAT.dataSourceIdentifier))
                    data.DSIList.Add(packetCAT.dataSourceIdentifier);
                if (!data.SensorList.Contains(packetCAT.sensor) && packetCAT.sensor != "N/A")
                    data.SensorList.Add(packetCAT.sensor);
                messagesInPacket += 1;
                indexMessage = packetCAT.firstIndex;
                if (packetCAT.category == "01")
                {
                    data.messagesCAT01++;
                    if (packetCAT.mode3A.Reply != "N/A" && packetCAT.mode3A.Reply != "7777" && packetCAT.mode3A.Reply != "1000" && packetCAT.mode3A.Reply != "7000")
                    {
                        if (data.FlightList.Exists(r => r.mode3A == packetCAT.mode3A.Reply))
                        {
                            int flightIndex = data.FlightList.FindIndex(r => r.mode3A == packetCAT.mode3A.Reply);
                            // Sort the radar data chronologically of flights detected by various radars
                            int index = data.FlightList[flightIndex].decimalSeconds.Count - 1;
                            while (data.FlightList[flightIndex].decimalSeconds[index] > packetCAT.timeOfDay.decimalSeconds)
                            { index--; if (index == -1) { break; } }
                            data.FlightList[flightIndex].insertValueFlight(index + 1, packetCAT.category, packetCAT.sensor, packetCAT.trackNumber, packetCAT.timeOfDay.seconds, packetCAT.timeOfDay.decimalSeconds, packetCAT.positionWGS84.longitude, packetCAT.positionWGS84.latitude, packetCAT.flightLevel.altitude, packetCAT.flightLevel.FL, packetCAT.trackVelocityPolar.groundSpeed, 0);
                        }
                        else
                        {
                            Flight flight = new Flight();
                            flight.fillFlight(packetCAT.category, packetCAT.sensor, packetCAT.callsign.TargetID, packetCAT.ICAOAdress, packetCAT.trackNumber, packetCAT.mode3A.Reply, packetCAT.timeOfDay.seconds, packetCAT.timeOfDay.decimalSeconds, packetCAT.positionWGS84.longitude, packetCAT.positionWGS84.latitude, packetCAT.flightLevel.altitude, packetCAT.flightLevel.FL, packetCAT.trackVelocityPolar.groundSpeed, 0);
                            data.FlightList.Add(flight);
                        }
                    }
                }
                else if (packetCAT.category == "02")
                {
                    data.messagesCAT02++;
                }
                else if (packetCAT.category == "08")
                {
                    data.messagesCAT08++;
                }
                else if (packetCAT.category == "10")
                {
                    data.messagesCAT10++;
                    double trackVelocity = 0;
                    if (packetCAT.trackVelocityPolar.trackAngle != 0)
                        trackVelocity = Math.Abs(packetCAT.trackVelocityCartesian.Vy * Math.Cos(packetCAT.trackVelocityPolar.trackAngle));
                    // Filling the list of SMR aircraft filtering by Track Number
                    if (data.RadarStationList.Find(r => r.radarStation == packetCAT.sensor).type == "SMR")
                    {
                        if (packetCAT.trackNumber != "N/A" && packetCAT.positionCartesian.x != 0)
                        {
                            if (data.FlightList.Exists(r => r.trackNumber.Contains(packetCAT.trackNumber)))
                            {
                                int flightIndex = data.FlightList.FindIndex(r => r.trackNumber.Contains(packetCAT.trackNumber));
                                // Sort the radar data chronologically of flights detected by various radars
                                int index = data.FlightList[flightIndex].decimalSeconds.Count - 1;
                                while (data.FlightList[flightIndex].decimalSeconds[index] > packetCAT.timeOfDay.decimalSeconds)
                                { index--; if (index == -1) { break; } }
                                data.FlightList[flightIndex].insertValueFlight(index + 1, packetCAT.category, packetCAT.sensor, packetCAT.trackNumber, packetCAT.timeOfDay.seconds, packetCAT.timeOfDay.decimalSeconds, packetCAT.positionWGS84.longitude, packetCAT.positionWGS84.latitude, packetCAT.flightLevel.altitude, packetCAT.flightLevel.FL, packetCAT.trackVelocityPolar.groundSpeed, 0);
                            }
                            else
                            {
                                Flight flight = new Flight();
                                flight.fillFlight(packetCAT.category, packetCAT.sensor, packetCAT.callsign.TargetID, packetCAT.ICAOAdress, packetCAT.trackNumber, packetCAT.mode3A.Reply, packetCAT.timeOfDay.seconds, packetCAT.timeOfDay.decimalSeconds, packetCAT.positionWGS84.longitude, packetCAT.positionWGS84.latitude, packetCAT.flightLevel.altitude, packetCAT.flightLevel.FL, packetCAT.trackVelocityPolar.groundSpeed, 0);
                                data.FlightList.Add(flight);
                            }
                        }
                    }
                    // Filling the list of MLAT aircraft filtering by ICAO Address
                    else if (data.RadarStationList.Find(r => r.radarStation == packetCAT.sensor).type == "SMMS") //MLAT
                    {
                        if (packetCAT.ICAOAdress != "N/A" && packetCAT.positionCartesian.x != 0)
                        {
                            if (data.FlightList.Exists(r => r.ICAOadress == packetCAT.ICAOAdress))
                            {
                                int flightIndex = data.FlightList.FindIndex(r => r.ICAOadress == packetCAT.ICAOAdress);
                                // Sort the radar data chronologically of flights detected by various radars
                                int index = data.FlightList[flightIndex].decimalSeconds.Count - 1;
                                while (data.FlightList[flightIndex].decimalSeconds[index] > packetCAT.timeOfDay.decimalSeconds)
                                { index--; if (index == -1) { break; } }
                                data.FlightList[flightIndex].insertValueFlight(index + 1, packetCAT.category, packetCAT.sensor, packetCAT.trackNumber, packetCAT.timeOfDay.seconds, packetCAT.timeOfDay.decimalSeconds, packetCAT.positionWGS84.longitude, packetCAT.positionWGS84.latitude, packetCAT.flightLevel.altitude, packetCAT.flightLevel.FL, packetCAT.trackVelocityPolar.groundSpeed, 0);
                            }
                            else
                            {
                                Flight flight = new Flight();
                                flight.fillFlight(packetCAT.category, packetCAT.sensor, packetCAT.callsign.TargetID, packetCAT.ICAOAdress, packetCAT.trackNumber, packetCAT.mode3A.Reply, packetCAT.timeOfDay.seconds, packetCAT.timeOfDay.decimalSeconds, packetCAT.positionWGS84.longitude, packetCAT.positionWGS84.latitude, packetCAT.flightLevel.altitude, packetCAT.flightLevel.FL, packetCAT.trackVelocityPolar.groundSpeed, 0);
                                data.FlightList.Add(flight);
                            }
                        }
                    }
                }
                else if (packetCAT.category == "21")
                {
                    data.messagesCAT21++;
                    // Filling the list of aircraft filtering by ICAO Address
                    if (packetCAT.ICAOAdress != "N/A" && packetCAT.positionWGS84.latitude != 0)
                    {
                        if (data.FlightList.Exists(r => r.ICAOadress == packetCAT.ICAOAdress || (r.mode3A == packetCAT.mode3A.Reply && packetCAT.mode3A.Reply != "N/A")))
                        {
                            int flightIndex = data.FlightList.FindIndex(r => r.ICAOadress == packetCAT.ICAOAdress || (r.mode3A == packetCAT.mode3A.Reply && packetCAT.mode3A.Reply != "N/A"));
                            // Sort the radar data chronologically of flights detected by various radars
                            int index = data.FlightList[flightIndex].decimalSeconds.Count - 1;
                            while (data.FlightList[flightIndex].decimalSeconds[index] > packetCAT.timeOfDay.decimalSeconds)
                            { index--; if (index == -1) { break; } }
                            data.FlightList[flightIndex].insertValueFlight(index + 1, packetCAT.category, packetCAT.sensor, packetCAT.trackNumber, packetCAT.timeOfDay.seconds, packetCAT.timeOfDay.decimalSeconds, packetCAT.positionWGS84.longitude, packetCAT.positionWGS84.latitude, packetCAT.flightLevel.altitude, packetCAT.flightLevel.FL, packetCAT.trackVelocityPolar.groundSpeed, 0);
                            if (data.FlightList[flightIndex].callsign == "N/A")
                                data.FlightList[flightIndex].callsign = packetCAT.callsign.TargetID;
                            if (data.FlightList[flightIndex].mode3A == "N/A")
                                data.FlightList[flightIndex].mode3A = packetCAT.mode3A.Reply;
                            if (data.FlightList[flightIndex].ICAOadress == "N/A")
                                data.FlightList[flightIndex].ICAOadress = packetCAT.ICAOAdress;
                        }
                        else
                        {
                            Flight flight = new Flight();
                            flight.fillFlight(packetCAT.category, packetCAT.sensor, packetCAT.callsign.TargetID, packetCAT.ICAOAdress, packetCAT.trackNumber, packetCAT.mode3A.Reply, packetCAT.timeOfDay.seconds, packetCAT.timeOfDay.decimalSeconds, packetCAT.positionWGS84.longitude, packetCAT.positionWGS84.latitude, packetCAT.flightLevel.altitude, packetCAT.flightLevel.FL, packetCAT.groundVector.GroundSpeed, 0);
                            data.FlightList.Add(flight);
                        }
                    }
                }
                else if (packetCAT.category == "34")
                {
                    data.messagesCAT34++;
                }
                else if (packetCAT.category == "48")
                {
                    data.messagesCAT48++;
                    if (packetCAT.ICAOAdress != "N/A" && packetCAT.positionWGS84.longitude != 0)
                    {
                        if (data.FlightList.Exists(r => (r.ICAOadress == packetCAT.ICAOAdress && (r.mode3A == packetCAT.mode3A.Reply || packetCAT.callsign.TargetID == "N/A")) || (r.mode3A == packetCAT.mode3A.Reply && r.ICAOadress == "N/A")))
                        {
                            int flightIndex = data.FlightList.FindIndex(r => (r.ICAOadress == packetCAT.ICAOAdress && (r.mode3A == packetCAT.mode3A.Reply || packetCAT.callsign.TargetID == "N/A")) || (r.mode3A == packetCAT.mode3A.Reply && r.ICAOadress == "N/A"));
                            // Sort the radar data chronologically of flights detected by various radars
                            int index = data.FlightList[flightIndex].decimalSeconds.Count - 1;
                            while (data.FlightList[flightIndex].decimalSeconds[index] > packetCAT.timeOfDay.decimalSeconds)
                            { index--; if (index == -1) { break; } }
                            data.FlightList[flightIndex].insertValueFlight(index + 1, packetCAT.category, packetCAT.sensor, packetCAT.trackNumber, packetCAT.timeOfDay.seconds, packetCAT.timeOfDay.decimalSeconds, packetCAT.positionWGS84.longitude, packetCAT.positionWGS84.latitude, packetCAT.flightLevel.altitude, packetCAT.flightLevel.FL, packetCAT.trackVelocityPolar.groundSpeed, 0);
                            if (data.FlightList[flightIndex].callsign == "N/A")
                                data.FlightList[flightIndex].callsign = packetCAT.callsign.TargetID;
                            if (data.FlightList[flightIndex].mode3A == "N/A")
                                data.FlightList[flightIndex].mode3A = packetCAT.mode3A.Reply;
                            if (data.FlightList[flightIndex].ICAOadress == "N/A")
                                data.FlightList[flightIndex].ICAOadress = packetCAT.ICAOAdress;
                        }
                        else
                        {
                            Flight flight = new Flight();
                            flight.fillFlight(packetCAT.category, packetCAT.sensor, packetCAT.callsign.TargetID, packetCAT.ICAOAdress, packetCAT.trackNumber, packetCAT.mode3A.Reply, packetCAT.timeOfDay.seconds, packetCAT.timeOfDay.decimalSeconds, packetCAT.positionWGS84.longitude, packetCAT.positionWGS84.latitude, packetCAT.flightLevel.altitude, packetCAT.flightLevel.FL, packetCAT.trackVelocityPolar.groundSpeed, 0);
                            data.FlightList.Add(flight);
                        }
                    }
                }
                else if (packetCAT.category == "62")
                {
                    data.messagesCAT62++;
                    if (packetCAT.ICAOAdress != "N/A" && packetCAT.positionWGS84.longitude != 0)
                    {
                        if (data.FlightList.Exists(r => r.ICAOadress == packetCAT.ICAOAdress && r.callsign == packetCAT.callsign.TargetID))
                        {
                            int flightIndex = data.FlightList.FindIndex(r => r.ICAOadress == packetCAT.ICAOAdress && r.callsign == packetCAT.callsign.TargetID);
                            // Sort the radar data chronologically of flights detected by various radars
                            int index = data.FlightList[flightIndex].decimalSeconds.Count - 1;
                            while (data.FlightList[flightIndex].decimalSeconds[index] > packetCAT.timeOfDay.decimalSeconds)
                            { index--; if (index == -1) { break; } }
                            data.FlightList[flightIndex].insertValueFlight(index + 1, packetCAT.category, packetCAT.sensor, packetCAT.trackNumber, packetCAT.timeOfDay.seconds, packetCAT.timeOfDay.decimalSeconds, packetCAT.positionWGS84.longitude, packetCAT.positionWGS84.latitude, packetCAT.flightLevel.altitude, packetCAT.flightLevel.FL, packetCAT.trackVelocityPolar.groundSpeed, 0);
                        }
                        else
                        {
                            Flight flight = new Flight();
                            flight.fillFlight(packetCAT.category, packetCAT.sensor, packetCAT.callsign.TargetID, packetCAT.ICAOAdress, packetCAT.trackNumber, packetCAT.mode3A.Reply, packetCAT.timeOfDay.seconds, packetCAT.timeOfDay.decimalSeconds, packetCAT.positionWGS84.longitude, packetCAT.positionWGS84.latitude, packetCAT.flightLevel.altitude, packetCAT.flightLevel.FL, packetCAT.trackVelocityPolar.groundSpeed, 0);
                            data.FlightList.Add(flight);
                        }
                    }
                }
                // Filling the lists with the DataItems of interest and then show it in the filter tables of the Map View
                if (!data.TrackNumberList.Contains(packetCAT.trackNumber) && packetCAT.trackNumber != "N/A")
                    data.TrackNumberList.Add(packetCAT.trackNumber);
                if (!data.CallsignList.Contains(packetCAT.callsign.TargetID) && packetCAT.callsign.TargetID != "N/A")
                    data.CallsignList.Add(packetCAT.callsign.TargetID);
            }
        }
    }
}