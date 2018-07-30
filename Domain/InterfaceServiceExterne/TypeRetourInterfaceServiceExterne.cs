using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.InterfaceServiceExterne
{
	public class TypeRetourInterfaceServiceExterne
	{
		
	
			#region Attributs
			public string Type;
			public string Description;

			#endregion

			#region Constructeur 
			public TypeRetourInterfaceServiceExterne(string type, string description)
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
			public static List<TypeRetourInterfaceServiceExterne> TypeRetourMethodesInterfaceServiceExterne(XmlDocument doc, XmlNamespaceManager nsmgr,int i , int cmp)
			{

				XmlNodeList nodeList2;
				XmlElement root = doc.DocumentElement;
				List<string> ListeTypeRetourInterfaceServiceExterne = new List<string>();

				if (MethodeInterfaceServiceExterne.NombreMethodesInterfaceServiceExterne(doc, nsmgr,i - 1 )!= 0)
					{
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 2) + "]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 2) + "]/preceding-sibling:: w:tbl / w:tr /w:tc)]";



				if (i == InterfaceServiceExterne.NomsInterfacesServicesExternes(doc, nsmgr).Count && cmp == MethodeInterfaceServiceExterne.NombreMethodesInterfaceServiceExterne(doc, nsmgr, i - 1))
				{
					
					 xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + 1 + "]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + 1 + "]  /preceding-sibling:: w:tbl / w:tr /w:tc)]";

				}


				if (i < InterfaceServiceExterne.NomsInterfacesServicesExternes(doc, nsmgr).Count && cmp == MethodeInterfaceServiceExterne.NombreMethodesInterfaceServiceExterne(doc, nsmgr, i - 1) - 1)
				{
					 xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5]  /preceding-sibling:: w:tbl / w:tr /w:tc)]";

				}
					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{

						ListeTypeRetourInterfaceServiceExterne.Add(isbn2.InnerText);

					}

					
				}
				return ListeATypeRetourInterfaceServiceExterne(ListeTypeRetourInterfaceServiceExterne);

		}






			/// <summary>
			/// Renvoie la liste des types de retour des services externes associés à une liste donnée
			/// </summary>
			/// <returns></returns>
			public static List<TypeRetourInterfaceServiceExterne> ListeATypeRetourInterfaceServiceExterne(List<string> liste)
			{
				List<TypeRetourInterfaceServiceExterne> ListeTypeRetourInterfaceServiceExterne = new List<TypeRetourInterfaceServiceExterne>();
				for (int i = 2; i < liste.Count; i = i + 2)
				{
					ListeTypeRetourInterfaceServiceExterne.Add(new TypeRetourInterfaceServiceExterne(liste[i], liste[i + 1]));
				}
				return ListeTypeRetourInterfaceServiceExterne;
			}
			#endregion
		}
	}

