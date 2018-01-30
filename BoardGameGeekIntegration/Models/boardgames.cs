using System.Xml.Serialization;

namespace BoardGameGeekIntegration.Models
{
    /// <remarks />
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class boardgames
    {
        /// <remarks />
        [XmlElement("boardgame")]
        public boardgamesBoardgame[] boardgame { get; set; }

        /// <remarks />
        [XmlAttribute]
        public string termsofuse { get; set; }
    }

    /// <remarks />
    [XmlType(AnonymousType = true)]
    public class boardgamesBoardgame
    {
        /// <remarks />
        public boardgamesBoardgameName name { get; set; }

        /// <remarks />
        public ushort yearpublished { get; set; }

        /// <remarks />
        [XmlAttribute]
        public uint objectid { get; set; }
    }

    /// <remarks />
    [XmlType(AnonymousType = true)]
    public class boardgamesBoardgameName
    {
        /// <remarks />
        [XmlAttribute]
        public bool primary { get; set; }

        /// <remarks />
        [XmlText]
        public string Value { get; set; }
    }
}