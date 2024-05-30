using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DryiceProgram.MiniClass.ForFile {
    public class FileListStLink {

        public FileListStLink() {

        }

        /// <summary>
        /// Extracts the value of the first occurrence of SN: in the ST-LINK list output string.
        /// </summary>
        /// <param name="stLinkListOutput">The output string from the ST-LINK list command.</param>
        /// <returns>The value of the first occurrence of SN: in the string, or null if not found.</returns>
        public string GetSNFromStLinkList(string stLinkListOutput) {
            const string snPrefix = "SN: ";
            // find the index of the first occurrence of "SN: " in the string
            int snIndex = stLinkListOutput.IndexOf(snPrefix);
            // if "SN: " is not found, return null
            if (snIndex < 0)
            {
                return null;
            }
            // add the length of "SN: " to get the index of the beginning of the SN value
            snIndex += snPrefix.Length;
            // find the index of the next newline character after the SN value
            int snEndIndex = stLinkListOutput.IndexOf('\n', snIndex);
            // if no newline character is found, assume the end of the string
            if (snEndIndex < 0)
            {
                snEndIndex = stLinkListOutput.Length;
            }
            // extract the SN value from the string, trimming any whitespace characters
            return stLinkListOutput.Substring(snIndex, snEndIndex - snIndex).Trim();
        }

        /// <summary>
        /// Extracts the serial numbers of ST-LINK probes from the ST-LINK CLI output.
        /// </summary>
        /// <param name="stLinkCliOutput">The ST-LINK CLI output string.</param>
        /// <returns>An array of serial numbers of connected ST-LINK probes.</returns>
        public static string[] GetProbeSerialNumbers(string stLinkCliOutput) {
            List<string> serialNumbers = new List<string>();
            string[] lines = stLinkCliOutput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();

                if (line.StartsWith("SN:"))
                {
                    string serialNumber = line.Substring(4).Trim();

                    if (serialNumber != "N/A")
                    {
                        serialNumbers.Add(serialNumber);
                    }
                }
            }

            return serialNumbers.ToArray();
        }


    }
}
