using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypeAheadControl {
	public static class ExtenstionUtility {
		public static void SafeInvoke(this Control control,  Action action ) {
			if ( control.InvokeRequired ) {
				control.Invoke( action );
				return;
			}
			action.Invoke( );
		}
	}
}
