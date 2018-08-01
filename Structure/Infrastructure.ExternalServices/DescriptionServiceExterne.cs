using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Infrastructure.ExternalServices
{
	class DescriptionServiceExterne
	{
		#region Attributs

		public string Nom;
		public string Visibilite;
		public string Description;

		#endregion

		#region Constructeur 

		public DescriptionServiceExterne(string nom, string visibilite, string description)
		{
			this.Nom = nom;
			this.Visibilite = visibilite;
			this.Description = description;

		}

		#endregion

		#region Méthodes 

		/// <summary>
		/// retourne la liste des descriptions des methodes des entités 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<DescriptionServiceExterne> DescriptionsMethodesServiceExterne(XmlDocument doc, XmlNamespaceManager nsmgr,int i,int cmp )
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeDescriptionsMethodesServiceExterne = new List<string>();

				if (MethodeServiceExterne.NombreMethodesServiceExterne(doc, nsmgr,i - 1) != 0)
				{



						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+ "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][1]/ following-sibling:: w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']]["+(cmp+1)+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2] / preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']]["+(cmp+1)+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2]  / preceding-sibling::w:tbl / w:tr /w:tc)]";


						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{
							if (isbn2.InnerText != "")
							{
								ListeDescriptionsMethodesServiceExterne.Add(isbn2.InnerText.Trim());
							}
						}

					}

			
			return(ListeADescriptionsMethodeServiceExterne(ListeDescriptionsMethodesServiceExterne));

		}


		/// <summary>
		/// Renvoie la liste des colonnes de descriptions associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<DescriptionServiceExterne> ListeADescriptionsMethodeServiceExterne(List<string> liste)
		{
			List<DescriptionServiceExterne> ListeDescriptionsServiceExterne = new List<DescriptionServiceExterne>();
			for (int i = 3; i < liste.Count; i = i + 3)
			{
				ListeDescriptionsServiceExterne.Add(new DescriptionServiceExterne(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeDescriptionsServiceExterne;
		}






		#endregion
	}
}
