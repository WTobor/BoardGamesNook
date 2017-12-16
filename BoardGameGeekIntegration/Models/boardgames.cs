
namespace BoardGameGeekIntegration.Models
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public  class boardgames
    {
        private string termsofuseField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("boardgame")]
        public boardgamesBoardgame[] boardgame { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string termsofuse
        {
            get => termsofuseField;
            set => termsofuseField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class boardgamesBoardgame
    {

        private boardgamesBoardgameName nameField;

        private ushort yearpublishedField;

        private uint objectidField;

        /// <remarks/>
        public boardgamesBoardgameName name
        {
            get => nameField;
            set => nameField = value;
        }

        /// <remarks/>
        public ushort yearpublished
        {
            get => yearpublishedField;
            set => yearpublishedField = value;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint objectid
        {
            get => objectidField;
            set => objectidField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class boardgamesBoardgameName
    {

        private bool primaryField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool primary
        {
            get => primaryField;
            set => primaryField = value;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get => valueField;
            set => valueField = value;
        }
    }


}
