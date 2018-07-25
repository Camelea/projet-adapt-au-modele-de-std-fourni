using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.Registres
{
	class Registre
	{
		#region Attributs

		public string Nom;
		public string Description;
		public string InterfaceImplementee;
		public List<MethodeRegistre> Methodes;

		#endregion


		#region Constructeur
		public Registre(string nom, string description,string interfaceImplementee , List<MethodeRegistre> methodes)
		{
			this.Nom = nom;
			this.Description = description;
			this.InterfaceImplementee = interfaceImplementee;
			this.Methodes = methodes;
		}
		public Registre(string nom, string interfaceImplementee, string description)
		{
			this.Nom = nom;
			this.Description = description;
			this.InterfaceImplementee = interfaceImplementee;

		}


		#endregion

		#region Méthodes 

		public override string ToString()
		{
			return (this.Nom + this.Description);
		}

		/// <summary>
		/// Retourne une liste de noms des registres présents dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsRegistres(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeNoms = new List<string>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][3]/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading3']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][4]/ preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading3']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][4]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading3']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeNoms.Add(isbn2.InnerText);
			}

			return ListeNoms;


		}

		/// <summary>
		/// Fonction qui retourne la liste des descriptions des registres    
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<String> DescriptionsRegistres(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeDescriptionsRegistres = new List<string>();

			for (int i = 1; i < NomsRegistres(doc, nsmgr).Count + 1; i++)

			{
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][1] / following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeDescriptionsRegistres.Add(isbn2.InnerText);
				}

			}
			return ListeDescriptionsRegistres;


		}

		/// <summary>
		/// Fonction qui retourne la liste des interfaces implementees des registres    
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<String> InterfacesImplementeesRegistres(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeInterfacesImplementeesRegistres = new List<string>();

			for (int i = 1; i < NomsRegistres(doc, nsmgr).Count + 1; i++)

			{
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2] ";
				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeInterfacesImplementeesRegistres.Add(isbn2.InnerText);
				}

			}
			return ListeInterfacesImplementeesRegistres;


		}


		/// <summary>
		/// Retourne la liste des registre du fichier  
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<Registre> Registres(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<Registre> registres = new List<Registre>();
			List<string> noms = NomsRegistres(doc, nsmgr);
			List<string> descriptions = DescriptionsRegistres(doc, nsmgr);
			List<string> interfacesImplementees = InterfacesImplementeesRegistres(doc, nsmgr);
			List<List<MethodeRegistre>> methodes = MethodeRegistre.MethodesRegistres(doc, nsmgr);

			for (int i = 1; i < NomsRegistres(doc, nsmgr).Count + 1; i++)
			{


				if (MethodeRegistre.NombreMethodesRegistres(doc, nsmgr)[i - 1] != 0)
				{

					registres.Add(new Registre(noms[i - 1], descriptions[i - 1], interfacesImplementees[i - 1], methodes[i - 1]));
				}

				if (MethodeRegistre.NombreMethodesRegistres(doc, nsmgr)[i - 1] == 0)
				{

					registres.Add(new Registre(noms[i - 1], descriptions[i - 1],interfacesImplementees[i-1]));
				}



			}
			return registres;

		}





		#endregion
	}
}
