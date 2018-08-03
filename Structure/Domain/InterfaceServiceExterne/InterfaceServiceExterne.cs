using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.InterfaceServiceExterne
{
	class InterfaceServiceExterne
	{
		#region Attributs 
		public string Nom;
		public List<MethodeInterfaceServiceExterne> Methodes;

		#endregion

		#region Constructeur 

		public InterfaceServiceExterne(string nom, List<MethodeInterfaceServiceExterne> methodes)
		{
			this.Nom = nom;
			this.Methodes = methodes;

		}
		public InterfaceServiceExterne(string nom)
		{
			this.Nom = nom;

		}

		#endregion

		#region Méthodes 

		public override string ToString()
		{
			var doc = "/// <summary>" + "\r\n" + "/// " /*this.Description.Trim()*/  + "." + "\r\n" + "/// </summary>" + "\r\n";
			var methodes = "";
			foreach (MethodeInterfaceServiceExterne m in this.Methodes)
			{
				methodes = methodes + "\r\n";

		
					methodes = methodes + m.ToString() + "\r\n";

			}
			var res = doc +  "\r\n" + "[ServiceContract]" + "\r\n" + "public interface " + this.Nom  + "\r\n"  +"#region Méthodes " + "{ " + "\r\n" + methodes + "\r\n" + "#endregion" + "\r\n" +  "}";

			return res;
		}
		/// <summary>
		/// Retourne une liste de noms des interfaces de services externes présents dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsInterfacesServicesExternes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeNoms = new List<string>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][4]/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading3']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] / preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading3']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading3']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeNoms.Add(isbn2.InnerText);
			}

			return ListeNoms;


		}

		/// <summary>
		/// Retourne la liste des interfaces de services externes du fichier  
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<InterfaceServiceExterne> InterfacesServicesExternes (XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<InterfaceServiceExterne> interfacesRegistresExternes = new List<InterfaceServiceExterne>();
			List<string> noms = NomsInterfacesServicesExternes(doc, nsmgr);
			

			for (int i = 1; i < NomsInterfacesServicesExternes(doc, nsmgr).Count + 1; i++)
			{
				List<MethodeInterfaceServiceExterne> methodes = MethodeInterfaceServiceExterne.MethodeServicesExternes(doc, nsmgr, i);


				if (MethodeInterfaceServiceExterne.NombreMethodesInterfaceServiceExterne(doc, nsmgr,i - 1) != 0)
				{

					interfacesRegistresExternes.Add(new InterfaceServiceExterne(noms[i - 1], methodes));
				}

				if (MethodeInterfaceServiceExterne.NombreMethodesInterfaceServiceExterne(doc, nsmgr,i - 1) == 0)
				{

					interfacesRegistresExternes.Add(new InterfaceServiceExterne(noms[i - 1]));
				}



			}
			return interfacesRegistresExternes;

		}

		#endregion
	}
}
