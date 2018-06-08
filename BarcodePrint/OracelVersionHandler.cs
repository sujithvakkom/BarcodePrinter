using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.Win32;

namespace BarcodePrinter
{
    public class OracelVersionHandler
    {
        public enum OracleVersion
        {
            Oracle9,
            Oracle10,
            Oracle0
        };

        public OracleVersion GetOracleVersion()
        {
            RegistryKey rgkLM = Registry.LocalMachine;
            RegistryKey rgkAllHome = rgkLM.OpenSubKey(@"SOFTWARE\ORACLE\ALL_HOMES");

            /* 
             * 10g Installationen don't have an ALL_HOMES key
             * Try to find HOME at SOFTWARE\ORACLE\
             * 10g homes start with KEY_
             */
            string[] okeys = rgkLM.OpenSubKey(@"SOFTWARE\ORACLE").GetSubKeyNames();
            foreach (string okey in okeys)
            {
                if (okey.StartsWith("KEY_"))
                    return OracleVersion.Oracle10;
            }

            if (rgkAllHome != null)
            {
                string strLastHome = "";
                object objLastHome = rgkAllHome.GetValue("LAST_HOME");
                strLastHome = objLastHome.ToString();
                RegistryKey rgkActualHome = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\ORACLE\HOME" + strLastHome);
                string strOraHome = "";
                object objOraHome = rgkActualHome.GetValue("ORACLE_HOME");
                string strOracleHome = strOraHome = objOraHome.ToString();
                return OracleVersion.Oracle9;
            }
            return OracleVersion.Oracle0;
        }

        public string GetOracleHome()
        {
            RegistryKey rgkLM = Registry.LocalMachine;
            RegistryKey rgkAllHome = rgkLM.OpenSubKey(@"SOFTWARE\ORACLE\ALL_HOMES");
            OracleVersion ov = this.GetOracleVersion();

            switch (ov)
            {
                case OracleVersion.Oracle10:
                    {
                        string[] okeys = rgkLM.OpenSubKey(@"SOFTWARE\ORACLE").GetSubKeyNames();
                        foreach (string okey in okeys)
                        {
                            if (okey.StartsWith("KEY_"))
                            {
                                return rgkLM.OpenSubKey(@"SOFTWARE\ORACLE\" + okey).GetValue("ORACLE_HOME") as string;
                            }
                        }
                        throw new Exception("No Oracle Home found");
                    }
                case OracleVersion.Oracle9:
                    {
                        string strLastHome = "";
                        object objLastHome = rgkAllHome.GetValue("LAST_HOME");
                        strLastHome = objLastHome.ToString();
                        RegistryKey rgkActualHome = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\ORACLE\HOME" + strLastHome);
                        string strOraHome = "";
                        object objOraHome = rgkActualHome.GetValue("ORACLE_HOME");
                        string strOracleHome = strOraHome = objOraHome.ToString();
                        return strOraHome;
                    }
                default:
                    {
                        throw new Exception("No supported Oracle Installation found");
                    }
            }
        }


        /// <summary>
        /// Get TNS Name Entries from TNSNames.ora file
        /// </summary>
        /// <returns></returns>
        public List<string> LoadTNSNames()
        {
            List<string> DBNamesCollection = new List<string>();
            string regPattern = @"[\n][\s]*[^\(][a-zA-Z0-9_.]+[\s]*";
            string tnsNamesOraFilePath = GetPathToTNSNamesFile();

            if (!tnsNamesOraFilePath.Equals(""))
            {
                // Verify file exists
                FileInfo tnsNamesOraFile = new FileInfo(tnsNamesOraFilePath);
                if (tnsNamesOraFile.Exists)
                {
                    if (tnsNamesOraFile.Length > 0)
                    {
                        //read tnsnames.ora file                        
                        string tnsNamesContents = File.ReadAllText(tnsNamesOraFile.FullName);
                        int numMatches = Regex.Matches(tnsNamesContents, regPattern).Count;
                        MatchCollection col = Regex.Matches(tnsNamesContents, regPattern);
                        foreach (Match match in col)
                        {
                            string m = match.ToString();
                            m = m.Trim();
                            DBNamesCollection.Add(m.ToUpper());
                        }
                    }
                }
            }
            return DBNamesCollection;
        }

        /// <summary>
        /// Gets TNSNames file path from system path
        /// </summary>
        /// <returns>TNSNames.ora file path</returns>
        public string GetPathToTNSNamesFile()
        {
            string systemPath = Environment.GetEnvironmentVariable("Path");
            Regex reg = new Regex
                ("[a-zA-Z]:\\\\[a-zA-Z0-9\\\\]*(oracle|app)[a-zA-Z0-9_.\\\\]*(?=bin)");
            MatchCollection col = reg.Matches(systemPath);

            string subpath = "network\\ADMIN\\tnsnames.ora";
            foreach (Match match in col)
            {
                string path = match.ToString() + subpath;
                if (File.Exists(path))
                    return path;
            }
            return string.Empty;
        }

    }
}
