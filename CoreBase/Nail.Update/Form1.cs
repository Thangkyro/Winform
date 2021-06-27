using Ionic.Zip;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Nail.Core;
using Nail.Core.Net;

namespace Nail.Update
{
    public partial class Form1 : Form
    { /// <summary>
      /// The default configuration file
      /// </summary>
        public const string DefaultConfigFile = "update.xml";

        public const string WorkPath = "updates";
        private volatile bool _updating;
        private readonly UpdateManifest _localConfig;
        private  UpdateManifest _remoteConfig;
        private readonly FileInfo _localConfigFile;
        //private WebClient _webClient;

        public Form1()
        {
            InitializeComponent();
            _localConfigFile = new FileInfo(DefaultConfigFile);
            Log.Write("Loaded.");
            Log.Write("Initializing using file '{0}'.", _localConfigFile.FullName);
            if (!_localConfigFile.Exists)
            {
                Log.Write("Config file '{0}' does not exist, stopping.", _localConfigFile.Name);
                return;
            }

            string data = File.ReadAllText(_localConfigFile.FullName);
            this._localConfig = new UpdateManifest(data);
            lblCurrentVersion.Text = _localConfig.Version.ToString();
            
            Shown += Form1_Shown; 
            //Activated += Form1_Shown;
            //button1.Click += Form1_Shown;

            //_webClient = new WebClient();
            //_webClient.DownloadProgressChanged += OnDownloadProgressChanged;

            //_webClient.DownloadFileCompleted += OnDownloadComplete;
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Refresh();

            if (Check())
            {
                Log.Write("Remote version is newer. Updating.");
                _updating = true;
                Thread.Sleep(2000);
                Update();
                _updating = false;
                Log.Write("Check ending.");
            }
            StartMain();
            Close();
            
        }
        

