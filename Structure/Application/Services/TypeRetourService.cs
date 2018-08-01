using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Application.Services
{
	class TypeRetourService
	{
		#region Attributs
		public string Type;
		public string Description;

		#endregion

		#region Constructeur 
		public TypeRetourService(string type, string description)
		{
			this.Type = type;
			this.Description = description;

		}

		#endregion

		#region Méthodes

		public override string ToString()
		{
			return (Type + " " + Description);

		}

		/// <summary>
		/// Methode qui renvoie la liste des colonnes des types de retour des methodes des services
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<TypeRetourService> TypeRetourMethodesServices(XmlDocument doc, XmlNamespaceManager nsmgr,int i , int cmp)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeTypeRetourServices = new List<string>();

			if (MethodeService.NombreMethodesServices(doc, nsmgr, i - 1) != 0)
			{


				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/preceding-sibling:: w:tbl / w:tr /w:tc)]";


				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{

					ListeTypeRetourServices.Add(isbn2.InnerText);

				}
			
			}
					
			
			return (ListeATypeRetourService(ListeTypeRetourServices));

		}






		/// <summary>
		/// Renvoie la liste des types de retour des services associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<TypeRetourService> ListeATypeRetourService(List<string> liste)
		{
			List<TypeRetourService> ListeTypeRetourService = new List<TypeRetourService>();
			for (int i = 2; i < liste.Count; i = i + 2)
			{
				ListeTypeRetourService.Add(new TypeRetourService(liste[i], liste[i + 1]));
			}
			return ListeTypeRetourService;
		}
		#endregion
	}
}
