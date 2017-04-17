
namespace BoardGameGeekIntegration.Models
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public  class boardgames
    {

        private boardgamesBoardgame[] boardgameField;

        private string termsofuseField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("boardgame")]
        public boardgamesBoardgame[] boardgame
        {
            get
            {
                return this.boardgameField;
            }
            set
            {
                this.boardgameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string termsofuse
        {
            get
            {
                return this.termsofuseField;
            }
            set
            {
                this.termsofuseField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class boardgamesBoardgame
    {

        private boardgamesBoardgameName nameField;

        private ushort yearpublishedField;

        private uint objectidField;

        /// <remarks/>
        public boardgamesBoardgameName name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public ushort yearpublished
        {
            get
            {
                return this.yearpublishedField;
            }
            set
            {
                this.yearpublishedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint objectid
        {
            get
            {
                return this.objectidField;
            }
            set
            {
                this.objectidField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class boardgamesBoardgameName
    {

        private bool primaryField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool primary
        {
            get
            {
                return this.primaryField;
            }
            set
            {
                this.primaryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


}
