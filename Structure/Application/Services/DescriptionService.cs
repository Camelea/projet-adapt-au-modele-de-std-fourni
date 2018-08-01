using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Application.Services
{
	class DescriptionService
	{
		#region Attributs

		public string Nom;
		public string Visibilite;
		public string Description;

		#endregion

		#region Constructeur 

		public DescriptionService(string nom, string visibilite, string description)
		{
			this.Nom = nom;
			this.Visibilite = visibilite;
			this.Description = description;
		}

		#endregion

		#region Méthodes 

		/// <summary>
		/// retourne la liste des descriptions des methodes des services 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<DescriptionService> DescriptionsMethodesServices(XmlDocument doc, XmlNamespaceManager nsmgr,int i , int cmp )
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeDescriptionsMethodesServices = new List<string>();

				if (MethodeService.NombreMethodesServices(doc, nsmgr,i - 1) != 0)
				{
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][1]/ following-sibling:: w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2] / preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2] / preceding-sibling::w:tbl / w:tr /w:tc)]";


						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{
							
							{
								ListeDescriptionsMethodesServices.Add(isbn2.InnerText.Trim());
							}
						}
					
				}
			
			return (ListeADescriptionsServices(ListeDescriptionsMethodesServices));

		}


		/// <summary>
		/// Renvoie la liste des colonnes de types de retour associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<DescriptionService> ListeADescriptionsServices(List<string> liste)
		{
			List<DescriptionService> ListeDescriptionsServices = new List<DescriptionService>();
			for (int i = 3; i < liste.Count; i = i + 3)
			{
				ListeDescriptionsServices.Add(new DescriptionService(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeDescriptionsServices;
		}





		#endregion
	}
}
