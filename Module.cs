using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Com.Dover.IntegrationLib {
	/// <summary>
	/// Dover API integration class for manipulating module data
	/// </summary>
	public class Module {
		public Module() {
		}

		/// <summary>
		/// Gets the module URL.
		/// </summary>
		/// <param name="_moduleId">The module id.</param>
		/// <returns>The Dover module URL</returns>
		public string GetModuleUrl(int _moduleId) {
			return GetApiUrl("module", _moduleId.ToString());
		}

		private string GetModulesUrl(params int[] _moduleIds) {
			string ids = String.Empty;

			foreach (int id in _moduleIds) {
				ids += id + ",";
			}

			return GetApiUrl("modules", ids.TrimEnd(",".ToCharArray()));
		}

		private string GetApiUrl(string _operation, string _moduleId) {
			return String.Format("{0}/{1}/{2}/", DoverApiHelper.BaseUrl, _operation, _moduleId);
		}

		/// <summary>
		/// Loads the data xml for the provided module id list.
		/// </summary>
		/// <param name="_moduleIds">The module ids.</param>
		/// <returns>A XML Document with the data from all the specified modules</returns>
		public XDocument LoadXml(params int[] _moduleIds) {
			return DoverApiHelper.MakeRequest(GetModulesUrl(_moduleIds));
		}

		/// <summary>
		/// Loads the data xml for the provided module id.
		/// </summary>
		/// <param name="_moduleId">The module id.</param>
		/// <returns>>A XML Document with the data from the module</returns>
		public XDocument LoadXml(int _moduleId) {
			return DoverApiHelper.MakeRequest(GetModuleUrl(_moduleId));
		}

		/// <summary>
		/// Loads the data xml for the specified record in the provided module.
		/// </summary>
		/// <param name="_moduleId">The module id.</param>
		/// <param name="_id">The record id.</param>
		/// <returns>>A XML Document with the record data from the module</returns>
		public XDocument LoadXml(int _moduleId, int _id) {
			return DoverApiHelper.MakeRequest(GetModuleUrl(_moduleId) + _id);
		}

		/// <summary>
		/// Loads the data xml for the provided module id, filtered with the provided query string values.
		/// </summary>
		/// <param name="_moduleId">The module id.</param>
		/// <param name="_queryString">The query string for results filtering.</param>
		/// <returns>A XML Document with the matching records data from the module</returns>
		public XDocument LoadXml(int _moduleId, string _queryString) {
			return DoverApiHelper.MakeRequest(GetModuleUrl(_moduleId) + "?" + _queryString);
		}
	}
}
