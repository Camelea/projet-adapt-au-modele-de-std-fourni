using ConsoleApp4.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4
{
	class Program
	{
		public static void Main(string[] args)
		{


			XmlDocument doc = new XmlDocument();
			//doc.Load("C:\\Users\\CameleaOUARKOUB\\Pictures\\Exemple2.xml");
			doc.Load("C:\\Users\\CameleaOUARKOUB\\Desktop\\document.xml");



			//Create an XmlNamespaceManager for resolving namespaces.
			XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
			nsmgr.AddNamespace("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
			nsmgr.AddNamespace("cx", "http://schemas.microsoft.com/office/drawing/2014/chartex");
			nsmgr.AddNamespace("cx1", "http://schemas.microsoft.com/office/drawing/2015/9/8/chartex");
			nsmgr.AddNamespace("cx2", "http://schemas.microsoft.com/office/drawing/2015/10/21/chartex");
			nsmgr.AddNamespace("cx3", "http://schemas.microsoft.com/office/drawing/2016/5/9/chartex");
			nsmgr.AddNamespace("cx4", "http://schemas.microsoft.com/office/drawing/2016/5/10/chartex");
			nsmgr.AddNamespace("cx5", "http://schemas.microsoft.com/office/drawing/2016/5/11/chartex");
			nsmgr.AddNamespace("cx6", "http://schemas.microsoft.com/office/drawing/2016/5/12/chartex");
			nsmgr.AddNamespace("cx7", "http://schemas.microsoft.com/office/drawing/2016/5/13/chartex");
			nsmgr.AddNamespace("cx8", "http://schemas.microsoft.com/office/drawing/2016/5/14/chartex");
			nsmgr.AddNamespace("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
			nsmgr.AddNamespace("aink", "http://schemas.microsoft.com/office/drawing/2016/ink");
			nsmgr.AddNamespace("am3d", "http://schemas.microsoft.com/office/drawing/2017/model3d");
			nsmgr.AddNamespace("o", "urn:schemas-microsoft-com:office:office");
			nsmgr.AddNamespace("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
			nsmgr.AddNamespace("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
			nsmgr.AddNamespace("v", "urn:schemas-microsoft-com:vml");
			nsmgr.AddNamespace("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
			nsmgr.AddNamespace("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
			nsmgr.AddNamespace("w10", "urn:schemas-microsoft-com:office:word");
			nsmgr.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			nsmgr.AddNamespace("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
			nsmgr.AddNamespace("w15", "http://schemas.microsoft.com/office/word/2012/wordml");
			nsmgr.AddNamespace("w16se", "http://schemas.microsoft.com/office/word/2015/wordml/symex");
			nsmgr.AddNamespace("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
			nsmgr.AddNamespace("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
			nsmgr.AddNamespace("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
			nsmgr.AddNamespace("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");
			nsmgr.AddNamespace("mc: Ignorable", "w14 w15 w16se wp14");

			//var sequences = ConstructeurInitialisation.GetDescriptionContrainteInitialisation(doc, nsmgr);
			//List<string> resultat = sequences;
			//foreach (string y in resultat)
			//{

			//	Console.WriteLine(y.ToString());

			//}

			#region TestTable 
			var sequences = Table.Tables(doc, nsmgr);
			List<Table> resultat = sequences;
			foreach (Table y in resultat)
			{
				foreach (Colonne c in y.Colonnes)
				{
					Console.WriteLine(c.ToString());
				}
			
			}



			Console.ReadKey();

			#endregion
		}
	}
}
