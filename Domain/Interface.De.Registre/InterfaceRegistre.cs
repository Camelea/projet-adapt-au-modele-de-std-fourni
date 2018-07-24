using ConsoleApp4.Domain.CommonType.Services_Externes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.Interface.De.Registre
{
	public class InterfaceRegistre
	{

		#region Attributs

		public string Nom;
		public string Description;
		public List<MethodeInterfaceRegistre> Methodes;

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
			return (this.Nom + this.Description);
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
		/// Fonction qui retourne la liste des descriptions des interfaces de registre    
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<String> DescriptionsInterfacesRegistres(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeDescriptionsInterfacesRegistres = new List<string>();

			for (int i = 1; i < NomsInterfacesRegistres(doc, nsmgr).Count + 1; i++)

			{
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][1] / following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeDescriptionsInterfacesRegistres.Add(isbn2.InnerText);
				}

			}
			return ListeDescriptionsInterfacesRegistres;


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
			List<string> descriptions = DescriptionsInterfacesRegistres(doc, nsmgr);
			List<List<MethodeInterfaceRegistre>> methodes = MethodeInterfaceRegistre.MethodesRegistres(doc, nsmgr);

			for (int i = 1; i < NomsInterfacesRegistres(doc, nsmgr).Count + 1; i++)
			{


				if (MethodeInterfaceRegistre.NombreMethodesInterfacesRegistres(doc, nsmgr)[i - 1] != 0)
				{

					interfacesRegistre.Add(new InterfaceRegistre(noms[i - 1], descriptions[i - 1], methodes[i - 1]));
				}

				if (MethodeInterfaceRegistre.NombreMethodesInterfacesRegistres(doc, nsmgr)[i - 1] == 0)
				{

					interfacesRegistre.Add(new InterfaceRegistre(noms[i - 1], descriptions[i - 1]));
				}



			}
			return interfacesRegistre;

		}





		#endregion
	}
}
