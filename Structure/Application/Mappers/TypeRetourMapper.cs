using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Application.Mappers
{
	class TypeRetourMapper
	{
		#region Attributs
		public string Type { get; private set; }
		public string Description { get; private set; }

		#endregion

		#region Constructeur 
		public TypeRetourMapper(string type, string description)
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
		/// Methode qui renvoie la liste des colonnes des types de retour des methodes des mappers
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<TypeRetourMapper> TypeRetourMethodesMappers(XmlDocument doc, XmlNamespaceManager nsmgr,int i , int cmp)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeTypeRetourServices = new List<string>();
			
				if (MethodeMapper.NombreMethodesMappers(doc, nsmgr,i - 1) != 0)
				{
				
							string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/preceding-sibling:: w:tbl / w:tr /w:tc)]";


							nodeList2 = root.SelectNodes(xpath, nsmgr);

							foreach (XmlNode isbn2 in nodeList2)
							{

								ListeTypeRetourServices.Add(isbn2.InnerText);

							}
						
					}
			
			return (ListeATypeRetourMapper(ListeTypeRetourServices));

		}






		/// <summary>
		/// Renvoie la liste des types de retour des services associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<TypeRetourMapper> ListeATypeRetourMapper(List<string> liste)
		{
			List<TypeRetourMapper> ListeTypeRetourMapper = new List<TypeRetourMapper>();
			for (int i = 2; i < liste.Count; i = i + 2)
			{
				ListeTypeRetourMapper.Add(new TypeRetourMapper(liste[i], liste[i + 1]));
			}
			return ListeTypeRetourMapper;
		}
		#endregion
	}
}