        private void StartMain()
        {
            if(_remoteConfig == null)
                Process.Start(_localConfig.MainAppExecute);
            else
                Process.Start(_remoteConfig.MainAppExecute);
        }
        private void UpdateStatus(string msg)
        {
            lblStatus.Text = msg;
            lblStatus.Refresh();

        }
        private void UpdateProgressBar(int value)
        {
            progressBar.Refresh();
        }
        private bool Check()
        {
            Log.Write("Check starting.");
            UpdateStatus("Check update information ...");
            UpdateProgressBar(0);
            if (_updating)
            {
                Log.Write("Updater is already updating.");
                Log.Write("Check ending.");
            }
            var remoteUri = new Uri(this._localConfig.RemoteConfigUri);
            UpdateProgressBar(0);
            Log.Write("Fetching '{0}'.", remoteUri.AbsoluteUri);

            var http = new Fetch { Retries = 5, RetrySleep = 30000, Timeout = 30000 };
            http.Load(remoteUri.AbsoluteUri);
            UpdateProgressBar(0);
            if (!http.Success)
            {
                Log.Write("Fetch error: {0}", http.Response.StatusDescription);
                this._remoteConfig = null;
                return false;
            }

            string data = Encoding.UTF8.GetString(http.ResponseData);
            this._remoteConfig = new UpdateManifest(data);
            lblNewVersion.Text = _remoteConfig.Version.ToString();
            lblNewVersion.Refresh();
            UpdateProgressBar(0);
            if (this._remoteConfig == null)
                return false;

            if (this._localConfig.SecurityToken != this._remoteConfig.SecurityToken)
            {
                Log.Write("Security token mismatch.");
                return false;
            }
            Log.Write("Remote config is valid.");
            Log.Write("Local version is  {0}.", this._localConfig.Version);
            Log.Write("Remote version is {0}.", this._remoteConfig.Version);

            if (this._remoteConfig.Version.CompareTo(this._localConfig.Version) == 0)
            {
                Log.Write("Versions are the same.");
                Log.Write("Check ending.");
                return false;
            }
            if (this._remoteConfig.Version.CompareTo(this._localConfig.Version) < 0)
            {
                Log.Write("Remote version is older. That's weird.");
                Log.Write("Check ending.");
                return false;
            }

            return true;
        }
        private void Update()
        {

            Log.Write("Updating '{0}' files.", this._remoteConfig.Payloads.Count);
            UpdateProgressBar(0);
            // Clean up failed attempts.
            if (Directory.Exists(WorkPath))
            {
                Log.Write("WARNING: Work directory already exists.");
                try { Directory.Delete(WorkPath, true); }
                catch (IOException)
                {
                    Log.Write("Cannot delete open directory '{0}'.", WorkPath);
                    return;
                }
            }
            UpdateProgressBar(0);
            Directory.CreateDirectory(WorkPath);
            UpdateProgressBar(0);
            // Download files in manifest.
            //foreach (string update in this._remoteConfig.Payloads)
            foreach (var update in this._remoteConfig.Payloads)
            {
                
                UpdateStatus("Downloading files: " + update.Key);
                UpdateProgressBar(0);
                Log.Write("Fetching '{0}'.", update);
                //var url = this._remoteConfig.BaseUri + update;
                var url = update.Value;
                //var uri = new Uri(_downloadURL);

                //_webClient.DownloadFileAsync(uri, Path.Combine(WorkPath, update));

                var file = Fetch.Get(url);
                if (file == null)
                {
                    Log.Write("Fetch failed.");
                    return;
                }
                var info = new FileInfo(Path.Combine(WorkPath, update.Key));
                Directory.CreateDirectory(info.DirectoryName);
                File.WriteAllBytes(Path.Combine(WorkPath, update.Key), file);
                UpdateProgressBar(0);
                // Unzip
                if (Regex.IsMatch(update.Key, @"\.zip"))
                {
                    try
                    {
                        UpdateStatus("Unzip the file: " + update.Key);
                        var zipfile = Path.Combine(WorkPath, update.Key);
                        using (var zip = ZipFile.Read(zipfile))
                            zip.ExtractAll(WorkPath, ExtractExistingFileAction.Throw);
                        File.Delete(zipfile);
                    }
                    catch (Exception ex)
                    {
                        Log.Write("Unpack failed: {0}", ex.Message);
                        return;
                    }
                }
                UpdateProgressBar(0);
            }

            UpdateStatus("Make an update ...");
            UpdateProgressBar(0);

            // Change the currently running executable so it can be overwritten.
            //Process thisprocess = Process.GetCurrentProcess();
            //string me = thisprocess.MainModule.FileName;
            //string bak = me + ".bak";
            //Log.Write("Renaming running process to '{0}'.", bak);
            //if (File.Exists(bak))
            //    File.Delete(bak);
            //File.Move(me, bak);
            //File.Copy(bak, me);

            // Write out the new manifest.
            _remoteConfig.Write(Path.Combine(WorkPath, _localConfigFile.Name));
            UpdateProgressBar(0);
            // Copy everything.
            var directory = new DirectoryInfo(WorkPath);
            var files = directory.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (FileInfo file in files)
            {
                string destination = file.FullName.Replace(directory.FullName + @"\", "");
                Log.Write("installing file '{0}'.", destination);
                Directory.CreateDirectory(new FileInfo(destination).DirectoryName);
                file.CopyTo(destination, true);
                UpdateProgressBar(0);
            }

            // Clean up.
            Log.Write("Deleting work directory.");
            Directory.Delete(WorkPath, true);

            // Restart.
            //Log.Write("Spawning new process.");
            //var spawn = Process.Start(me);
            //Log.Write("New process ID is {0}", spawn.Id);
            //Log.Write("Closing old running process {0}.", thisprocess.Id);
            //thisprocess.CloseMainWindow();
            //thisprocess.Close();
            //thisprocess.Dispose();
        }
    }
}
