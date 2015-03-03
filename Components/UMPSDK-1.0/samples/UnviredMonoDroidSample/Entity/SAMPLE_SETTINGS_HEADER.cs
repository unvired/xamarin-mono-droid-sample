using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Unvired.Kernel.Model;
using Unvired.Kernel.Database;

namespace Entity {
	/*
	This class represents Business Entity Header for Settings table
	*/	
	public class SAMPLE_SETTINGS_HEADER : DataStructure {
		
		
		// Key name
		private string _KEY_NAME;

		// Key value
		private string _KEY_VALUE;

	
		internal static bool IsHeader {
			get {
			    return true;
			}
	    }
		
			[Mandatory]
		
		public string KEY_NAME { 
			get {
				return _KEY_NAME;
			}
			set {
				_KEY_NAME = value;
				RaisePropertyChanged("KEY_NAME");
			}
		}

		public string KEY_VALUE { 
			get {
				return _KEY_VALUE;
			}
			set {
				_KEY_VALUE = value;
				RaisePropertyChanged("KEY_VALUE");
			}
		}

	}
}
