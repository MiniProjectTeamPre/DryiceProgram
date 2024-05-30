using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DryiceProgram.MiniClass.ForFile {
    public class FileTxt {

        public FileTxt() {
            //วิธีการเรียกใช้
            //string fileName = "topics.txt";

            //// Create the file with some topics and details
            //Dictionary<string, List<string>> topics = new Dictionary<string, List<string>>();
            //topics["Topic 1"] = new List<string>() { "Detail 1", "Detail 2", "Detail 3" };
            //topics["Topic 2"] = new List<string>() { "Detail 4", "Detail 5", "Detail 6" };
            //topics["Topic 3"] = new List<string>() { "Detail 7", "Detail 8", "Detail 9" };
            //WriteTopicsToFile(fileName, topics);

            //// Edit one of the details in the file
            //EditDetailInFile(fileName, "Topic 2", "New detail 5");

            //// Read the file and display its contents again
            //topics = ReadTopicsFromFile(fileName);
            //Console.WriteLine("\nContents of file after editing: ");
            //foreach (KeyValuePair<string, List<string>> topic in topics)
            //{
            //    Console.WriteLine(topic.Key);
            //    foreach (string detail in topic.Value)
            //    {
            //        Console.WriteLine("\t" + detail);
            //    }
            //}
        }


        /// <summary>
        /// Writes the topics and their details to a file.
        /// </summary>
        /// <param name="fileName">The name of the file to write to.</param>
        /// <param name="topics">The dictionary of topics and their details.</param>
        public void WriteTopicsToFile(string fileName, Dictionary<string, List<string>> topics) {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (KeyValuePair<string, List<string>> topic in topics)
                {
                    writer.WriteLine("[" + topic.Key + "]");
                    foreach (string detail in topic.Value)
                    {
                        writer.WriteLine(detail);
                    }
                }
            }
        }


        ///<summary>
        ///Reads the topics and their corresponding details from the specified file.
        ///</summary>
        ///<param name="fileName">The name of the file to read from.</param>
        ///<returns>A dictionary containing the topics and their corresponding details.</returns>
        public Dictionary<string, List<string>> ReadTopicsFromFile(string fileName) {
            Dictionary<string, List<string>> topics = new Dictionary<string, List<string>>();
            if (!File.Exists(fileName))
            {
                return topics;
            }
            try
            {
                string currentTopic = "";
                List<string> currentDetails = new List<string>();
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("["))
                        {
                            // New topic found, save current topic and details and start a new one
                            if (currentTopic != "")
                            {
                                topics[currentTopic] = currentDetails;
                            }
                            currentTopic = line.Substring(1, line.Length - 2);
                            currentDetails = new List<string>();
                        }
                        else
                        {
                            // Add detail to current topic
                            currentDetails.Add(line);
                        }
                    }
                    // Save last topic and details
                    if (currentTopic != "")
                    {
                        topics[currentTopic] = currentDetails;
                    }
                }
            } catch (Exception ex)
            {
                // handle any exceptions that may occur while reading the file
                Console.WriteLine($"Error while reading file {fileName}: {ex.Message}");
            }
            return topics;
        }



        /// <summary>
        /// Edits the specified detail for the given topic in the specified file.
        /// </summary>
        /// <param name="fileName">The name of the file to edit.</param>
        /// <param name="topic">The topic to edit the detail for.</param>
        /// <param name="newDetail">The new detail to replace the old detail with.</param>
        public void EditDetailInFile(string fileName, string topic, string newDetail) {
            // Read all topics and details from the file
            Dictionary<string, List<string>> topics = ReadTopicsFromFile(fileName);

            // Check if the specified topic exists in the file
            if (topics.ContainsKey(topic))
            {
                // Replace the old detail for the specified topic with the new detail
                topics[topic] = new List<string> { newDetail };

                // Write the updated topics and details to the file
                WriteTopicsToFile(fileName, topics);
            }
        }
        public void EditDetailInFile(string fileName, string topic, List<string> newDetails) {
            // Read all topics and details from the file
            Dictionary<string, List<string>> topics = ReadTopicsFromFile(fileName);

            // Check if the specified topic exists in the file
            if (topics.ContainsKey(topic))
            {
                // Replace the old detail for the specified topic with the new details
                topics[topic] = newDetails;

                // Write the updated topics and details to the file
                WriteTopicsToFile(fileName, topics);
            }
        }



        /// <summary>
        /// Reads all details associated with a given topic from the specified file.
        /// </summary>
        /// <param name="fileName">The name of the file to read from.</param>
        /// <param name="topic">The topic to search for.</param>
        /// <returns>A list of details associated with the given topic, or a list containing "not found" if the topic was not found.</returns>
        public List<string> ReadDetailByTopic(string fileName, string topic) {
            // Read all topics and details from the file
            Dictionary<string, List<string>> topics = ReadTopicsFromFile(fileName);

            // Check if the specified topic exists in the file
            if (topics.ContainsKey(topic))
            {
                // Return a copy of the list of details associated with the specified topic,
                // to prevent the caller from accidentally modifying the original list
                return new List<string>(topics[topic]);
            }

            // If the specified topic was not found, return a list containing "not found"
            return new List<string>() { "not found" };
        }



        /// <summary>
        /// Attempts to delete a file, retrying up to a specified number of times with a specified delay between attempts.
        /// </summary>
        /// <param name="filePath">The path to the file to delete.</param>
        /// <param name="maxAttempts">The maximum number of attempts to delete the file.</param>
        /// <param name="retryDelayMs">The delay between retry attempts in milliseconds.</param>
        /// <returns>True if the file was successfully deleted, false otherwise.</returns>
        public bool TryDeleteFile(string filePath, int maxAttempts = 5, int retryDelayMs = 200) {
            int attempts = 0;
            while (attempts < maxAttempts)
            {
                try
                {
                    File.Delete(filePath);
                    return true; // File deleted successfully
                } catch
                {
                    // Ignore any exceptions and retry
                    attempts++;
                    Thread.Sleep(retryDelayMs);
                }
            }
            return false; // Max attempts reached without success
        }


    }
}
