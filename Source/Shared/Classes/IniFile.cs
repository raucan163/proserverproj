using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Shared.Classes
{
    /// <summary>
    /// This class makes it possible to read and write ini files.
    /// </summary>
    public class IniFile
    {
        private string sPath;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string sSection, string sKey, string sValue, string sFilePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string sSection, string sKey, string sDef, StringBuilder oReturnValue, int iSize, string sFilePath);
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sPath">Path to the ini file that has to be initialized.</param>
        public IniFile(string sPath)
        {
            this.sPath = sPath;
        }
 
        /// <summary>
        /// Writes a value into an ini file.
        /// </summary>
        /// <param name="sSection">Section</param>
        /// <param name="sKey">Name of the variable</param>
        /// <param name="sValue">Value of the variable</param>
        public void Write(string sSection, string sKey, string sValue)
        {
            WritePrivateProfileString(sSection, sKey, sValue, this.sPath);
        }

        /// <summary>
        /// Reads the value of an ini file.
        /// </summary>
        /// <param name="sSection">Section</param>
        /// <param name="sKey">Name of the variable</param>
        /// <returns>Value of the variable</returns>
        public string Read(string sSection, string sKey)
        {
            StringBuilder oTemp = new StringBuilder(255);
            int iInt = GetPrivateProfileString(sSection, sKey, "", oTemp, 255, this.sPath);
            return oTemp.ToString();
        }
    }
}