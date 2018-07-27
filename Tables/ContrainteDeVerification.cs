using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Tables
{
	public class ContrainteDeVerification
	{
		#region Attributs
		public string Nom { get; private set; }
		public string Colonne;
		public string Condition;
		#endregion

		#region Constructeur
		/// <summary>
		/// Constructeur d'une contrainte de vérification 
		/// </summary>
		/// <param name="nom"></param>
		/// <param name="colonne"></param>
		/// <param name="condition"></param>
		public ContrainteDeVerification(string nom, string colonne, string condition)
		{
			this.Nom = nom;
			this.Colonne = colonne;
			this.Condition = condition;
		}

		#endregion

		#region Méthodes

		public override string ToString() // à corriger 
		{
			return (Nom + " " + Colonne + " " + Condition);

		}

		/// <summary>
		/// Renvoie la liste des contraintes de verification associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<ContrainteDeVerification> ListeAContraintesDeVerification(List<string> liste)
		{
			List<ContrainteDeVerification> ListeContraintesDeVerificationTables = new List<ContrainteDeVerification>();
			for (int i = 3; i < liste.Count; i = i + 3)
			{
				ListeContraintesDeVerificationTables.Add(new ContrainteDeVerification(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeContraintesDeVerificationTables;
		}


		public static List<ContrainteDeVerification> ContraintesDeVerificationTables(XmlDocument doc, XmlNamespaceManager nsmgr,int i)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeContrainteDeVerification = new List<string>();
			
				string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][5]/ following-sibling::w:tbl / w:tr /w:tc [count(. | //w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/preceding-sibling::w:tbl / w:tr /w:tc)]";
				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeContrainteDeVerification.Add(isbn2.InnerText);

				}

			return ListeAContraintesDeVerification(ListeContrainteDeVerification);

		}

		#endregion

	}
}