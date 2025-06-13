using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht___Programmeren_in_C____LOI.UI
{
    /// <summary>
    /// Container voor het koppelen van een PersonPanel aan zijn optionele database ID
    /// </summary>
    public class PanelTag
    {
        /// <summary>
        /// De UI componenten van dit panel
        /// </summary>
        public PersonPanelComponents Components { get; set; }

        /// <summary>
        /// De database ID van de persoon, als deze bestaat
        /// </summary>
        public int? PersonId { get; set; }

        /// <summary>
        /// Maakt een nieuwe PanelTag aan met componenten en optionele ID
        /// </summary>
        /// <param name="components">De UI componenten van het panel</param>
        /// <param name="personId">De optionele ID van de persoon in de database</param>
        public PanelTag(PersonPanelComponents components, int? personId = null)
        {
            Components = components;
            PersonId = personId;
        }
    }
}
