using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Diagnostics;

namespace Com.Dover.IntegrationLib {
	public class DoverApiHelper {
		internal static string BaseUrl;
		
		public DoverApiHelper(string _userName) {
			string baseAddress = String.Empty;

#if DEBUG
			baseAddress = "http://api.localdover.com";
#else
			baseAddress = "https://api.dovercms.com";
#endif
			BaseUrl = String.Format("{0}/{1}", baseAddress, _userName);
		}

		internal static XDocument MakeRequest(string url) {
			var meter = new Stopwatch();
			meter.Start();
			var document = XDocument.Load(url);
			meter.Stop();

			Debug.WriteLine("Dover request for " + url + " took " + meter.Elapsed.Seconds + " seconds");

			return document;
		}
	}
}
