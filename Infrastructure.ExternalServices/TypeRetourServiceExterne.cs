using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Infrastructure.ExternalServices
{
	class TypeRetourServiceExterne
	{
		#region Attributs
		public string Type;
		public string Description;

		#endregion

		#region Constructeur 
		public TypeRetourServiceExterne(string type, string description)
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
		/// Methode qui renvoie la liste des colonnes des types de retour des methodes des services externes 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<TypeRetourServiceExterne>> TypeRetourMethodesServiceExternes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeTypeRetourServiceExterne = new List<List<string>>();
			List<List<TypeRetourServiceExterne>> TypeRetourInterfacesServiceExterne = new List<List<TypeRetourServiceExterne>>();

			for (int i = 1; i < ServiceExterne.NomsServiceExterne(doc, nsmgr).Count + 1; i++)
			{

				if (MethodeServiceExterne.NombreMethodesServiceExterne(doc, nsmgr)[i - 1] != 0)
				{

					for (int cmp = 0; cmp < MethodeServiceExterne.NombreMethodesServiceExterne(doc, nsmgr)[i - 1] + 1; cmp++)
					{
						
							ListeTypeRetourServiceExterne.Add(new List<string>());
							string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']]["+(cmp+1)+"]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']]["+(cmp+1)+"]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][4]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']]["+(cmp+1)+"]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][4]/preceding-sibling:: w:tbl / w:tr /w:tc)]";


							nodeList2 = root.SelectNodes(xpath, nsmgr);

							foreach (XmlNode isbn2 in nodeList2)
							{

								ListeTypeRetourServiceExterne[cmp].Add(isbn2.InnerText);

							}
							TypeRetourInterfacesServiceExterne.Add(ListeATypeRetourServiceExterne(ListeTypeRetourServiceExterne[cmp]));

						
					


						}
					}
				}
			
			return TypeRetourInterfacesServiceExterne;

		}






		/// <summary>
		/// Renvoie la liste des types de retour des registres associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<TypeRetourServiceExterne> ListeATypeRetourServiceExterne(List<string> liste)
		{
			List<TypeRetourServiceExterne> ListeTypeRetourServiceExterne = new List<TypeRetourServiceExterne>();
			for (int i = 2; i < liste.Count; i = i + 2)
			{
				ListeTypeRetourServiceExterne.Add(new TypeRetourServiceExterne(liste[i], liste[i + 1]));
			}
			return ListeTypeRetourServiceExterne;
		}
		#endregion
	}
}
