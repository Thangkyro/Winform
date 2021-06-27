using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Nail.Core
{
    public class UpdateManifest
    {
        #region Fields
        private string _data;
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateManifest"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public UpdateManifest(string data)
        {
            Load(data);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>The version.</value>
        public Version Version { get; private set; }
        /// <summary>
        /// Gets the check interval.
        /// </summary>
        /// <value>The check interval.</value>
        public int CheckInterval { get; private set; }

        /// <summary>
        /// Gets the remote configuration URI.
        /// </summary>
        /// <value>The remote configuration URI.</value>
        public string RemoteConfigUri { get; private set; }

        /// <summary>
        /// Gets the security token.
        /// </summary>
        /// <value>The security token.</value>
        public string SecurityToken { get; private set; }

        /// <summary>
        /// Gets the base URI.
        /// </summary>
        /// <value>The base URI.</value>
        public string BaseUri { get; private set; }

        public string MainAppExecute { get; private set; }
        /// <summary>
        /// Gets the payload.
        /// </summary>
        /// <value>The payload.</value>
        public IList<KeyValuePair<string, string>> Payloads { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Loads the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        private void Load(string data)
        {
            _data = data;
            try
            {
                // Load config from XML
                var xml = XDocument.Parse(data);
                if (xml.Root.Name.LocalName != "Manifest")
                {
                    Log.Write("Root XML element '{0}' is not recognized, stopping.", xml.Root.Name);
                    return;
                }

                // Set properties.
                Version = new Version(xml.Root.Attribute("version").Value);
                CheckInterval = int.Parse(xml.Root.Element("CheckInterval").Value);
                SecurityToken = xml.Root.Element("SecurityToken").Value;
                RemoteConfigUri = xml.Root.Element("RemoteConfigUri").Value;
                BaseUri = xml.Root.Element("BaseUri").Value;
                MainAppExecute = xml.Root.Element("MainAppExecute").Value;
                Payloads = new List<KeyValuePair<string, string>>();
                foreach (var e in xml.Root.Elements("Payload"))
                {
                    Payloads.Add(new KeyValuePair<string, string>(e.Attribute("filename").Value, e.Value));
                }

                //Payloads = xml.Root.Elements("Payload").Select(x => x.Value).ToArray();
            }
            catch (Exception ex)
            {
                Log.Write("Error: {0}", ex.Message);
                return;
            }
        }

        /// <summary>
        /// Writes the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        public void Write(string path)
        {
            File.WriteAllText(path, _data);
        }
        #endregion
    }
}
