using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Extensions.SettingsManager
{
    /// <summary>
    /// Entry-Point For SettingsManager
    /// </summary>
    class Main
    {

    //    #region Attributes
    //    private String _fileLocation = "";
    //    public SortedDictionary<String, String> settings = new SortedDictionary<string, string>();
    //    #endregion

    //    #region Constructor

    //    public Main(String fileLocation = "settings.ini")
    //    {
    //        if (!File.Exists(fileLocation))
    //        {
    //            throw new FileNotFoundException("The File: '" + fileLocation + "' was not found.");
    //        }
    //        _fileLocation = fileLocation;
            
    //    }

    //    #endregion

    //    #region Properties

        

    //    #endregion

    //    #region Methods

    //    public void load()
    //    {
    //        settings = new SortedDictionary<string, string>();
    //        foreach (string str in File.ReadAllText(_fileLocation).Split((string)Environment.NewLine))
    //        {
    //            settings.Add(str.Split(string["=="])[0],str.Split(string["=="])[1]);
    //        }
    //    }

    //    public void Save()
    //    {
    //        string file = "";
    //        foreach (string key in settings.Keys)
    //        {
    //            file += key+"=="+settings[key]+Environment.NewLine;
    //        }
    //        File.WriteAllText(_fileLocation, file);
    //    }

    //    #endregion

    }
}
