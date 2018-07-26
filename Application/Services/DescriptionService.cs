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
		public static List<List<DescriptionService>> DescriptionsMethodesServices(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeDescriptionsMethodesServices = new List<List<string>>();
			List<List<DescriptionService>> DescriptionsMethodesServices = new List<List<DescriptionService>>();

			for (int i = 1; i < Service.NomsServices(doc, nsmgr).Count + 1; i++)
			{

				if (MethodeService.NombreMethodesServices(doc, nsmgr)[i - 1] != 0)
				{

					for (int cmp = 0; cmp < MethodeService.NombreMethodesServices(doc, nsmgr)[i - 1]; cmp++)
					{

						ListeDescriptionsMethodesServices.Add(new List<string>());
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][1]/ following-sibling:: w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2] / preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2] / preceding-sibling::w:tbl / w:tr /w:tc)]";


						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{
							if (isbn2.InnerText != "")
							{
								ListeDescriptionsMethodesServices[cmp].Add(isbn2.InnerText.Trim());
							}
						}
						DescriptionsMethodesServices.Add(ListeADescriptionsServices(ListeDescriptionsMethodesServices[cmp]));

					}

				}
			}
			return DescriptionsMethodesServices;

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
