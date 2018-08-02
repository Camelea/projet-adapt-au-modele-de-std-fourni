using ConsoleApp4.Domain.CommonType;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Code
{
	class EntiteToCode
	{
		public XmlDocument doc;
		public XmlNamespaceManager nsmgr;

		public static void CreateDirectoryOnDesktop(string directoryName)
		{
			Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), directoryName));

		}

		public void CreerEnumerations()
		{
			CreateDirectoryOnDesktop("enumerations");
			foreach (Enumeration e in Enumeration.Enumerations(doc, nsmgr))
			{
				string chemin = @"C:\Users\CameleaOUARKOUB\Desktop\enumerations\" + e.Nom.Trim() + ".cs";
				FileStream stream = new FileStream(chemin, FileMode.Append, FileAccess.Write);
				StreamWriter writer = new StreamWriter(stream);
				using (writer)
					writer.WriteLine(e.ToString());
				writer.Close();
			}
		}




		
	}
}

