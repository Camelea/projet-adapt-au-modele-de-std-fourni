using ConsoleApp4.Domain.CommonType.Services_Externes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.Interface.De.Registre
{ 
	/// <summary>
	/// Classe qui permet de récupérer la liste des interfaces de registre
	/// </summary>
	public class InterfaceRegistre
	{

		#region Attributs

		public string Nom { get; private set; }
		public string Description { get; private set; }
		public List<MethodeInterfaceRegistre> Methodes { get; private set; }


		#endregion


		#region Constructeur
		public InterfaceRegistre(string nom, string description, List<MethodeInterfaceRegistre> methodes)
		{
			this.Nom = nom;
			this.Description = description;
			this.Methodes = methodes;
		}
		public InterfaceRegistre(string nom, string description)
		{
			this.Nom = nom;
			this.Description = description;

		}


		#endregion

		#region Méthodes 

		public override string ToString()
		{
			var doc = "/// <summary>" + "\r\n" + "/// " + this.Description.Trim()  + "." + "\r\n" + "/// </summary>" + "\r\n";
			StringBuilder methodes = new StringBuilder();
			foreach (MethodeInterfaceRegistre m in this.Methodes)
			{
				methodes.Append( "\r\n");


				methodes.Append(m.ToString() + "\r\n");

			}
			var res = doc + "\r\n"  + "public interface " + this.Nom + "\r\n" + "#region Méthodes " + "{ " + "\r\n" + methodes + "\r\n" + "#endregion" + "\r\n" + "}";

			return res;
		}

		/// <summary>
		/// Retourne une liste de noms des interfaces de registre présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsInterfacesRegistres(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeNoms = new List<string>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][2]/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading3']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][3]/ preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading3']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][3]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading3']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeNoms.Add(isbn2.InnerText);
			}

			return ListeNoms;


		}

		/// <summary>
		/// Fonction qui retourne la description des interfaces de registre    
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static string DescriptionsInterfacesRegistres(XmlDocument doc, XmlNamespaceManager nsmgr,int i)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;

				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][1] / following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/preceding-sibling::w:p)]";
				var res = "";
				nodeList2 = root.SelectNodes(xpath, nsmgr);
				
				foreach (XmlNode isbn2 in nodeList2)
				{
					res = res + " " + (isbn2.InnerText);
				}

			
			return res;


		}


		/// <summary>
		/// Retourne la liste des interfaces de registre du fichier  
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<InterfaceRegistre> InterfacesRegistre(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<InterfaceRegistre> interfacesRegistre = new List<InterfaceRegistre>();
			List<string> noms = NomsInterfacesRegistres(doc, nsmgr);
		

			for (int i = 0; i < NomsInterfacesRegistres(doc, nsmgr).Count; i++)
			{
				List<MethodeInterfaceRegistre> methodes = MethodeInterfaceRegistre.MethodesRegistres(doc, nsmgr, i);
				string descriptions = DescriptionsInterfacesRegistres(doc, nsmgr,i);


				if (MethodeInterfaceRegistre.NombreMethodesInterfacesRegistres(doc, nsmgr,i - 1)!= 0)
				{

					interfacesRegistre.Add(new InterfaceRegistre(noms[i-1], descriptions, methodes));
				}

				if (MethodeInterfaceRegistre.NombreMethodesInterfacesRegistres(doc, nsmgr,i - 1) == 0)
				{

					interfacesRegistre.Add(new InterfaceRegistre(noms[i-1], descriptions));
				}



			}
			return interfacesRegistre;

		}





		#endregion
	}
}
