using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Tables
{
	class Contrainte
	{
		#region Attributs
		public List<ClePrimaire> ClesPrimaires;
		public List<CleEtrangere> Clesetrangeres;
		public List<ContrainteNonNulle> ContraintesNonNulles;
		public List<ContrainteDeVerification> Contraintesdeverification;
		public Sequence Sequence;
		public List<Index> Indexes;

		#endregion


		#region Constructeur 
		/// <summary>
		/// Constructeur pour la contrainte qui va contenir une sequence , une liste de : clées primaires , clés etrangeres , contraintes non nulles et d'indexes 
		/// </summary>
		/// <param name="sequence"></param>
		/// <param name="clesPrimaires"></param>
		/// <param name="contraintesNonNulles"></param>
		/// <param name="indexes"></param>
		public Contrainte(Sequence sequence, List<ClePrimaire> clesPrimaires, List<ContrainteNonNulle> contraintesNonNulles, List<Index> indexes, List<CleEtrangere> clesEtrangeres, List<ContrainteDeVerification> contraintesDeVerification)
		{
			this.ClesPrimaires = clesPrimaires;
			this.Sequence = sequence;
			this.ContraintesNonNulles = contraintesNonNulles;
			this.Indexes = indexes;
			this.Clesetrangeres = clesEtrangeres;
			this.Contraintesdeverification = contraintesDeVerification;
		}
		#endregion

		#region Méthodes
		/// <summary>
		/// Fonction qui permet de construire une contrainte
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<Contrainte> Contraintes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<Sequence> sequences = Sequence.SequencesTables(doc, nsmgr);
			List<Contrainte> contraintes = new List<Contrainte>();
			List<List<ClePrimaire>> clesprimaires = ClePrimaire.ClesPrimairesTables(doc, nsmgr);
			List<List<ContrainteNonNulle>> contraintesnonnulles = ContrainteNonNulle.ContraintesNonNullesTables(doc, nsmgr);
			List<List<Index>> indexes = Index.IndexTables(doc, nsmgr);
			List<List<CleEtrangere>> clesetrangeres = CleEtrangere.ClesEtrangeresTables(doc, nsmgr);
			List<List<ContrainteDeVerification>> contraintesdeverification = ContrainteDeVerification.ContraintesDeVerificationTables(doc, nsmgr);
			for (int i = 0; i < sequences.Count; i++)
			{
				contraintes.Add(new Contrainte(sequences[i], clesprimaires[i], contraintesnonnulles[i], indexes[i], clesetrangeres[i], contraintesdeverification[i]));

			}
			return contraintes;

		}
		#endregion
	}
}
