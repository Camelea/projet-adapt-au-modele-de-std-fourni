using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.Registres
{/// <summary>
 /// Classe qui permet de récupérer la liste des registres 
 /// </summary>
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
			var methodes = "";
			foreach (MethodeRegistre methode in this.Methodes)
			{
				methodes = methodes + methode.ToString();
			}
			var res = "{" + "/// <summary>" + "\r\n" + "/// " + this.Description + "." + "\r\n" + "/// </summary>" + "\r\n" + "public class " + this.Nom + " : " + this.InterfaceImplementee + "\r\n" + "{" + methodes + "}" +"\r\n" + "}";
			return res;
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
		public static string DescriptionsRegistres(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;

				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][1] / following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/preceding-sibling::w:p)]";
				var res = "";
				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					res = res + (isbn2.InnerText);
				}

			
			return res;


		}

		/// <summary>
		/// Fonction qui retourne la liste des interfaces implementees des registres    
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static string InterfacesImplementeesRegistres(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
	
				var res = "";
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2] ";
				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					res = res + (isbn2.InnerText);
				}

			
			return res;


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

			for (int i = 1; i < NomsRegistres(doc, nsmgr).Count + 1; i++)
			{
				string interfacesImplementees = InterfacesImplementeesRegistres(doc, nsmgr, i);
				List<MethodeRegistre> methodes = MethodeRegistre.MethodesRegistres(doc, nsmgr,i);
				string descriptions = DescriptionsRegistres(doc, nsmgr, i);

				if (MethodeRegistre.NombreMethodesRegistres(doc, nsmgr,i - 1) != 0)
				{

					registres.Add(new Registre(noms[i - 1], descriptions, interfacesImplementees, methodes));
				}

				if (MethodeRegistre.NombreMethodesRegistres(doc, nsmgr,i - 1) == 0)
				{

					registres.Add(new Registre(noms[i - 1], descriptions,interfacesImplementees));
				}



			}
			return registres;

		}





		#endregion
	}
}
